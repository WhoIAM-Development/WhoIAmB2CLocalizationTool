using CsvHelper;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;

namespace B2CLocalizationTool.Service.Utility
{
    internal static class ExcelCsvUtility
    {
        internal static DataSet ReadExcelFile(string fileName)
        {
            using var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            return ReadFile(reader);
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

        internal static string WriteCSVFile(IEnumerable<object> input, string outputPath = null)
        {
            if (string.IsNullOrEmpty(outputPath))
            {
                outputPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            var completeFileName = $"{outputPath}\\Localization{DateTimeOffset.Now.ToUnixTimeSeconds()}.csv";
            using (var writer = new StreamWriter(completeFileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(input);
            }
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
