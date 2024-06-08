using GUI.Pages;
using GUI.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
            frameContent.Content = new Estadisticas();
        }

        private void rdReservas_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Reservas());
        }

        private void rdReservas_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Estadisticas());
        }

        private void rdEstadisticas_Checked(object sender, RoutedEventArgs e)
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

        private void rdRegistrarFacturas_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new Facturas());
        }

        private void rdRegistrarFacturas_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            if (Themes.IsChecked == true)
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
            else
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
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
