using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Lógica de interacción para habitaciones.xaml
    /// </summary>
    public partial class Habitaciones : Page
    {
        public List<Habitacion> habitaciones = null;

        HabitacionBLL servicio = new HabitacionBLL();


        public Habitaciones()
        {
            InitializeComponent();
            DataContext = this;
            habitaciones = servicio.ObtenerHabitaciones();
            HabitacionesDataGrid.ItemsSource = habitaciones;
        }

        private void EditarCliente_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void EliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
