using B2CLocalizationTool.Service.Abstract;
using B2CLocalizationTool.Service.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;

namespace B2CLocalizationTool.Service
{
    public class ExternalDataService: IExternalDataService
    {
        public DataSet ReadFileAsDataSet(string fileName)
        {
            var pathExtension = Path.GetExtension(fileName);
            switch (pathExtension.ToLower())
            {
                case ".xls":
                case ".xlsx":
                case ".xlsm": return ReadFullExcelFile(fileName);
                case ".csv": return ReadFullCsvFile(fileName);
                default: throw new Exception("Input file cannot be parsed because it is not in an expected format.");
            }
        }

        public string WriteToExcelOrCSV (IEnumerable<object> input, string fileFormat, string outputPath = null)
        {
            if (fileFormat.ToLower().Trim() == "csv")
            {
                return ExcelCsvUtility.WriteCSVFile(input, outputPath);
            }
            else
            {
                // Do nothing for now
            }
            return null;
        }

        public XmlDocument ReadXml(string fileName)
        {
            return XMLUtility.ReadXMLFile(fileName);
        }


        public string WriteXmlToFile(XmlDocument document, string outputPath = null)
        {
            return XMLUtility.WriteToXMLFile(document, outputPath);
        }

        private DataSet ReadFullExcelFile(string path)
        {
            return ExcelCsvUtility.ReadExcelFile(path);
        }

        private DataSet ReadFullCsvFile(string path)
        {
            return ExcelCsvUtility.ReadCsvFile(path);
        }
    }
}
