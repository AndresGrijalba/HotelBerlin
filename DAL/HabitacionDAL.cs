using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HabitacionDAL
    {
        public void AgregarHabitacion(Habitacion habitacion)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO habitaciones (numero, estado, id_tipo)" +
                               "VALUES (@numero, @estado, @id_tipo)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numero", habitacion.Numero);
                    command.Parameters.AddWithValue("@id_tipo", habitacion.Id_Tipo);
                    command.Parameters.AddWithValue("@estado", habitacion.Disponibilidad);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Habitacion> ObtenerHabitaciones()
        {
            List<Habitacion> habitaciones = new List<Habitacion>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "select h.id, h.numero, h.estado, th.nombre as tipo_habitacion, th.precio_noche from habitaciones as h left join tipo_habitacion as th on th.id=h.id_tipo;";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Habitacion habitacion = new Habitacion
                            (
                                Convert.ToInt32(reader["id"]),
                                Convert.ToInt32(reader["numero"]),
                                Convert.ToString(reader["estado"]),
                                Convert.ToString(reader["tipo_habitacion"]),
                                float.Parse(reader["precio_noche"].ToString())
                            );

                            habitaciones.Add(habitacion);
                        }
                    }
                }
                connection.Close();
            }

            return habitaciones;
        }

        public Habitacion obtenerHabitacionPorId(string id)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM habitaciones WHERE id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Habitacion habitacion = new Habitacion
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Numero = Convert.ToInt32(reader["numero"]),
                                Id_Tipo = Convert.ToInt32(reader["id_tipo"])
                            };

                            habitacion.setDisponibilidad(reader["estado"].ToString());

                            return habitacion;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public bool actualizarHabitacion(Habitacion habitacion)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                bool tipoHabitacionExistente = false;
                string tipoHabitacionQuery = "SELECT COUNT(*) FROM tipo_habitacion WHERE id = @id_tipo";

                using (SqlCommand tipoHabitacionCommand = new SqlCommand(tipoHabitacionQuery, connection))
                {
                    tipoHabitacionCommand.Parameters.AddWithValue("@id_tipo", habitacion.Id_Tipo);
                    connection.Open();
                    int tipoHabitacionCount = (int)tipoHabitacionCommand.ExecuteScalar();
                    tipoHabitacionExistente = tipoHabitacionCount > 0;
                }

                if (!tipoHabitacionExistente)
                {
                    return false;
                }

                string query = "UPDATE habitaciones SET numero = @numero, estado = @estado, id_tipo = @id_tipo WHERE id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", habitacion.Id);
                    command.Parameters.AddWithValue("@numero", habitacion.Numero);
                    command.Parameters.AddWithValue("@estado", habitacion.Disponibilidad);
                    command.Parameters.AddWithValue("@id_tipo", habitacion.Id_Tipo);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool EliminarHabitacion(int id)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM habitaciones WHERE id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al eliminar la habitación: " + ex.Message);
                        return false;
                    }
                }
            }
        }

    }
}
