using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace CovID19CalculatorNet.CommonTools
{
    public static class DataObject
    {
        private static string connectionString = "Persist Security Info=False;Data Source = covidsql19.database.windows.net,1433; Initial Catalog = COVID19Forecasts; User Id = mainuser;Password=#covid2019#";
        public static bool OpenSqlConnection()
        {
           using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                    Console.WriteLine("State: {0}", connection.State);
                    return true;                
                }
                catch
                {
                    return false;
                }
                
                
            }
        }        

        public static DataTable GetDataTable(string query)
        {
            try
            {
                // connection may be dormant, let's try to wake it up
                bool awake = OpenSqlConnection();
                if (!awake)
                {
                    //database is warming up;
                    Thread.Sleep(500);
                }

                string connString = connectionString;

                DataTable dataTable = new DataTable();

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                return dataTable;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

      


        public static void ReadSingleRow(IDataRecord record)
        {
            var email = record["email"];
            Console.WriteLine(String.Format("{0}", email));
        }
    }
}