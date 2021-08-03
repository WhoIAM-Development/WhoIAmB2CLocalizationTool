namespace B2CLocalizationTool.Shared
{
    public class AppSettings
    {
        public bool OverwriteFiles { get; set; }
        public ToXMLSettings ToXML { get; set; }
    }

    public class ToXMLSettings
    {
        public SupportedLanguages SupportedLanguages { get; set; }
    }

    public class SupportedLanguages
    {
        public bool Enabled { get; set; } 
        public string Comment { get; set; } 
        public string DefaultLanguageCode { get; set; } 
    }
}
