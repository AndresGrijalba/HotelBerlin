using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace GUI.Pages
{
    /// <summary>
    /// Lógica de interacción para Facturas.xaml
    /// </summary>
    public partial class Facturas : Page
    {
        public List<Factura> factura = null;
        FacturaBLL servicio = new FacturaBLL();
        private FacturaBLL facturaBLL = new FacturaBLL();

        public Facturas()
        {
            InitializeComponent();
            DataContext = this;
            factura = servicio.ObtenerFacturas();
            FacturasDataGrid.ItemsSource = factura;
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            List<Factura> facturas = facturaBLL.ObtenerFacturas();
            FacturasDataGrid.ItemsSource = facturas;
        }

        private void txtFiltro_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txtFiltro.Text.ToLower();

            var facturasFiltradas = factura.Where(factura => factura.Cedula.ToLower().Contains(filtro) ||
                                                               factura.Nombres.ToLower().Contains(filtro) ||
                                                               factura.Apellidos.ToLower().Contains(filtro) ||
                                                               factura.FechaEmision.ToLower().Contains(filtro));
            FacturasDataGrid.ItemsSource = facturasFiltradas;
        }

        public void VerPDF_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int facturaId = (int)button.Tag;

                var facturaSeleccionada = FacturasDataGrid.Items.Cast<Factura>().FirstOrDefault(f => f.Id == facturaId);
                if (facturaSeleccionada != null)
                {
                    string inicialNombre = facturaSeleccionada.Nombres.Substring(0, 1).ToUpper();
                    string apellido = facturaSeleccionada.Apellidos.Substring(0, 1).ToUpper();
                    string cedula = facturaSeleccionada.Cedula.Substring(0, 4);
                    string nombreArchivo = $"{inicialNombre}{apellido}{cedula}.pdf";
                    string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);

                    if (File.Exists(rutaArchivo))
                    {
                        try
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = rutaArchivo,
                                UseShellExecute = true
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al abrir el archivo PDF: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El archivo PDF no se encuentra en el escritorio.");
                    }
                }
            }
        }
    }
}
