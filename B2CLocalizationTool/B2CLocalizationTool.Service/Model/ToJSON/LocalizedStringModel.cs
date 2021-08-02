using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace B2CLocalizationTool.Service.Model.ToJSON
{
    public class LocalizedJson
    {
        [JsonIgnore]
        public string Resource { get; set; }
        [JsonIgnore]
        public string LangaugeCode { get; set; }
        public IEnumerable<LocalizedStringModel> LocalizedStrings { get; set; }
    }
    public class LocalizedStringModel
    {
        [JsonIgnore]
        public string Resource { get; set; }
        [JsonIgnore]
        public string LangaugeCode { get; set; }
        [JsonPropertyName("ElementType")]
        public string ElementType { get; set; }
        [JsonPropertyName("ElementId")]
        public string ElementId { get; set; }
        [JsonPropertyName("StringId")]
        public string StringId { get; set; }
        [JsonPropertyName("Override")]
        public bool Override { get; set; }
        [JsonPropertyName("Value")]
        public string Value { get; set; }
    }
}
