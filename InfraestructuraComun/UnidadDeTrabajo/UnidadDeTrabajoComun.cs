using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Repositorios;
using DominioComun.Entidades;
using DominioComun.UnidadDeTrabajo;
using InfraestructuraBase.Repositorios;
using InfraestructuraComun.Contexto;

namespace InfraestructuraComun.UnidadDeTrabajo
{
    public class UnidadDeTrabajoComun: IUnidadDeTrabajoComun
    {

         private readonly ContextoComun _contexto;

        public UnidadDeTrabajoComun(ContextoComun contexto)
        {
            _contexto = contexto;
        }

        private IRepositorio<Membresia> _membresiaRepositorio; 
        public DominioBase.Repositorios.IRepositorio<DominioComun.Entidades.Membresia> MembresiaRepositorio
        {
            get { return _membresiaRepositorio ?? (_membresiaRepositorio = new Repositorio<Membresia>(_contexto)); }
            

        }

        private IRepositorio<Promocion> _promocionRepositorio; 
        public DominioBase.Repositorios.IRepositorio<DominioComun.Entidades.Promocion> PromocionRepositorio
        {
            get { return _promocionRepositorio ?? (_promocionRepositorio = new Repositorio<Promocion>(_contexto)); }

        }

        private IRepositorio<Clase> _tipoClaseRepositorio; 
        public DominioBase.Repositorios.IRepositorio<DominioComun.Entidades.Clase> TipoClaseRepositorio
        {
            get { return _tipoClaseRepositorio ?? (_tipoClaseRepositorio = new Repositorio<Clase>(_contexto)); }
            
        }

        private IRepositorio<HorarioClase> _horarioClaseRepositorio; 
        public DominioBase.Repositorios.IRepositorio<DominioComun.Entidades.HorarioClase> HorarioClaseRepositorio
        {
            get { return _horarioClaseRepositorio ?? (_horarioClaseRepositorio = new Repositorio<HorarioClase>(_contexto)); }
            
        }

        private IRepositorio<DatosSocio> _datoSocioRepositorio; 
        public DominioBase.Repositorios.IRepositorio<DominioComun.Entidades.DatosSocio> DatoSocioRepositorio
        {
            get { return _datoSocioRepositorio ?? (_datoSocioRepositorio = new Repositorio<DatosSocio>(_contexto)); }

        }

        private IRepositorio<Rutina> _rutinaRepositorio; 
        public DominioBase.Repositorios.IRepositorio<DominioComun.Entidades.Rutina> RutinaRepositorio
        {
            get { return _rutinaRepositorio ?? (_rutinaRepositorio = new Repositorio<Rutina>(_contexto)); }

        }


        private IRepositorio<TipoRutina> _tiporutinaRepositorio; 
        public DominioBase.Repositorios.IRepositorio<DominioComun.Entidades.TipoRutina> TipoRutinaRepositorio
        {
            get { return _tiporutinaRepositorio ?? (_tiporutinaRepositorio = new Repositorio<TipoRutina>(_contexto)); }

        }

        private IRepositorio<AreaGimnasio> _areaGimnasioRepositorio; 
        public DominioBase.Repositorios.IRepositorio<DominioComun.Entidades.AreaGimnasio> AreaGimnasioRepositorio
        {
            get { return _areaGimnasioRepositorio ?? (_areaGimnasioRepositorio= new Repositorio<AreaGimnasio>(_contexto)); }
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
