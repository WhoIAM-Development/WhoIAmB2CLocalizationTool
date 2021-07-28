using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Text;

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

        internal static string WriteCSVFile(string input, string inputPath, string outputPath = null)
        {
            var outputFileName = Path.GetFileNameWithoutExtension(inputPath);
            if (string.IsNullOrEmpty(outputPath))
            {
                outputPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            var completeFileName = $"{outputPath}\\{outputFileName}{DateTimeOffset.Now.ToUnixTimeSeconds()}.csv";

            File.WriteAllText(completeFileName, input, Encoding.UTF8);

            return completeFileName;
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
