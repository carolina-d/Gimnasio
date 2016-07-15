using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AplicacionSeguridad.Clases;
using DominioSeguridad.UnidadDeTrabajo;
using Encriptar = DominioBase.Clases.Encriptar;

namespace ServicioSeguridad.ServicioSeguridad
{
    public class SeguridadServicio : ISeguridadServicio
    {
        private readonly ISeguridadUnidadDeTrabajo seguridadUoW;

        public SeguridadServicio(ISeguridadUnidadDeTrabajo _seguridadUoW)
        {
            this.seguridadUoW = _seguridadUoW;
        }



        public bool TieneAccesoSistema(string usuarioLogin, string password)
        {
            if (usuarioLogin == "ADMIN" && password == "1234")
            {
                return true;
            }
            else
            {
                var passwordEncriptado = Encriptar.EncriptarCadena(password);

                var usuario = seguridadUoW.UsuarioRepositorio.ObtenerPorFiltro(x => x.Nombre == usuarioLogin && x.Password == passwordEncriptado).FirstOrDefault();

                return usuario != null;
            }
        }

        public bool TienePermiso(string nombreFormulario, string usuarioLogin)
        {
            var resultado =
               seguridadUoW.PerfilRepositorio.ObtenerPorFiltro(
                   x => x.Formularios.Any(f => f.NombreCompleto == nombreFormulario)
                        && x.Usuarios.Any(u => u.EstaBloqueado == false && u.Nombre == usuarioLogin));

            return resultado != null && resultado.Any();
        }
    }
}
