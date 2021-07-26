using B2CLocalizationTool.Service.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace B2CLocalizationTool.Service.Extensions
{
    internal static class LocalizationModelExtension
    {
        internal static IEnumerable<IGrouping<string, LocalizationModel>> ToLocalizationModel(this DataSet dataSet)
        {

            if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count > 0)
            {
                var list = new List<LocalizationModel>();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    for (int i = 4; i < row.ItemArray.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(row.ItemArray[i].ToString()))
                        {
                            var model = new LocalizationModel();
                            model.Resource = $"{row.ItemArray[0]}.{row.Table.Columns[i]}";
                            model.ElementType = row.ItemArray[1].ToString();
                            model.ElementId = row.ItemArray[2].ToString();
                            model.StringId = row.ItemArray[3].ToString();
                            model.Value = row.ItemArray[i].ToString();

                            list.Add(model);
                        }
                    }
                }
                return list.GroupBy(x => x.Resource).ToList();
            }
            return null;
        }

        internal static XmlDocument ToXml(this IEnumerable<IGrouping<string, LocalizationModel>> localizationResources)
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
    }
}
