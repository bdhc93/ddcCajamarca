﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ddcCajamarca.Repository.Directorio.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Directorio.Datos
{
    public class OrganizacionRepository : MasterRepository, IOrganizacionRepository
    {
        public void EliminarOrganizacion(int id)
        {
            var elim = ObtenerOrganizacionPorId(id);

            elim.Estado = false;
            Context.Entry(elim).State = EntityState.Modified;
            Context.SaveChanges();
            //Context.Organizaciones.Remove(elim);
            //Context.SaveChanges();
        }

        public void GuardarOrganizacion(Organizacion organizacion)
        {
            organizacion.Estado = true;
            Context.Organizaciones.Add(organizacion);
            Context.SaveChanges();
        }

        public void ModificarOrganizacion(Organizacion organizacion)
        {
            organizacion.Estado = true;
            Context.Entry(organizacion).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<Organizacion> ObtenerOrganizacionPorCriterio(string criterio, bool completo)
        {
            if (completo)
            {
                if (!String.IsNullOrEmpty(criterio))
                {
                    return Context.Organizaciones.Where(p => p.Nombre.ToUpper().Contains(criterio.ToUpper()) && p.Estado == true).OrderBy(p => p.Nombre).ToList();
                }
                return Context.Organizaciones.Where(p => p.Estado == true).OrderBy(p => p.Nombre).ToList();
            }
            else
            {
                if (!String.IsNullOrEmpty(criterio))
                {
                    return Context.Organizaciones.Where(p => p.Nombre.ToUpper().Contains(criterio.ToUpper())
                    && p.Nombre.ToUpper() != "DESCONOCIDA" && p.Estado == true).OrderBy(p => p.Nombre).ToList();
                }
                return Context.Organizaciones.Where(p => p.Nombre.ToUpper() != "DESCONOCIDA" && p.Estado == true).OrderBy(p => p.Nombre).ToList();
            }
        }

        public Organizacion ObtenerOrganizacionPorId(int id)
        {
            return Context.Organizaciones.Find(id);
        }
    }
}
