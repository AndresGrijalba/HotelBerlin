using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseConnection
    {
        //private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=HotelBerlinDB;
        private static string connectionString = "Server=.\\SQLEXPRESS;Database=prueba;Trusted_Connection=True";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            return connection;
        }
    }
}
