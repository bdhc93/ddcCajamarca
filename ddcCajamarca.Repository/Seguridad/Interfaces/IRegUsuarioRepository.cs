using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Seguridad.Interfaces
{
    public interface IRegUsuarioRepository
    {
        IEnumerable<RegUsuario> ObtenerRegUsuario(String usuario);

        void GuardarRegUsuario(RegUsuario movimiento);
    }
}
