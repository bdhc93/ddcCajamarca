﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            this.DetalleHorasEventos = new List<DetalleHorasEvento>();
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

        public Boolean Lunes { get; set; }
        public Boolean Martes { get; set; }
        public Boolean Miercoles { get; set; }
        public Boolean Jueves { get; set; }
        public Boolean Viernes { get; set; }
        public Boolean Sabado { get; set; }
        public Boolean Domingo { get; set; }

        public Int32 IdAmbiente { get; set; }
        public Ambiente Ambiente { get; set; }

        public List<DetalleRequerimiento> DetalleRequerimientos { get; set; }
        public List<DetalleHorasEvento> DetalleHorasEventos { get; set; }

        public Boolean Estado { get; set; }
        
        [NotMapped]
        public String FechaRegistroMDA
        {
            get
            {
                return FechaRegistro.Month + "/" + FechaRegistro.Day + "/" + FechaRegistro.Year;
            }
        }

        [NotMapped]
        public String EventoMostrar { get {
                if (Evento)
                {
                    return "EVENTO";
                }
                else
                {
                    return "ENSAYO";
                }
            } }

        [NotMapped]
        public String FechaInicioMostrar
        {
            get
            {
                if (FechaInicio.Day < 10)
                {
                    if (FechaInicio.Month < 10)
                    {
                        return "0" + FechaInicio.Month + "/0" + FechaInicio.Day + "/" + FechaInicio.Year;
                    }
                    else
                    {
                        return FechaInicio.Month + "/0" + FechaInicio.Day + "/" + FechaInicio.Year;
                    }
                }
                else
                {
                    if (FechaInicio.Month < 10)
                    {
                        return "0" + FechaInicio.Month + "/" + FechaInicio.Day + "/" + FechaInicio.Year;
                    }
                    else
                    {
                        return FechaInicio.Month + "/" + FechaInicio.Day + "/" + FechaInicio.Year;
                    }
                }
            }
        }

        [NotMapped]
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
            }
        }

        [NotMapped]
        public String FechaFinMostrar
        {
            get
            {
                if (FechaFin.Day < 10)
                {
                    if (FechaFin.Month < 10)
                    {
                        return "0" + FechaFin.Month + "/0" + FechaFin.Day + "/" + FechaFin.Year;
                    }
                    else
                    {
                        return FechaFin.Month + "/0" + FechaFin.Day + "/" + FechaFin.Year;
                    }
                }
                else
                {
                    if (FechaFin.Month < 10)
                    {
                        return "0" + FechaFin.Month + "/" + FechaFin.Day + "/" + FechaFin.Year;
                    }
                    else
                    {
                        return FechaFin.Month + "/" + FechaFin.Day + "/" + FechaFin.Year;
                    }
                }
            }
        }

        [NotMapped]
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
