using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class UsuarioBLL
    {
        public UsuarioBLL() { }
        public void ValidarCredenciales(string User, string Password)
        {
            if (!string.IsNullOrEmpty(User) || (!string.IsNullOrEmpty(Password)))
            {
                throw new ArgumentException("Todos los campos son obligatorios.");
            }
        }
    }
}
