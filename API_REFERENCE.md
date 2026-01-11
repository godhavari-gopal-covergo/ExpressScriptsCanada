# Public API & Component Reference

This document captures every public surface exposed by the `EligibilityModule` and `ExperienceModule` projects so you can confidently script against them, extend their configuration, or wrap them in higher-level tooling. Each section lists entry points, runtime expectations, and concrete examples sourced from the current repository.

---

## Eligibility Module (`EligibilityModule`)

### CLI entry point
- **Command**: `dotnet run --project EligibilityModule/EligibilityModule.csproj -- [--partner PARTNER_ID]`
- **Arguments**:
  - `--partner` *(optional)*: applies overrides stored in `EligibilityModule/Config/Partners/{PARTNER_ID}/record_*.yml` before processing.
- **Input**: defaults to `EligibilityModule/Input/input.json` (list of dictionaries). Override by editing the file or wiring your own path inside `Program.cs`.
- **Output**: timestamped fixed-width file in `EligibilityModule/Output/ehc_output_{yyyyMMdd_HHmmss}.txt`.

**Example**
```bash
cd ExpressScriptsCanada
DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1 \
  dotnet run --project EligibilityModule/EligibilityModule.csproj -- \
  --partner GMS
```
The sample above loads `Config/common_rules.yml`, every `Config/record_*.yml`, then merges overrides under `Config/Partners/GMS/` before emitting the transformed feed.

### Processing stages (from `Program.cs`)
1. **Bootstrap**: parse `--partner`, log context, load `CommonRules` via YAML (`LoadYaml<CommonRules>`).
2. **Record definitions**: enumerate every `Config/record_*.yml` into `RecordTypeDefinition` objects (`LoadRecordDefinitions`).
3. **Partner overrides** *(optional)*: apply `PartnerFieldOverride` entries record-by-record.
4. **Lookup hydration**: resolve `LookupDefinition` files referenced by `CommonRules.Lookup_Files`.
5. **Interpreter setup**: register `DateTime`, `Math`, `String`, and the reusable `Lookup(table, key, default)` delegate with `DynamicExpresso` so transforms can use C# expressions.
6. **Input ingestion**: deserialize `Input/input.json` into `List<Dictionary<string, JsonElement>>` and coerce primitives (`ConvertJsonElementsToObjects`).
7. **Record rendering**: for every record, `ProcessRecord` walks the ordered `FieldDefinition` list to
   - pick the source value or `Default_Value`
   - run `FieldRule` matches (`ApplyCommonFieldRules`)
   - execute `Transform` / `Transform_Lookup`
   - enforce formatting, padding, allowed values, required checks
   - emit concatenated fixed-width text.
8. **Output**: write all rendered lines to `Output/` and print per-record-type counts.

### Configuration & model APIs
All publicly accessible POCOs live in `EligibilityModule/Models`. They are intended to be hydrated from YAML or JSON, but you can also instantiate them in code when scripting tests.

#### `CommonRules` (`Models/CommonRules.cs`)
| Property | Type | Purpose / Notes |
| --- | --- | --- |
| `Version` | `string` | Free-form descriptor surfaced in logs.
| `Description` | `string` | Human-readable context for auditors.
| `Field_Rules` | `List<FieldRule>` | Global regex-driven rules automatically applied to every field before transforms.
| `Global_Transforms` | `Dictionary<string,string>` | Named fragments you can inject into `FieldDefinition.Transform` expressions (keyed by alias).
| `Lookup_Files` | `List<string>` | Relative YAML paths (under `Config/`) that produce `LookupDefinition` objects.
| `Validation_Rules` | `ValidationRules` | Feature flags for trimming, length enforcement, etc.

**Usage example**
```yaml
# EligibilityModule/Config/common_rules.yml (excerpt)
lookup_files:
  - "Lookups/language_codes.yml"
field_rules:
  - pattern: "date"
    type: "date_format"
    format: "yyyyMMdd"
```
The config above ensures every field whose `name` or `key` contains `date` is normalized to `yyyyMMdd` if a value exists.

#### `ValidationRules`
| Property | Type | Default |
| --- | --- | --- |
| `Required_Fields` | `bool` | `true` – warn when mandatory data is blank.
| `Trim_Whitespace` | `bool` | `true` – global trimming before padding.
| `Enforce_Length` | `bool` | `true` – truncates and logs when data overruns `FieldDefinition.Length`.
| `Log_Warnings` | `bool` | `true` – toggles console output for soft validation hits.

#### `RecordTypeDefinition` (`Models/RecordTypeDefinition.cs`)
Represents a single fixed-width record layout sourced from `Config/record_*.yml`.

