using B2CLocalizationTool.Service.Abstract;
using B2CLocalizationTool.Service.Extensions;
using B2CLocalizationTool.Service.Model;
using B2CLocalizationTool.Service.Model.ToJSON;
using B2CLocalizationTool.Shared;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace B2CLocalizationTool.Service
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IExternalDataService _externalDataService;
        private readonly ILogger<LocalizationService> _logger;

        private readonly ToJsonSettings _toJsonSettings;
        private readonly AppSettings _appSettings;

        public LocalizationService(IExternalDataService externalDataService,
            ILogger<LocalizationService> logger,
            IOptions<ToJsonSettings> toJsonOptions,
            IOptions<AppSettings> appSettings)
        {
            this._externalDataService = externalDataService;
            this._logger = logger;
            this._toJsonSettings = toJsonOptions.Value;
            this._appSettings = appSettings.Value;
        }

        public IResultDTO ReadInputAndWriteToJson(string inputPath, string outputFileNamePrefix, string outputPath = null)
        {
            try
            {
                _logger.LogInformation($"Converting Excel to JSON from {inputPath} to {outputPath}");
                var dataSet = _externalDataService.ReadFileAsDataSet(inputPath);

                var result = dataSet.ToJsonResultDTO(_toJsonSettings);

                foreach (var warning in result.Warnings)
                {
                    _logger.LogWarning(warning);
                }

                foreach (var error in result.Errors)
                {
                    _logger.LogError(error);
                }

                // How are collections represented in JSON file? - Currently not considering them.

                if (result.IsSuccess)
                {
                    var localizationGropuedByResourceId = result.LocalizedStrings.GroupBy(x => x.Resource).ToList();

                    if (string.IsNullOrEmpty(outputFileNamePrefix))
                    {
                        outputFileNamePrefix = _toJsonSettings.FilePrefix;
                    }

                    string absoluteInputPath = Path.GetDirectoryName(inputPath);

                    if (string.IsNullOrEmpty(outputPath))
                    {
                        outputPath = absoluteInputPath;
                    }

                    if (_appSettings.OverwriteFiles)
                    {
                        outputPath = $"{outputPath}\\{outputFileNamePrefix}";
                    }
                    else
                    {
                        outputPath = $"{outputPath}\\{outputFileNamePrefix}_{DateTimeOffset.Now.ToUnixTimeSeconds()}";
                    }

                    Directory.CreateDirectory(outputPath);

                    foreach (IGrouping<string, LocalizedStringModel> item in localizationGropuedByResourceId)
                    {
                        var completeFileName = $"{outputPath}\\{outputFileNamePrefix}_{item.First().Resource}.json";

                        using (StreamWriter file = File.CreateText(completeFileName))
                        {
                            var data = new
                            {
                                LocalizedStrings = item
                            };

                            JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings() { Formatting = Formatting.Indented });
                            serializer.Serialize(file, data);
                        }

                        _logger.LogInformation($"Created JSON file from {inputPath} to {completeFileName}");
                    }

                    result.OutputPath = outputPath;
                }
                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResultDTO()
                {
                    IsSuccess = false
                };
            }
        }

        public IResultDTO ReadInputAndWriteToXml(string inputPath, string outputPath = null)
        {
            try
            {
                _logger.LogInformation($"Converting Excel to XML from {inputPath} to {outputPath}");

                var dataSet = _externalDataService.ReadFileAsDataSet(inputPath);

                var result = dataSet.ToXmlResultDTO();

                foreach (var warning in result.Warnings)
                {
                    _logger.LogWarning(warning);
                }

                foreach (var error in result.Errors)
                {
                    _logger.LogError(error);
                }

                if (result.IsSuccess)
                {
                    var localizationGropuedByResourceId = result.LocalizationResources.GroupBy(x => x.Resource).ToList();
                    var xmlDocument = localizationGropuedByResourceId.ToXml();
                    result.OutputPath = _externalDataService.WriteXmlToFile(xmlDocument, inputPath, outputPath);

                    _logger.LogInformation($"Completed converting Excel to XML from {inputPath} to {result.OutputPath}");
                }
                return result;
            }
            catch (Exception ex)
            {
                return new ResultDTO()
                {
                    IsSuccess = false
                };
            }
        }

        public IResultDTO ReadJsonFilesAndWriteToExcel(string inputFiles, string outputPath = null)
        {
            try
            {
                var localizedJsonList = new List<LocalizedJson>();
                string[] fileNames = inputFiles.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                var languages = new List<string>();


                foreach (var fileName in fileNames)
                {
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    var splitName = fileNameWithoutExtension.Split("_");

                    if(splitName.Length < 2)
                    {
                        continue;
                    }

                    var resource = splitName[splitName.Length - 2];
                    var languageCode = splitName[splitName.Length - 1];
                    languageCode = languageCode.Trim();
                    var match = Regex.Match(languageCode, "^[a-z]{2}(-[A-Z]{2})?$");

                    if (!match.Success)
                    {
                        continue;
                    }

                    if (!languages.Contains(languageCode))
                    {
                        languages.Add(languageCode);
                    }

                    using (System.IO.StreamReader file = System.IO.File.OpenText(fileName))
                    {
                        using (JsonTextReader reader = new JsonTextReader(file))
                        {
                            var model = new JsonSerializer().Deserialize<LocalizedJson>(reader);
                            model.Resource = resource;
                            model.LangaugeCode = languageCode;
                            localizedJsonList.Add(model);
                        }
                    }
                }

                if(languages.Count == 0)
                {
                    throw new Exception("No langauges could be found");
                }

                var csvString = localizedJsonList.MapLocalizedJSONToCSVString(languages);

                outputPath = _externalDataService.WriteStringToCSV(csvString, fileNames.First(), outputPath);
                return new ResultDTO
                {
                    IsSuccess = true,
                    OutputPath = outputPath
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResultDTO()
                {
                    IsSuccess = false
                };
            }
        }

        public IResultDTO ReadXmlAndWriteToExcel(string inputPath, string fileFormat, string outputPath = null)
        {
            try
            {
                var document = _externalDataService.ReadXml(inputPath);
                outputPath = _externalDataService.WriteToExcelOrCSV(document, inputPath, fileFormat, outputPath);
                return new ResultDTO
                {
                    IsSuccess = true,
                    OutputPath = outputPath
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResultDTO()
                {
                    IsSuccess = false
                };
            }
        }

    }
}
