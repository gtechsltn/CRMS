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

        public static int Customer_Insert(CustomerModel customer)
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
                    cmd.Parameters["@Name"].Value = customer.Name;

                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@PhoneNumber"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@PhoneNumber"].Value = customer.PhoneNumber;

                    cmd.Parameters.Add("@Gender", SqlDbType.Bit, 0);
                    cmd.Parameters["@Gender"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Gender"].Value = customer.Gender;

                    cmd.Parameters.Add("@CCCD", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@CCCD"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@CCCD"].Value = customer.CCCD;

                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 250);
                    cmd.Parameters["@Address"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Address"].Value = customer.Address;

                    cmd.Parameters.Add("@DoB", SqlDbType.DateTime, 0);
                    cmd.Parameters["@DoB"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@DoB"].Value = customer.DoB;

                    cmd.Parameters.Add("@YoB", SqlDbType.SmallInt, 0);
                    cmd.Parameters["@YoB"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@YoB"].Value = customer.YoB;

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Email"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Email"].Value = customer.Email;

                    cmd.Parameters.Add("@Facebook", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Facebook"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Facebook"].Value = customer.Facebook;

                    cmd.Parameters.Add("@Hobbies", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Hobbies"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Hobbies"].Value = customer.Hobbies;

                    cmd.Parameters.Add("@Note", SqlDbType.NVarChar, -1);
                    cmd.Parameters["@Note"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Note"].Value = customer.Note;

                    cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int, 0);
                    cmd.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters["@RETURN_VALUE"].Value = RETURN_VALUE;

                    cmd.SetDBNullValue();

                    cmd.ExecuteNonQuery();

                    RETURN_VALUE = (int)cmd.Parameters["@RETURN_VALUE"].Value;
                }
            }

            return RETURN_VALUE;
        }

        public static int Customer_Update(CustomerModel customer)
        {
            int RETURN_VALUE = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Customer_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int, 0);
                    cmd.Parameters["@Id"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Id"].Value = customer.Id;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Name"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Name"].Value = customer.Name;

                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@PhoneNumber"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@PhoneNumber"].Value = customer.PhoneNumber;

                    cmd.Parameters.Add("@Gender", SqlDbType.Bit, 0);
                    cmd.Parameters["@Gender"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Gender"].Value = customer.Gender;

                    cmd.Parameters.Add("@CCCD", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@CCCD"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@CCCD"].Value = customer.CCCD;

                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 250);
                    cmd.Parameters["@Address"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Address"].Value = customer.Address;

                    cmd.Parameters.Add("@DoB", SqlDbType.DateTime, 0);
                    cmd.Parameters["@DoB"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@DoB"].Value = customer.DoB;

                    cmd.Parameters.Add("@YoB", SqlDbType.SmallInt, 0);
                    cmd.Parameters["@YoB"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@YoB"].Value = customer.YoB;

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Email"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Email"].Value = customer.Email;

                    cmd.Parameters.Add("@Facebook", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Facebook"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Facebook"].Value = customer.Facebook;

                    cmd.Parameters.Add("@Hobbies", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Hobbies"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Hobbies"].Value = customer.Hobbies;

                    cmd.Parameters.Add("@Note", SqlDbType.NVarChar, -1);
                    cmd.Parameters["@Note"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Note"].Value = customer.Note;

                    cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int, 0);
                    cmd.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters["@RETURN_VALUE"].Value = RETURN_VALUE;

                    cmd.SetDBNullValue();

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
                            item.Id = reader.GetSafe<Int32>(0);
                            item.Name = reader.GetSafe<string>(1);
                            item.PhoneNumber = reader.GetSafe<string>(2);
                            item.Gender = reader.GetSafe<bool?>(3);
                            item.CCCD = reader.GetSafe<string>(4);
                            item.Address = reader.GetSafe<string>(5);
                            item.DoB = reader.GetSafe<DateTime?>(6);
                            item.YoB = reader.GetSafe<short?>(7);
                            item.Email = reader.GetSafe<string>(8);
                            item.Facebook = reader.GetSafe<string>(9);
                            item.Hobbies = reader.GetSafe<string>(10);
                            item.Note = reader.GetSafe<string>(11);
                            lst.Add(item);
                        }
                    }
                }
            }
            return lst;
        }

        public static CustomerModel GetById(int id)
        {
            CustomerModel item = null;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Customer_Select", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            item = new CustomerModel();

                            while (reader.Read())
                            {
                                item.Id = reader.GetSafe<Int32>("Id");
                                item.Name = reader.GetSafe<string>("Name");
                                item.PhoneNumber = reader.GetSafe<string>("PhoneNumber");
                                item.Gender = reader.GetSafe<bool?>("Gender");
                                item.CCCD = reader.GetSafe<string>("CCCD");
                                item.Address = reader.GetSafe<string>("Address");
                                item.DoB = reader.GetSafe<DateTime?>("DoB");
                                item.YoB = reader.GetSafe<short?>("YoB");
                                item.Email = reader.GetSafe<string>("Email");
                                item.Facebook = reader.GetSafe<string>("Facebook");
                                item.Hobbies = reader.GetSafe<string>("Hobbies");
                                item.Note = reader.GetSafe<string>("Note");
                            }
                        }
                    }
                }
            }
            return item;
        }

        public static int Customer_Delete(int id)
        {
            int RETURN_VALUE = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Customer_Delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Id", SqlDbType.Int, 0);
                    cmd.Parameters["@Id"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@Id"].Value = id;

                    cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int, 0);
                    cmd.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters["@RETURN_VALUE"].Value = RETURN_VALUE;

                    cmd.ExecuteNonQuery();

                    RETURN_VALUE = (int)cmd.Parameters["@RETURN_VALUE"].Value;
                }
            }

            return RETURN_VALUE;
        }
    }
}