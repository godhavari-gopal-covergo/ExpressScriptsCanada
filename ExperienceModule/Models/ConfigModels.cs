using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace ExperienceModule.Models;

public class FeedConfig
{
    [YamlMember(Alias = "feed")]
    public FeedInfo Feed { get; set; } = new();

    [YamlMember(Alias = "records")]
    public Dictionary<string, string> Records { get; set; } = new(StringComparer.Ordinal);

    [YamlMember(Alias = "batching")]
    public BatchingConfig Batching { get; set; } = new();

    [YamlMember(Alias = "output")]
    public OutputConfig Output { get; set; } = new();
}

public class FeedInfo
{
    [YamlMember(Alias = "name")]
    public string Name { get; set; } = "dental";

    [YamlMember(Alias = "record_length")]
    public int RecordLength { get; set; }

    [YamlMember(Alias = "description")]
    public string? Description { get; set; }
}

public class BatchingConfig
{
    [YamlMember(Alias = "provider")]
    public BatchGroup Provider { get; set; } = new();

    [YamlMember(Alias = "client")]
    public BatchGroup Client { get; set; } = new();

    [YamlMember(Alias = "file_header")]
    public string FileHeader { get; set; } = "0";

    [YamlMember(Alias = "file_trailer")]
    public string FileTrailer { get; set; } = "8";
}

public class BatchGroup
{
    [YamlMember(Alias = "header")]
    public string Header { get; set; } = string.Empty;

    [YamlMember(Alias = "detail_types")]
    public List<string> DetailTypes { get; set; } = new();

    [YamlMember(Alias = "trailer")]
    public string Trailer { get; set; } = string.Empty;
}

public class OutputConfig
{
    [YamlMember(Alias = "schema")]
    public string Schema { get; set; } = "schemas/dental_batch.schema.json";

    [YamlMember(Alias = "file_pattern")]
    public string FilePattern { get; set; } = "Output/dental_batches_{timestamp}.jsonl";
}

public class RecordDefinition
{
    [YamlMember(Alias = "record_type")]
    public string RecordType { get; set; } = string.Empty;

    [YamlMember(Alias = "description")]
    public string Description { get; set; } = string.Empty;

    [YamlMember(Alias = "fields")]
    public List<FieldDefinition> Fields { get; set; } = new();
}

public class FieldDefinition
{
    [YamlMember(Alias = "field_number")]
    public string FieldNumber { get; set; } = string.Empty;

    [YamlMember(Alias = "name")]
    public string Name { get; set; } = string.Empty;

    [YamlMember(Alias = "key")]
    public string Key { get; set; } = string.Empty;

    [YamlMember(Alias = "start")]
    public int? Start { get; set; }

    [YamlMember(Alias = "end")]
    public int? End { get; set; }

    [YamlMember(Alias = "length")]
    public int? Length { get; set; }

    [YamlMember(Alias = "format")]
    public string Format { get; set; } = string.Empty;

    [YamlMember(Alias = "description")]
    public string? Description { get; set; }

    [YamlMember(Alias = "value_format")]
    public FieldValueFormat? ValueFormat { get; set; }
}

public class ParsedRecord
{
    public string RecordType { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public Dictionary<string, string?> Fields { get; init; } = new(StringComparer.OrdinalIgnoreCase);
}

public class FieldValueFormat
{
    [YamlMember(Alias = "type")]
    public string Type { get; set; } = string.Empty;

    [YamlMember(Alias = "scale")]
    public int Scale { get; set; } = 0;
}

public class BatchPayload
{
    [JsonPropertyName("feedName")]
    public string FeedName { get; set; } = string.Empty;

    [JsonPropertyName("batchType")]
    public string BatchType { get; set; } = string.Empty;

    [JsonPropertyName("header")]
    public RecordPayload? Header { get; set; }

    [JsonPropertyName("details")]
    public List<RecordPayload> Details { get; set; } = new();

    [JsonPropertyName("trailer")]
    public RecordPayload? Trailer { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string?> Metadata { get; set; } = new();
}

public class RecordPayload
{
    [JsonPropertyName("recordType")]
    public string RecordType { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("fields")]
    public Dictionary<string, string?> Fields { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

