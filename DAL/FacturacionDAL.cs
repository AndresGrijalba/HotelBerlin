using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FacturacionDAL
    {
        public void AgregarFactura(Facturacion facturacion)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string checkQuery = "SELECT COUNT(1) FROM reservas WHERE id = @id_reserva";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@id_reserva", facturacion.id_reserva);
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count == 0)
                    {
                        throw new ArgumentException("La reserva con el id especificado existe.");
                    }
                }

                string query = "insert into facturas (id_reserva, precio_noche, cantidad_noches, total, fecha_emision)" +
                    "values (@id_reserva, @precio_noche, @cantidad_noches, @total, @fecha_emision)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_reserva", facturacion.id_reserva);
                    command.Parameters.AddWithValue("@precio_noche", facturacion.valor_noche);
                    command.Parameters.AddWithValue("@cantidad_noches", facturacion.cantidad_noches);
                    command.Parameters.AddWithValue("@total", facturacion.total);
                    command.Parameters.AddWithValue("@fecha_emision", facturacion.fecha_emision);
                    command.ExecuteNonQuery();
                }

            }
        }

        public bool Id_Reserva(string id_reserva)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM facturas WHERE id_reserva = @id_reserva";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_reserva", id_reserva);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                
            }

            
        }
    }
}