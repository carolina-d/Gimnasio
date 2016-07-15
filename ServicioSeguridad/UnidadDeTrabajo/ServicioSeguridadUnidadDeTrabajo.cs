using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSeguridad.UnidadDeTrabajo;
using ServicioSeguridad.ServicioFormulario;
using ServicioSeguridad.ServicioFormularioPerfil;
using ServicioSeguridad.ServicioSeguridad;
using ServicioSeguridad.ServicioUsuario;
using ServicioSeguridad.ServicioUsuarioPerfil;
using StructureMap;

namespace ServicioSeguridad.UnidadDeTrabajo
{
    public class ServicioSeguridadUnidadDeTrabajo : IServicioSeguridadUnidadDeTrabajo
    {
        private readonly ISeguridadUnidadDeTrabajo seguridadUoW;

        public ServicioSeguridadUnidadDeTrabajo(ISeguridadUnidadDeTrabajo _seguridadUoW)
        {
            this.seguridadUoW = _seguridadUoW;
        }

        private IUsuarioServicio _usuarioServicio;
        public IUsuarioServicio UsuarioServicio
        {
            get { return _usuarioServicio ?? (_usuarioServicio = ObjectFactory.GetInstance<IUsuarioServicio>()); }
        }

        private ISeguridadServicio _seguridadServicio;
        public ISeguridadServicio SeguridadServicio
        {
            get { return _seguridadServicio ?? (_seguridadServicio = ObjectFactory.GetInstance<ISeguridadServicio>()); }
        }

        private IFormularioServicio _formularioServicio;
        public IFormularioServicio FormularioServicio
        {
            get { return _formularioServicio ?? (_formularioServicio = ObjectFactory.GetInstance<IFormularioServicio>()); }
        }

        private IUsuarioPerfilServicio _usuarioPerfilServicio;
        public IUsuarioPerfilServicio UsuarioPerfilServicio
        {
            get { return _usuarioPerfilServicio ?? (_usuarioPerfilServicio = ObjectFactory.GetInstance<IUsuarioPerfilServicio>()); }
        }

        private IFormularioPerfilServicio _formularioPerfilServicio;
        public IFormularioPerfilServicio FormularioPerfilServicio
        {
            get { return _formularioPerfilServicio ?? (_formularioPerfilServicio = ObjectFactory.GetInstance<IFormularioPerfilServicio>()); }
        }
    }
}

