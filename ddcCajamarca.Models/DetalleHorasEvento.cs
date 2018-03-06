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

        //public Int32 Estado { get; set; }

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
                var hora = TimeSpan.Parse(FechaInicio.Hour + ":" + FechaInicio.Minute);

                if (hora.Hours < 13)
                {
                    return (hora + "").Substring(0, 5) + " AM";
                }
                else
                {
                    switch (hora.Hours)
                    {
                        case 13:
                            hora = TimeSpan.Parse("01" + ":" + FechaInicio.Minute);
                            break;
                        case 14:
                            hora = TimeSpan.Parse("02" + ":" + FechaInicio.Minute);
                            break;
                        case 15:
                            hora = TimeSpan.Parse("03" + ":" + FechaInicio.Minute);
                            break;
                        case 16:
                            hora = TimeSpan.Parse("04" + ":" + FechaInicio.Minute);
                            break;
                        case 17:
                            hora = TimeSpan.Parse("05" + ":" + FechaInicio.Minute);
                            break;
                        case 18:
                            hora = TimeSpan.Parse("06" + ":" + FechaInicio.Minute);
                            break;
                        case 19:
                            hora = TimeSpan.Parse("07" + ":" + FechaInicio.Minute);
                            break;
                        case 20:
                            hora = TimeSpan.Parse("08" + ":" + FechaInicio.Minute);
                            break;
                        case 21:
                            hora = TimeSpan.Parse("09" + ":" + FechaInicio.Minute);
                            break;
                        case 22:
                            hora = TimeSpan.Parse("10" + ":" + FechaInicio.Minute);
                            break;
                        case 23:
                            hora = TimeSpan.Parse("11" + ":" + FechaInicio.Minute);
                            break;
                        case 24:
                            hora = TimeSpan.Parse("12" + ":" + FechaInicio.Minute);
                            break;
                        default:
                            break;
                    }

                    return (hora + "").Substring(0, 5) + " PM";
                }

                //return (TimeSpan.Parse(FechaInicio.Hour + ":" + FechaInicio.Minute) + "").Substring(0, 5);
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
                var hora = TimeSpan.Parse(FechaFin.Hour + ":" + FechaFin.Minute);

                if (hora.Hours < 13)
                {
                    return (hora + "").Substring(0, 5) + " AM";
                }
                else
                {
                    switch (hora.Hours)
                    {
                        case 13:
                            hora = TimeSpan.Parse("01" + ":" + FechaFin.Minute);
                            break;
                        case 14:
                            hora = TimeSpan.Parse("02" + ":" + FechaFin.Minute);
                            break;
                        case 15:
                            hora = TimeSpan.Parse("03" + ":" + FechaFin.Minute);
                            break;
                        case 16:
                            hora = TimeSpan.Parse("04" + ":" + FechaFin.Minute);
                            break;
                        case 17:
                            hora = TimeSpan.Parse("05" + ":" + FechaFin.Minute);
                            break;
                        case 18:
                            hora = TimeSpan.Parse("06" + ":" + FechaFin.Minute);
                            break;
                        case 19:
                            hora = TimeSpan.Parse("07" + ":" + FechaFin.Minute);
                            break;
                        case 20:
                            hora = TimeSpan.Parse("08" + ":" + FechaFin.Minute);
                            break;
                        case 21:
                            hora = TimeSpan.Parse("09" + ":" + FechaFin.Minute);
                            break;
                        case 22:
                            hora = TimeSpan.Parse("10" + ":" + FechaFin.Minute);
                            break;
                        case 23:
                            hora = TimeSpan.Parse("11" + ":" + FechaFin.Minute);
                            break;
                        case 24:
                            hora = TimeSpan.Parse("12" + ":" + FechaFin.Minute);
                            break;
                        default:
                            break;
                    }

                    return (hora + "").Substring(0, 5) + " PM";
                }
            }
        }
    }
}
