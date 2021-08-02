using B2CLocalizationTool.Service.Model;
using B2CLocalizationTool.Service.Model.ToJSON;
using B2CLocalizationTool.Service.Utility;
using B2CLocalizationTool.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace B2CLocalizationTool.Service.Extensions
{
    public static class ToJSONModelExtensions
    {
        // issuccess defaults to true for now
        internal static ResultDTO ToJsonResultDTO(this DataSet dataSet, ToJsonSettings toJsonOptions)
        {
            var errors = new List<string>();
            var warnings = new List<string>();

            var resultDTO = new ResultDTO
            {
                IsSuccess = true,
            };

            if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count > 0)
            {
                var localizedStringsList = new List<LocalizedStringModel>();

                var minLanguageIndex = toJsonOptions.LanguageSchema.OrderBy(x => x.Index).FirstOrDefault().ModifiedValueIndex;
                var defaultValueIndexes = toJsonOptions.LanguageSchema.Where(x => x.IsDefaultValue);

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var rowNumber = dataSet.Tables[0].Rows.IndexOf(row) + 2;

                    // skip for now
                    if (row.ToSafeString(Constants.ResourceType) != Constants.LocalizedString)
                    {
                        continue;
                    }

                    var tempModel = new LocalizedStringModel
                    {
                        ElementType = row.ToSafeString(Constants.ElementType),
                        ElementId = row.ToSafeString(Constants.ElementId),
                        StringId = row.ToSafeString(Constants.StringId),
                    };

                    // Resource missing -> Serious error -> Should be skipped may be a new group called skipped?

                    if (string.IsNullOrEmpty(row.ToSafeString(Constants.Resource)))
                    {
                        errors.Add($"Empty Resource value found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }


                    // Localized strings

                    if (string.IsNullOrEmpty(tempModel.ElementType))
                    {
                        warnings.Add($"Empty ElementType found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    if (string.IsNullOrEmpty(tempModel.StringId))
                    {
                        warnings.Add($"Empty StringId found at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                    }

                    foreach (var item in defaultValueIndexes)
                    {
                        bool overrideFlag;
                        var modifiedValue = row.ItemArray[item.ModifiedValueIndex].ToString();
                        var defaultValue = row.ItemArray[item.Index].ToString();

                        var languageValue = string.Empty;

                        if (string.IsNullOrEmpty(modifiedValue) && string.IsNullOrEmpty(defaultValue))
                        {
                            warnings.Add($"Empty language value found for language {row.Table.Columns[item.ModifiedValueIndex]} at Row : {rowNumber}, Data: {JsonConvert.SerializeObject(tempModel)}");
                            overrideFlag = false;
                        }
                        else if (string.IsNullOrEmpty(modifiedValue) && !(string.IsNullOrEmpty(defaultValue)))
                        {
                            overrideFlag = false;
                            languageValue = defaultValue;
                        }
                        else if (modifiedValue == defaultValue)
                        {
                            overrideFlag = false;
                            languageValue = defaultValue;
                        }
                        else
                        {
                            overrideFlag = true;
                            languageValue = modifiedValue;
                        }

                        if (toJsonOptions.WriteOnlyModifiedValues && !overrideFlag)
                        {
                            continue;
                        }


                        var model = new LocalizedStringModel
                        {
                            Resource = $"{row.ToSafeString(Constants.Resource)}.{row.Table.Columns[item.ModifiedValueIndex]}",
                            ElementType = tempModel.ElementType,
                            ElementId = tempModel.ElementId,
                            StringId = tempModel.StringId,
                            Override = overrideFlag,
                            Value = languageValue,
                        };

                        localizedStringsList.Add(model);
                    }
                }

                resultDTO.LocalizedStrings = localizedStringsList;

                resultDTO.Errors = errors;
                resultDTO.Warnings = warnings;
            }

            return resultDTO;
        }
    }
}
