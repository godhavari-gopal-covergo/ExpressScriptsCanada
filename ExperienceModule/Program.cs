using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using ExperienceModule.Models;
using Json.Schema;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var arguments = ArgumentParser.Parse(args);

var deserializer = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)
    .Build();

var feedConfigPath = ResolvePath(arguments.FeedConfig ?? "Config/dental_feed.yml");
if (!File.Exists(feedConfigPath))
{
    Console.Error.WriteLine($"Feed config not found: {feedConfigPath}");
    return 1;
}

var feedConfig = deserializer.Deserialize<FeedConfig>(File.ReadAllText(feedConfigPath));
var feedConfigDir = Path.GetDirectoryName(feedConfigPath)!;
var projectRoot = Path.GetFullPath(Path.Combine(feedConfigDir, ".."));
var recordDefinitions = LoadRecordDefinitions(feedConfig, deserializer, projectRoot);

string ResolveProjectPath(string relativePath) =>
    Path.GetFullPath(Path.Combine(projectRoot, relativePath));

var defaultInput = ResolveProjectPath("Input/dental_sample.txt");
var inputPath = ResolvePath(arguments.Input ?? defaultInput);
if (!File.Exists(inputPath))
{
    Console.Error.WriteLine($"Input file not found: {inputPath}");
    return 1;
}

var timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
var defaultOutputRelative = feedConfig.Output.FilePattern.Replace("{timestamp}", timestamp);
var defaultOutput = ResolveProjectPath(defaultOutputRelative);
var outputPath = ResolvePath(arguments.Output ?? defaultOutput);
Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

var schemaPath = ResolveProjectPath(feedConfig.Output.Schema);
if (!File.Exists(schemaPath))
{
    Console.Error.WriteLine($"Schema file not found: {schemaPath}");
    return 1;
}
var schema = JsonSchema.FromText(File.ReadAllText(schemaPath));
var evalOptions = new EvaluationOptions { OutputFormat = OutputFormat.List };
var jsonOptions = new JsonSerializerOptions { WriteIndented = false };

var parser = new RecordParser(feedConfig, recordDefinitions);
parser.ProcessFile(inputPath);

var payloads = parser.BuildPayloads();
using var writer = new StreamWriter(outputPath);
foreach (var payload in payloads)
{
    var json = JsonSerializer.Serialize(payload, jsonOptions);
    var node = JsonNode.Parse(json);
    var results = schema.Evaluate(node!, evalOptions);
    if (!results.IsValid)
    {
        var errorDetails = JsonSerializer.Serialize(results, jsonOptions);
        throw new InvalidOperationException($"Schema validation failed for batch '{payload.BatchType}': {errorDetails}");
    }
    writer.WriteLine(json);
}

Console.WriteLine($"✅ Parsed {parser.RecordCount} records");
Console.WriteLine($"   Provider batches: {parser.ProviderBatchCount}");
Console.WriteLine($"   Client batches:   {parser.ClientBatchCount}");
Console.WriteLine($"Output written to {outputPath}");
return 0;

static string ResolvePath(string path) =>
    Path.GetFullPath(Path.IsPathRooted(path) ? path : Path.Combine(Directory.GetCurrentDirectory(), path));

static Dictionary<string, RecordDefinition> LoadRecordDefinitions(
    FeedConfig config,
    IDeserializer deserializer,
    string baseDirectory)
{
    var map = new Dictionary<string, RecordDefinition>(StringComparer.Ordinal);
    foreach (var kvp in config.Records)
    {
        var recordPath = kvp.Value;
        var filePath = Path.GetFullPath(Path.IsPathRooted(recordPath)
            ? recordPath
            : Path.Combine(baseDirectory, recordPath));
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Record definition file not found: {filePath}");
        var definition = deserializer.Deserialize<RecordDefinition>(File.ReadAllText(filePath));
        map[kvp.Key] = definition;
    }
    return map;
}

internal class ArgumentParser
{
    public string? FeedConfig { get; private set; }
    public string? Input { get; private set; }
    public string? Output { get; private set; }

