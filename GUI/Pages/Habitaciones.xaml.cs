﻿using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Lógica de interacción para habitaciones.xaml
    /// </summary>
    public partial class Habitaciones : Page
    {
        public List<Habitacion> habitacion = null;

        HabitacionBLL servicio = new HabitacionBLL();

        public Habitaciones()
        {
            InitializeComponent();
            DataContext = this;
            habitacion = servicio.ObtenerHabitaciones();
            HabitacionesDataGrid.ItemsSource = habitacion;
        }

        public Habitaciones(Habitacion habitacionId)
        {

        }

        private void EditarHabitacion_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int habitacionId = (int)button.Tag;
            EditarHabitacion editarHabitacionPage = new EditarHabitacion(Convert.ToString(habitacionId));
            this.NavigationService.Navigate(editarHabitacionPage);
        }

        private void EliminarHabitacion_Click(object sender, RoutedEventArgs e)
        {
            Button botonEliminar = sender as Button;
            int habitacionId = (int)botonEliminar.Tag;
            var mensaje = servicio.EliminarHabitacion(habitacionId);
            MessageBox.Show(mensaje);
            Habitaciones updateHabitacion = new Habitaciones();
            this.NavigationService.Navigate(updateHabitacion);
        }
    }
}
