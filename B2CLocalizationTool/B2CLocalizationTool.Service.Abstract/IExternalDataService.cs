using System.Data;
using System.Xml;

namespace B2CLocalizationTool.Service.Abstract
{
    public interface IExternalDataService
    {
        DataSet ReadFileAsDataSet(string path);
        string WriteXmlToFile(XmlDocument document, string inputPath = null, string outputPath = null);
        XmlDocument ReadXml(string fileName);
        string WriteToExcelOrCSV(XmlDocument input,  string inputPath, string fileFormat, string outputPath = null);
        string WriteStringToCSV(string csvString, string inputPath, string outputPath = null);
    }
}
