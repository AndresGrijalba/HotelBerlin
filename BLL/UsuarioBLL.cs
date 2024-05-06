using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UsuarioBLL
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        public void AgregarUsuario(string nombre, string apellido, string cedula, string correo)
        {

            Usuario usuario = new Usuario
            {
                Nombre = nombre,
                Apellido = apellido,
                Cedula = cedula,
                Correo = correo,
            };

            usuarioDAL.AgregarUsuario(usuario);

        }

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarioDAL.ObtenerUsuarios(); 
        }
    }
}
