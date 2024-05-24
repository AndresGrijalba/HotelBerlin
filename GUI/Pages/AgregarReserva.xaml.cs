using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Lógica de interacción para AgregarReserva.xaml
    /// </summary>
    public partial class AgregarReserva : Page
    {
        private string _cedula;
        public List<Habitacion> habitacion = null;
        ClienteBLL clienteBLL = new ClienteBLL();
        ReservaBLL reservaBLL = new ReservaBLL();
        HabitacionBLL habitacionBLL = new HabitacionBLL();

        public AgregarReserva()
        {
            InitializeComponent();
            CargarDatosCliente();
            habitacion = habitacionBLL.ObtenerHabitaciones();
            CargarHabitacionesDisponibles();
            cargarDatosHabitacion();
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
            DateTime fechaInicio;
            DateTime fechaFin;
            int cantidadNoches;

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

            if (!int.TryParse(txtNumeroNoches.Text, out cantidadNoches))
            {
                MessageBox.Show("Por favor, ingrese un número de noches válido.");
                return;
            }

            idCliente = (int)cmbCedula.SelectedValue;
            idHabitacion = (int)cmbHabitaciones.SelectedValue;

            Reserva nuevaReserva = new Reserva
            {
                idCliente = idCliente,
                idHabitacion = idHabitacion,
                fechaInicio = fechaInicio,
                fechaFin = fechaFin,
                cantidadNoches = cantidadNoches
            };

            try
            {
                reservaBLL.agregarReserva(nuevaReserva);
                MessageBox.Show("Reserva agregada exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la reserva: " + ex.Message);
            }
        }

        private void CargarDatosCliente()
        {
            Cliente cliente = clienteBLL.ObtenerClientePorCedula(_cedula);
            if (cliente != null)
            {
                cmbCedula.Text = cliente.Cedula;
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.");
            }
        }

        private void CargarHabitacionesDisponibles()
        {
            List<Habitacion> habitacionesDisponibles = habitacionBLL.ObtenerHabitacionesDisponibles();
            cmbHabitaciones.ItemsSource = habitacionesDisponibles;
            cmbHabitaciones.DisplayMemberPath = "Numero";
            cmbHabitaciones.SelectedValuePath = "Id"; 
        }

        private void cargarDatosHabitacion()
        {
            //Habitacion habitacion = habitacionBLL.ObtenerHabitacionPorId(_id);
            //if (habitacion != null)
            //{
            //    cmbTipoHabitacion.SelectedValue = habitacion.Id_Tipo;
            //    cmbHabitaciones.SelectedValue = habitacion.Id;
            //}
            //else
            //{
            //    MessageBox.Show("Habitación no encontrada");
            //}
        }
    }
}
