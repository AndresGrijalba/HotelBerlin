﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Habitacion : TipoHabitacion
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public bool? Disponibilidad { get; set; }
        public int Id_Tipo { get; set; }
        public string tipoHabitacion { get; set; }
        public string disponibilidadString {  get; private set; }
        public float precioNoche {  get; private set; }

        public Habitacion() { }

        public Habitacion(int numero, string disponibilidad, string tipo, float precioNoche)
        {
            this.Numero = numero;
            this.setDisponibilidad(disponibilidad);
            this.tipoHabitacion = tipo;
            this.precioNoche = precioNoche;
        }

        private void setDisponibilidad(string disponibilidad)
        {
            if (disponibilidad.Equals("1"))
            {
                this.disponibilidadString = "Si";
            }
            else
            {
                this.disponibilidadString = "No";
            }
        }

        public override string ToString()
        {
            return $"{Id_Tipo}";
        }
    }
}
