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
                string query = "INSERT INTO clientes (nombres, apellidos, cedula, correo, telefono)" +
                               "VALUES (@nombres, @apellidos, @cedula, @correo, @telefono)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombres", cliente.Nombre);
                    command.Parameters.AddWithValue("@apellidos", cliente.Apellido);
                    command.Parameters.AddWithValue("@cedula", cliente.Cedula);
                    command.Parameters.AddWithValue("@correo", cliente.Correo);
                    command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool CedulaExiste(string cedula)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM clientes WHERE cedula = @cedula";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cedula", cedula);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public Cliente ObtenerClientePorCedula(string cedula)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM clientes WHERE cedula = @cedula";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cedula", cedula);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Cedula = reader["Cedula"].ToString(),
                                Nombre = reader["Nombres"].ToString(),
                                Apellido = reader["Apellidos"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "UPDATE clientes SET nombres = @nombres, apellidos = @apellidos, correo = @correo, telefono = @telefono WHERE cedula = @cedula";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                    command.Parameters.AddWithValue("@Nombres", cliente.Nombre);
                    command.Parameters.AddWithValue("@Apellidos", cliente.Apellido);
                    command.Parameters.AddWithValue("@Correo", cliente.Correo);
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool EliminarCliente(string cedula)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection()) 
            {
                string query = "DELETE FROM clientes WHERE cedula = @cedula";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cedula", cedula);
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
                string query = "SELECT * FROM clientes";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                Nombre = reader["Nombres"].ToString(),
                                Apellido = reader["Apellidos"].ToString(),
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

        public List<Cliente> BuscarClientesPorCedula(string cedula)
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM clientes WHERE cedula LIKE '%' + @cedula + '%'";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cedula", cedula);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                Nombre = reader["Nombres"].ToString(),
                                Apellido = reader["Apellidos"].ToString(),
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
