using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using DAL;
using Entity;
using System.IO;

namespace BLL
{
    public class FacturaBLL
    {
        private FacturaDAL facturaDAL = new FacturaDAL();

        public void agregarFactura(Reserva reserva)
        {
            facturaDAL.agregarFactura(reserva);
            EnviarCorreoFactura(reserva.Correo, reserva);
        }

        public void EnviarCorreoFactura(string emailCliente, Reserva reserva)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            mail.From = new MailAddress("hotelberlinva@gmail.com", "Hotel Berlin");
            mail.To.Add(emailCliente);
            mail.Subject = "¡Hey! Hemos reservado tu habitación";

            
            string html = $"Estimado {reserva.Nombres}, <br/><br/>Tu reserva ha sido confirmada. Adjunto encontrarás la factura de tu reserva.";
            AlternateView htmlview = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html); 
            mail.AlternateViews.Add(htmlview);

            string fileName = $"{reserva.Nombres[0]}{reserva.Apellidos[0]}{reserva.Cedula.Substring(0, 4)}.pdf";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);


            Attachment attachment = new Attachment(filePath);
            mail.Attachments.Add(attachment);

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("hotelberlinva@gmail.com", "jpga frgj xsma nlnm");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

        public List<Factura> ObtenerFacturas()
        {
            return facturaDAL.ObtenerFacturas();
        }

        public double ObtenerTotalFacturas()
        {
            return facturaDAL.ObtenerTotalFacturas();
        }
    }
}
