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
    }
}
