using System;
using System.Xml;

namespace B2CLocalizationTool.Service.Utility
{
    internal static class XMLUtility
    {
        internal static string WriteToXMLFile(XmlDocument xml, string outputPath = null)
        {
            if (string.IsNullOrEmpty(outputPath))
            {
                outputPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            var completeFileName = $"{outputPath}\\Localization{DateTimeOffset.Now.ToUnixTimeSeconds()}.xml";
            xml.Save(completeFileName);
            return completeFileName;
        }
    }
}
