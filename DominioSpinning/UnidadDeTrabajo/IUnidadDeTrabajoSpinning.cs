using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Repositorios;
using DominioSpinning.Entidades;

namespace DominioSpinning.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajoSpinning
    {

        //spining
        IRepositorio<Spinning> SpinningRepositorio { get; }

        IRepositorio<TurnoSpinning> TurnoSpinningRepositorio { get; }


        void Commit();
        void Disposed();
    }
}
