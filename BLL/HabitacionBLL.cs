using DAL;
using Entity;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class HabitacionBLL
    {
        private HabitacionDAL habitacionDAL = new HabitacionDAL();
        List<Habitacion> habitaciones = new List<Habitacion>();

        public HabitacionBLL()
        {
            habitaciones = habitacionDAL.ObtenerHabitaciones();
        }

        public void AgregarHabitacion(Habitacion habitacion)
        {
            habitacionDAL.AgregarHabitacion(habitacion);
        }

        public List<Habitacion> ObtenerHabitaciones()
        {
            return habitaciones;
        }

        public Habitacion obtenerHabitacionPorId(string habitacionId)
        {
            return habitacionDAL.obtenerHabitacionPorId(habitacionId);
        }

        public bool actualizarHabitacion(Habitacion habitacion)
        {
            return habitacionDAL.actualizarHabitacion(habitacion);
        }

        public string EliminarHabitacion(int id)
        {
            try
            {
                var respuesta = habitacionDAL.EliminarHabitacion(id);
                if (respuesta)
                {
                    return "Se eliminó la habitación correctamente";
                }
                return "No se eliminó la habitación";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la habitación: " + ex.Message;
            }
        }

        public List<Habitacion> ObtenerHabitacionesDisponibles(int idTipo)
        {
            return habitacionDAL.ObtenerHabitacionesDisponibles(idTipo);
        }

        public float ObtenerPrecioHabitacion(int nHabitacion)
        {
            foreach (var item in habitaciones)
            {
                if (item.Numero == nHabitacion)
                {
                    return item.precioNoche;
                }
            }
            return -1;
        }
    }
}
