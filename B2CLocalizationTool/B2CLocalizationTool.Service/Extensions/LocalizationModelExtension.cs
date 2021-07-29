using B2CLocalizationTool.Service.Model;
using B2CLocalizationTool.Service.Utility;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace B2CLocalizationTool.Service.Extensions
{
    internal static class LocalizationModelExtension
    {
        internal static bool Validate(this IEnumerable<IGrouping<string, LocalizationInputModel>> localizationResources)
        {
            return true;
        }

        internal static IEnumerable<IGrouping<string, LocalizationInputModel>> ToLocalizationModel(this DataSet dataSet)
        {

            if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count > 0)
            {
                var list = new List<LocalizationInputModel>();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    for (int i = Constants.LanguageIndex; i < row.ItemArray.Length; i++)
                    {
                        var temp = row[Constants.ItemValue];

                        list.Add(new LocalizationInputModel
                        {
                            Resource = $"{row.ToSafeString(Constants.Resource)}.{row.Table.Columns[i]}",
                            ResourceType = row.ToSafeString(Constants.ResourceType),
                            ElementType = row.ToSafeString(Constants.ElementType),
                            ElementId = row.ToSafeString(Constants.ElementId),
                            StringId = row.ToSafeString(Constants.StringId),
                            TargetCollection = row.ToSafeString(Constants.TargetCollection),
                            ItemValue = row.ToSafeString(Constants.ItemValue),
                            LanguageValue = row.ItemArray[i].ToString()
                        });
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
            doc.InsertBefore(declaire, doc.DocumentElement);

            foreach (var resources in localizationResources)
            {
                XmlElement localizedResourcesNode = doc.CreateElement(Constants.LocalizedResources);
                localizedResourcesNode.SetAttribute(Constants.Id, resources.Key);

                XmlElement localizedStringsNode = doc.CreateElement(Constants.LocalizedStrings);
                XmlElement localizedCollectionsNode = doc.CreateElement(Constants.LocalizedCollections);

                foreach (var resource in resources)
                {
                    if (resource.ResourceType == Constants.LocalizedString)
                    {
                        if (string.IsNullOrEmpty(resource.LanguageValue))
                        {
                            continue;
                        }

                        XmlElement localizedStringElement = doc.CreateElement(Constants.LocalizedString);
                        if (!string.IsNullOrEmpty(resource.ElementType))
                            localizedStringElement.SetAttribute(Constants.ElementType, resource.ElementType);
                        if (!string.IsNullOrEmpty(resource.ElementId))
                            localizedStringElement.SetAttribute(Constants.ElementId, resource.ElementId);
                        if (!string.IsNullOrEmpty(resource.StringId))
                            localizedStringElement.SetAttribute(Constants.StringId, resource.StringId);
                        if (!string.IsNullOrEmpty(resource.LanguageValue))
                            localizedStringElement.InnerText = resource.LanguageValue;

                        localizedStringsNode.AppendChild(localizedStringElement);
                    } 
                    else if(resource.ResourceType == Constants.LocalizedCollections || resource.ResourceType == Constants.Collection)
                    {
                        XmlElement localizedCollectionNode = doc.CreateElement(Constants.LocalizedCollection);
                        if (!string.IsNullOrEmpty(resource.ElementType))
                            localizedCollectionNode.SetAttribute(Constants.ElementType, resource.ElementType);
                        if (!string.IsNullOrEmpty(resource.ElementId))
                            localizedCollectionNode.SetAttribute(Constants.ElementId, resource.ElementId);
                        if (!string.IsNullOrEmpty(resource.StringId))
                            localizedCollectionNode.SetAttribute(Constants.StringId, resource.StringId);
                        if (!string.IsNullOrEmpty(resource.TargetCollection))
                            localizedCollectionNode.SetAttribute(Constants.TargetCollection, resource.TargetCollection);

                        var childCollections = resources.Where(x => x.Resource == resource.Resource
                            && ( x.ResourceType == Constants.LocalizedCollection || x.ResourceType == Constants.CollectionValues )
                            && x.ElementId == resource.ElementId

                            // Optional -> this might not be set
                            //&& x.ElementType == resource.ElementType
                            //&& x.StringId == resource.StringId
                            //&& x.TargetCollection == resource.TargetCollection
                        );

                        foreach (var collectionValue in childCollections)
                        {
                            if (string.IsNullOrEmpty(collectionValue.LanguageValue))
                            {
                                continue;
                            }

                            XmlElement itemElement = doc.CreateElement(Constants.Item);

                            itemElement.SetAttribute(Constants.Text, collectionValue.LanguageValue);

                            if (!string.IsNullOrEmpty(collectionValue.ItemValue))
                                itemElement.SetAttribute(Constants.Value, collectionValue.ItemValue);

                            if (collectionValue.SelectByDefault.HasValue)
                            {
                                itemElement.SetAttribute(Constants.SelectByDefault, collectionValue.SelectByDefault.Value.ToString());
                            }

                            localizedCollectionNode.AppendChild(itemElement);
                        }
                        localizedCollectionsNode.AppendChild(localizedCollectionNode);
                    }
                }

                localizedResourcesNode.AppendChild(localizedStringsNode);
                localizedResourcesNode.AppendChild(localizedCollectionsNode);
                rootnode.AppendChild(localizedResourcesNode);
            }
            doc.AppendChild(rootnode);
            return doc;
        }


        // this method is quite bloated and very inefficient, needs to redo this.
        internal static string ToCSVString(this XmlDocument document)
        {
            if (document != null)
            {
                XmlNode lnode = document.SelectSingleNode(Constants.Localization);
                if (lnode != null && lnode.ChildNodes.Count > 0)
                {
                    var localizationModels = new List<LocalizationOutputModel>();
                    List<string> langauges = new List<string> { };
                    foreach (XmlNode xnode in lnode.ChildNodes)
                    {
                        var resourceId = xnode.Attributes[Constants.Id].Value;
                        var splitArray = resourceId.Split(".");
                        var resourceLanguage = splitArray.Last();

                        if (!langauges.Contains(resourceLanguage))
                        {
                            langauges.Add(resourceLanguage);
                        }

                        var resourceIdWithoutLanguage = string.Join(".", splitArray.SkipLast(1));

                        var localizedStrings = xnode.SelectSingleNode(Constants.LocalizedStrings);

                        foreach (XmlNode lsNode in localizedStrings.ChildNodes)
                        {
                            var existingLocalization = localizationModels.FirstOrDefault(x => x.Resource == resourceIdWithoutLanguage
                                && x.ElementType == lsNode.Attributes[Constants.ElementType]?.Value
                                && x.ElementId == lsNode.Attributes[Constants.ElementId]?.Value
                                && x.StringId == lsNode.Attributes[Constants.StringId]?.Value);
                            if (existingLocalization != null)
                            {
                                existingLocalization.LanguageValues = AddToLanguageValues(resourceLanguage, lsNode.InnerText, existingLocalization.LanguageValues);
                            }
                            else
                            {
                                localizationModels.Add(new LocalizationOutputModel()
                                {
                                    Resource = resourceIdWithoutLanguage,
                                    ElementType = lsNode.Attributes[Constants.ElementType]?.Value,
                                    ElementId = lsNode.Attributes[Constants.ElementId]?.Value,
                                    StringId = lsNode.Attributes[Constants.StringId]?.Value,
                                    LanguageValues = AddToLanguageValues(resourceLanguage, lsNode?.InnerText)
                                });
                            }
                        }
                    }

                    var csv = new StringBuilder();
                    var headerLine = $"{PreProcess(Constants.Resource)},{PreProcess(Constants.ElementType)},{PreProcess(Constants.ElementId)},{PreProcess(Constants.StringId)}";
                    foreach (var lang in langauges)
                    {
                        headerLine = $"{headerLine},{PreProcess(lang)}";
                    }
                    csv.AppendLine(headerLine);

                    foreach (var item in localizationModels)
                    {
                        var newLine = $"{PreProcess(item.Resource)},{PreProcess(item.ElementType)},{PreProcess(item.ElementId)},{PreProcess(item.StringId)}";

                        foreach (var lang in langauges)
                        {
                            if (item.LanguageValues.ContainsKey(lang))
                            {
                                newLine = $"{newLine},{PreProcess(item.LanguageValues[lang])}";
                            }
                            else
                            {
                                newLine = $"{newLine},{string.Empty}";
                            }
                        }
                        csv.AppendLine(newLine);
                    }
                    return csv.ToString();
                }
            }
            return null;
        }

        private static string PreProcess(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            input = input.Replace('ı', 'i')
                .Replace('ç', 'c')
                .Replace('ö', 'o')
                .Replace('ş', 's')
                .Replace('ü', 'u')
                .Replace('ğ', 'g')
                .Replace('İ', 'I')
                .Replace('Ç', 'C')
                .Replace('Ö', 'O')
                .Replace('Ş', 'S')
                .Replace('Ü', 'U')
                .Replace('Ğ', 'G')
                .Replace("\"", "\"\"")
                .Trim();
            if (input.Contains(","))
            {
                input = "\"" + input + "\"";
            }
            return input;
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
