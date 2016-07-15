using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioComun.Entidades;
using InfraestructuraBase.Contexto;

namespace InfraestructuraComun.Contexto
{
    public class ContextoComun: ContextoBase, IContextoComun
    {
        private IDbSet<Membresia> _membresia;
        public System.Data.Entity.IDbSet<DominioComun.Entidades.Membresia> MEMBRESIA    
        {
            get { return _membresia ?? (_membresia = Set<Membresia>()); }
            set { }
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

    

        private IDbSet<Clase> _tipoClases;
        public IDbSet<Clase> TIPOCLASE
        {
            get
            {
                return _tipoClases ?? (_tipoClases = Set<Clase>());
            }
            set
            {

            }
        }

 
        public IDbSet<HorarioClase> _HorarioClases;
        public IDbSet<HorarioClase> HORARIOCLASES
        {
            get
            {
                return _HorarioClases ?? (_HorarioClases = Set<HorarioClase>());
            }
            set {}
        }

        private IDbSet<TipoRutina> _TipoRutinas; 
        public IDbSet<TipoRutina> TIPORUTINA
        {
            get
            {
                return _TipoRutinas ?? (_TipoRutinas = Set<TipoRutina>());
            }
            set{}
        }

        private IDbSet<Promocion> _Promocion; 
        public IDbSet<Promocion> PROMOCION
        {
            get
            {
                return _Promocion ?? (_Promocion = Set<Promocion>());
            }
            set
            {
                
            }
        }

        private IDbSet<AreaGimnasio> _areaGimnasio;
        public IDbSet<AreaGimnasio> AREAGIMNASIO
        {
            get { return _areaGimnasio ?? (_areaGimnasio = Set<AreaGimnasio>()); }
            set { }
        }


        protected override void OnModelCreating(DbModelBuilder constructor)
        {
            base.OnModelCreating(constructor);

    
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

            //creacion de tablas intermedia de RutinaSocio
            constructor.Entity<Rutina>()
                .HasMany(x => x.Socios)
                .WithMany(y => y.Rutinas)
                .Map(m => m.MapLeftKey("RutinaId")
                    .MapRightKey("SocioId")
                    .ToTable("RutinaSocio"));

            //creacion de tablas intermedia de HorarioSocio
            constructor.Entity<Clase>()
          .HasMany(x => x.Socios)
          .WithMany(y => y.TipoClases)
          .Map(m => m.MapLeftKey("ClaseId")
              .MapRightKey("SocioId")
              .ToTable("ClaseDatosSocio"));
            
        }




       
    }
}
