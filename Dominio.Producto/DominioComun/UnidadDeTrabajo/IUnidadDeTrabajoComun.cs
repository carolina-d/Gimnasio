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
       
        IRepositorio<DatosSocio> DatosSocioRepositorio { get; }

        //Rutina repositorio
        IRepositorio<Rutina> RutinaRepositorio { get; }
        IRepositorio<TipoRutina> TiporutinaRepositorio { get; }

        //repositorio clase
        IRepositorio<Clase> TipoClaseRepositorio { get; }
        IRepositorio<HorarioClase> HorarioRepositorio { get; }

        //Membresia
        IRepositorio<Membresia> MembresiaRepositorio { get; }
 
        //Promocion
        IRepositorio<Promocion> PromocionRepositorio { get; } 

        
        //Area Gimnasio
        IRepositorio<AreaGimnasio> AreaGimnasioRepositorio { get; } 

        void Commit();
        void Disposed();
    }
}
