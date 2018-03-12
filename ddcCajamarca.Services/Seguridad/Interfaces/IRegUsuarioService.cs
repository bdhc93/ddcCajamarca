using System;
using System.Collections.Generic;
using ddcCajamarca.Models;

namespace ddcCajamarca.Services.Seguridad.Interfaces
{
    public interface IRegUsuarioService
    {
        IEnumerable<RegUsuario> ObtenerRegUsuario(String usuario);

        void GuardarRegUsuario(RegUsuario movimiento);
    }
}
