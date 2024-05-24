using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cliente
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Cedula{ get; set; }
        public string Telefono { get ; set; }
        public Cliente() { }

        public Cliente(string id) {
            this.Id = Convert.ToInt32(id);
        }

        public Cliente(int id, string nombres, string apellidos, string cedula)
        {
            this.Id = id;
            this.Nombre = nombres;
            this.Apellido = apellidos;
            this.Cedula = cedula;
        }
    }
}
