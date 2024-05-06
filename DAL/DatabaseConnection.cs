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
        private static string connectionString = @"Data Source=Lenovo\SQLEXPRESS;Initial Catalog=USUARIOS;user Id=soporte;Password=1234";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
