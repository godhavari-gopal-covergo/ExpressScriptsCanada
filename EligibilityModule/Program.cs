using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using DynamicExpresso;
using EligibilityModule.Models;
using System.Globalization;

namespace EligibilityModule
{
    class Program
    {
        private static CommonRules _commonRules;
        private static Dictionary<string, RecordTypeDefinition> _recordDefinitions;
        private static Interpreter _interpreter;
        private static Dictionary<string, Dictionary<string, string>> _allLookups;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== EHC Patient ETL Processor ===\n");

                // Parse command-line arguments
                string partnerId = null;
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "--partner" && i + 1 < args.Length)
                    {
                        partnerId = args[i + 1];
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(partnerId))
                {
                    Console.WriteLine($"Using partner configuration: {partnerId}\n");
                }

                // Step 1: Load common rules
                Console.WriteLine("Loading common rules...");
                _commonRules = LoadYaml<CommonRules>("Config/common_rules.yml");
                Console.WriteLine($"✓ Loaded common rules: {_commonRules.Field_Rules.Count} field rules, {_commonRules.Global_Transforms.Count} transforms\n");

                // Step 2: Load all record type definitions
                Console.WriteLine("Loading record type definitions...");
                _recordDefinitions = LoadRecordDefinitions();
                Console.WriteLine($"✓ Loaded {_recordDefinitions.Count} record type definitions: {string.Join(", ", _recordDefinitions.Keys)}\n");

                // Step 3: Apply partner-specific overrides if partner specified
                if (!string.IsNullOrEmpty(partnerId))
                {
                    Console.WriteLine($"Applying partner overrides for {partnerId}...");
                    ApplyPartnerOverrides(partnerId);
                    Console.WriteLine($"✓ Partner overrides applied\n");
                }

                // Step 4: Load lookup files
                Console.WriteLine("Loading lookup tables...");
                _allLookups = LoadLookupFiles(_commonRules.Lookup_Files);
                Console.WriteLine($"✓ Loaded {_allLookups.Count} lookup table(s): {string.Join(", ", _allLookups.Keys)}\n");

                // Step 5: Setup expression interpreter
                _interpreter = new Interpreter();
                SetupInterpreter();

                // Step 6: Load input data
                Console.WriteLine("Loading input data...");
                var records = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(
                    File.ReadAllText("Input/input.json"))!;
                Console.WriteLine($"✓ Loaded {records.Count} input records\n");

                // Step 7: Process records
                Console.WriteLine("Processing records...");
                var outputLines = new List<string>();
                var recordCounts = new Dictionary<string, int>();

                foreach (var record in records)
                {
                    // Convert JsonElement values to objects
                    var recordData = ConvertJsonElementsToObjects(record);
                    
                    // Get record type
                    var recordType = recordData.ContainsKey("record_type") 
                        ? recordData["record_type"]?.ToString() ?? "unknown"
                        : "unknown";

                    // Track record counts
                    if (!recordCounts.ContainsKey(recordType))
                        recordCounts[recordType] = 0;
                    recordCounts[recordType]++;

                    // Find matching record definition
                    if (_recordDefinitions.TryGetValue(recordType, out var definition))
                    {
                        Console.WriteLine($"  Processing record type: {recordType} ({definition.Description})");
                        var outputLine = ProcessRecord(recordData, definition);
                        outputLines.Add(outputLine);
                    }
                    else
                    {
                        Console.WriteLine($"  ⚠ Warning: No definition found for record type '{recordType}'");
                    }
                }

                // Step 8: Write output file
                var outputFileName = $"Output/ehc_output_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                Directory.CreateDirectory("Output");
                File.WriteAllLines(outputFileName, outputLines, Encoding.UTF8);
                
