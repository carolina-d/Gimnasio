using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSeguridad.Entidades;


namespace InfraestructuraSeguridad.Contexto
{
    public interface IContextoSeguridad
    {
       // IDbSet<Usuario> Usuario { get; set; }
       // IDbSet<Perfil> Perfil { get; set; }
       // IDbSet<Formulario> Formulario { get; set; }
        
        IDbSet<TipoEmpleado> TipoEmpleado { get; set; }

        IDbSet<Usuario> Usuario { get; set; }
        IDbSet<Perfil> Perfil { get; set; }
        IDbSet<Formulario> Formulario { get; set; }
        IDbSet<Empleado> Empleado { get; set; }
        
    }
}
