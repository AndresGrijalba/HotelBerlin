using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Reserva
    {
        public int Id {  get; set; }
        public int idCliente {  get; set; }
        public int idHabitacion {  get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CantidadNoches { get; set; }
        public double PrecioTotal { get; set; }
        public string NumeroHabitacion { get; set; }
        public string TipoHabitacion { get; set; }
        public double ValorNoche {  get; set; }
        public DateTime FechaRegistro {  get; set; }
        public string EstadoReserva { get; set; }

        public Reserva() 
        {
            EstadoReserva = "Pendiente";
        }

        public Reserva(int id, string nombres, string apellidos, string cedula, string correo, DateTime fechainicio, DateTime fechafin, int cantidadnoches, double preciototal, string numerohabitacion, DateTime fecharegistro, string tipoHabitacion, double precionoche, string estadoreserva)
        {
            this.Id = id;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.Correo = correo;
            this.FechaInicio = fechainicio;
            this.FechaFin = fechafin;
            this.CantidadNoches = cantidadnoches;
            this.PrecioTotal = preciototal;
            this.NumeroHabitacion = numerohabitacion;
            this.FechaRegistro = fecharegistro;
            this.TipoHabitacion = tipoHabitacion;
            this.ValorNoche = precionoche;
            this.EstadoReserva = estadoreserva;
        }

        public int CalcularCantidadNoches()
        {
            return (FechaFin - FechaInicio).Days;
        }

        public double CalcularPrecio()
        {
            return (CantidadNoches *  ValorNoche);
        }
    }
}
