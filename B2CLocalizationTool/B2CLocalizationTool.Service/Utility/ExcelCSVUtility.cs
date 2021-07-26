using ExcelDataReader;
using System;
using System.Data;
using System.IO;

namespace B2CLocalizationTool.Service.Utility
{
    internal static class ExcelCsvUtility
    {
        internal static DataSet ReadExcelFile(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    return ReadFile(reader);
                }
            }
        }

        internal static DataSet ReadCsvFile(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                var config = new ExcelReaderConfiguration();
                config.AnalyzeInitialCsvRows = 500;
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    var fileData = ReadFile(reader);
                    return fileData;
                }

            }
        }

        private static DataSet ReadFile(IExcelDataReader reader)
        {
            try
            {
                return reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
