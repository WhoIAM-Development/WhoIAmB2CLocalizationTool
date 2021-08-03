using B2CLocalizationTool.Service.Abstract;
using B2CLocalizationTool.Service.Extensions;
using B2CLocalizationTool.Service.Utility;
using B2CLocalizationTool.Shared;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.IO;
using System.Xml;

namespace B2CLocalizationTool.Service
{
    public class ExternalDataService: IExternalDataService
    {
        private readonly ILogger<ExternalDataService> _logger;
        private readonly AppSettings _appSettings;

        public ExternalDataService(ILogger<ExternalDataService> logger,
            IOptions<AppSettings> appSettings)
        {
            this._logger = logger;
            this._appSettings = appSettings.Value;
        }

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

        public string WriteToExcelOrCSV (XmlDocument document, string inputPath, string fileFormat, string outputPath = null)
        {
            if (fileFormat.ToLower().Trim() == "csv")
            {
                var csvString = document.ToCSVString();

                if (string.IsNullOrEmpty(csvString))
                {
                    throw new Exception("Could not create CSV string");
                }

                return ExcelCsvUtility.WriteCSVFile(csvString, inputPath, outputPath, _appSettings.OverwriteFiles);
            }
            else
            {
                // Do nothing for now
            }
            return null;
        }

        public string WriteStringToCSV(string csvString, string inputPath, string outputPath = null)
        {
            return ExcelCsvUtility.WriteCSVFile(csvString, inputPath, outputPath, _appSettings.OverwriteFiles);
        }

        public XmlDocument ReadXml(string fileName)
        {
            return XMLUtility.ReadXMLFile(fileName);
        }

        public string WriteXmlToFile(XmlDocument document, string inputPath = null, string outputPath = null)
        {
            return XMLUtility.WriteToXMLFile(document, inputPath, outputPath, _appSettings.OverwriteFiles);
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
