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
    public class Track
    {

        public static string connectionString = "data source=localhost; Initial Catalog=Project; integrated security=true";

        public static int doTrack(int orderid)
        { 
            if (orderid ==-1 )
            {
                return -1;
            }

            int result = 0;

            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            SqlCommand cmd;

            try
            {

                cmd = new SqlCommand("track", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@orderid", SqlDbType.Int, 50).Value = orderid;
               
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