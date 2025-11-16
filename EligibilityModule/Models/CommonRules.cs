using System.Collections.Generic;

namespace EligibilityModule.Models
{
    public class CommonRules
    {
        public string Version { get; set; }
        public string Description { get; set; }
        public List<FieldRule> Field_Rules { get; set; } = new();
        public Dictionary<string, string> Global_Transforms { get; set; } = new();
        public List<string> Lookup_Files { get; set; } = new();
        public ValidationRules Validation_Rules { get; set; } = new();
    }

    public class ValidationRules
    {
        public bool Required_Fields { get; set; } = true;
        public bool Trim_Whitespace { get; set; } = true;
        public bool Enforce_Length { get; set; } = true;
        public bool Log_Warnings { get; set; } = true;
    }
}

