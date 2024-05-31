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
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CantidadNoches { get; set; }
        public double PrecioTotal { get; set; }
        public string NumeroHabitacion { get; set; }
        public string TipoHabitacion { get; set; }
        public DateTime FechaRegistro {  get; set; }

        public Reserva() { }

        public Reserva(string nombres, string apellidos, string cedula , DateTime fechainicio, DateTime fechafin, int cantidadnoches, double preciototal, string numerohabitacion, DateTime fecharegistro, string tipoHabitacion)
        {
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.FechaInicio = fechainicio;
            this.FechaFin = fechafin;
            this.CantidadNoches = cantidadnoches;
            this.PrecioTotal = preciototal;
            this.NumeroHabitacion = numerohabitacion;
            this.FechaRegistro = fecharegistro;
            this.TipoHabitacion = tipoHabitacion;
        }

        public int CalcularCantidadNoches()
        {
            return (FechaFin - FechaInicio).Days;
        }
    }
}
