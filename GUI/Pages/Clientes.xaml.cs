using Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BLL;

namespace GUI.Pages
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Clientes : Page
    {
        public List<Cliente> cliente = null;

        ClienteBLL servicio = new ClienteBLL();
        

        public Clientes()
        {
            InitializeComponent();
            DataContext = this;
            cliente = servicio.ObtenerClientes();
            ClientesDataGrid.ItemsSource = cliente;
        }

        private void EditarCliente_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string cedula = button.Tag as string;
            EditarCliente editarClientePage = new EditarCliente(cedula);
            this.NavigationService.Navigate(editarClientePage);
        }
        private void EliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            Button botonEliminar = sender as Button;
            string cedulaCliente = botonEliminar.Tag as string;
            var mensaje = servicio.EliminarCliente(cedulaCliente);
            MessageBox.Show(mensaje);
            Clientes updateCliente = new Clientes();
            this.NavigationService.Navigate(updateCliente);
        }
    }
}