using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReservaDAL
    {
        //public void agregarReserva(Reserva reserva)
        //{
        //    using (SqlConnection connection = DatabaseConnection.GetConnection())
        //    {
        //        connection.Open();
        //        string query = "INSERT INTO reservas (cedula, id_habitacion, fecha_inicio, fecha_fin, cantidad_noches, precio_total)" +
        //                       "VALUES (cedula, @id_habitacion, @fecha_inicio, @fecha_fin, @cantidad_noches, @precio_total)";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@cedula", reserva.idCliente);
        //            command.Parameters.AddWithValue("@id_habitacion", reserva.idHabitacion);
        //            command.Parameters.AddWithValue("@fecha_inicio", reserva.fechaInicio);
        //            command.Parameters.AddWithValue("@fecha_fin", reserva.fechaFin);
        //            command.Parameters.AddWithValue("@cantidad_noches", reserva.cantidadNoches);
        //            command.Parameters.AddWithValue("@precio_total", reserva.precioTotal);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        public void agregarReserva(Reserva reserva)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO reservas (id_cliente, id_habitacion, fecha_inicio, fecha_fin, cantidad_noches)" +
                               "VALUES (@id_cliente, @id_habitacion, @fecha_inicio, @fecha_fin, @cantidad_noches)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_cliente", reserva.idCliente);
                    command.Parameters.AddWithValue("@id_habitacion", reserva.idHabitacion);
                    command.Parameters.AddWithValue("@fecha_inicio", reserva.fechaInicio);
                    command.Parameters.AddWithValue("@fecha_fin", reserva.fechaFin);
                    command.Parameters.AddWithValue("@cantidad_noches", reserva.cantidadNoches);
                    command.ExecuteNonQuery();
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
                                Cedula = reader["Cedula"].ToString()
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
