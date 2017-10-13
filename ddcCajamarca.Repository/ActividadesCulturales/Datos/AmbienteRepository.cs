using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ddcCajamarca.Repository.ActividadesCulturales.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.ActividadesCulturales.Datos
{
    public class AmbienteRepository : MasterRepository, IAmbienteRepository
    {
        public void EliminarAmbiente(int id)
        {
            var elim = ObtenerAmbientePorId(id);

            Context.Ambientes.Remove(elim);
            Context.SaveChanges();
        }

        public void GuardarAmbiente(Ambiente ambiente)
        {
            Context.Ambientes.Add(ambiente);
            Context.SaveChanges();
        }

        public void ModificarAmbiente(Ambiente ambiente)
        {
            Context.Entry(ambiente).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<Ambiente> ObtenerAmbientePorCriterio(string criterio)
        {
            if (!String.IsNullOrEmpty(criterio))
            {
                return Context.Ambientes.Where(p => p.Nombre.ToUpper().Contains(criterio.ToUpper())).OrderBy(p => p.Nombre).ToList();
            }
            return Context.Ambientes.OrderBy(p => p.Nombre).ToList();
        }

        public Ambiente ObtenerAmbientePorId(int id)
        {
            return Context.Ambientes.Find(id);
        }
    }
}
