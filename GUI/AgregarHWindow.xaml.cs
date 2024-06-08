﻿using BLL;
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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Lógica de interacción para AgregarHWindow.xaml
    /// </summary>
    public partial class AgregarHWindow : Window
    {
        private HabitacionBLL habitacionBLL;
        private TipoHabitacionBLL tipoHabitacionBLL;

        public AgregarHWindow()
        {
            InitializeComponent();
            habitacionBLL = new HabitacionBLL();
            tipoHabitacionBLL = new TipoHabitacionBLL();
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
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la habitación: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            cmbTipoHabitacion.SelectedIndex = -1;
            txtNumero.Clear();

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