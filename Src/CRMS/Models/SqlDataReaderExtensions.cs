using System;
using System.Data;
using System.Data.SqlClient;

namespace CRMS.Models
{
    public static class SqlDataReaderExtensions
    {
        public static T GetSafe<T>(this SqlDataReader reader, int columnIndex)
        {
            return reader.IsDBNull(columnIndex) ? default : reader.GetFieldValue<T>(columnIndex);
        }

        public static T GetSafe<T>(this SqlDataReader reader, string columnName)
        {
            int columnIndex = reader.GetOrdinal(columnName);
            return reader.IsDBNull(columnIndex) ? default : reader.GetFieldValue<T>(columnIndex);
        }

        public static void SetDBNullValue(this SqlCommand cmd)
        {
            foreach (IDataParameter param in cmd.Parameters)
            {
                if (param.Value == null)
                {
                    param.Value = DBNull.Value;
                }
                if (param.Value == (object)DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
            }
        }
    }
}