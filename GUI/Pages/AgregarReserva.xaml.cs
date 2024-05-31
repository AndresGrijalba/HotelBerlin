using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Pages
{
    /// <summary>
    /// Lógica de interacción para AgregarReserva.xaml
    /// </summary>
    public partial class AgregarReserva : Page
    {
        public List<Habitacion> habitacion = null;
        ClienteBLL clienteBLL = new ClienteBLL();
        ReservaBLL reservaBLL = new ReservaBLL();
        HabitacionBLL habitacionBLL = new HabitacionBLL();
        TipoHabitacionBLL tipoHabitacionBLL = new TipoHabitacionBLL();

        public AgregarReserva()
        {
            InitializeComponent();
            habitacion = habitacionBLL.ObtenerHabitaciones();
            CargarTiposHabitacion();
        }

        public void btnFecha_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la reserva: " + ex.Message);
            }
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
                MessageBox.Show(selectedCliente.Id.ToString());
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
