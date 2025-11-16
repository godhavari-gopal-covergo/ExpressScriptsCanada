namespace EligibilityModule.Models
{
    public class OutputDefinition
    {
        public string Format { get; set; }
        public bool Include_Headers { get; set; }
        public string File_Name_Pattern { get; set; }
        public string Encoding { get; set; }
    }
}
