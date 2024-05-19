using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    };

                    tiposHabitacion.Add(tipo);
                }

                reader.Close();
            }

            return tiposHabitacion;
        }
    }
}
