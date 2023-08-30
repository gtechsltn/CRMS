using System.Data.SqlClient;

namespace CRMS.Models
{
    public static class SqlDataReaderExtensions
    {
        public static T SafeGet<T>(this SqlDataReader reader, int columnIndex)
        {
            return reader.IsDBNull(columnIndex) ? default : reader.GetFieldValue<T>(columnIndex);
        }

        public static T SafeGet<T>(this SqlDataReader reader, string columnName)
        {
            int columnIndex = reader.GetOrdinal(columnName);
            return reader.IsDBNull(columnIndex) ? default : reader.GetFieldValue<T>(columnIndex);
        }
    }
}