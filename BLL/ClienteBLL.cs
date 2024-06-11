using Entity;
using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class ClienteBLL
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public void AgregarCliente(string nombre, string apellido, string cedula, string correo, string telefono)
        {

            ValidarCampoObligatorio(nombre, "Nombre");
            ValidarCampoObligatorio(apellido, "Apellido");
            ValidarCampoObligatorio(cedula, "Cédula");
            ValidarCampoObligatorio(correo, "Correo");
            ValidarCampoObligatorio(telefono, "Teléfono");

            if (clienteDAL.CedulaExiste(cedula))
            {
                throw new ArgumentException("La cédula ya está registrada.");
            }

            Cliente cliente = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                Cedula = cedula,
                Correo = correo,
                Telefono = telefono
            };

            clienteDAL.agregarCliente(cliente);

        }

        private void ValidarCampoObligatorio(string valor, string nombreCampo)
        {
            if (string.IsNullOrEmpty(valor))
            {
                throw new ArgumentException($"El campo '{nombreCampo}' es obligatorio.");
            }
        }

        public Cliente ObtenerClientePorCedula(string cedula)
        {
            return clienteDAL.ObtenerClientePorCedula(cedula);
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            return clienteDAL.ActualizarCliente(cliente);
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