| Property | Type | Notes |
| --- | --- | --- |
| `Record_Type` | `string` | e.g., `"20"` for client records.
| `Description` | `string` | Same prose as the YAML header comment.
| `Lookups` | `Dictionary<string, Dictionary<string,string>>` | Inline lookup overrides scoped to this record type.
| `Fields` | `List<FieldDefinition>` | Ordered definitions describing each column.

#### `FieldDefinition` (`Models/FieldDefinition.cs`)
Defines how a single column is read, validated, transformed, and written.

| Property | Type | Default / Notes |
| --- | --- | --- |
| `Name` | `string` | Descriptive label (mirrors YAML `name`).
| `Key` | `string` | Identifier used to map JSON input and interpreter variables.
| `Length` | `int` | Fixed width for padding + truncation.
| `Padding` | `string` | `"right"` by default; use `"left"` or `"none"`.
| `Pad_Char` | `string` | Single-character padding token (defaults to space).
| `Transform` | `string?` | Inline DynamicExpresso expression (`value` variable pre-populated).
| `Transform_Lookup` | `string?` | Expression typically calling `Lookup(...)` to remap codes.
| `Default_Value` | `string?` | Used when JSON input omits the key.
| `Format` | `string?` | Special formatter alias (currently `"accumulator_amount"`).
| `Required` | `bool` | Forces warning/log when blank.
| `Allowed_Values` | `List<string>` | Explicit whitelist compared case-insensitively.

**Usage example** (from `Config/record_20_client.yml`)
```yaml
- name: "Client Province Code"
  key: "client_province_code"
  length: 2
  padding: "right"
  allowed_values: ["AB", "BC", "QC", "ON", "NB", "NS", "MB", "PE", "SK", "NL", "NT", "YT", "NU"]
  transform_lookup: "Lookup(\"province_codes\", client_province_code, client_province_code?.ToUpper())"
```
This field normalizes province abbreviations by running through the shared `province_codes` lookup, guaranteeing uppercase codes in the feed.

#### `FieldRule` (`Models/FieldRule.cs`)
Used inside `CommonRules.Field_Rules` for cross-cutting defaults and formatting.

| Property | Type | Notes |
| --- | --- | --- |
| `Pattern` | `string` | Regex applied to both `FieldDefinition.Name` and `.Key`.
| `Type` | `string` | Currently supports `default_value`, `date_format`, `numeric_format`.
| `Value`/`Format`/`Decimal_Places` | `string`/`string`/`int?` | Parameters consumed by each rule type.
| `Pad_Char`, `Padding` | `string` | Allow rule-level padding overrides.
| `Condition`, `Action`, `Message` | `string` | Reserved for richer rule engines; today they remain unused but available for future branches.

#### `LookupDefinition` (`Models/LookupDefinition.cs`)
| Property | Type | Description |
| --- | --- | --- |
| `Lookup_Name` | `string` | Name referenced by `FieldDefinition.Transform_Lookup`.
| `Description` | `string` | Explains the mapping’s intent.
| `Mappings` | `Dictionary<string,string>` | Source → target pairs.

**Usage example**
```yaml
# EligibilityModule/Config/Lookups/language_codes.yml
lookup_name: "language_codes"
description: "Maps input language tokens to ESC standard codes"
mappings:
  english: "E"
  french: "F"
```
Add the file path to `CommonRules.Lookup_Files` so it is available at runtime.

#### `OutputDefinition` (`Models/OutputDefinition.cs`)
Encapsulates metadata for downstream writers.

| Property | Type | Notes |
| --- | --- | --- |
| `Format` | `string` | e.g., `"fixed_width"`.
| `Include_Headers` | `bool` | Toggle header/footer emission.
| `File_Name_Pattern` | `string` | Allows deterministic naming when the default timestamped pattern is insufficient.
| `Encoding` | `string` | e.g., `"utf-8"` (passed to `File.WriteAllLines`).

#### `EtlDefinition` (`Models/EtlDefinition.cs`)
Wrapper used when orchestrating the module from other services.

| Property | Type | Notes |
| --- | --- | --- |
| `Context` | `string` | Identifier for the ETL job.
| `Description` | `string` | Optional summary.
| `Output` | `OutputDefinition` | Reuses the structure above.
| `Lookups` | `Dictionary<string, Dictionary<string,string>>` | Additional lookup maps if you need to package them inline.
| `Field_Templates` | `Dictionary<string, object>` | Arbitrary template objects that other tooling can expand into `FieldDefinition` instances.
| `Fields` | `List<FieldDefinition>` | Convenience when defining ad-hoc record layouts outside the YAML files.

