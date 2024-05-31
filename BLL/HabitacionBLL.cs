using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HabitacionBLL
    {
        private HabitacionDAL habitacionDAL = new HabitacionDAL();


        public void AgregarHabitacion(Habitacion habitacion)
        {
            habitacionDAL.AgregarHabitacion(habitacion);
        }

        public List<Habitacion> ObtenerHabitaciones()
        {
            return habitacionDAL.ObtenerHabitaciones();
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
    }
}
