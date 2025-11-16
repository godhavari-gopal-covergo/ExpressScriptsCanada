using System.Collections.Generic;

namespace EligibilityModule.Models
{
    public class LookupDefinition
    {
        public string Lookup_Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Mappings { get; set; } = new();
    }
}

