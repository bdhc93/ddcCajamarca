using System;
using System.Collections.Generic;
using System.Linq;
using ddcCajamarca.Repository.Seguridad.Interfaces;
using ddcCajamarca.Services.Seguridad.Interfaces;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Seguridad.Datos
{
    public class RegUsuarioService : IRegUsuarioService
    {
        public IRegUsuarioRepository regUsuarioRepository { get; set; }

        public RegUsuarioService(IRegUsuarioRepository regUsuarioRepository)
        {
            this.regUsuarioRepository = regUsuarioRepository;
        }

        public void GuardarRegUsuario(RegUsuario movimiento)
        {
            regUsuarioRepository.GuardarRegUsuario(movimiento);
        }

        public IEnumerable<RegUsuario> ObtenerRegUsuario(string usuario)
        {
            return regUsuarioRepository.ObtenerRegUsuario(usuario);
        }
    }
}
