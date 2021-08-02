namespace B2CLocalizationTool.Service.Abstract
{
    public interface ILocalizationService
    {
        IResultDTO ReadInputAndWriteToXml(string inputPath, string outputPath = null);
        IResultDTO ReadXmlAndWriteToExcel(string inputPath, string fileFormat, string outputPath = null);
        IResultDTO ReadInputAndWriteToJson(string inputPath, string outputFileNamePrefix, string outputPath = null);
        IResultDTO ReadJsonFilesAndWriteToExcel(string inputFiles, string outputPath = null);
    }
}
