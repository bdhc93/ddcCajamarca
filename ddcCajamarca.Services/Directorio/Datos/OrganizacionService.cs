using System;
using System.Collections.Generic;
using System.Linq;
using ddcCajamarca.Repository.Directorio.Interfaces;
using ddcCajamarca.Services.Directorio.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Directorio.Datos
{
    public class OrganizacionService : IOrganizacionService
    {
        public IOrganizacionRepository organizacionRepository { get; set; }

        public OrganizacionService(IOrganizacionRepository organizacionRepository)
        {
            this.organizacionRepository = organizacionRepository;
        }

        public Organizacion ObtenerOrganizacionPorId(int id)
        {
            return organizacionRepository.ObtenerOrganizacionPorId(id);
        }

        public IEnumerable<Organizacion> ObtenerOrganizacionPorCriterio(string criterio, bool completo)
        {
            return organizacionRepository.ObtenerOrganizacionPorCriterio(criterio, completo);
        }

        public void GuardarOrganizacion(Organizacion organizacion)
        {
            organizacionRepository.GuardarOrganizacion(organizacion);
        }

        public void ModificarOrganizacion(Organizacion organizacion)
        {
            organizacionRepository.ModificarOrganizacion(organizacion);
        }

        public void EliminarOrganizacion(int id)
        {
            organizacionRepository.EliminarOrganizacion(id);
        }
    }
}
