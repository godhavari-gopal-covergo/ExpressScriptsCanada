using System.Collections.Generic;

namespace EligibilityModule.Models
{
    public class FieldDefinition
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int Length { get; set; }
        public string Padding { get; set; } = "right";
        public string Pad_Char { get; set; } = " ";
        public string Transform { get; set; }
        public string Transform_Lookup { get; set; }
        public string Default_Value { get; set; }
        public string Format { get; set; }
        public bool Required { get; set; } = false;
        public List<string> Allowed_Values { get; set; } = new();
    }
}