                Console.WriteLine($"\n✅ Output written to {outputFileName}");
                Console.WriteLine($"\nRecord counts:");
                foreach (var kvp in recordCounts.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"  Type {kvp.Key}: {kvp.Value} record(s)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Error: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        static Dictionary<string, object> ConvertJsonElementsToObjects(Dictionary<string, JsonElement> source)
        {
            var result = new Dictionary<string, object>();
            foreach (var kvp in source)
            {
                result[kvp.Key] = kvp.Value.ValueKind switch
                {
                    JsonValueKind.String => kvp.Value.GetString(),
                    JsonValueKind.Number => kvp.Value.TryGetInt32(out var i) ? (object)i : kvp.Value.GetDouble(),
                    JsonValueKind.True => true,
                    JsonValueKind.False => false,
                    JsonValueKind.Null => null,
                    _ => kvp.Value.ToString()
                };
            }
            return result;
        }

        static string ProcessRecord(Dictionary<string, object> record, RecordTypeDefinition definition)
        {
            // Merge record-specific lookups with global lookups
            var recordLookups = new Dictionary<string, Dictionary<string, string>>(_allLookups);
            foreach (var lookup in definition.Lookups)
            {
                recordLookups[lookup.Key] = lookup.Value;
            }

            // Set all record variables in interpreter
            foreach (var kv in record)
            {
                _interpreter.SetVariable(kv.Key, kv.Value);
            }

            var outputFields = new List<string>();

            foreach (var field in definition.Fields)
            {
                // Get initial value from input JSON or use YAML default
                object value = null;
                
                if (record.ContainsKey(field.Key) && record[field.Key] != null)
                {
                    // Use value from input JSON (even if empty string)
                    value = record[field.Key];
                }
                else if (!string.IsNullOrWhiteSpace(field.Default_Value))
                {
                    // Use default value from YAML if field is missing or null in JSON
                    value = field.Default_Value;
                }

                // Apply common field rules based on field name patterns
                value = ApplyCommonFieldRules(field, value);

                // Apply field-specific transform
                if (!string.IsNullOrWhiteSpace(field.Transform))
                {
                    try
                    {
                        _interpreter.SetVariable("value", value);
                        value = _interpreter.Eval(field.Transform);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"    ⚠ Transform error for field '{field.Name}': {ex.Message}");
                    }
                }

                // Apply lookup transformation
                if (!string.IsNullOrWhiteSpace(field.Transform_Lookup))
                {
                    try
                    {
                        _interpreter.SetVariable("value", value);
                        // Update Lookup function with current lookups
                        _interpreter.SetFunction("Lookup", (Func<string, string, string, string>)((table, key, defaultValue) =>
                        {
                            if (recordLookups.TryGetValue(table, out var map) && map.TryGetValue(key, out var val))
                                return val;
                            return defaultValue;
                        }));
                        value = _interpreter.Eval(field.Transform_Lookup);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"    ⚠ Lookup transform error for field '{field.Name}': {ex.Message}");
                    }
                }

                // Apply special formatting based on field.Format property
                if (!string.IsNullOrWhiteSpace(field.Format))
                {
                    value = ApplyFieldFormat(field.Format, value, field.Length);
                }

                // Validate required fields
                if (field.Required && (value == null || string.IsNullOrWhiteSpace(value.ToString())))
                {
                    Console.WriteLine($"    ⚠ Warning: Required field '{field.Name}' is empty");
                }

                // Validate allowed values
                if (field.Allowed_Values.Count > 0 && value != null)
                {
                    var strValue = value.ToString();
                    if (!field.Allowed_Values.Contains(strValue, StringComparer.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"    ⚠ Warning: Field '{field.Name}' value '{strValue}' not in allowed values: {string.Join(", ", field.Allowed_Values)}");
                    }
                }

                // Format output with padding
                string strVal = value?.ToString() ?? "";
                
                // Apply padding (skip if padding is "none")
                if (field.Padding != "none")
                {
                    char padChar = field.Pad_Char?.FirstOrDefault() ?? ' ';
                    if (field.Padding == "left")
                        strVal = strVal.PadLeft(field.Length, padChar);
                    else
                        strVal = strVal.PadRight(field.Length, padChar);
                }

                // Enforce length
                if (strVal.Length > field.Length)
                {
                    if (_commonRules.Validation_Rules.Log_Warnings)
                        Console.WriteLine($"    ⚠ Warning: Field '{field.Name}' truncated from {strVal.Length} to {field.Length} chars");
                    strVal = strVal.Substring(0, field.Length);
                }

                outputFields.Add(strVal);
            }

