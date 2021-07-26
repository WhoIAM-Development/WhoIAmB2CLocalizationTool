using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace B2CLocalizationTool.Service.Extensions
{
    public static class DatatableExtension
    {
        public static List<T> ConvertDataTable<T>(this DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    var cName = dt.Rows[0][column.ColumnName].ToString();
                    if (!dt.Columns.Contains(cName) && cName != "")
                    {
                        column.ColumnName = cName;
                    }
                }

                dt.Rows[0].Delete();
                dt.AcceptChanges();
            }

            var data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                var item = GetItem<T>(row);
                data.Add(item);
            }

            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            var temp = typeof(T);
            var tempProperties = temp.GetProperties();
            var obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                var pro = tempProperties.FirstOrDefault(x => x.Name == column.ColumnName);

                if (pro != null)
                {
                    pro.SetValue(obj, dr[column.ColumnName], null);
                }
            }

            return obj;
        }
    }
}
