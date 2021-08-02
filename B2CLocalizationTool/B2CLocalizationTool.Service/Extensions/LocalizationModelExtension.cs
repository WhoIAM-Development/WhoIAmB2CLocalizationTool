using B2CLocalizationTool.Service.Model;
using B2CLocalizationTool.Service.Model.ToJSON;
using B2CLocalizationTool.Service.Utility;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace B2CLocalizationTool.Service.Extensions
{
    internal static class LocalizationModelExtension
    {
        // issuccess defaults to true for now
        internal static ResultDTO ToXmlResultDTO(this DataSet dataSet)
        {
            var errors = new List<string>();
            var warnings = new List<string>();

            var resultDTO = new ResultDTO
            {
                IsSuccess = true,
            };

            if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count > 0)
            {
                var list = new List<LocalizationInputModel>();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var rowNumber = dataSet.Tables[0].Rows.IndexOf(row) + 2;

                    var tempModel = new LocalizationInputModel
                    {
                        ResourceType = row.ToSafeString(Constants.ResourceType),
                        ElementType = row.ToSafeString(Constants.ElementType),
                        ElementId = row.ToSafeString(Constants.ElementId),
                        StringId = row.ToSafeString(Constants.StringId),
                        TargetCollection = row.ToSafeString(Constants.TargetCollection),
                        ItemValue = row.ToSafeString(Constants.ItemValue),
                        SelectByDefault = row.ToSafeNullableBool(Constants.SelectByDefault)
                    };


                    // Resource missing -> Serious error -> Should be skipped may be a new group called skipped?

                    if (string.IsNullOrEmpty(row.ToSafeString(Constants.Resource)))
                    {
                        errors.Add($"Empty Resource value found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    //Validations

                    if (string.IsNullOrEmpty(tempModel.ResourceType))
                    {
                        warnings.Add($"Empty ResourceType found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    // Localized strings

                    if (tempModel.ResourceType == Constants.LocalizedString && string.IsNullOrEmpty(tempModel.ElementType))
                    {
                        warnings.Add($"Empty ElementType found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    if (tempModel.ResourceType == Constants.LocalizedString && string.IsNullOrEmpty(tempModel.StringId))
                    {
                        warnings.Add($"Empty StringId found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    // Localized Collections

                    if (tempModel.ResourceType == Constants.Collection && string.IsNullOrEmpty(tempModel.TargetCollection))
                    {
                        warnings.Add($"Empty TargetCollection found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    if (tempModel.ResourceType == Constants.Collection && string.IsNullOrEmpty(tempModel.ElementType))
                    {
                        warnings.Add($"Empty ElementType found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    if (tempModel.ResourceType == Constants.Collection && string.IsNullOrEmpty(tempModel.ElementId))
                    {
                        warnings.Add($"Empty ElementId found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    if (tempModel.ResourceType == Constants.Collection && string.IsNullOrEmpty(tempModel.ElementType))
                    {
                        warnings.Add($"Empty ElementType found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    // Localized Collection
                    if (tempModel.ResourceType == Constants.CollectionValues && string.IsNullOrEmpty(tempModel.ElementId))
                    {
                        warnings.Add($"Empty ElementId found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    if (tempModel.ResourceType == Constants.CollectionValues && string.IsNullOrEmpty(tempModel.ItemValue))
                    {
                        warnings.Add($"Empty ItemValue found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    if (tempModel.ResourceType == Constants.CollectionValues && string.IsNullOrEmpty(tempModel.TargetCollection))
                    {
                        warnings.Add($"Empty TargetCollection found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    for (int i = Constants.LanguageIndex; i < row.ItemArray.Length; i++)
                    {
                        var model = new LocalizationInputModel
                        {
                            Resource = $"{row.ToSafeString(Constants.Resource)}.{row.Table.Columns[i]}",
                            ResourceType = row.ToSafeString(Constants.ResourceType),
                            ElementType = row.ToSafeString(Constants.ElementType),
                            ElementId = row.ToSafeString(Constants.ElementId),
                            StringId = row.ToSafeString(Constants.StringId),
                            TargetCollection = row.ToSafeString(Constants.TargetCollection),
                            ItemValue = row.ToSafeString(Constants.ItemValue),
                            LanguageValue = row.ItemArray[i].ToString(),
                            SelectByDefault = row.ToSafeNullableBool(Constants.SelectByDefault)
                        };

                        //// Resource missing

                        //if (string.IsNullOrEmpty(row.ToSafeString(Constants.Resource)))
                        //{
                        //    warnings.Add($"Empty Resource value found for language {row.Table.Columns[i]} at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(model)}");
                        //}

                        // Langauge missing - it will be empty for LocalizedCollections

                        if (string.IsNullOrEmpty(model.LanguageValue) && (model.ResourceType != Constants.Collection))
                        {
                            warnings.Add($"Empty language value found for language {row.Table.Columns[i]} at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(model)}");
                        }

                        list.Add(model);
                    }
                }

                resultDTO.LocalizationResources = list;
                resultDTO.Errors = errors;
                resultDTO.Warnings = warnings;
            }

            return resultDTO;
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
                    else if (resource.ResourceType == Constants.Collection)
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
                            && (x.ResourceType == Constants.CollectionValues)
                            && x.ElementId == resource.ElementId
                            && x.TargetCollection == resource.TargetCollection

                            // Optional -> this might not be set
                            //&& x.ElementType == resource.ElementType
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
                                itemElement.SetAttribute(Constants.SelectByDefault, collectionValue.SelectByDefault.Value.ToString().ToLower());
                            }

                            localizedCollectionNode.AppendChild(itemElement);
                        }
                        localizedCollectionsNode.AppendChild(localizedCollectionNode);
                    }
                }

                // Seems like collections should come before strings
                if (localizedCollectionsNode.ChildNodes.Count > 0)
                {
                    localizedResourcesNode.AppendChild(localizedCollectionsNode);
                }

                if (localizedStringsNode.ChildNodes.Count > 0)
                {
                    localizedResourcesNode.AppendChild(localizedStringsNode);
                }

                if (localizedResourcesNode.ChildNodes.Count > 0)
                {
                    rootnode.AppendChild(localizedResourcesNode);
                }
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
                    List<string> languages = new List<string> { };
                    foreach (XmlNode xnode in lnode.SelectNodes(Constants.LocalizedResources))
                    {
                        var resourceId = xnode.Attributes[Constants.Id].Value;
                        var splitArray = resourceId.Split(".");
                        var resourceLanguage = splitArray.Last();

                        if (!languages.Contains(resourceLanguage))
                        {
                            languages.Add(resourceLanguage);
                        }

                        var resourceIdWithoutLanguage = string.Join(".", splitArray.SkipLast(1));

                        var localziedCollections = xnode.SelectSingleNode(Constants.LocalizedCollections);

                        if(localziedCollections != null)
                        {
                            foreach (XmlNode lcNode in localziedCollections.ChildNodes)
                            {
                                var existingCollection = localizationModels.FirstOrDefault(x => x.Resource == resourceIdWithoutLanguage
                                    && x.ResourceType == Constants.Collection
                                    && x.ElementType == lcNode.Attributes[Constants.ElementType]?.Value
                                    && x.ElementId == lcNode.Attributes[Constants.ElementId]?.Value
                                    && x.TargetCollection == lcNode.Attributes[Constants.TargetCollection]?.Value);

                                // if it already exists -> no need to add again

                                if (existingCollection == null)
                                {
                                    localizationModels.Add(new LocalizationOutputModel()
                                    {
                                        Resource = resourceIdWithoutLanguage,
                                        ResourceType = Constants.Collection,
                                        ElementType = lcNode.Attributes[Constants.ElementType]?.Value,
                                        ElementId = lcNode.Attributes[Constants.ElementId]?.Value,
                                        TargetCollection = lcNode.Attributes[Constants.TargetCollection]?.Value,
                                    });
                                }

                                // Map collectionValues 
                                foreach (XmlElement itemElement in lcNode.ChildNodes)
                                {
                                    var exisistingCollectionValue = localizationModels.FirstOrDefault(x => x.Resource == resourceIdWithoutLanguage
                                        && x.ResourceType == Constants.CollectionValues
                                        && x.ElementId == lcNode.Attributes[Constants.ElementId]?.Value
                                        && x.TargetCollection == lcNode.Attributes[Constants.TargetCollection]?.Value
                                        && x.ItemValue == itemElement.Attributes[Constants.Value]?.Value);

                                    if(exisistingCollectionValue == null)
                                    {
                                        localizationModels.Add(new LocalizationOutputModel()
                                        {
                                            Resource = resourceIdWithoutLanguage,
                                            ResourceType = Constants.CollectionValues,
                                            ElementId = lcNode.Attributes[Constants.ElementId]?.Value,
                                            TargetCollection = lcNode.Attributes[Constants.TargetCollection]?.Value,
                                            ItemValue = itemElement.Attributes[Constants.Value]?.Value,
                                            SelectByDefault = itemElement.Attributes[Constants.SelectByDefault]?.Value,
                                            LanguageValues = AddToLanguageValues(resourceLanguage, itemElement.Attributes[Constants.Text]?.Value),
                                        });
                                    }
                                    else
                                    {
                                        exisistingCollectionValue.LanguageValues = AddToLanguageValues(resourceLanguage, itemElement.Attributes[Constants.Text]?.Value, exisistingCollectionValue.LanguageValues);
                                    }
                                }
                            }
                        }

                        var localizedStrings = xnode.SelectSingleNode(Constants.LocalizedStrings);
                        if (localizedStrings != null)
                        {
                            foreach (XmlNode lsNode in localizedStrings.ChildNodes)
                            {
                                var existingLocalization = localizationModels.FirstOrDefault(x => x.Resource == resourceIdWithoutLanguage
                                    && x.ResourceType == Constants.LocalizedString
                                    && x.ElementType == lsNode.Attributes[Constants.ElementType]?.Value
                                    && x.ElementId == lsNode.Attributes[Constants.ElementId]?.Value
                                    && x.StringId == lsNode.Attributes[Constants.StringId]?.Value);
                                if (existingLocalization == null)
                                {
                                    localizationModels.Add(new LocalizationOutputModel()
                                    {
                                        Resource = resourceIdWithoutLanguage,
                                        ResourceType = Constants.LocalizedString,
                                        ElementType = lsNode.Attributes[Constants.ElementType]?.Value,
                                        ElementId = lsNode.Attributes[Constants.ElementId]?.Value,
                                        StringId = lsNode.Attributes[Constants.StringId]?.Value,
                                        LanguageValues = AddToLanguageValues(resourceLanguage, lsNode?.InnerText)
                                    });
                                }
                                else
                                {
                                    existingLocalization.LanguageValues = AddToLanguageValues(resourceLanguage, lsNode.InnerText, existingLocalization.LanguageValues);
                                }
                            }
                        }
                    }

                    return MapLocalizationModelsToCSVString(localizationModels, languages);
                }
            }
            return null;
        }

        internal static string MapLocalizedJSONToCSVString(this List<LocalizedJson> localizedJsons, List<string> languages)
        {
            List<LocalizationOutputModel> localizationModels = new List<LocalizationOutputModel>();
            foreach (var localizedJson in localizedJsons)
            {
                foreach (var localizedString in localizedJson.LocalizedStrings)
                {
                    var existingLocalization = localizationModels.FirstOrDefault(x => x.Resource == localizedJson.Resource
                               //&& x.ResourceType == Constants.LocalizedString
                               && x.ElementType == localizedString.ElementType
                               && x.ElementId == localizedString.ElementId
                               && x.StringId == localizedString.StringId);

                    if (existingLocalization == null)
                    {
                        localizationModels.Add(new LocalizationOutputModel()
                        {
                            Resource = localizedJson.Resource,
                            ResourceType = Constants.LocalizedString,
                            ElementType = localizedString.ElementType,
                            ElementId = localizedString.ElementId,
                            StringId = localizedString.StringId,
                            LanguageValues = AddToLanguageValues(localizedJson.LangaugeCode, localizedString.Value)
                        });
                    }
                    else
                    {
                        existingLocalization.LanguageValues = AddToLanguageValues(localizedJson.LangaugeCode, localizedString.Value, existingLocalization.LanguageValues);
                    }
                }
            }
            return MapLocalizationModelsToCSVString(localizationModels, languages);
        }

        internal static string MapLocalizationModelsToCSVString(List<LocalizationOutputModel> localizationModels, List<string> langauges)
        {
            var csv = new StringBuilder();
            var headerLine =
                $"{PreProcess(Constants.Resource)}," +
                $"{PreProcess(Constants.ResourceType)}," +
                $"{PreProcess(Constants.ElementType)}," +
                $"{PreProcess(Constants.ElementId)}," +
                $"{PreProcess(Constants.StringId)}," +
                $"{PreProcess(Constants.TargetCollection)}," +
                $"{PreProcess(Constants.ItemValue)}," +
                $"{PreProcess(Constants.SelectByDefault)}";

            foreach (var lang in langauges)
            {
                headerLine = $"{headerLine},{PreProcess(lang)}";
            }
            csv.AppendLine(headerLine);

            foreach (var item in localizationModels)
            {
                var newLine =
                    $"{PreProcess(item.Resource)}," +
                    $"{PreProcess(item.ResourceType)}," +
                    $"{PreProcess(item.ElementType)}," +
                    $"{PreProcess(item.ElementId)}," +
                    $"{PreProcess(item.StringId)}," +
                    $"{PreProcess(item.TargetCollection)}," +
                    $"{PreProcess(item.ItemValue)}," +
                    $"{PreProcess(item.SelectByDefault)}";

                foreach (var lang in langauges)
                {
                    if (item.LanguageValues != null && item.LanguageValues.ContainsKey(lang))
                    {
                        newLine = $"{newLine},{PreProcess(item.LanguageValues[lang], trim: false)}";
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

        private static string PreProcess(string input, bool trim = true)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            input = input.Replace("\"", "\"\"");

            if (input.Contains(","))
            {
                input = "\"" + input + "\"";
            }

            if (trim)
            {
                input = input.Trim();
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
