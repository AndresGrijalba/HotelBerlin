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
    /// Lógica de interacción para pruebaCliente.xaml
    /// </summary>
    public partial class pruebaCliente : Page
    {
        public List<Cliente> Clientes = null;

        ClienteBLL servicio = new ClienteBLL();
        
        public pruebaCliente()
        {
            InitializeComponent();
            DataContext = this;
            Clientes = servicio.ObtenerClientes();
            ClientesDataGrid.ItemsSource = Clientes;
        }

        private void EliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            Button botonEliminar = sender as Button;
            string cedulaCliente = botonEliminar.Tag as string;
            var mensaje = servicio.EliminarCliente(cedulaCliente);
            MessageBox.Show(mensaje);
            //MessageBox.Show($"Cédula del cliente a eliminar: {cedulaCliente}", "Cédula del cliente", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
