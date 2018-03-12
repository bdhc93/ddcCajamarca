using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddcCajamarca.Models;
using ddcCajamarca.Repository.Directorio.Interfaces;
using ddcCajamarca.Repository.Directorio.Datos;

namespace ddcCajamarca.CreateDB
{
    class Program
    {
        static void Main(string[] args)
        {
            IOcupacionCulturalRepository _repository = new OcupacionCulturalRepository();

            Console.WriteLine("Creando DB!!!");

            var x = _repository.ObtenerOcupacionCulturalPorCriterio("",true);
            
            Console.WriteLine("Creada!!!");

        }
    }
}
