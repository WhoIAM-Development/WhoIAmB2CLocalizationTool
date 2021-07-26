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
                    for (int i = Constants.LanguageIndex; i < row.ItemArray.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(row.ItemArray[i].ToString()))
                        {
                            list.Add(new LocalizationModel
                            {
                                Resource = $"{row.Field<string>(Constants.Resource)}.{row.Table.Columns[i]}",
                                ElementType = row.Field<string>(Constants.ElementType),
                                ElementId = row.Field<string>(Constants.ElementId),
                                StringId = row.Field<string>(Constants.StringId),
                                Value = row.ItemArray[i].ToString()
                            });
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
            XmlElement rootnode = doc.CreateElement(Constants.Localization);
            rootnode.SetAttribute(Constants.Enabled, "true");
            doc.InsertBefore(declaire, doc.DocumentElement);

            foreach (var resources in localizationResources)
            {
                XmlElement localizedResourcesNode = doc.CreateElement(Constants.LocalizedResources);
                localizedResourcesNode.SetAttribute(Constants.Id, resources.Key);

                foreach (var resource in resources)
                {
                    XmlElement localizedStringElement = doc.CreateElement(Constants.LocalizedString);
                    localizedStringElement.SetAttribute(Constants.ElementType, resource.ElementType);
                    localizedStringElement.SetAttribute(Constants.ElementId, resource.ElementId);
                    localizedStringElement.SetAttribute(Constants.StringId, resource.StringId);
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
