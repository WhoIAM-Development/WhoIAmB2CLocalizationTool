using System.Collections.Generic;

namespace B2CLocalizationTool.Service.Model
{

    public class LocalizationInputModel
    {
        public string Resource { get; set; }
        public string ElementType { get; set; }
        public string ElementId { get; set; }
        public string StringId { get; set; }
        public string Value { get; set; }
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
