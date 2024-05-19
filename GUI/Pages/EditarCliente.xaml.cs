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
    /// Lógica de interacción para EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : Page
    {
        private string _cedula;
        private ClienteBLL clienteBLL = new ClienteBLL();

        public EditarCliente()
        {

        }

        public EditarCliente(string cedula)
        {
            InitializeComponent();
            _cedula = cedula;
            CargarDatosCliente();
        }

        private void CargarDatosCliente()
        {
            Cliente cliente = clienteBLL.ObtenerClientePorCedula(_cedula);
            if (cliente != null)
            {
                CedulaTextBox.Text = cliente.Cedula;
                NombreTextBox.Text = cliente.Nombre;
                ApellidoTextBox.Text = cliente.Apellido;
                CorreoTextBox.Text = cliente.Correo;
                TelefonoTextBox.Text = cliente.Telefono;
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.");
            }
        }

        private void ActualizarInformacion_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Cedula = CedulaTextBox.Text,
                Nombre = NombreTextBox.Text,
                Apellido = ApellidoTextBox.Text,
                Correo = CorreoTextBox.Text,
                Telefono = TelefonoTextBox.Text
            };

            bool exito = clienteBLL.ActualizarCliente(cliente);
            if (exito)
            {
                MessageBox.Show("Datos del cliente actualizados correctamente.");
                // Navegar de vuelta a Page1 (Clientes)
                this.NavigationService.Navigate(new Clientes());
            }
            else
            {
                MessageBox.Show("Error al actualizar los datos del cliente.");
            }
        }
    }
}
