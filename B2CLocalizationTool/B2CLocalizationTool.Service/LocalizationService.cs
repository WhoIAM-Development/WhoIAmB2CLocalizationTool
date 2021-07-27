using B2CLocalizationTool.Service.Abstract;
using B2CLocalizationTool.Service.Extensions;

namespace B2CLocalizationTool.Service
{
    public class LocalizationService: ILocalizationService
    {
        private readonly IExternalDataService _externalDataService;

        public LocalizationService(IExternalDataService externalDataService)
        {
            this._externalDataService = externalDataService;
        }

        public string ReadInputAndWriteToXml(string inputPath, string outputPath = null)
        {
            var dataSet = _externalDataService.ReadFileAsDataSet(inputPath);
            var model = dataSet.ToLocalizationModel();
            return _externalDataService.WriteXmlToFile(model.ToXml(), inputPath, outputPath);
        }

        public string ReadXmlAndWriteToExcel(string inputPath, string fileFormat, string outputPath = null)
        {

            var document = _externalDataService.ReadXml(inputPath);
            var model = document.ToLocalizationModels();

            return _externalDataService.WriteToExcelOrCSV(model, fileFormat, outputPath);
        }
    }
}
