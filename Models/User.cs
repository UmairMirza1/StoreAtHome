using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Helpers;
namespace temp2.Models
{
    public class User
    {
        public static string connectionString = "data source=localhost; Initial Catalog=Project; integrated security=true";

        public static int signUp(string email, string password, string type)
        {
            if (email.Length == 0 || password.Length == 0 || type.Length == 0)
            {
                return -1;
            }

            int result = 0;

            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            SqlCommand cmd;

            try
            {

                cmd = new SqlCommand("signup", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 200).Value = password;
                cmd.Parameters.Add("@type", SqlDbType.VarChar, 100).Value = type;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;
            }
            finally
            {
                con.Close();
            }

            return result;
        }
    }
}