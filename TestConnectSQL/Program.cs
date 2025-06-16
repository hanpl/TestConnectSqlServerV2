using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnectSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            Console.WriteLine("ConnectionString = "+connectionString);
            TestSqlConnection(connectionString);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void TestSqlConnection(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("\nSuccessfully connected to SQL Server!");
                    }
                    else
                    {
                        Console.WriteLine("\nFailed to establish connection to SQL Server.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error while connecting to SQL Server:");
                Console.WriteLine(ex.Message);
            }
        }
    }
    
}
