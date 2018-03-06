using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class Persona
    {
        public Int32 Id { get; set; }
        public String NombreArtistico { get; set; }
        public String NombreApellidos { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Email { get; set; }
        public String Imagen { get; set; }
        public String RedesSociales { get; set; }

        public Int32 IdOrganizacion { get; set; }
        public Organizacion Organizacion { get; set; }

        public Int32 IdOcupacionCultural { get; set; }
        public OcupacionCultural OcupacionCultural { get; set; }

        public Int32 IdProfesion { get; set; }
        public Profesion Profesion { get; set; }
        //[NotMapped]
        //public Int32 Estado { get; set; }

        public String NombreMostrar { get {
                if (!String.IsNullOrEmpty(NombreArtistico))
                {
                    return NombreApellidos + " - " + NombreArtistico;
                }
                else
                {
                    return NombreApellidos;
                }} }

        public String FechaRegistroMostrar { get
            {
                return FechaRegistro.Day + "/" + FechaRegistro.Month + "/" + FechaRegistro.Year;
            } }

        public String FechaNacimientoMostrar { get
            {
                if (FechaNacimiento.Month == 1)
                {
                    return FechaNacimiento.Day + " de Enero";
                }
                else if (FechaNacimiento.Month == 2)
                {
                    return FechaNacimiento.Day + " de Febrero";
                }
                else if (FechaNacimiento.Month == 3)
                {
                    return FechaNacimiento.Day + " de Marzo";
                }
                else if (FechaNacimiento.Month == 4)
                {
                    return FechaNacimiento.Day + " de Abril";
                }
                else if (FechaNacimiento.Month == 5)
                {
                    return FechaNacimiento.Day + " de Mayo";
                }
                else if (FechaNacimiento.Month == 6)
                {
                    return FechaNacimiento.Day + " de Junio";
                }
                else if (FechaNacimiento.Month == 7)
                {
                    return FechaNacimiento.Day + " de Julio";
                }
                else if (FechaNacimiento.Month == 8)
                {
                    return FechaNacimiento.Day + " de Agosto";
                }
                else if (FechaNacimiento.Month == 9)
                {
                    return FechaNacimiento.Day + " de Septiembre";
                }
                else if (FechaNacimiento.Month == 10)
                {
                    return FechaNacimiento.Day + " de Octubre";
                }
                else if (FechaNacimiento.Month == 11)
                {
                    return FechaNacimiento.Day + " de Noviembre";
                }
                else if (FechaNacimiento.Month == 12)
                {
                    return FechaNacimiento.Day + " de Diciembre";
                }
                else
                {
                    return FechaNacimiento.Day + "/" + FechaNacimiento.Month + "/" + FechaNacimiento.Year;
                }
            } }

        [NotMapped]
        public String ImagenTemp { get; set; }
    }
}
