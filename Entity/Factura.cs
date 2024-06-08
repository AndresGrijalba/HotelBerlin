using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Factura
    {
        public int Id {  get; set; }
        public string Cedula {  get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IdReserva {  get; set; }
        public string FechaEmision {  get; set; }
        public double PrecioTotal {  get; set; }
    }
}
