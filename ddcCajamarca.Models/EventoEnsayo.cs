using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class EventoEnsayo
    {
        public EventoEnsayo()
        {
            this.DetalleRequerimientos = new List<DetalleRequerimiento>();
        }
        
        public Int32 Id { get; set; }
        public String NombreActividad { get; set; }
        public String InstitucionEncargada { get; set; }
        public String InformacionAdicional { get; set; }
        public Boolean TodoDia { get; set; }
        public Boolean Evento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Int32 IdAmbiente { get; set; }
        public Ambiente Ambiente { get; set; }

        public List<DetalleRequerimiento> DetalleRequerimientos { get; set; }
    }
}
