using System.Data;
using System.Xml;

namespace B2CLocalizationTool.Service.Abstract
{
    public interface IExternalDataService
    {
        DataSet ReadFileAsDataSet(string path);
        string WriteXmlToFile(XmlDocument document, string outputPath = null);
    }
}
