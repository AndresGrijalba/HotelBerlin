using BLL;
using Entity;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace GUI.Pages
{
    /// <summary>
    /// Lógica de interacción para Reservas.xaml
    /// </summary>
    public partial class Reservas : Page
    {
        public List<Reserva> reserva = null;
        ReservaBLL servicio = new ReservaBLL();

        public Reservas()
        {
            InitializeComponent();
            DataContext = this;
            reserva = servicio.ObtenerReservas();
            ReservasDataGrid.ItemsSource = reserva;
        }

        private void AgregarReserva_Click(object sender, RoutedEventArgs e)
        {
            Window reservasWindow = Window.GetWindow(this);
            AgregarRWindow revWindow = new AgregarRWindow();

            revWindow.Owner = reservasWindow;
            revWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            revWindow.ShowDialog();

            Reservas updateReserva = new Reservas();
            this.NavigationService.Navigate(updateReserva);
        }
    }
}