#### Partner override models (`Models/PartnerConfiguration.cs`)
| Class | Key Properties | Purpose |
| --- | --- | --- |
| `PartnerFieldOverride` | `Key`, `Default_Value`, `Skip` | Entry describing how a single field should change for a partner.
| `PartnerRecordConfiguration` | `Partner_Id`, `Record_Type`, `Field_Overrides` | Collection applied on top of the base `RecordTypeDefinition`.

**Example**
```yaml
# EligibilityModule/Config/Partners/GMS/record_20_client.yml
partner_id: "GMS"
record_type: "20"
field_overrides:
  - key: "client_language_code"
    default_value: "E"
  - key: "group_number"
    default_value: "GMS-DEFAULT"
```
Running `--partner GMS` now injects English and default group numbers whenever the incoming JSON omits them.

---

## Experience Module (`ExperienceModule`)

### CLI entry point
- **Command**: `dotnet run --project ExperienceModule -- [--feed path] [--input path] [--output path]`
- **Arguments**:
  - `--feed` *(optional)*: YAML master config (defaults to `ExperienceModule/Config/dental_feed.yml`).
  - `--input`: fixed-width source file (defaults to `ExperienceModule/Input/dental_sample.txt`).
  - `--output`: newline-delimited JSON file (defaults to pattern inside the feed config).
- **Exit codes**: `0` on success, `>0` if CLI parsing fails, files are missing, or schema validation fails.

**Example**
```bash
cd ExpressScriptsCanada
 dotnet run --project ExperienceModule -- \
  --feed ExperienceModule/Config/dental_feed.yml \
  --input ExperienceModule/Input/dental_sample.txt \
  --output /tmp/dental_batches.jsonl
```
Every emitted JSON object gets validated against the schema declared in the feed config (default `schemas/dental_batch.schema.json`).

### Parsing & batching flow
1. **Argument parsing**: `ArgumentParser.Parse` handles `--feed`, `--input`, `--output`, and `--help` (exits early after printing usage).
2. **Config load**: the selected YAML file hydrates `FeedConfig`, then `LoadRecordDefinitions` resolves each per-record YAML path.
3. **Input scanning**: `RecordParser.ProcessFile` walks each line, infers the record type from the first character, and maps the fixed-width payload into a `ParsedRecord` via field offsets/lengths.
4. **Batch routing**: provider/client batches are assembled according to `BatchingConfig` headers, detail types, and trailers (with validation so headers/trailers are balanced).
5. **Payload generation**: `RecordParser.BuildPayloads` yields a stream of `BatchPayload` objects (file header, provider batches, client batches, file trailer).
6. **Schema enforcement**: each payload is serialized, validated via `Json.Schema`, and written as a single line to your chosen output file.

### Configuration & payload models (`ExperienceModule/Models/ConfigModels.cs`)
All of the following classes are `public` so other tooling (unit tests, scripts, or alternative hosts) can compose them directly.

#### `FeedConfig`
| Property | Type | Notes |
| --- | --- | --- |
| `Feed` | `FeedInfo` | Declarative metadata such as name and record length.
| `Records` | `Dictionary<string,string>` | Maps record type identifiers (e.g., `"4"`) to YAML layout files.
| `Batching` | `BatchingConfig` | Defines headers, detail types, and trailers for provider/client batches plus file-level wrappers.
| `Output` | `OutputConfig` | Points to the JSON schema and output path pattern.

**Usage example** (current default `Config/dental_feed.yml`):
```yaml
feed:
  name: dental_thbm
  record_length: 4561
  description: ESC Dental Claims Experience Feed (THBM)
records:
  "4": "Config/Records/Dental/record_4.yml"
  "5": "Config/Records/Dental/record_5.yml"
  # ...
batching:
  provider:
    header: "2"
    detail_types: ["4", "5"]
    trailer: "6"
  client:
    header: "3"
    detail_types: ["4", "5"]
    trailer: "7"
  file_header: "0"
  file_trailer: "8"
output:
  schema: "schemas/dental_batch.schema.json"
  file_pattern: "Output/dental_batches_{timestamp}.jsonl"
```

#### `FeedInfo`
| Property | Type | Notes |
| --- | --- | --- |
| `Name` | `string` | Logical feed identifier, stamped into payload metadata.
| `RecordLength` | `int` | Expected width of every line in the source file.
| `Description` | `string?` | Optional for documentation.

#### `BatchingConfig` & `BatchGroup`
| Property | Type | Notes |
| --- | --- | --- |
| `Provider`, `Client` | `BatchGroup` | Each group lists header code, detail codes, trailer code.
| `FileHeader` / `FileTrailer` | `string` | Record types for file-level wrappers.
| `BatchGroup.Header` | `string` | Record type that begins a batch.
| `BatchGroup.DetailTypes` | `List<string>` | Acceptable detail records while the batch is open.
| `BatchGroup.Trailer` | `string` | Record type that must close the batch.

