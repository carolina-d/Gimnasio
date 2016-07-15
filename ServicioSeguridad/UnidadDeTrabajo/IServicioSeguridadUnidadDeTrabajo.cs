using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioSeguridad.ServicioFormulario;
using ServicioSeguridad.ServicioFormularioPerfil;
using ServicioSeguridad.ServicioSeguridad;
using ServicioSeguridad.ServicioUsuario;
using ServicioSeguridad.ServicioUsuarioPerfil;

namespace ServicioSeguridad.UnidadDeTrabajo
{
    public interface IServicioSeguridadUnidadDeTrabajo
    {
        IUsuarioServicio UsuarioServicio { get; }
        ISeguridadServicio SeguridadServicio { get; }
        IFormularioServicio FormularioServicio { get; }
        IUsuarioPerfilServicio UsuarioPerfilServicio { get; }
        IFormularioPerfilServicio FormularioPerfilServicio { get; }
    }
}

