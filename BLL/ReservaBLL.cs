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

        public string agregarReserva(Reserva reserva)
        {
            try
            {
                int cantidadNoches = reserva.CalcularCantidadNoches();
                reserva.CantidadNoches = cantidadNoches;

                reservaDAL.agregarReserva(reserva);
                return "Sucessfull";
            }
            catch (Exception ex)
            {
                return "Error: " + ex;
            }
        }

        public List<Reserva> ObtenerReservas()
        {
            return reservaDAL.ObtenerReservas();
        }
    }
}
