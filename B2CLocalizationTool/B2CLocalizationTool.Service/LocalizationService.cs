using B2CLocalizationTool.Service.Abstract;
using B2CLocalizationTool.Service.Extensions;
using B2CLocalizationTool.Service.Model;
using System;

namespace B2CLocalizationTool.Service
{
    public class LocalizationService: ILocalizationService
    {
        private readonly IExternalDataService _externalDataService;

        public LocalizationService(IExternalDataService externalDataService)
        {
            this._externalDataService = externalDataService;
        }

        public IResultDTO ReadInputAndWriteToXml(string inputPath, string outputPath = null)
        {
            try
            {
                var dataSet = _externalDataService.ReadFileAsDataSet(inputPath);
                var model = dataSet.ToLocalizationModel();
                IResultDTO result = new ResultDTO { IsSuccess = true };
                if (result.IsSuccess)
                {
                    result.OutputPath = _externalDataService.WriteXmlToFile(model.ToXml(), inputPath, outputPath);
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

        public string ReadXmlAndWriteToExcel(string inputPath, string fileFormat, string outputPath = null)
        {
            var document = _externalDataService.ReadXml(inputPath);
            return _externalDataService.WriteToExcelOrCSV(document, inputPath, fileFormat, outputPath);
        }
    }
}
