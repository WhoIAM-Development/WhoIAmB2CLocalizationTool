using System.Collections.Generic;

namespace B2CLocalizationTool.Shared
{
    public class ToJsonSettings
    {
        public string FilePrefix { get; set; }
        public bool WriteOnlyModifiedValues { get; set; }
        public List<Schema> LanguageSchema { get; set; }
    }

    public class Schema
    {
        public string Name { get; set; }
        public bool IsDefaultValue { get; set; }
        public int ModifiedValueIndex { get; set; }
        public int Index { get; set; }
    }
}
