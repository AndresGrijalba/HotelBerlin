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
using BLL;

namespace GUI.Pages
{
    /// <summary>
    /// Lógica de interacción para Reservas.xaml
    /// </summary>
    public partial class Reservas : Page
    {
        public Reservas()
        {
            InitializeComponent();
        }

        public void btnFecha_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RegistrarReserva_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los datos del formulario
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string cedula = txtCedula.Text;
            string correo = txtCorreo.Text;

            // Crear una instancia de UsuarioDAL
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            // Llamar al método AgregarUsuario para agregar el usuario a la base de datos
            usuarioBLL.AgregarUsuario(nombre, apellido, cedula, correo);

            // Mostrar un mensaje de éxito
            MessageBox.Show("Usuario registrado correctamente.");

            // Limpiar los campos del formulario después de agregar el usuario
            LimpiarCampos();
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtCorreo.Text = "";
        }

    }
}
