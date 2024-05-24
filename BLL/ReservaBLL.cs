using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReservaBLL
    {
        private ReservaDAL reservaDAL = new ReservaDAL();

        public void agregarReserva(Reserva reserva)
        {
            reservaDAL.agregarReserva(reserva);
        }
    }
}
