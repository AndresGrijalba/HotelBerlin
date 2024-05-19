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
    }
}
