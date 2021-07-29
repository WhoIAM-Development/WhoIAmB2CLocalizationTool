namespace B2CLocalizationTool.Service.Abstract
{
    public interface ILocalizationService
    {
        IResultDTO ReadInputAndWriteToXml(string inputPath, string outputPath = null);
        string ReadXmlAndWriteToExcel(string inputPath, string fileFormat, string outputPath = null);
    }
}