            return string.Join("", outputFields);
        }

        static object ApplyCommonFieldRules(FieldDefinition field, object value)
        {
            foreach (var rule in _commonRules.Field_Rules)
            {
                // Check if field name matches the pattern
                if (!string.IsNullOrWhiteSpace(rule.Pattern))
                {
                    var regex = new Regex(rule.Pattern, RegexOptions.IgnoreCase);
                    if (regex.IsMatch(field.Name) || regex.IsMatch(field.Key))
                    {
                        // Apply rule based on type
                        switch (rule.Type?.ToLower())
                        {
                            case "default_value":
                                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                                    value = rule.Value ?? "";
                                break;

                            case "date_format":
                                if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                                {
                                    try
                                    {
                                        var date = DateTime.Parse(value.ToString());
                                        value = date.ToString(rule.Format ?? "yyyyMMdd");
                                    }
                                    catch { }
                                }
                                break;

                            case "numeric_format":
                                if (value != null)
                                {
                                    try
                                    {
                                        var number = Convert.ToDecimal(value);
                                        if (rule.Decimal_Places.HasValue)
                                        {
                                            value = (number * (decimal)Math.Pow(10, rule.Decimal_Places.Value)).ToString("0");
                                        }
                                    }
                                    catch { }
                                }
                                break;
                        }
                    }
                }
            }
            return value;
        }

        static void SetupInterpreter()
        {
            // Register DateTime type
            _interpreter.Reference(typeof(DateTime));
            
            // Register Math type for Math.Round and other functions
            _interpreter.Reference(typeof(Math));
            
            // Register String type for string.Format
            _interpreter.Reference(typeof(String));

            // Register common functions
            _interpreter.SetFunction("Lookup", (Func<string, string, string, string>)((table, key, defaultValue) =>
            {
                if (_allLookups.TryGetValue(table, out var map) && map.TryGetValue(key, out var val))
                    return val;
                return defaultValue;
            }));
        }

        static string ApplyFieldFormat(string format, object rawValue, int length)
        {
            switch (format?.ToLower())
            {
                case "accumulator_amount":
                    return FormatAccumulatorAmount(rawValue, length);
                default:
                    return rawValue?.ToString() ?? "";
            }
        }

        static string FormatAccumulatorAmount(object rawValue, int length)
        {
            var zeroString = new string('0', length);
            if (rawValue == null)
                return zeroString;

            var str = rawValue.ToString()?.Trim();
            if (string.IsNullOrWhiteSpace(str))
                return zeroString;

            if (!decimal.TryParse(str, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.InvariantCulture, out var dec) &&
                !decimal.TryParse(str, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out dec))
            {
                return str;
            }

            dec = Math.Round(dec * 100m, 0, MidpointRounding.AwayFromZero);
            var scaled = ((long)dec).ToString(CultureInfo.InvariantCulture);
            return scaled;
        }

        static Dictionary<string, RecordTypeDefinition> LoadRecordDefinitions()
        {
            var definitions = new Dictionary<string, RecordTypeDefinition>();
            var configFiles = Directory.GetFiles("Config", "record_*.yml");

            foreach (var file in configFiles)
            {
                try
                {
                    var definition = LoadYaml<RecordTypeDefinition>(file);
                    definitions[definition.Record_Type] = definition;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  ⚠ Error loading {Path.GetFileName(file)}: {ex.Message}");
                }
            }

            return definitions;
        }

        static Dictionary<string, Dictionary<string, string>> LoadLookupFiles(List<string> lookupFiles)
        {
            var allLookups = new Dictionary<string, Dictionary<string, string>>();

            foreach (var lookupFile in lookupFiles)
            {
                try
                {
                    var filePath = Path.Combine("Config", lookupFile);
                    var lookupDef = LoadYaml<LookupDefinition>(filePath);
                    allLookups[lookupDef.Lookup_Name] = lookupDef.Mappings;
                    Console.WriteLine($"  ✓ {lookupDef.Lookup_Name}: {lookupDef.Mappings.Count} entries");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  ⚠ Error loading {lookupFile}: {ex.Message}");
                }
            }

            return allLookups;
        }

        static T LoadYaml<T>(string path)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .IgnoreUnmatchedProperties()
                .Build();
            return deserializer.Deserialize<T>(File.ReadAllText(path));
        }

        static void ApplyPartnerOverrides(string partnerId)
        {
            var partnerConfigPath = Path.Combine("Config", "Partners", partnerId);
            
            if (!Directory.Exists(partnerConfigPath))
            {
                Console.WriteLine($"  ⚠ Warning: Partner configuration directory not found: {partnerConfigPath}");
                return;
            }

            // Load all partner configuration files
            var partnerConfigFiles = Directory.GetFiles(partnerConfigPath, "record_*.yml");
            var overrideCount = 0;

            foreach (var configFile in partnerConfigFiles)
            {
                try
                {
                    var partnerConfig = LoadYaml<PartnerRecordConfiguration>(configFile);
                    
                    // Find the matching base record definition
                    if (_recordDefinitions.TryGetValue(partnerConfig.Record_Type, out var baseDefinition))
                    {
                        // Apply field overrides
                        foreach (var fieldOverride in partnerConfig.Field_Overrides)
                        {
                            var field = baseDefinition.Fields.Find(f => f.Key == fieldOverride.Key);
                            
                            if (field != null)
                            {
                                // If skip is true, we use base config as-is (no partner changes)
                                if (!fieldOverride.Skip)
                                {
                                    // Only apply default_value if it's specified
                                    if (!string.IsNullOrEmpty(fieldOverride.Default_Value))
                                    {
                                        field.Default_Value = fieldOverride.Default_Value;
                                        overrideCount++;
                                        Console.WriteLine($"  ✓ Record {partnerConfig.Record_Type}: '{field.Name}' default = '{fieldOverride.Default_Value}'");
                                    }
                                }
                                // If skip is true, we just don't override anything - base config is used
                            }
                            else
                            {
                                Console.WriteLine($"  ⚠ Warning: Field '{fieldOverride.Key}' not found in base definition for record type {partnerConfig.Record_Type}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"  ⚠ Warning: Base record definition not found for type '{partnerConfig.Record_Type}'");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  ⚠ Error loading partner config {Path.GetFileName(configFile)}: {ex.Message}");
                }
            }

            Console.WriteLine($"  Applied {overrideCount} field override(s)");
        }
    }
}
