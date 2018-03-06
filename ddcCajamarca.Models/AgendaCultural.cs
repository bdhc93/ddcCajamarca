using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class AgendaCultural
    {
        public Int32 Id { get; set; }
        public String Titulo { get; set; }
        public String Descripcion { get; set; }
        public String Imagen { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String Lugar { get; set; }
        public String Encagardo { get; set; }
        //[NotMapped]
        //public Int32 Estado { get; set; }

    }
}
