using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Net.Http;

namespace BLL
{
    public class ClienteBLL
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public void AgregarCliente(string nombre, string apellido, string cedula, string correo, string telefono)
        {

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(telefono))
            {
                throw new ArgumentException("Todos los campos son obligatorios.");
            }

            Cliente cliente = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                Cedula = cedula,
                Correo = correo,
                Telefono = telefono
            };

            

            clienteDAL.AgregarCliente(cliente);

        }

        public string EliminarCliente(string cedula)
        {
            try
            {
                var Respuesta = clienteDAL.EliminarCliente(cedula);
                if (Respuesta)
                {
                    return "Se elimino el cliente correctamente";
                }
                return "No se eliminó el cliente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el cliente"; 
            }
        }

        public List<Cliente> ObtenerClientes()
        {
            return clienteDAL.ObtenerClientes(); 
        }

        public List<Cliente> BuscarClientesPorCedula(string cedula)
        {
            if (string.IsNullOrEmpty(cedula))
            {
                throw new ArgumentException("La cédula no puede estar vacía.");
            }

            return clienteDAL.BuscarClientesPorCedula(cedula);
        }
    }
}
