using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddcCajamarca.Models
{
    public class Ambiente
    {
        public Ambiente()
        {
            this.EventoEnsayos = new List<EventoEnsayo>();
        }

        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Aforo { get; set; }
        public String Color { get; set; }
        public DateTime FechaRegistro { get; set; }

        public List<EventoEnsayo> EventoEnsayos { get; set; }


        public String FechaRegistroMostrar { get { return FechaRegistro.Day + "/" + FechaRegistro.Month + "/" + FechaRegistro.Year; } }

        public String NombreMostrar
        {
            get
            {
                if (Aforo != 0)
                {
                    return Nombre + " - Aforo: " + Aforo;
                }
                else
                {
                    return Nombre;
                }
            }
        }

        public String ColorNombre
        {
            get
            {
                var color = Color;

                if (color == "Azul")
                {
                    color = "#2591F6";
                }
                else if (color == "Amarillo")
                {
                    color = "#EAE54E";
                }
                else if (color == "Berenjena")
                {
                    color = "#5D0560";
                }
                else if (color == "Celeste")
                {
                    color = "#66C4E5";
                }
                else if (color == "Chicle")
                {
                    color = "#F5D4F4";
                }
                else if (color == "Cielo")
                {
                    color = "#27F8F5";
                }
                else if (color == "Ciruela")
                {
                    color = "#A023A4";
                }
                else if (color == "Fresa")
                {
                    color = "#F31ADE";
                }
                else if (color == "Limon")
                {
                    color = "#F4DA18";
                }
                else if (color == "Orquidea")
                {
                    color = "#8D7CCA";
                }
                else if (color == "Musgo")
                {
                    color = "#337352";
                }
                else if (color == "Magenta")
                {
                    color = "#C352D4";
                }
                else if (color == "Morado")
                {
                    color = "#F00C82";
                }
                else if (color == "Naranja")
                {
                    color = "#E79742";
                }
                else if (color == "Rosa")
                {
                    color = "#EE79E3";
                }
                else if (color == "Rojo")
                {
                    color = "#FF0000";
                }
                else if (color == "Rojo Oscuro")
                {
                    color = "#8A0808";
                }
                else if (color == "Trebol")
                {
                    color = "#397402";
                }
                else if (color == "Verde")
                {
                    color = "#50B258";
                }
                else
                {
                    color = "#2591F6";
                }

                return color;
            }
        }
    }
}
