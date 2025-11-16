namespace EligibilityModule.Models
{
    public class FieldRule
    {
        public string Pattern { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Format { get; set; }
        public string Pad_Char { get; set; }
        public int? Decimal_Places { get; set; }
        public string Padding { get; set; }
        public string Condition { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
    }
}
