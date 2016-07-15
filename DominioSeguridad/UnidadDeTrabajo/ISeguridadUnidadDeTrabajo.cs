using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Repositorios;
using DominioSeguridad.Entidades;


namespace DominioSeguridad.UnidadDeTrabajo
{
    public interface ISeguridadUnidadDeTrabajo
    {
        
        IRepositorio<TipoEmpleado>TipoEmpleadoRepositorio { get; }
        IRepositorio<Empleado> EmpleadoRepositorio { get; }
       IRepositorio<Usuario> UsuarioRepositorio { get; }
        IRepositorio<Perfil> PerfilRepositorio { get; }
        IRepositorio<Formulario> FormularioRepositorio { get; }

        void Commit();
        void Disposed();

      
    }
}
