using System;
using System.Collections.Generic;
using System.Linq;
using ddcCajamarca.Repository.Seguridad.Interfaces;
using ddcCajamarca.Services.Seguridad.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Seguridad.Datos
{
    public class webpages_RolService : Iwebpages_RolService
    {
        public Iwebpages_RolRepository webpages_RolRepository { get; set; }

        public webpages_RolService(Iwebpages_RolRepository webpages_RolRepository)
        {
            this.webpages_RolRepository = webpages_RolRepository;
        }

        public void EliminarRol(int id)
        {
            webpages_RolRepository.EliminarRol(id);
        }

        public void GuardarRol(webpages_Rol Rol)
        {
            webpages_RolRepository.GuardarRol(Rol);
        }

        public void ModificarRol(webpages_Rol Rol)
        {
            webpages_RolRepository.ModificarRol(Rol);
        }

        public IEnumerable<webpages_Rol> ObtenerRolPorCriterio(string criterio)
        {
            return webpages_RolRepository.ObtenerRolPorCriterio(criterio);
        }

        public webpages_Rol ObtenerRolPorId(int id)
        {
            return webpages_RolRepository.ObtenerRolPorId(id);
        }
    }
}
