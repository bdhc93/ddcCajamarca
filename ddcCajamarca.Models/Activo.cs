﻿using System;
using System.Collections.Generic;
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

        public List<DetalleRequerimiento> DetalleRequerimientos { get; set; }
    }
}
