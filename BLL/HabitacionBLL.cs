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

    }
}
