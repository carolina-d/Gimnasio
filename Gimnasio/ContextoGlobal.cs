using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioComun.Entidades;
using DominioSpinning;
using DominioSpinning.Entidades;
using InfraestructuraBase.Contexto;
using System.Data.Entity;
using DominioSeguridad.Entidades;
using Dominio.Producto.Entidades;
using Dominio.Caja.Entidades;
using Infraestructura.Caja.Contexto;



namespace Gimnasio
{
    public class ContextoGlobal : ContextoBase
    {

        #region Comun 
        private IDbSet<Membresia> _membresia;
        public System.Data.Entity.IDbSet<DominioComun.Entidades.Membresia> MEMBRESIA
        {
            get { return _membresia ?? (_membresia = Set<Membresia>()); }
            set { }
        }

        private IDbSet<DominioComun.Entidades.Promocion> _promocion;
        public IDbSet<DominioComun.Entidades.Promocion> PROMOCIONES
        {
            get { return _promocion ?? (_promocion = Set<DominioComun.Entidades.Promocion>()); }
        }
 
      
        

        private IDbSet<DatosSocio> _datosSocio;
        public IDbSet<DatosSocio> DATOSSOCIO
        {
            get { return _datosSocio ?? (_datosSocio = Set<DatosSocio>()); }
            set { }
        }

        private IDbSet<Rutina> _rutina;
        public IDbSet<Rutina> RUTINA
        {
            get { return _rutina ?? (_rutina = Set<Rutina>()); }
            set { }
        }

        private IDbSet<TipoRutina> _tipoRutinas;
        public IDbSet<TipoRutina> TIPORUTINAS
        {
            get { return _tipoRutinas ?? (_tipoRutinas = Set<TipoRutina>()); }
            set { }
        }



        private IDbSet<Clase> _tipoClases;
        public IDbSet<Clase> TIPOCLASES
        {
            get { return _tipoClases ?? (_tipoClases = Set<Clase>()); }
            set { }
        }

        private IDbSet<HorarioClase> _horarioClases;
        public IDbSet<HorarioClase> HORARIOCLASES
        {
            get { return _horarioClases ?? (_horarioClases = Set<HorarioClase>()); }
            set { }
        }

        private IDbSet<AreaGimnasio> _areaGimnasio;
        public IDbSet<AreaGimnasio> AREAGIMNASIO
        {
            get { return _areaGimnasio ?? (_areaGimnasio = Set<AreaGimnasio>()); }
            set { }
        }
   
      
      

#endregion fin comun

        #region Seguridad
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

        private IDbSet<Empleado> _empleado;
        public IDbSet<Empleado> Empleado
        {
            get { return _empleado ?? (_empleado = Set<Empleado>()); }
            set { }
        }

        private IDbSet<TipoEmpleado> _TipoEmpleado;
        public IDbSet<TipoEmpleado> TipoEmpleados
        {
            get { return _TipoEmpleado ?? (_TipoEmpleado = Set<TipoEmpleado>()); }
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

          constructor.Entity<Clase>()
               .HasMany(x => x.Socios)
               .WithMany(y => y.TipoClases)
               .Map(m => m.MapLeftKey("ClaseId")
                   .MapRightKey("SocioId")
                   .ToTable("ClaseDatosSocio"));

         /*   //creacion de tablas intermedia de HorarioSocio
            constructor.Entity<HorarioClase>()
          .HasMany(x => x.Socios)
          .WithMany(y => y.HorarioClases)
          .Map(m => m.MapLeftKey("HorarioClaseId")
              .MapRightKey("SocioId")
              .ToTable("ClaseSocio"));*/

            //creacion de tablas intermedia de MembresiaSocio
            constructor.Entity<DatosSocio>()
                .HasMany(x => x.Membresias)
                .WithMany(y => y.Socio)
                .Map(m => m.MapLeftKey("MembresiaId")
                    .MapRightKey("SocioId")
                    .ToTable("MembresiaSocio"));

            //creacion de tablas intermedia de PromocionSocio
            constructor.Entity<DatosSocio>()
                .HasMany(x => x.Promocion)
                .WithMany(y => y.Socios)
                .Map(m => m.MapLeftKey("PromocionId")
                    .MapRightKey("SocioId")
                    .ToTable("PromocionSocio"));

            //creacion de tablas intermedia de PromocionSocio
            constructor.Entity<Rutina>()
                .HasMany(x => x.Socios)
                .WithMany(y => y.Rutinas)
                .Map(m => m.MapLeftKey("RutinaId")
                    .MapRightKey("SocioId")
                    .ToTable("RutinaSocio"));

            constructor.Entity<Proveedor>()
              .HasMany(x => x.Productos)
              .WithMany(y => y.Proveedores)
              .Map(m => m.MapLeftKey("ProveedorId")
                  .MapRightKey("ProductoId")
                  .ToTable("ProveedorProducto"));
        }

#endregion

        #region Producto
        private IDbSet<Venta> _venta;
        public System.Data.Entity.IDbSet<Venta> VENTA
        {
            get { return _venta ?? (_venta = Set<Venta>()); }
            set { }
        }

        private IDbSet<DetalleVenta> _detalleVenta;
        public System.Data.Entity.IDbSet<DetalleVenta> DETALLEVENTA
        {
            get { return _detalleVenta ?? (_detalleVenta = Set<DetalleVenta>()); }
            set { }
        }

        private IDbSet<Dominio.Producto.Entidades.Producto> _producto;
        public System.Data.Entity.IDbSet<Dominio.Producto.Entidades.Producto> PRODUCTO
        {
            get { return _producto ?? (_producto = Set<Dominio.Producto.Entidades.Producto>()); }
            set { }
        }

        private IDbSet<Dominio.Producto.Entidades.Proveedor> _proveedor;
        public System.Data.Entity.IDbSet<Dominio.Producto.Entidades.Proveedor> PROVEEDOR
        {
            get { return _proveedor ?? (_proveedor = Set<Dominio.Producto.Entidades.Proveedor>()); }
            set { }
        }

        #endregion

        #region Caja


        private IDbSet<Movimiento> Movimientos;
        public IDbSet<Movimiento> MOVIMIENTO
        {
            get { return Movimientos ?? (Movimientos = Set<Movimiento>()); }
            set { }

        }

        private IDbSet<PagoCuota> PagoCuota;
        public IDbSet<PagoCuota> PAGOCUOTA
        {
            get { return PagoCuota ?? (PagoCuota = Set<PagoCuota>()); }
            set { }
        }





        private IDbSet<Pago> Pago;
        public IDbSet<Pago> PAGO
        {
            get
            {
                return Pago ?? (Pago = Set<Pago>());
            }
            set
            {

            }
        }

      // private IDbSet<Promocion> Promocion;
        //public IDbSet<Promocion> PROMOCION
        //{
          //  get { return Promocion ?? (Promocion = Set<Promocion>()); }
            //set { }
        //}
        #endregion

        #region Clase

        public IDbSet<Spinning> _Spinning;
        public System.Data.Entity.IDbSet<DominioSpinning.Spinning> SPINNING
        {
            get
            {
                return _Spinning ?? (_Spinning = Set<Spinning>());

            }
            set { }
        }

        public IDbSet<TurnoSpinning> _TurnoSpinning;
        public System.Data.Entity.IDbSet<DominioSpinning.Entidades.TurnoSpinning> TURNOSPINNING
        {
            get
            {
                return _TurnoSpinning ?? (_TurnoSpinning = Set<TurnoSpinning>());

            }
            set { }
        }




        
        #endregion






    }
}
