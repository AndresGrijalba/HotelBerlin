﻿using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FacturaDAL
    {
        public void agregarFactura(Reserva reserva)
        {
            string query = "INSERT INTO facturas (id_reserva, precio_noche, cantidad_noches, total, fecha_emision)" +
                           "VALUES (@id_reserva, @precio_noche, @cantidad_noches, @total, @fecha_emision)";

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                SqlCommand command = setParamsToSaveFactura(query, connection, reserva);

                using (command)
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private SqlCommand setParamsToSaveFactura(string query, SqlConnection connection, Reserva reserva)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_reserva", reserva.Id);
            command.Parameters.AddWithValue("@precio_noche", reserva.ValorNoche);
            command.Parameters.AddWithValue("@cantidad_noches", reserva.CantidadNoches);
            command.Parameters.AddWithValue("@total", reserva.PrecioTotal);
            command.Parameters.AddWithValue("@fecha_emision", DateTime.Now);

            return command;
        }

        public List<Factura> ObtenerFacturas()
        {
            List<Factura> facturas = new List<Factura>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "select r.id as idr, c.nombres, c.apellidos, c.cedula, f.id, f.total, f.fecha_emision from facturas as f left join reservas as r on r.id = f.id_reserva left join clientes as c on c.id = r.id_cliente";

                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Factura factura = new Factura
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Cedula = reader["cedula"].ToString(),
                                Nombres = reader["nombres"].ToString(),
                                Apellidos = reader["apellidos"].ToString(),
                                IdReserva = Convert.ToInt32(reader["idr"].ToString()),
                                FechaEmision = reader["fecha_emision"].ToString(),
                                PrecioTotal = Convert.ToDouble(reader["total"])

                            };

                            facturas.Add(factura);
                        }
                    }
                }
                connection.Close();
            }

            return facturas;
        }
    }
}