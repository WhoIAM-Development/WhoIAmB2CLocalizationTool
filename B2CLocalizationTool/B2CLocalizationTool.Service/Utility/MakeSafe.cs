using System;
using System.Data;

namespace B2CLocalizationTool.Service.Utility
{
    public static class MakeSafe
    {
        public static string ToSafeString(this DataRow row, string propName)
        {
            if (row.Table.Columns.Contains(propName) && row[propName] != null)
            {
                return row[propName].ToString();
            }
            return string.Empty;
        }

        public static bool? ToSafeNullableBool(this DataRow row, string propName)
        {
            if (row.Table.Columns.Contains(propName) && row[propName] != null)
            {
                bool result;
                Boolean.TryParse(row[propName].ToString(), out result);
                return result;
            }
            return null;
        }
    }
}
