using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class FacturaBLL
    {
        private FacturaDAL facturaDAL = new FacturaDAL();

        public void agregarFactura(Reserva reserva)
        {
            facturaDAL.agregarFactura(reserva);
        }

        public List<Factura> ObtenerFacturas()
        {
            return facturaDAL.ObtenerFacturas();
        }

        public double ObtenerTotalFacturas()
        {
            return facturaDAL.ObtenerTotalFacturas();
        }
    }
}
