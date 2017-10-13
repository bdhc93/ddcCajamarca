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
        public DateTime FechaRegistro { get; set; }

        public List<EventoEnsayo> EventoEnsayos { get; set; }
    }
}
