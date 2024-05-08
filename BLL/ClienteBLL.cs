﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ClienteBLL
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public void AgregarCliente(string nombre, string apellido, string cedula, string correo)
        {

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(correo))
            {
                throw new ArgumentException("Todos los campos son obligatorios.");
            }

            Cliente usuario = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                Cedula = cedula,
                Correo = correo,
            };

            clienteDAL.AgregarCliente(usuario);

        }

        public string EliminarCliente(string cedula)
        {
            try
            {
                var Respuesta = clienteDAL.EliminarCliente(cedula);
                if (Respuesta)
                {
                    return "Se elimino el cliente";
                }
                return "No se eliminó el cliente";
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que ocurra durante la eliminación
                //Console.WriteLine("Error en la capa BLL al eliminar el usuario: " + ex.Message);
                return "Error al eliminar el cliente"; // Fallo al eliminar el usuario
            }
        }

        public List<Cliente> ObtenerClientes()
        {
            return clienteDAL.ObtenerClientes(); 
        }
    }
}
