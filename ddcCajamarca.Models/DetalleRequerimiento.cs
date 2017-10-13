using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class DetalleRequerimiento
    {
        public Int32 Id { get; set; }
        public Int32 IdEventoEnsayo { get; set; }
        public Int32 IdActivo { get; set; }
        public Int32 Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Activo Activo { get; set; }
        public EventoEnsayo EventoEnsayo { get; set; }
    }
}
