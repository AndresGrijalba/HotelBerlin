using BLL;
using Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;
using System.Windows;
using System;
using GUI.Pages;
using System.Collections.Generic;
namespace GUI
{
    /// <summary>
    /// Lógica de interacción para InformacionFWindow.xaml
    /// </summary>
    public partial class InformacionFWindow : Window
    {
        private FacturaBLL facturaBLL = new FacturaBLL();
        public Reserva ReservaSeleccionada { get; set; }
        public List<Reserva> Reservas { get; set; }

        public InformacionFWindow(Reserva reserva)
        {
            InitializeComponent();
            FechaActual.Text = DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("es-ES"));
            ReservaSeleccionada = reserva;
            DataContext = ReservaSeleccionada; 
        }

        private void AgregarFactura_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GenerarPDF(ReservaSeleccionada);
                facturaBLL.agregarFactura(ReservaSeleccionada);
                MessageBox.Show("Factura guardada y correo enviado exitosamente");

                btnFacturar.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void GenerarPDF(Reserva reserva)
        {
            string fileName = $"{reserva.Nombres[0]}{reserva.Apellidos[0]}{reserva.Cedula.Substring(0, 4)}.pdf";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            BaseColor customColor = new BaseColor(38, 101, 147);
            BaseColor grayBackground = new BaseColor(211, 211, 211);
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
            Font bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
            Font smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
            Font hotelFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, customColor);
            Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);

            Paragraph header = new Paragraph("Factura\n", titleFont);
            header.Alignment = Element.ALIGN_RIGHT;
            header.SpacingAfter = 10;
            doc.Add(header);

            DateTime fechaFactura = DateTime.Now;
            Paragraph facturaInfo = new Paragraph($"Numero de factura: {reserva.Id}\nFecha de la factura: {fechaFactura.ToString("dd MMMM yyyy", new CultureInfo("es-CO"))}\n\n\n", bodyFont);
            facturaInfo.Alignment = Element.ALIGN_RIGHT;
            doc.Add(facturaInfo);

            PdfPTable infoTable = new PdfPTable(2);
            infoTable.WidthPercentage = 100;
            infoTable.SetWidths(new float[] { 50f, 50f });

            PdfPCell hotelHeaderCell = new PdfPCell(new Paragraph("De", boldFont));
            hotelHeaderCell.BackgroundColor = grayBackground;
            hotelHeaderCell.Border = PdfPCell.NO_BORDER;
            infoTable.AddCell(hotelHeaderCell);

            PdfPCell clienteHeaderCell = new PdfPCell(new Paragraph("Facturar a", boldFont));
            clienteHeaderCell.BackgroundColor = grayBackground;
            clienteHeaderCell.Border = PdfPCell.NO_BORDER;
            infoTable.AddCell(clienteHeaderCell);

            PdfPCell hotelInfoCell = new PdfPCell();
            hotelInfoCell.Border = PdfPCell.NO_BORDER;
            hotelInfoCell.AddElement(new Paragraph("Hotel Berlin", bodyFont));
            hotelInfoCell.AddElement(new Paragraph("3023527935", bodyFont));
            hotelInfoCell.AddElement(new Paragraph("hotelberlinva@gmail.com", bodyFont));
            hotelInfoCell.AddElement(new Paragraph("Valledupar - Cesar, Colombia", bodyFont));
            infoTable.AddCell(hotelInfoCell);

            PdfPCell clienteInfoCell = new PdfPCell();
            clienteInfoCell.Border = PdfPCell.NO_BORDER;
            clienteInfoCell.AddElement(new Paragraph($"Cedula: {reserva.Cedula}", bodyFont));
            clienteInfoCell.AddElement(new Paragraph($"Nombres: {reserva.Nombres}", bodyFont));
            clienteInfoCell.AddElement(new Paragraph($"Apellidos: {reserva.Apellidos}", bodyFont));
            clienteInfoCell.AddElement(new Paragraph($"Correo: {reserva.Correo}", bodyFont));
            infoTable.AddCell(clienteInfoCell);

            doc.Add(infoTable);

            Paragraph detallesHeader = new Paragraph("Detalles de la Reserva", titleFont);
            detallesHeader.Alignment = Element.ALIGN_CENTER;
            detallesHeader.SpacingBefore = 80;
            doc.Add(detallesHeader);

            doc.Add(new Paragraph($"Tipo de habitación: {reserva.TipoHabitacion}", bodyFont) { Leading = 20 });
            doc.Add(new Paragraph($"N° Habitación: {reserva.NumeroHabitacion}", bodyFont) { Leading = 20 });
            doc.Add(new Paragraph($"Valor por noche: {reserva.ValorNoche.ToString("$#,###.00", new CultureInfo("es-CO"))}", bodyFont) { Leading = 20 });
            doc.Add(new Paragraph($"Fecha Inicio: {reserva.FechaInicio.ToString("d/M/yyyy", new CultureInfo("es-CO"))}", bodyFont) { Leading = 20 });
            doc.Add(new Paragraph($"Fecha Fin: {reserva.FechaFin.ToString("d/M/yyyy", new CultureInfo("es-CO"))}", bodyFont) { Leading = 20 });
            doc.Add(new Paragraph($"N° Noches: {reserva.CantidadNoches}", bodyFont) { Leading = 20 });

            Paragraph precioTotal = new Paragraph($"Precio Total: ................................................................... {reserva.PrecioTotal.ToString("$#,###.00", new CultureInfo("es-CO"))}", titleFont);
            precioTotal.SpacingBefore = 20;
            doc.Add(precioTotal);

            Paragraph agradecimiento = new Paragraph("Gracias por confiar en nosotros para su reserva.", smallFont) { Leading = 20 };
            Paragraph agradecimiento2 = new Paragraph("De parte del equipo de trabajo", smallFont) { Leading = 20 };
            Paragraph hotelinfo = new Paragraph("Hotel Berlin", hotelFont) { Leading = 20 };
            Paragraph hotelinfo2 = new Paragraph("Para más información, contacte con nuestro servicio al cliente.", smallFont) { Leading = 20 };
            agradecimiento.SpacingBefore = 140;
            agradecimiento.Alignment = Element.ALIGN_CENTER;
            agradecimiento2.Alignment = Element.ALIGN_CENTER;
            hotelinfo.Alignment = Element.ALIGN_CENTER;
            hotelinfo2.Alignment = Element.ALIGN_CENTER;
            doc.Add(agradecimiento);
            doc.Add(agradecimiento2);
            doc.Add(hotelinfo);
            doc.Add(hotelinfo2);

            doc.Close();

            MessageBox.Show($"PDF generado y guardado como: {fileName}");
        }
    }
}
