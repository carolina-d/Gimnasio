using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Repositorios;
using DominioComun.Entidades;

namespace DominioComun.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajoComun
    {
        IRepositorio<Membresia> MembresiaRepositorio { get; }
        IRepositorio<Promocion> PromocionRepositorio { get; }
        IRepositorio<Clase> TipoClaseRepositorio { get; }
        IRepositorio<HorarioClase> HorarioClaseRepositorio { get; }
        IRepositorio<DatosSocio> DatoSocioRepositorio { get; }
        IRepositorio<Rutina> RutinaRepositorio { get; }
        IRepositorio<TipoRutina> TipoRutinaRepositorio { get; }
        IRepositorio<AreaGimnasio> AreaGimnasioRepositorio { get; }


        void Commit();
        void Disposed();
    }
}
