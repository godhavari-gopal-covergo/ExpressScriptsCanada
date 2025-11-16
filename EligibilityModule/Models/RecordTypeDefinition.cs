using System.Collections.Generic;

namespace EligibilityModule.Models
{
    public class RecordTypeDefinition
    {
        public string Record_Type { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Dictionary<string, string>> Lookups { get; set; } = new();
        public List<FieldDefinition> Fields { get; set; }
    }
}

