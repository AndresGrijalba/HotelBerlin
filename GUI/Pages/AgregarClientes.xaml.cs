using BLL;
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
    /// Lógica de interacción para AgregarUsuarios.xaml
    /// </summary>
    public partial class AgregarClientes : Page
    {
        public AgregarClientes()
        {
            InitializeComponent();
        }

        private void RegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string cedula = txtCedula.Text;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;

            
            ClienteBLL clienteBLL = new ClienteBLL();

            try
            {
                clienteBLL.AgregarCliente(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCorreo.Text, txtTelefono.Text);
                MessageBox.Show("Cliente registrado exitosamente.", "Registro Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                Clientes clientePage = new Clientes();
                this.NavigationService.Navigate(clientePage);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar el cliente: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
        }
    }
}
