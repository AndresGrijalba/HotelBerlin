using GUI.Pages;
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

namespace GUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rdReservas_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new ListaReservas());
        }

        private void rdReservas_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void rdRegistrarReserva_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new AgregarReserva());
        }

        private void rdRegistrarReserva_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdHabitaciones_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Habitaciones());
        }

        private void rdHabitaciones_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdUsuarios_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Clientes());
        }

        private void rdUsuarios_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdRegistrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new AgregarClientes());
        }

        private void rdRegistrarUsuario_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdCerrarSesion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rdCerrarSesion_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void rdUsuariosPrueba_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new pruebaCliente());
        }

        private void rdUsuariosPrueba_Checked(object sender, RoutedEventArgs e)
        {
            
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
