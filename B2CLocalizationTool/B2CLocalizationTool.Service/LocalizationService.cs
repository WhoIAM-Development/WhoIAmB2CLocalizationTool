using B2CLocalizationTool.Service.Abstract;
using B2CLocalizationTool.Service.Extensions;
using B2CLocalizationTool.Service.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace B2CLocalizationTool.Service
{
    public class LocalizationService: ILocalizationService
    {
        private readonly IExternalDataService _externalDataService;
        private readonly ILogger<LocalizationService> _logger;

        public LocalizationService(IExternalDataService externalDataService, ILogger<LocalizationService> logger)
        {
            this._externalDataService = externalDataService;
            this._logger = logger;
        }

        public IResultDTO ReadInputAndWriteToXml(string inputPath, string outputPath = null)
        {
            try
            {
                _logger.LogInformation($"Converting Excel to XML from {inputPath} to {outputPath}");

                var dataSet = _externalDataService.ReadFileAsDataSet(inputPath);

                var result = dataSet.ToResultDTO();

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
                return new ResultDTO()
                {
                    IsSuccess = false
                };
            }
        }
    }
}
