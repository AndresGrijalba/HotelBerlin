using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Facturacion
    {
        public int id { get; set; }
        public int id_reserva { get; set; }
        public double valor_noche { get; set; }
        public int cantidad_noches { get; set; }
        public double total { get; set; }
        public DateTime fecha_emision { get; set; }

        public Facturacion()
        {

        }

        public Facturacion(int id, int id_reserva, int valor_noche, int cantidad_noches, int total, DateTime fecha_emision)
        {
            this.id = id;
            this.id_reserva = id_reserva;
            this.valor_noche = valor_noche;
            this.cantidad_noches = cantidad_noches;
            this.total = total;
            this.fecha_emision = fecha_emision;
        }
    }
}
