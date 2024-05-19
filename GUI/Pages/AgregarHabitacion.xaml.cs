using BLL;
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

namespace GUI.Pages
{
    /// <summary>
    /// Lógica de interacción para AgregarHabitacion.xaml
    /// </summary>
    public partial class AgregarHabitacion : Page
    {
        private HabitacionBLL habitacionBLL;
        private TipoHabitacionBLL tipoHabitacionBLL;
        public AgregarHabitacion()
        {
            InitializeComponent();
            habitacionBLL = new HabitacionBLL();
            tipoHabitacionBLL = new TipoHabitacionBLL();
            CargarTiposHabitacion();
        }

        private void btnAgregarHabitacion_Click(object sender, RoutedEventArgs e)
        {
            int numeroHabitacion;
            int idTipoHabitacion;
            bool? disponibilidad = cbDisponibilidad.IsChecked;

            if (cmbTipoHabitacion.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de habitación.");
                return;
            }

            if (!int.TryParse(txtNumero.Text, out numeroHabitacion))
            {
                MessageBox.Show("Por favor, ingrese un número de habitación válido.");
                return;
            }
            idTipoHabitacion = (int)cmbTipoHabitacion.SelectedValue;

            Habitacion nuevaHabitacion = new Habitacion
            {
                Numero = numeroHabitacion,
                Id_Tipo = idTipoHabitacion,
                Disponibilidad = disponibilidad 
            };

            try
            {
                habitacionBLL.AgregarHabitacion(nuevaHabitacion);
                MessageBox.Show("Habitación agregada exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la habitación: " + ex.Message);
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
