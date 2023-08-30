using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CRMS.Models
{
    public static class CustomerDao
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static int Customer_Insert(CustomerModel customerModel)
        {
            int RETURN_VALUE = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Customer_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Name"].Value = customerModel.Name ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@PhoneNumber"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@PhoneNumber"].Value = customerModel.PhoneNumber ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@Gender", SqlDbType.Bit, 0);
                    cmd.Parameters["@Gender"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Gender"].Value = customerModel.Gender ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@CCCD", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@CCCD"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@CCCD"].Value = customerModel.CCCD ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 250);
                    cmd.Parameters["@Address"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Address"].Value = customerModel.Address ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@DoB", SqlDbType.DateTime, 0);
                    cmd.Parameters["@DoB"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@DoB"].Value = customerModel.DoB ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@YoB", SqlDbType.SmallInt, 0);
                    cmd.Parameters["@YoB"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@YoB"].Value = customerModel.YoB ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Email"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Email"].Value = customerModel.Email ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@Facebook", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Facebook"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Facebook"].Value = customerModel.Facebook ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@Hobbies", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Hobbies"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Hobbies"].Value = customerModel.Hobbies ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@Note", SqlDbType.NVarChar, -1);
                    cmd.Parameters["@Note"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Note"].Value = customerModel.Note ?? (object)DBNull.Value;

                    cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int, 0);
                    cmd.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters["@RETURN_VALUE"].Value = RETURN_VALUE;

                    cmd.ExecuteNonQuery();

                    RETURN_VALUE = (int)cmd.Parameters["@RETURN_VALUE"].Value;
                }
            }

            return RETURN_VALUE;
        }

        public static List<CustomerModel> GetAll()
        {
            var lst = new List<CustomerModel>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Customer_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new CustomerModel();
                            item.Id = reader.SafeGet<Int32>(0);
                            item.Name = reader.SafeGet<string>(1);
                            item.PhoneNumber = reader.SafeGet<string>(2);
                            item.Gender = reader.SafeGet<bool?>(3);
                            item.CCCD = reader.SafeGet<string>(4);
                            item.Address = reader.SafeGet<string>(5);
                            item.DoB = reader.SafeGet<DateTime?>(6);
                            item.YoB = reader.SafeGet<short?>(7);
                            item.Email = reader.SafeGet<string>(8);
                            item.Facebook = reader.SafeGet<string>(9);
                            item.Hobbies = reader.SafeGet<string>(10);
                            item.Note = reader.SafeGet<string>(11);
                            lst.Add(item);
                        }
                    }
                }
            }
            return lst;
        }
    }
}