﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class Activo
    {
        public Activo()
        {
            this.DetalleRequerimientos = new List<DetalleRequerimiento>();
        }

        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Int32 Estado { get; set; }

        public List<DetalleRequerimiento> DetalleRequerimientos { get; set; }

        public String FechaRegistroMostrar
        {
            get
            {
                return FechaRegistro.Day + "/" + FechaRegistro.Month + "/" + FechaRegistro.Year;
            }
        }
    }
}
