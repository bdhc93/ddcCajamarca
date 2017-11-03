using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class DetalleHorasEvento
    {
        public Int32 Id { get; set; }
        public Int32 IdEventoEnsayo { get; set; }
        public EventoEnsayo EventoEnsayo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public String FechaInicioMostrar
        {
            get
            {
                return FechaInicio.Day + "/" + FechaInicio.Month + "/" + FechaInicio.Year;
            }
        }
        public String HoraInicioMostrar
        {
            get
            {
                return (TimeSpan.Parse(FechaInicio.Hour + ":" + FechaInicio.Minute) + "").Substring(0, 5);
            }
        }
        public String FechaFinMostrar
        {
            get
            {
                return FechaFin.Day + "/" + FechaFin.Month + "/" + FechaFin.Year;
            }
        }
        public String HoraFinMostrar
        {
            get
            {
                return (TimeSpan.Parse(FechaFin.Hour + ":" + FechaFin.Minute) + "").Substring(0, 5);
            }
        }
    }
}
