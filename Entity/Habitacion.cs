using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{ 
    public class Habitacion : TipoHabitacion
    {
        public string Id {  get; set; }
        public string Numero {  get; set; }
        public string Disponibilidad { get; set; }
        public string Id_Tipo { get; set; }

        public Habitacion() { }

        public override string ToString()
        {
            return $"{Id_Tipo}";
        }
    }
}
