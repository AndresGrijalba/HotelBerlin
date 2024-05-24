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
        public int idCliente {  get; set; }
        public int idHabitacion {  get; set; }
        public DateTime fechaInicio{ get; set; }
        public DateTime fechaFin {  get; set; }
        public double precioTotal {  get; set; }
        public int cantidadNoches {  get; set; }

        public Reserva() { }


    }


}
