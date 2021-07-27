using B2CLocalizationTool.Service.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace B2CLocalizationTool.Service.Extensions
{
    internal static class LocalizationModelExtension
    {
        internal static IEnumerable<IGrouping<string, LocalizationInputModel>> ToLocalizationModel(this DataSet dataSet)
        {

            if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count > 0)
            {
                var list = new List<LocalizationInputModel>();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    for (int i = Constants.LanguageIndex; i < row.ItemArray.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(row.ItemArray[i].ToString()))
                        {
                            list.Add(new LocalizationInputModel
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

        internal static XmlDocument ToXml(this IEnumerable<IGrouping<string, LocalizationInputModel>> localizationResources)
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


        internal static IEnumerable<LocalizationOutputModel> ToLocalizationModels(this XmlDocument document)
        {
            if (document != null)
            {
                XmlNodeList nl = document.SelectNodes(Constants.Localization);
                if (nl != null && nl[0] != null && nl[0].ChildNodes.Count > 0)
                {
                    var root = nl[0];

                    var localizationModels = new List<LocalizationOutputModel>();
                    foreach (XmlNode xnode in root.ChildNodes)
                    {
                        var resourceId = xnode.Attributes[Constants.Id].Value;
                        var splitArray = resourceId.Split(".");
                        var resourceLanguage = splitArray.Last();
                        var resourceIdWithoutLanguage = string.Join(".", splitArray.SkipLast(1));

                        foreach (XmlNode lsNode in xnode.ChildNodes)
                        {
                            var existingLocalization = localizationModels.FirstOrDefault(x => x.Resource == resourceIdWithoutLanguage
                                && x.ElementType == lsNode.Attributes[Constants.ElementType].Value
                                && x.ElementId == lsNode.Attributes[Constants.ElementId].Value
                                && x.StringId == lsNode.Attributes[Constants.StringId].Value);
                            if (existingLocalization != null)
                            {
                                existingLocalization.LanguageValues = AddToLanguageValues(resourceLanguage, lsNode.InnerText, existingLocalization.LanguageValues);
                            }
                            else
                            {
                                localizationModels.Add(new LocalizationOutputModel()
                                {
                                    Resource = resourceIdWithoutLanguage,
                                    ElementType = lsNode.Attributes[Constants.ElementType].Value,
                                    ElementId = lsNode.Attributes[Constants.ElementId].Value,
                                    StringId = lsNode.Attributes[Constants.StringId].Value,
                                    LanguageValues = AddToLanguageValues(resourceLanguage, lsNode.InnerText)
                                });
                            }
                        }
                    }
                    return localizationModels;
                }
            }
            return null;
        }

        private static Dictionary<string, string> AddToLanguageValues(string languageKey, string value, Dictionary<string, string> existingCollection = null)
        {
            if (existingCollection == null)
            {
                existingCollection = new Dictionary<string, string>();
            }
            existingCollection.Add(languageKey, value);
            return existingCollection;
        }
    }
}
