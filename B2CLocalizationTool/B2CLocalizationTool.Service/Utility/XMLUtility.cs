using B2CLocalizationTool.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace B2CLocalizationTool.Service.Utility
{
    internal static class XMLUtility
    {
        internal static string WriteToXMLFile(IEnumerable<IGrouping<string, LocalizationInputModel>> localizationResources)
        {
            XmlDocument xml = CreateXmlDocument(localizationResources);
            return WriteToFile(xml);
        }

        private static XmlDocument CreateXmlDocument(IEnumerable<IGrouping<string, LocalizationInputModel>> localizationResources)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaire = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement rootnode = doc.CreateElement("Localization");
            rootnode.SetAttribute("Enabled", "true");
            doc.InsertBefore(declaire, doc.DocumentElement);

            foreach (var resources in localizationResources)
            {
                XmlElement localizedResourcesNode = doc.CreateElement("LocalizedResources");
                localizedResourcesNode.SetAttribute("Id", resources.Key);

                foreach (var resource in resources)
                {
                    XmlElement localizedStringElement = doc.CreateElement("LocalizedString");
                    localizedStringElement.SetAttribute("ElementType", resource.ElementType);
                    localizedStringElement.SetAttribute("ElementId", resource.ElementId);
                    localizedStringElement.SetAttribute("StringId", resource.StringId);
                    localizedStringElement.InnerText = resource.Value;

                    localizedResourcesNode.AppendChild(localizedStringElement);
                }

                rootnode.AppendChild(localizedResourcesNode);
                doc.AppendChild(rootnode);
            }

            return doc;
        }

        private static string WriteToFile(XmlDocument xml)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var completeFileName = $"{path}\\Localization{DateTimeOffset.Now.ToUnixTimeSeconds()}.xml";
            xml.Save(completeFileName);
            return path;
        }
    }
}