    public static ArgumentParser Parse(string[] args)
    {
        var parser = new ArgumentParser();
        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--feed":
                    parser.FeedConfig = ExpectValue(args, ++i, "--feed");
                    break;
                case "--input":
                    parser.Input = ExpectValue(args, ++i, "--input");
                    break;
                case "--output":
                    parser.Output = ExpectValue(args, ++i, "--output");
                    break;
                case "--help":
                case "-h":
                    PrintHelp();
                    Environment.Exit(0);
                    break;
                default:
                    Console.Error.WriteLine($"Unknown argument: {args[i]}");
                    PrintHelp();
                    Environment.Exit(1);
                    break;
            }
        }
        return parser;
    }

    private static string ExpectValue(string[] args, int index, string name)
    {
        if (index >= args.Length)
            throw new ArgumentException($"Missing value for {name}");
        return args[index];
    }

    private static void PrintHelp()
    {
        Console.WriteLine("Usage: dotnet run -- [--feed path] [--input path] [--output path]");
    }
}

internal class RecordParser
{
    private readonly FeedConfig _config;
    private readonly Dictionary<string, RecordDefinition> _definitions;
    private readonly HashSet<string> _providerDetailTypes;
    private readonly HashSet<string> _clientDetailTypes;

    private readonly List<BatchBuilder> _providerBatches = new();
    private readonly List<BatchBuilder> _clientBatches = new();

    private BatchBuilder? _currentProvider;
    private BatchBuilder? _currentClient;

    private ParsedRecord? _fileHeader;
    private ParsedRecord? _fileTrailer;

    public int RecordCount { get; private set; }
    public int ProviderBatchCount => _providerBatches.Count;
    public int ClientBatchCount => _clientBatches.Count;

    public RecordParser(FeedConfig config, Dictionary<string, RecordDefinition> definitions)
    {
        _config = config;
        _definitions = definitions;
        _providerDetailTypes = new HashSet<string>(config.Batching.Provider.DetailTypes);
        _clientDetailTypes = new HashSet<string>(config.Batching.Client.DetailTypes);
    }

    public void ProcessFile(string path)
    {
        foreach (var rawLine in File.ReadLines(path))
        {
            if (string.IsNullOrWhiteSpace(rawLine))
                continue;

            RecordCount++;
            var recordType = rawLine[0].ToString();
            if (!_definitions.TryGetValue(recordType, out var definition))
                throw new InvalidOperationException($"Unsupported record type '{recordType}' at record #{RecordCount}");

            var record = Parse(rawLine, definition);
            RouteRecord(record, recordType);
        }

        if (_currentProvider != null)
            throw new InvalidOperationException("Provider batch not closed before end of file.");
        if (_currentClient != null)
            throw new InvalidOperationException("Client batch not closed before end of file.");
    }

    public IEnumerable<BatchPayload> BuildPayloads()
    {
        var feedName = _config.Feed.Name;
        if (_fileHeader != null)
        {
            yield return BatchPayloadFactory.Single(feedName, "file_header", header: _fileHeader);
        }

        foreach (var batch in _providerBatches)
            yield return BatchPayloadFactory.FromBatch(feedName, "provider", batch);

        foreach (var batch in _clientBatches)
            yield return BatchPayloadFactory.FromBatch(feedName, "client", batch);

        if (_fileTrailer != null)
        {
            yield return BatchPayloadFactory.Single(feedName, "file_trailer", trailer: _fileTrailer);
        }
    }

    private void RouteRecord(ParsedRecord record, string recordType)
    {
        switch (recordType)
        {
            case var type when type == _config.Batching.FileHeader:
                _fileHeader = record;
                break;
            case var type when type == _config.Batching.FileTrailer:
                _fileTrailer = record;
                break;
            case var type when type == _config.Batching.Provider.Header:
                if (_currentProvider != null)
                    throw new InvalidOperationException("Encountered provider header before previous provider batch closed.");
                _currentProvider = new BatchBuilder("provider", record);
                break;
            case var type when type == _config.Batching.Client.Header:
                if (_currentClient != null)
                    throw new InvalidOperationException("Encountered client header before previous client batch closed.");
                _currentClient = new BatchBuilder("client", record);
                break;
            case var type when type == _config.Batching.Provider.Trailer:
                if (_currentProvider == null)
                    throw new InvalidOperationException("Provider trailer encountered without active provider batch.");
                _currentProvider.Close(record);
                _providerBatches.Add(_currentProvider);
                _currentProvider = null;
                break;
            case var type when type == _config.Batching.Client.Trailer:
                if (_currentClient == null)
                    throw new InvalidOperationException("Client trailer encountered without active client batch.");
                _currentClient.Close(record);
                _clientBatches.Add(_currentClient);
                _currentClient = null;
                break;
            case var type when _providerDetailTypes.Contains(type):
                if (_currentProvider != null)
                    _currentProvider.AddDetail(record);
                else if (_currentClient != null)
                    _currentClient.AddDetail(record);
                else
                    throw new InvalidOperationException($"Detail record {type} encountered outside of an active batch.");
                break;
            case var type when _clientDetailTypes.Contains(type):
                if (_currentClient != null)
                    _currentClient.AddDetail(record);
                else if (_currentProvider != null)
                    _currentProvider.AddDetail(record);
                else
                    throw new InvalidOperationException($"Detail record {type} encountered outside of an active batch.");
                break;
            default:
                throw new InvalidOperationException($"Unhandled record type {recordType}");
        }
    }

