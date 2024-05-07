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

        public void btnFecha_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los datos del formulario
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string cedula = txtCedula.Text;
            string correo = txtCorreo.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(correo))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return; // Salir del método si algún campo está vacío
            }

            // Crear una instancia de ClienteBLL
            ClienteBLL clienteBLL = new ClienteBLL();

            try
            {
                // Llamar al método AgregarCliente para agregar el cliente a la base de datos
                clienteBLL.AgregarCliente(nombre, apellido, cedula, correo);

                // Mostrar un mensaje de éxito
                MessageBox.Show("Cliente registrado correctamente.");

                // Limpiar los campos del formulario después de agregar el cliente
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Error al registrar el cliente: {ex.Message}");
            }
            // Crear una instancia de UsuarioDAL
            //ClienteBLL clienteBLL = new ClienteBLL();

            //// Llamar al método AgregarUsuario para agregar el usuario a la base de datos
            //clienteBLL.AgregarCliente(nombre, apellido, cedula, correo);

            //// Mostrar un mensaje de éxito
            //MessageBox.Show("Usuario registrado correctamente.");

            //// Limpiar los campos del formulario después de agregar el usuario
            //LimpiarCampos();
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtCorreo.Text = "";
        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
