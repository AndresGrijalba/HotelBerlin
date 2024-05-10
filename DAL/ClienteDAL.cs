using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAL
    {
        public void AgregarCliente(Cliente cliente)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Table_Usuarios (Nombre, Apellido, Cedula, Correo, Telefono)" +
                               "VALUES (@Nombre, @Apellido, @Cedula, @Correo, @Telefono)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    command.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                    command.Parameters.AddWithValue("@Correo", cliente.Correo);
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool EliminarCliente(string cedula)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection()) 
            {
                string query = "DELETE FROM Table_Usuarios WHERE Cedula = @Cedula";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cedula", cedula);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Error al eliminar el cliente: " + ex.Message);
                        return false;

                    }
                    


                }

            }
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Table_Usuarios";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Cedula = reader["Cedula"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            };

                            clientes.Add(cliente);
                        }
                    }
                }
                connection.Close();
            }
            
            return clientes;
        }
    }
}
