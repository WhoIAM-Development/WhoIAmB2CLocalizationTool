using B2CLocalizationTool.Service.Abstract;
using B2CLocalizationTool.Service.Utility;
using System.Data;
using B2CLocalizationTool.Service;

namespace B2CLocalizationTool.Service
{
    public class ExternalDataService: IExternalDataService
    {
        public string ReadFullExcelFile(string FileName)
        {
            // Move this to a different class.
            var dataSet = ExcelCsvUtility.ReadExcelFile(FileName);
            var model = dataSet.ToLocalizationInputModel();
            var groupedList = model.ToLocalizationModel();


            return XMLUtility.WriteToXMLFile(groupedList);
        }
    }
}
