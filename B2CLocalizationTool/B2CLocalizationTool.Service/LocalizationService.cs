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
            return _externalDataService.WriteXmlToFile(model.ToXml(), outputPath);
        }
    }
}
