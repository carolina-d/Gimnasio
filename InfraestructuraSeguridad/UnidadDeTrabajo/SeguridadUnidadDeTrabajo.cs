using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Repositorios;
using DominioSeguridad.Entidades;
using DominioSeguridad.UnidadDeTrabajo;

using InfraestructuraBase.Repositorios;
using InfraestructuraSeguridad.Contexto;

namespace InfraestructuraSeguridad.UnidadDeTrabajo
{
    public class SeguridadUnidadDeTrabajo : ISeguridadUnidadDeTrabajo
    {
        private readonly ContextoSeguridad _contexto;

        public SeguridadUnidadDeTrabajo(ContextoSeguridad contexto)
        {
            _contexto = contexto;
        }

       
        private IRepositorio<Empleado> _empleadoRepositorio;
        public IRepositorio<Empleado> EmpleadoRepositorio
        {
            get { return _empleadoRepositorio ?? (_empleadoRepositorio = new Repositorio<Empleado>(_contexto)); }
        }

        private IRepositorio<TipoEmpleado> _tipoEmpleadoRepositorio; 
        public IRepositorio<TipoEmpleado> TipoEmpleadoRepositorio
        {
            get
            {
                return _tipoEmpleadoRepositorio ?? (_tipoEmpleadoRepositorio = new Repositorio<TipoEmpleado>(_contexto));
            }
        }


      

        // Repositorios
        private IRepositorio<Usuario> _usuarioRepositorio;
        public IRepositorio<Usuario> UsuarioRepositorio
        {
            get { return _usuarioRepositorio ?? (_usuarioRepositorio = new Repositorio<Usuario>(_contexto)); }
        }

        private IRepositorio<Perfil> _perfilRepositorio;
        public IRepositorio<Perfil> PerfilRepositorio
        {
            get { return _perfilRepositorio ?? (_perfilRepositorio = new Repositorio<Perfil>(_contexto)); }
        }

        private IRepositorio<Formulario> _formularioRepositorio;
        public IRepositorio<Formulario> FormularioRepositorio
        {
            get { return _formularioRepositorio ?? (_formularioRepositorio = new Repositorio<Formulario>(_contexto)); }
        }

      

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public void Disposed()
        {
            _contexto.Dispose();
        }
    }
}
