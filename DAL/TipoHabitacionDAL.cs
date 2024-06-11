using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class TipoHabitacionDAL
    {
        public List<TipoHabitacion> ObtenerTiposHabitacion()
        {
            List<TipoHabitacion> tiposHabitacion = new List<TipoHabitacion>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT id, nombre FROM tipo_habitacion";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TipoHabitacion tipo = new TipoHabitacion
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombre"].ToString()
                    };

                    tiposHabitacion.Add(tipo);
                }
                reader.Close();
            }
            return tiposHabitacion;
        }
    }
}
