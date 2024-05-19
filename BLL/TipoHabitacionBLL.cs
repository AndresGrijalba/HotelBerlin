using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
