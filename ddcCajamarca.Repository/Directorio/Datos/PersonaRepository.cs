using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ddcCajamarca.Repository.Directorio.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Directorio.Datos
{
    public class PersonaRepository : MasterRepository, IPersonaRepository
    {
        public void EliminarPersona(int id)
        {
            var elim = ObtenerPersonaPorId(id);

            Context.Personas.Remove(elim);
            Context.SaveChanges();
        }

        public void GuardarPersona(Persona persona)
        {
            Context.Personas.Add(persona);
            Context.SaveChanges();
        }

        public void ModificarPersona(Persona persona)
        {
            Context.Entry(persona).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<Persona> ObtenerPersonaPorCriterio(string criterio)
        {
            var query = from p in Context.Personas.Include("Organizacion").Include("Profesion").Include("OcupacionCultural")
                        select p;

            if (!String.IsNullOrEmpty(criterio))
            {
                query = from p in query
                        where p.NombreApellidos.ToUpper().Contains(criterio.ToUpper()) || p.NombreArtistico.ToUpper().Contains(criterio.ToUpper())
                        select p;
            }
            
            return query.OrderBy(p => p.NombreApellidos).ToList();
        }

        public IEnumerable<Persona> ObtenerPersonaPorFechaNacimiento()
        {
            var query = from p in Context.Personas select p;

            query = from p in query
                    where p.FechaNacimiento.Month == DateTime.Today.Month && (p.FechaNacimiento.Day>(DateTime.Today.Day-5) && p.FechaNacimiento.Day < (DateTime.Today.Day + 5)) && p.FechaNacimiento.Year != 0001
                    select p;

            return query.ToList();
        }

        public IEnumerable<Persona> ObtenerPersonaPorFiltro(string criterio, int IdOrganizacion, int IdOcupacion, int IdProfesion)
        {
            var query = from p in Context.Personas.Include("Organizacion").Include("Profesion").Include("OcupacionCultural")
                        select p;

            if (!String.IsNullOrEmpty(criterio))
            {
                if (IdOrganizacion != 1)
                {
                    if (IdProfesion != 1)
                    {
                        if (IdOcupacion != 1)
                        {
                            query = from p in query
                                    where (p.NombreApellidos.ToUpper().Contains(criterio.ToUpper()) || p.NombreArtistico.ToUpper().Contains(criterio.ToUpper()))
                                    && p.IdOrganizacion == IdOrganizacion && p.IdProfesion == IdProfesion && p.IdOcupacionCultural == IdOcupacion
                                    select p;
                        }
                        else
                        {
                            query = from p in query
                                    where (p.NombreApellidos.ToUpper().Contains(criterio.ToUpper()) || p.NombreArtistico.ToUpper().Contains(criterio.ToUpper()))
                                    && p.IdOrganizacion == IdOrganizacion && p.IdProfesion == IdProfesion
                                    select p;
                        }
                    }
                    else if (IdOcupacion != 1)
                    {
                        query = from p in query
                                where (p.NombreApellidos.ToUpper().Contains(criterio.ToUpper()) || p.NombreArtistico.ToUpper().Contains(criterio.ToUpper()))
                                && p.IdOrganizacion == IdOrganizacion && p.IdOcupacionCultural == IdOcupacion
                                select p;
                    }
                    else
                    {
                        query = from p in query
                                where (p.NombreApellidos.ToUpper().Contains(criterio.ToUpper()) || p.NombreArtistico.ToUpper().Contains(criterio.ToUpper()))
                                && p.IdOrganizacion == IdOrganizacion
                                select p;
                    }
                }
                else if (IdProfesion != 1)
                {
                    if (IdOcupacion != 1)
                    {
                        query = from p in query
                                where (p.NombreApellidos.ToUpper().Contains(criterio.ToUpper()) || p.NombreArtistico.ToUpper().Contains(criterio.ToUpper()))
                                && p.IdProfesion == IdProfesion && p.IdOcupacionCultural == IdOcupacion
                                select p;
                    }
                    else
                    {
                        query = from p in query
                                where (p.NombreApellidos.ToUpper().Contains(criterio.ToUpper()) || p.NombreArtistico.ToUpper().Contains(criterio.ToUpper()))
                                && p.IdProfesion == IdProfesion
                                select p;
                    }
                }
                else if (IdOcupacion != 1)
                {
                    query = from p in query
                            where (p.NombreApellidos.ToUpper().Contains(criterio.ToUpper()) || p.NombreArtistico.ToUpper().Contains(criterio.ToUpper()))
                            && p.IdOcupacionCultural == IdOcupacion
                            select p;
                }
                else
                {
                    query = from p in query
                            where p.NombreApellidos.ToUpper().Contains(criterio.ToUpper()) || p.NombreArtistico.ToUpper().Contains(criterio.ToUpper())
                            select p;
                }
            }
            else
            {
                if (IdOrganizacion != 1)
                {
                    if (IdProfesion != 1)
                    {
                        if (IdOcupacion != 1)
                        {
                            query = from p in query
                                    where p.IdOrganizacion == IdOrganizacion && p.IdProfesion == IdProfesion && p.IdOcupacionCultural == IdOcupacion
                                    select p;
                        }
                        else
                        {
                            query = from p in query
                                    where p.IdOrganizacion == IdOrganizacion && p.IdProfesion == IdProfesion
                                    select p;
                        }
                    }
                    else if (IdOcupacion != 1)
                    {
                        query = from p in query
                                where p.IdOrganizacion == IdOrganizacion && p.IdOcupacionCultural == IdOcupacion
                                select p;
                    }
                    else
                    {
                        query = from p in query
                                where p.IdOrganizacion == IdOrganizacion
                                select p;
                    }
                }
                else if (IdProfesion != 1)
                {
                    if (IdOcupacion != 1)
                    {
                        query = from p in query
                                where p.IdProfesion == IdProfesion && p.IdOcupacionCultural == IdOcupacion
                                select p;
                    }
                    else
                    {
                        query = from p in query
                                where p.IdProfesion == IdProfesion
                                select p;
                    }
                }
                else if (IdOcupacion != 1)
                {
                    query = from p in query
                            where p.IdOcupacionCultural == IdOcupacion
                            select p;
                }
            }

            return query.OrderBy(p => p.NombreApellidos).ToList();
        }

        public Persona ObtenerPersonaPorId(int id)
        {
            return Context.Personas.Find(id);
        }
    }
}
