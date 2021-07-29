using System.Collections.Generic;

namespace B2CLocalizationTool.Service.Model
{

    public class LocalizationInputModel
    {
        public string Resource { get; set; }
        public string ResourceType { get; set; }
        public string TargetCollection { get; set; }
        public string ItemValue  { get; set; }
        public string ElementType { get; set; }
        public string ElementId { get; set; }
        public string StringId { get; set; }
        public string LanguageValue { get; set; }
        public bool? SelectByDefault { get; set; }   
    }

    public class LocalizationOutputModel
    {
        public string Resource { get; set; }
        public string ElementType { get; set; }
        public string ElementId { get; set; }
        public string StringId { get; set; }
        public Dictionary<string, string> LanguageValues { get; set; }
    }
}
