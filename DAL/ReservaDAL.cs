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
            string query = "INSERT INTO reservas (id_cliente, id_habitacion, fecha_inicio, fecha_fin, cantidad_noches, precio_total, fecha_registro, estado_reserva)" +
                           "VALUES (@id_cliente, @id_habitacion, @fecha_inicio, @fecha_fin, @cantidad_noches, @precio_total, @fecha_registro, @estado_reserva)";

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
            command.Parameters.AddWithValue("@estado_reserva", reserva.EstadoReserva);

            return command;
        }

        public List<Reserva> ObtenerReservas()
        {
            List<Reserva> reservas = new List<Reserva>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT c.nombres, c.apellidos, c.cedula, c.correo, r.id, r.fecha_inicio, r.fecha_fin, r.cantidad_noches, r.precio_total, r.fecha_registro, r.estado_reserva, h.numero, th.nombre, th.precio_noche FROM reservas AS r LEFT JOIN clientes AS c ON c.id = r.id_cliente LEFT JOIN habitaciones AS h ON h.id = r.id_habitacion LEFT JOIN tipo_habitacion AS th ON th.id = h.id_tipo ORDER BY CASE WHEN r.estado_reserva = 'Cancelada' THEN 1 ELSE 0 END, r.estado_reserva";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reserva reserva = new Reserva
                            (
                                Convert.ToInt32(reader["id"]),
                                reader["nombres"].ToString(),
                                reader["apellidos"].ToString(),
                                reader["cedula"].ToString(),
                                reader["correo"].ToString(),
                                Convert.ToDateTime(reader["fecha_inicio"]),
                                Convert.ToDateTime(reader["fecha_fin"]),
                                Convert.ToInt32(reader["cantidad_noches"]),
                                Convert.ToDouble(reader["precio_total"]),
                                reader["numero"].ToString(),
                                Convert.ToDateTime(reader["fecha_registro"].ToString()),
                                reader["nombre"].ToString(),
                                Convert.ToDouble(reader["precio_noche"]),
                                reader["estado_reserva"].ToString()
                                );

                            reservas.Add(reserva);
                        }
                    }
                }
                connection.Close();
            }

            return reservas;
        }

        public List<Reserva> ObtenerReservasCanceladas()
        {
            List<Reserva> reservas = new List<Reserva>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "select c.nombres, c.apellidos, c.cedula, c.correo, r.id, r.fecha_inicio, r.fecha_fin, r.cantidad_noches, r.precio_total, r.fecha_registro, r.estado_reserva, h.numero, th.nombre, th.precio_noche from reservas as r left join clientes as c on c.id = r.id_cliente left join habitaciones as h on h.id = r.id_habitacion left join tipo_habitacion as th on th.id = h.id_tipo where r.estado_reserva = 'Cancelada'";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reserva reserva = new Reserva
                            (
                                Convert.ToInt32(reader["id"]),
                                reader["nombres"].ToString(),
                                reader["apellidos"].ToString(),
                                reader["cedula"].ToString(),
                                reader["correo"].ToString(),
                                Convert.ToDateTime(reader["fecha_inicio"]),
                                Convert.ToDateTime(reader["fecha_fin"]),
                                Convert.ToInt32(reader["cantidad_noches"]),
                                Convert.ToDouble(reader["precio_total"]),
                                reader["numero"].ToString(),
                                Convert.ToDateTime(reader["fecha_registro"].ToString()),
                                reader["nombre"].ToString(),
                                Convert.ToDouble(reader["precio_noche"]),
                                reader["estado_reserva"].ToString()
                                );

                            reservas.Add(reserva);
                        }
                    }
                }
                connection.Close();
            }

            return reservas;
        }

        public List<Reserva> ObtenerReservasPendientes()
        {
            List<Reserva> reservas = new List<Reserva>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "select c.nombres, c.apellidos, c.cedula, c.correo, r.id, r.fecha_inicio, r.fecha_fin, r.cantidad_noches, r.precio_total, r.fecha_registro, r.estado_reserva, h.numero, th.nombre, th.precio_noche from reservas as r left join clientes as c on c.id = r.id_cliente left join habitaciones as h on h.id = r.id_habitacion left join tipo_habitacion as th on th.id = h.id_tipo where r.estado_reserva = 'Pendiente'";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reserva reserva = new Reserva
                            (
                                Convert.ToInt32(reader["id"]),
                                reader["nombres"].ToString(),
                                reader["apellidos"].ToString(),
                                reader["cedula"].ToString(),
                                reader["correo"].ToString(),
                                Convert.ToDateTime(reader["fecha_inicio"]),
                                Convert.ToDateTime(reader["fecha_fin"]),
                                Convert.ToInt32(reader["cantidad_noches"]),
                                Convert.ToDouble(reader["precio_total"]),
                                reader["numero"].ToString(),
                                Convert.ToDateTime(reader["fecha_registro"].ToString()),
                                reader["nombre"].ToString(),
                                Convert.ToDouble(reader["precio_noche"]),
                                reader["estado_reserva"].ToString()
                                );

                            reservas.Add(reserva);
                        }
                    }
                }
                connection.Close();
            }

            return reservas;
        }

        public List<Reserva> ObtenerReservasConfirmadas()
        {
            List<Reserva> reservas = new List<Reserva>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "select c.nombres, c.apellidos, c.cedula, c.correo, r.id, r.fecha_inicio, r.fecha_fin, r.cantidad_noches, r.precio_total, r.fecha_registro, r.estado_reserva, h.numero, th.nombre, th.precio_noche from reservas as r left join clientes as c on c.id = r.id_cliente left join habitaciones as h on h.id = r.id_habitacion left join tipo_habitacion as th on th.id = h.id_tipo where r.estado_reserva = 'Confirmada'";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reserva reserva = new Reserva
                            (
                                Convert.ToInt32(reader["id"]),
                                reader["nombres"].ToString(),
                                reader["apellidos"].ToString(),
                                reader["cedula"].ToString(),
                                reader["correo"].ToString(),
                                Convert.ToDateTime(reader["fecha_inicio"]),
                                Convert.ToDateTime(reader["fecha_fin"]),
                                Convert.ToInt32(reader["cantidad_noches"]),
                                Convert.ToDouble(reader["precio_total"]),
                                reader["numero"].ToString(),
                                Convert.ToDateTime(reader["fecha_registro"].ToString()),
                                reader["nombre"].ToString(),
                                Convert.ToDouble(reader["precio_noche"]),
                                reader["estado_reserva"].ToString()
                                );

                            reservas.Add(reserva);
                        }
                    }
                }
                connection.Close();
            }

            return reservas;
        }

        public Reserva ObtenerReservaPorId(string id)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM reservas WHERE id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Reserva reserva = new Reserva
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                EstadoReserva = reader["estado_reserva"].ToString()
                            };
                            return reserva;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void ActualizarReserva(Reserva reserva)
        {
            string query = "UPDATE reservas SET estado_reserva = @estado_reserva WHERE id = @id";

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@estado_reserva", reserva.EstadoReserva);
                    command.Parameters.AddWithValue("@id", reserva.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Dictionary<string, int> ObtenerReservasPorPeriodo(string periodo)
        {
            Dictionary<string, int> reservasPorPeriodo = new Dictionary<string, int>();
            string query = "";

            switch (periodo)
            {
                case "Día":
                    query = @"
                    SELECT 
                        FORMAT(fecha_inicio, 'yyyy-MM-dd') AS Periodo,
                        COUNT(*) AS TotalReservas
                    FROM reservas
                    GROUP BY FORMAT(fecha_inicio, 'yyyy-MM-dd')
                    ORDER BY Periodo";
                    break;
                case "Mes":
                    query = @"
                    SELECT 
                        FORMAT(fecha_inicio, 'yyyy-MM') AS Periodo,
                        COUNT(*) AS TotalReservas
                    FROM reservas
                    GROUP BY FORMAT(fecha_inicio, 'yyyy-MM')
                    ORDER BY Periodo";
                    break;
                case "Año":
                    query = @"
                    SELECT 
                        FORMAT(fecha_inicio, 'yyyy') AS Periodo,
                        COUNT(*) AS TotalReservas
                    FROM reservas
                    GROUP BY FORMAT(fecha_inicio, 'yyyy')
                    ORDER BY Periodo";
                    break;
            }

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string periodoClave = reader["Periodo"].ToString();
                            int totalReservas = Convert.ToInt32(reader["TotalReservas"]);

                            reservasPorPeriodo[periodoClave] = totalReservas;
                        }
                    }
                }
            }

            return reservasPorPeriodo;
        }
    }
}
