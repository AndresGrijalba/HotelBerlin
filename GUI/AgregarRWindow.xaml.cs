using BLL;
using Entity;
using GUI.Pages;
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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Lógica de interacción para AgregarRWindow.xaml
    /// </summary>
    public partial class AgregarRWindow : Window
    {
        public List<Habitacion> habitacion = null;
        ClienteBLL clienteBLL = new ClienteBLL();
        ReservaBLL reservaBLL = new ReservaBLL();
        HabitacionBLL habitacionBLL = new HabitacionBLL();
        TipoHabitacionBLL tipoHabitacionBLL = new TipoHabitacionBLL();

        public AgregarRWindow()
        {
            InitializeComponent();
            habitacion = habitacionBLL.ObtenerHabitaciones();
            CargarTiposHabitacion();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void AgregarReserva_Click(object sender, RoutedEventArgs e)
        {
            int idCliente;
            int idHabitacion;

            DateTime fechaInicio = dpDesde.SelectedDate.Value;
            DateTime fechaFin = dpHasta.SelectedDate.Value;
            DateTime fechaRegistro = DateTime.Now;

            if (cmbCedula.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente.");
                return;
            }

            if (cmbHabitaciones.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una habitación.");
                return;
            }

            if (!DateTime.TryParse(dpDesde.Text, out fechaInicio))
            {
                MessageBox.Show("Por favor, ingrese una fecha de inicio válida.");
                return;
            }

            if (!DateTime.TryParse(dpHasta.Text, out fechaFin))
            {
                MessageBox.Show("Por favor, ingrese una fecha de fin válida.");
                return;
            }

            idCliente = int.Parse(cmbCedula.SelectedValue.ToString());
            idHabitacion = int.Parse(cmbHabitaciones.SelectedValue.ToString());

            Reserva nuevaReserva = new Reserva
            {
                idCliente = idCliente,
                idHabitacion = idHabitacion,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                FechaRegistro = fechaRegistro
            };


            try
            {
                string mensaje = reservaBLL.agregarReserva(nuevaReserva);
                MessageBox.Show(mensaje);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la reserva: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            cmbCedula.SelectedIndex = -1;
            cmbHabitaciones.SelectedIndex = -1;
            cmbTipoHabitacion.SelectedIndex = -1;

            dpDesde.SelectedDate = null;
            dpHasta.SelectedDate = null;
        }

        private void OnListenerIdentification_PreviewKeyUp(object sender, KeyboardEventArgs e)
        {
            string cedula = cmbCedula.Text;
            List<Cliente> clientes;

            if (cedula.Length >= 3)
            {
                clientes = clienteBLL.BuscarClientesPorCedula(cedula);
                cmbCedula.ItemsSource = clientes;
                cmbCedula.DisplayMemberPath = "Nombre";
                cmbCedula.SelectedValuePath = "Id";
            }
        }

        private void cmbCedula_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbCedula.SelectedItem != null)
            {
                Cliente selectedCliente = (Cliente)cmbCedula.SelectedItem;
                txtNombre.Text = selectedCliente.Nombre;
                txtApellido.Text = selectedCliente.Apellido;
            }
        }

        private void CargarTiposHabitacion()
        {
            List<TipoHabitacion> tiposHabitacion = tipoHabitacionBLL.ObtenerTiposHabitacion();
            cmbTipoHabitacion.ItemsSource = tiposHabitacion;
            cmbTipoHabitacion.DisplayMemberPath = "Nombre";
            cmbTipoHabitacion.SelectedValuePath = "Id";
        }

        private void CargarHabitacionesPorTipo(int idTipo)
        {
            List<Habitacion> habitacionesDisponibles = habitacionBLL.ObtenerHabitacionesDisponibles(idTipo);
            cmbHabitaciones.ItemsSource = habitacionesDisponibles;
            cmbHabitaciones.DisplayMemberPath = "Numero";
            cmbHabitaciones.SelectedValuePath = "Id";
        }

        private void cmbTipoHabitacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipoHabitacion.SelectedItem != null)
            {
                int idTipoHabitacion = (int)cmbTipoHabitacion.SelectedValue;
                CargarHabitacionesPorTipo(idTipoHabitacion);
            }
        }
    }
}
