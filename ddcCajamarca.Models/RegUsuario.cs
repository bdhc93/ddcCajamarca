using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class RegUsuario
    {
        public Int32 Id { get; set; }
        public String Usuario { get; set; }

        public String Modulo { get; set; }
        public String Cambio { get; set; }
        public String IdModulo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
