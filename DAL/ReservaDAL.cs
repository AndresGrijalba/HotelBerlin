using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReservaDAL
    {
        public void agregarReserva(Reserva reserva)
        {
            string query = "INSERT INTO reservas (id_cliente, id_habitacion, fecha_inicio, fecha_fin, cantidad_noches, precio_total, fecha_registro)" +
                           "VALUES (@id_cliente, @id_habitacion, @fecha_inicio, @fecha_fin, @cantidad_noches, @precio_total, @fecha_registro)";

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                SqlCommand command = setParamsToSave(query, connection, reserva);

                using (command) { command.ExecuteNonQuery(); }
            }
        }

        private SqlCommand setParamsToSave(string query, SqlConnection connection, Reserva reserva)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_cliente", reserva.idCliente);
            command.Parameters.AddWithValue("@id_habitacion", reserva.idHabitacion);
            command.Parameters.AddWithValue("@fecha_inicio", reserva.FechaInicio);
            command.Parameters.AddWithValue("@fecha_fin", reserva.FechaFin);
            command.Parameters.AddWithValue("@cantidad_noches", reserva.CantidadNoches);
            command.Parameters.AddWithValue("@precio_total", reserva.PrecioTotal);
            command.Parameters.AddWithValue("@fecha_registro", reserva.FechaRegistro);

            return command;
        }

        public List<Reserva> ObtenerReservas()
        {
            List<Reserva> reservas = new List<Reserva>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "select c.nombres, c.apellidos, c.cedula, r.fecha_inicio, r.fecha_fin, r.cantidad_noches, r.precio_total, r.fecha_registro, h.numero, th.nombre from reservas as r left join clientes as c on c.id = r.id_cliente left join habitaciones as h on h.id = r.id_habitacion left join tipo_habitacion as th on th.id = h.id_tipo";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reserva reserva = new Reserva
                            (
                                reader["nombres"].ToString(),
                                reader["apellidos"].ToString(),
                                reader["cedula"].ToString(),
                                Convert.ToDateTime(reader["fecha_inicio"]),
                                Convert.ToDateTime(reader["fecha_fin"]),
                                Convert.ToInt32(reader["cantidad_noches"]),
                                Convert.ToDouble(reader["precio_total"]),
                                reader["numero"].ToString(),
                                Convert.ToDateTime(reader["fecha_registro"].ToString()),
                                reader["nombre"].ToString()
                            );

                            reservas.Add(reserva);
                        }
                    }
                }
                connection.Close();
            }

            return reservas;
        }
    }
}
