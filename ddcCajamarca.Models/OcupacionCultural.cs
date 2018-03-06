using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class OcupacionCultural
    {
        public OcupacionCultural()
        {
            this.Personas = new List<Persona>();
        }

        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        //[NotMapped]
        //public Int32 Estado { get; set; }

        public String FechaRegistroMostrar
        {
            get
            {
                return FechaRegistro.Day + "/" + FechaRegistro.Month + "/" + FechaRegistro.Year;
            }
        }

        public List<Persona> Personas { get; set; }
    }
}
