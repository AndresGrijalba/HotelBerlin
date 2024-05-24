using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FacturacionBLL
    {
        private FacturacionDAL facturacionDAL = new FacturacionDAL();

        public void AgregarFactura(int id_reserva, double valor_noche, int cantidad_noche, double total, DateTime fecha_emision) 
        {
            if (facturacionDAL.Id_Reserva(id_reserva.ToString()))
            {
                throw new ArgumentException("Facturacion ya existe");
            }

            Facturacion facturacion = new Facturacion
            {
                id_reserva = id_reserva,
                valor_noche = valor_noche,
                cantidad_noches = cantidad_noche,
                total = total,
                fecha_emision = fecha_emision
            };

            facturacionDAL.AgregarFactura(facturacion);
        }


    }
}
