using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Lógica de interacción para InformacionFWindow.xaml
    /// </summary>
    public partial class InformacionFWindow : Window
    {
        private FacturaBLL facturaBLL = new FacturaBLL();
        public Reserva ReservaSeleccionada { get; set; }

        public InformacionFWindow(Reserva reserva)
        {
            InitializeComponent();
            FechaActual.Text = DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("es-ES"));
            ReservaSeleccionada = reserva;
            DataContext = ReservaSeleccionada; 
        }

        private void AgregarFactura_Click(object sender, RoutedEventArgs e)
        {
            facturaBLL.agregarFactura(ReservaSeleccionada);
            MessageBox.Show("Factura guardada exitosamente");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
