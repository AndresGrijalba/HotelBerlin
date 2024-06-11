using DAL;
using Entity;
using System.Collections.Generic;

namespace BLL
{
    public class TipoHabitacionBLL
    {
        private TipoHabitacionDAL tipoHabitacionDAL = new TipoHabitacionDAL();

        public List<TipoHabitacion> ObtenerTiposHabitacion()
        {
            return tipoHabitacionDAL.ObtenerTiposHabitacion();
        }
    }
}
