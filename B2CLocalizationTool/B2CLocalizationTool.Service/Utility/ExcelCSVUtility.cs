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
                return null;
            }
        }
    }
}
