using System.Collections.Generic;

namespace EligibilityModule.Models
{
    public class PartnerFieldOverride
    {
        public string Key { get; set; }
        public string Default_Value { get; set; }
        public bool Skip { get; set; }
    }

    public class PartnerRecordConfiguration
    {
        public string Partner_Id { get; set; }
        public string Record_Type { get; set; }
        public List<PartnerFieldOverride> Field_Overrides { get; set; } = new List<PartnerFieldOverride>();
    }
}

