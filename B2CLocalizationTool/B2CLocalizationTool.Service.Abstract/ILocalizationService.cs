namespace B2CLocalizationTool.Service.Abstract
{
    public interface ILocalizationService
    {
        string ReadInputAndWriteToXml(string inputPath, string outputPath = null);
    }
}
