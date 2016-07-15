using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSeguridad.Entidades;

using InfraestructuraBase.Contexto;

namespace InfraestructuraSeguridad.Contexto
{
    public class ContextoSeguridad : ContextoBase, IContextoSeguridad
    {

        private IDbSet<TipoEmpleado> _tipoEmpleado;
        public IDbSet<TipoEmpleado> TipoEmpleado
        {
            get { return _tipoEmpleado ?? (_tipoEmpleado = Set<TipoEmpleado>()); }
            set { }
        }

        private IDbSet<Empleado> _empleado;
        public IDbSet<Empleado> Empleado
        {
            get { return _empleado ?? (_empleado = Set<Empleado>()); }
            set { }
        }

        private IDbSet<Usuario> _usuario;
        public IDbSet<Usuario> Usuario
        {
            get { return _usuario ?? (_usuario = Set<Usuario>()); }
            set { }
        }


        private IDbSet<Perfil> _perfil;
        public IDbSet<Perfil> Perfil
        {
            get { return _perfil ?? (_perfil = Set<Perfil>()); }
            set { }
        }


        private IDbSet<Formulario> _formulario;
        public IDbSet<Formulario> Formulario
        {
            get { return _formulario ?? (_formulario = Set<Formulario>()); }
            set { }
        }

        protected override void OnModelCreating(DbModelBuilder constructor)
        {
            base.OnModelCreating(constructor);

            constructor.Entity<Usuario>()
                .HasMany(x => x.Perfiles)
                .WithMany(y => y.Usuarios)
                .Map(m => m.MapLeftKey("UsuarioId")
                    .MapRightKey("PerfilId")
                    .ToTable("PerfilUsuario"));

            constructor.Entity<Formulario>()
                .HasMany(x => x.Perfiles)
                .WithMany(y => y.Formularios)
                .Map(m => m.MapLeftKey("FormularioId")
                    .MapRightKey("PerfilId")
                    .ToTable("PerfilFormulario"));
        }
    }
}
