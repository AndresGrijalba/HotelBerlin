using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BLL
{
    public class ReservaBLL
    {
        private ReservaDAL reservaDAL = new ReservaDAL();
        private ClienteDAL clienteDAL = new ClienteDAL();
  
 
        public string agregarReserva(Reserva reserva)
        {
            try
            {
                if (reserva == null || reserva.FechaInicio >= reserva.FechaFin)
                {
                    return "La fecha debe ser mayor a la inicial.";
                }

                reserva.CantidadNoches = reserva.CalcularCantidadNoches();
                reserva.PrecioTotal = reserva.CalcularPrecio();
                reservaDAL.agregarReserva(reserva);

                Cliente cliente = clienteDAL.ObtenerClientePorId(reserva.idCliente);
                if (cliente == null)
                {
                    return "Cliente no encontrado.";
                }

                EnviarCorreoReserva(cliente.Correo, reserva, cliente);

                return "Reserva agregada y correo enviado correctamente.";
            }
            catch (SqlException sqlEx)
            {
                return "Error al agregar la reserva (SQL): " + sqlEx.Message;
            }
            catch (SmtpException smtpEx)
            {
                return "Error al enviar el correo: " + smtpEx.Message;
            }
            catch (Exception ex)
            {
                return "Error al agregar la reserva: " + ex.Message;
            }
        }

        private void EnviarCorreoReserva(string emailCliente, Reserva reserva, Cliente cliente)
        {
            string html = $@"<!DOCTYPE html> <html> <head> <style> body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0; }} .container {{ width: 80%; margin: 20px auto; background-color: white; padding: 20px; border: 1px solid #ddd; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); }} .header {{ color: #266593; padding-bottom: 20px; border-bottom: 2px solid #266593; }} .content {{ padding: 20px 0; }} .content h2, .content label {{ margin: 20px 0; }} .footer {{ padding-top: 20px; border-top: 2px solid #266593; }} .footer label {{ display: block; margin: 10px 0; font-weight: bold; }} </style> </head> <body> <div class='container'> <div class='header'> <h1 style='color:#266593;'> Hey, {cliente.Nombre}</h1> </div> <div class='content'> <label style='color:black; font-size:1.5em;'>Hemos registrado tu reserva.</label> <h2 style='color:black;'>Desde el día: {reserva.FechaInicio.ToString("dd/MM/yyyy")}</h2> <h2 style='color:black;'>Hasta el día: {reserva.FechaFin.ToString("dd/MM/yyyy")}</h2> <label style='color:black;'>No olvides acercarte al hotel para confirmar tu reserva.</label> </div> <div class='footer'> <label style='color:black;'>De parte del equipo de trabajo</label> <label style='color:#266593;'>Hotel Berlin</label> </div> </div> </body> </html>";

            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            mail.From = new MailAddress("hotelberlinva@gmail.com", "Hotel Berlin");
            mail.To.Add(emailCliente);
            mail.Subject = "¡Hey! Hemos reservado tu habitación";

            AlternateView htmlview = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
            mail.AlternateViews.Add(htmlview);

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("hotelberlinva@gmail.com", "jpga frgj xsma nlnm");
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }

        public string ConfirmarReserva(string reservaId)
        {
            try
            {
                Reserva reserva = reservaDAL.ObtenerReservaPorId(reservaId);

                if (reserva == null)
                {
                    return "La reserva especificada no existe.";
                }

                if (reserva.EstadoReserva == "Cancelada")
                {
                    return "No se puede cancelar una reserva que ya ha sido cancelada.";
                }

                reserva.EstadoReserva = "Confirmada";
                reservaDAL.ActualizarReserva(reserva);

                return "Reserva confirmada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al confirmar la reserva: " + ex.Message;
            }
        }

        public string CancelarReserva(string reservaId)
        {
            try
            {
                Reserva reserva = reservaDAL.ObtenerReservaPorId(reservaId);

                if (reserva == null)
                {
                    return "La reserva especificada no existe.";
                }

                if (reserva.EstadoReserva == "Facturada" || reserva.EstadoReserva == "Cancelada")
                {
                    return "No se puede cancelar una reserva que ya ha sido facturada o cancelada.";
                }

                reserva.EstadoReserva = "Cancelada";
                reservaDAL.ActualizarReserva(reserva);

                return "Reserva cancelada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al cancelar la reserva: " + ex.Message;
            }
        }

        public List<Reserva> ObtenerReservas()
        {
            return reservaDAL.ObtenerReservas();
        }

        public List<Reserva> ObtenerReservasCanceladas()
        {
            return reservaDAL.ObtenerReservasCanceladas();
        }

        public List<Reserva> ObtenerReservasPendientes()
        {
            return reservaDAL.ObtenerReservasPendientes();
        }

        public List<Reserva> ObtenerReservasConfirmadas()
        {
            return reservaDAL.ObtenerReservasConfirmadas();
        }

        public Dictionary<string, int> ObtenerReservasPorPeriodo(string periodo)
        {
            return reservaDAL.ObtenerReservasPorPeriodo(periodo);
        }
    }
}
