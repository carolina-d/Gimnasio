using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioComun.Entidades;

namespace InfraestructuraComun.Contexto
{
    public interface IContextoComun
    {
       
        IDbSet<DatosSocio> DATOSSOCIO { get; set; }

        IDbSet<Rutina> RUTINA { get; set; }
        IDbSet<TipoRutina> TIPORUTINA { get; set; }


       IDbSet<Membresia> MEMBRESIA { get; set; }

       IDbSet<Promocion> PROMOCION { get; set; }

       IDbSet<Clase> TIPOCLASE { get; set; }
       IDbSet<HorarioClase> HORARIOCLASES { get; set; }

       IDbSet<AreaGimnasio> AREAGIMNASIO { get; set; } 

    }
}
