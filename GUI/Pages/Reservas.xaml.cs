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
        private ReservaBLL reservaBLL = new ReservaBLL();

        public Reservas()
        {
            InitializeComponent();
            DataContext = this;
            reserva = servicio.ObtenerReservas();
            ReservasDataGrid.ItemsSource = reserva;
            CargarReservas();
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

        private void CancelarReserva_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                int reservaId = (int)button.Tag;
                string resultado = reservaBLL.CancelarReserva(reservaId.ToString());

                if (resultado == "Reserva cancelada correctamente.")
                {
                    CargarReservas();
                }

                MessageBox.Show(resultado);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cancelar la reserva: " + ex.Message);
            }
        }

        private void ConfirmarReserva_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                int reservaId = (int)button.Tag;
                string resultado = reservaBLL.ConfirmarReserva(reservaId.ToString());

                if (resultado == "Reserva confirmada correctamente.")
                {
                    CargarReservas();
                }

                MessageBox.Show(resultado);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al confirmar la reserva: " + ex.Message);
            }
        }

        private void FacturarReserva_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int reservaId = (int)button.Tag;

            Reserva reservaSeleccionada = reserva.FirstOrDefault(r => r.Id == reservaId);
            reservaSeleccionada.PrecioTotal = reservaSeleccionada.CantidadNoches * new HabitacionBLL().ObtenerPrecioHabitacion(Convert.ToInt32(reservaSeleccionada.NumeroHabitacion));
            InformacionFWindow detallesReservaWindow = new InformacionFWindow(reservaSeleccionada);
            detallesReservaWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            detallesReservaWindow.ShowDialog();
            string resultado = reservaBLL.FacturarReserva(reservaId.ToString());
            CargarReservas();
        }

        private void CargarReservas()
        {
            List<Reserva> reservas = reservaBLL.ObtenerReservas();
            ReservasDataGrid.ItemsSource = reservas;
        }

        private void CargarReservasCanceladas()
        {
            List<Reserva> reservas = reservaBLL.ObtenerReservasCanceladas();
            ReservasDataGrid.ItemsSource = reservas;
        }

        private void CargarReservasPendientes()
        {
            List<Reserva> reservas = reservaBLL.ObtenerReservasPendientes();
            ReservasDataGrid.ItemsSource = reservas;
        }

        private void CargarReservasConfirmadas()
        {
            List<Reserva> reservas = reservaBLL.ObtenerReservasConfirmadas();
            ReservasDataGrid.ItemsSource = reservas;
        }

        private void EstadoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
                if (selectedItem != null)
                {
                    string selectedText = selectedItem.Content.ToString();

                    switch (selectedText)
                    {
                        case "Todas":
                            CargarReservas();
                            break;
                        case "Canceladas":
                            CargarReservasCanceladas();
                            break;
                        case "Pendientes":
                            CargarReservasPendientes();
                            break;
                        case "Confirmadas":
                            CargarReservasConfirmadas();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void txtFiltro_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txtFiltro.Text.ToLower();

            var reservasFiltradas = reserva.Where(reserva => reserva.Cedula.ToLower().Contains(filtro) ||
                                                               reserva.Nombres.ToLower().Contains(filtro) ||
                                                               reserva.Apellidos.ToLower().Contains(filtro));
            ReservasDataGrid.ItemsSource = reservasFiltradas;
        }
    }
}