#### `OutputConfig`
| Property | Type | Notes |
| --- | --- | --- |
| `Schema` | `string` | Path to a JSON Schema file used to validate each payload.
| `FilePattern` | `string` | Supports `{timestamp}` placeholder that gets replaced with UTC `yyyyMMdd_HHmmss`.

#### `RecordDefinition`
| Property | Type | Notes |
| --- | --- | --- |
| `RecordType` | `string` | Single-character identifiers such as `"4"` (paid claim record).
| `Description` | `string` | Copied from the spec.
| `Fields` | `List<FieldDefinition>` | Field-by-field layout instructions.

#### `FieldDefinition`
| Property | Type | Notes |
| --- | --- | --- |
| `FieldNumber` | `string` | Matches the numbering in ESC specs.
| `Name` | `string` | Friendly field label.
| `Key` | `string` | Dictionary key in `ParsedRecord.Fields`.
| `Start` / `End` | `int?` | 1-based offsets in the fixed-width line.
| `Length` | `int?` | Number of characters to read.
| `Format` | `string` | Spec format (e.g., `9(8)` for YYYYMMDD).
| `Description` | `string?` | Additional notes carried into docs.
| `ValueFormat` | `FieldValueFormat?` | Optional type metadata for implied decimal handling.

**Example** (from `Config/Records/Dental/record_4.yml`)
```yaml
- field_number: '005'
  name: Date Claim Received
  key: date_claim_received
  start: 36
  end: 43
  length: 8
  format: 9(8)
  description: Date claim was received in the office
```
This creates a `ParsedRecord.Fields["date_claim_received"]` entry containing the substring at positions 36–43.

#### `FieldValueFormat`
| Property | Type | Notes |
| --- | --- | --- |
| `Type` | `string` | `"implied_decimal"` or `"amount"` triggers scale-aware formatting.
| `Scale` | `int` | Number of decimal places implied in the raw fixed-width value.

`RecordParser` uses this metadata to convert `"000012345"` with `Scale = 2` into `"123.45"`.

#### `ParsedRecord`
| Property | Type | Notes |
| --- | --- | --- |
| `RecordType` | `string` | Echoes `RecordDefinition.RecordType`.
| `Description` | `string` | For downstream logging.
| `Fields` | `Dictionary<string,string?>` | Case-insensitive map of parsed values.

`RecordParser.Parse` populates this structure for every record. You can create instances manually in tests when seeding `BatchBuilder`.

#### Payload contracts (`BatchPayload`, `RecordPayload`)
| Property | Type | Notes |
| --- | --- | --- |
| `BatchPayload.FeedName` | `string` | Copied from `FeedConfig.Feed.Name`.
| `BatchPayload.BatchType` | `string` | `"provider"`, `"client"`, `"file_header"`, or `"file_trailer"`.
| `BatchPayload.Header` / `Details` / `Trailer` | `RecordPayload` / `List<RecordPayload>` | Parsed records organized per batch.
| `BatchPayload.Metadata` | `Dictionary<string,string?>` | Automatically populated with helper keys (`detailCount`, `providerNumber`, `clientId`).
| `RecordPayload.RecordType` | `string` | 1-character type ID.
| `RecordPayload.Description` | `string` | Human-readable label.
| `RecordPayload.Fields` | `Dictionary<string,string?>` | Field map cloned from `ParsedRecord`.

### End-to-end usage example
```csharp
var feedConfig = deserializer.Deserialize<FeedConfig>(File.ReadAllText("Config/dental_feed.yml"));
var records = LoadRecordDefinitions(feedConfig, deserializer, projectRoot);
var parser = new RecordParser(feedConfig, records);
parser.ProcessFile("Input/dental_sample.txt");
foreach (var batch in parser.BuildPayloads())
{
    // serialize or push to downstream queues
    Console.WriteLine(JsonSerializer.Serialize(batch));
}
```
Create your own harness (integration tests, custom hosts, etc.) by reusing the same models and parser shown above. Ensure your output JSON matches the schema declared in `feedConfig.Output.Schema` to avoid runtime validation failures.

---

## Tips for extending either module
- **Add new lookups** by dropping YAML into `EligibilityModule/Config/Lookups/` and appending the filename to `CommonRules.Lookup_Files`.
- **Inject partner defaults** by copying the relevant `Config/record_XX.yml` into `Config/Partners/{PARTNER}/` and trimming it down to just the fields you need to override.
- **Create new experience feeds** by cloning `Config/dental_feed.yml`, pointing `records` to your own layouts, and ensuring `schemas/*.json` reflects the batch payload you expect.
- **Test transforms safely** by running either `dotnet run` command against the sample inputs committed under `Input/` before promoting changes.
