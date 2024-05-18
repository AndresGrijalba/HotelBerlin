using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Reserva
    {
        public int id {  get; set; }
        public int cedula_Cliente {  get; set; }
        public int id_Habitacion {  get; set; }
        public string fecha_Inicio{ get; set; }
        public string fecha_Fin {  get; set; }
        public double precio_Total {  get; set; }
        public int cantidad_Noches {  get; set; }
    }
}
