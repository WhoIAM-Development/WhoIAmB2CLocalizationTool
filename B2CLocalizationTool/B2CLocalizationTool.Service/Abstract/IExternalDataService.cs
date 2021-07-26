using System.Data;

namespace B2CLocalizationTool.Service.Abstract
{
    public interface IExternalDataService
    {
        string ReadFullExcelFile(string FileName);
    }
}
