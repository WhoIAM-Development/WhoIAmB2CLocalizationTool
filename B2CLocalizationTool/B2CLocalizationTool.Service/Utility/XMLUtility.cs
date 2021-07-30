using System;
using System.IO;
using System.Xml;

namespace B2CLocalizationTool.Service.Utility
{
    internal static class XMLUtility
    {
        internal static string WriteToXMLFile(XmlDocument xml, string inputPath, string outputPath = null)
        {
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath);
            string absoluteInputPath = Path.GetDirectoryName(inputPath);

            if (string.IsNullOrEmpty(outputPath))
            {
                outputPath = absoluteInputPath;
            }
            var completeFileName = $"{outputPath}\\{outputFileName}_{DateTimeOffset.Now.ToUnixTimeSeconds()}.xml";
            xml.Save(completeFileName);
            return completeFileName;
        }

        internal static XmlDocument ReadXMLFile(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            return doc;
        }
    }
}
