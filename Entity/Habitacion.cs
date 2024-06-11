using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Habitacion
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public bool? Disponibilidad { get; set; }
        public int Id_Tipo { get; set; }
        public string tipoHabitacion { get; set; }
        public string disponibilidadString {  get; private set; }
        public float precioNoche {  get; private set; }

        public Habitacion() { }

        public Habitacion(int id,int numero, string disponibilidad, string tipo, float precioNoche)
        {
            this.Id = id;
            this.Numero = numero;
            this.setDisponibilidadString(disponibilidad);
            this.tipoHabitacion = tipo;
            this.precioNoche = precioNoche;
        }

        public void setDisponibilidad(string disponibilidad)
        {
            if (disponibilidad.Equals("1"))
            {
                this.Disponibilidad = true;
            }
            else
            {
                this.Disponibilidad = false;
            }
        }

        private void setDisponibilidadString(string disponibilidad)
        {
            if (disponibilidad.Equals("1"))
            {
                this.disponibilidadString = "Disponible";
            }
            else
            {
                this.disponibilidadString = "Reservada";
            }
        }
    }
}
