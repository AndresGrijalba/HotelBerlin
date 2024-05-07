using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Cedula{ get; set; }
        public Cliente() { }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