    private static ParsedRecord Parse(string line, RecordDefinition definition)
    {
        var fields = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
        foreach (var field in definition.Fields)
        {
            if (ShouldSkipField(field))
                continue;

            if (field.Start is null || field.Length is null)
            {
                fields[field.Key] = null;
                continue;
            }

            var startIndex = Math.Max(field.Start.Value - 1, 0);
            if (startIndex >= line.Length)
            {
                fields[field.Key] = null;
                continue;
            }

            var length = field.Length.Value;
            var maxLength = Math.Min(length, line.Length - startIndex);
            var value = line.Substring(startIndex, maxLength).TrimEnd();
            fields[field.Key] = FormatFieldValue(field, value);
        }

        return new ParsedRecord
        {
            RecordType = definition.RecordType,
            Description = definition.Description,
            Fields = fields
        };
    }

    private static bool ShouldSkipField(FieldDefinition field)
    {
        var name = field.Name ?? string.Empty;
        var key = field.Key ?? string.Empty;
        return name.Contains("filler", StringComparison.OrdinalIgnoreCase) ||
               key.Contains("filler", StringComparison.OrdinalIgnoreCase);
    }

    private static string? FormatFieldValue(FieldDefinition field, string? rawValue)
    {
        if (rawValue is null)
            return null;

        if (string.Equals(field.Key, "total_amt_paid", StringComparison.OrdinalIgnoreCase) &&
            TryFormatImpliedDecimal(rawValue, 2, out var formatted))
        {
            return formatted;
        }

        return rawValue;
    }

    private static bool TryFormatImpliedDecimal(string rawValue, int scale, out string formatted)
    {
        formatted = rawValue;

        var trimmed = rawValue.Trim();
        if (trimmed.Length == 0)
            return false;

        var sign = 1;
        if (trimmed[0] == '+' || trimmed[0] == '-')
        {
            sign = trimmed[0] == '-' ? -1 : 1;
            trimmed = trimmed[1..];
        }

        if (!long.TryParse(trimmed, NumberStyles.None, CultureInfo.InvariantCulture, out var integral))
            return false;

        var magnitude = sign * (decimal)integral;
        var divisor = (decimal)Math.Pow(10, scale);
        var value = magnitude / divisor;
        formatted = value.ToString($"F{scale}", CultureInfo.InvariantCulture);
        return true;
    }
}

internal class BatchBuilder
{
    private readonly string _type;

    public ParsedRecord Header { get; }
    public List<ParsedRecord> Details { get; } = new();
    public ParsedRecord? Trailer { get; private set; }

    public BatchBuilder(string type, ParsedRecord header)
    {
        _type = type;
        Header = header;
    }

    public void AddDetail(ParsedRecord record) => Details.Add(record);

    public void Close(ParsedRecord trailer) => Trailer = trailer;

}

internal static class BatchPayloadFactory
{
    public static BatchPayload FromBatch(string feedName, string batchType, BatchBuilder builder)
    {
        var payload = new BatchPayload
        {
            FeedName = feedName,
            BatchType = batchType,
            Header = builder.Header.ToPayload(),
            Details = builder.Details.Select(d => d.ToPayload()).ToList(),
            Trailer = builder.Trailer?.ToPayload(),
        };

        payload.Metadata["detailCount"] = payload.Details.Count.ToString();
        if (builder.Header.Fields.TryGetValue("provider_number", out var provider))
            payload.Metadata["providerNumber"] = provider;
        if (builder.Header.Fields.TryGetValue("client_id", out var client))
            payload.Metadata["clientId"] = client;
        return payload;
    }

    public static BatchPayload Single(
        string feedName,
        string batchType,
        ParsedRecord? header = null,
        ParsedRecord? trailer = null)
    {
        return new BatchPayload
        {
            FeedName = feedName,
            BatchType = batchType,
            Header = header?.ToPayload(),
            Trailer = trailer?.ToPayload(),
        };
    }

    public static RecordPayload ToPayload(this ParsedRecord record) => new()
    {
        RecordType = record.RecordType,
        Description = record.Description,
        Fields = record.Fields
    };
}
