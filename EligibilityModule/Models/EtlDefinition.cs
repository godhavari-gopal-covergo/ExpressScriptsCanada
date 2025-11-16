using System.Collections.Generic;

namespace EligibilityModule.Models
{
    public class EtlDefinition
    {
        public string Context { get; set; }
        public string Description { get; set; }
        public OutputDefinition Output { get; set; }
        public Dictionary<string, Dictionary<string, string>> Lookups { get; set; } = new();
        public Dictionary<string, object> Field_Templates { get; set; } = new();
        public List<FieldDefinition> Fields { get; set; }
    }
}
