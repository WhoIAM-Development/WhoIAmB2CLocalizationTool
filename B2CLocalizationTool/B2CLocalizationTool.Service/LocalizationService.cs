using B2CLocalizationTool.Service.Abstract;
using B2CLocalizationTool.Service.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace B2CLocalizationTool.Service
{
    public class LocalizationService: ILocalizationService
    {
         
    }

    internal static class ModelExtensions
    {
        internal static IEnumerable<LocalizationInputModel> ToLocalizationInputModel(this DataSet dataSet)
        {

            if (dataSet != null && dataSet.Tables != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows != null && dataSet.Tables[0].Rows.Count > 0)
            {
                var list = new List<LocalizationInputModel>();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    for (int i = 4; i < row.ItemArray.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(row.ItemArray[i].ToString()))
                        {
                            var model = new LocalizationInputModel();
                            model.Resource = $"{row.ItemArray[0]}.{row.Table.Columns[i]}";
                            model.ElementType = row.ItemArray[1].ToString();
                            model.ElementId = row.ItemArray[2].ToString();
                            model.StringId = row.ItemArray[3].ToString();
                            model.Value = row.ItemArray[i].ToString();

                            list.Add(model);
                        }
                    }
                }
                return list;
            }
            return null;
        }


        internal static IEnumerable<IGrouping<string, LocalizationInputModel>> ToLocalizationModel(this IEnumerable<LocalizationInputModel> input)
        {
             return input.GroupBy(x => x.Resource).ToList();
        }
    }
}
