using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ddcCajamarca.Repository.Directorio.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Directorio.Datos
{
    public class OcupacionCulturalRepository : MasterRepository, IOcupacionCulturalRepository
    {
        public void EliminarOcupacionCultural(int id)
        {
            var elim = ObtenerComercialPorId(id);

            elim.Estado = false;
            Context.Entry(elim).State = EntityState.Modified;
            Context.SaveChanges();
            //Context.OcupacionCulturales.Remove(elim);
            //Context.SaveChanges();
        }

        public void GuardarOcupacionCultural(OcupacionCultural ocupacionCultural)
        {
            ocupacionCultural.Estado = true;
            Context.OcupacionCulturales.Add(ocupacionCultural);
            Context.SaveChanges();
        }

        public void ModificarOcupacionCultural(OcupacionCultural ocupacionCultural)
        {
            ocupacionCultural.Estado = true;
            Context.Entry(ocupacionCultural).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public OcupacionCultural ObtenerComercialPorId(int id)
        {
            return Context.OcupacionCulturales.Find(id);
        }

        public IEnumerable<OcupacionCultural> ObtenerOcupacionCulturalPorCriterio(string criterio, bool completo)
        {
            if (completo)
            {
                if (!String.IsNullOrEmpty(criterio))
                {
                    return Context.OcupacionCulturales
                        .Where(p => p.Nombre.ToUpper().Contains(criterio.ToUpper()) && p.Estado == true)
                        .OrderBy(p => p.Nombre)
                        .ToList();
                }
                return Context.OcupacionCulturales.Where(p => p.Estado == true).OrderBy(p => p.Nombre).ToList();
            }
            else
            {
                if (!String.IsNullOrEmpty(criterio))
                {
                    return Context.OcupacionCulturales.Where(p => p.Nombre.ToUpper().Contains(criterio.ToUpper())
                    && p.Nombre.ToUpper() != "DESCONOCIDA" && p.Estado == true).OrderBy(p => p.Nombre).ToList();
                }
                return Context.OcupacionCulturales.Where(p => p.Nombre.ToUpper() != "DESCONOCIDA" && p.Estado == true).OrderBy(p => p.Nombre).ToList();
            }
        }
    }
}
