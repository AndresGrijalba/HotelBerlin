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
    /// Lógica de interacción para EditarHabitacion.xaml
    /// </summary>
    public partial class EditarHabitacion : Page
    {
        private string _id;
        private HabitacionBLL habitacionBLL = new HabitacionBLL();
        private TipoHabitacionBLL tipoHabitacionBLL = new TipoHabitacionBLL();

        public EditarHabitacion()
        {

        }

        public EditarHabitacion(string habitacionId)
        {
            InitializeComponent();
            _id = habitacionId;
            CargarTiposHabitacion();
            cargarDatosHabitacion();
        }
        private void actualizarInformacion_Click(object sender, RoutedEventArgs e)
        {
            Habitacion habitacion = new Habitacion
            {
                Id = Convert.ToInt32(_id),
                Id_Tipo = Convert.ToInt32(cmbTipoHabitacion.SelectedIndex),
                Numero = Convert.ToInt32(txtNumero.Text),
                Disponibilidad = Convert.ToBoolean(cbDisponibilidad.IsChecked)
            };

            bool exito = habitacionBLL.actualizarHabitacion(habitacion);
            if (exito)
            {
                MessageBox.Show("Datos de la habitacion actualizados correctamente.");
                this.NavigationService.Navigate(new Habitaciones());
            }
            else
            {
                MessageBox.Show("Error al actualizar los datos de la habitacion.");
            }
        }

        private void cargarDatosHabitacion()
        {
            Habitacion habitacion = habitacionBLL.obtenerHabitacionPorId(_id);
            if (habitacion != null)
            {
                cmbTipoHabitacion.SelectedValue = habitacion.Id_Tipo;
                txtNumero.Text = Convert.ToString(habitacion.Numero);
                cbDisponibilidad.IsChecked = habitacion.Disponibilidad;
            }
            else
            {
                MessageBox.Show("Habitacion no encontrado");
            }
        }

        private void CargarTiposHabitacion()
        {
            List<TipoHabitacion> tiposHabitacion = tipoHabitacionBLL.ObtenerTiposHabitacion();
            cmbTipoHabitacion.ItemsSource = tiposHabitacion;
            cmbTipoHabitacion.DisplayMemberPath = "Nombre";
            cmbTipoHabitacion.SelectedValuePath = "Id";
        }
    }
}
