using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Repositorios;
using DominioSpinning;
using DominioSpinning.Entidades;
using DominioSpinning.UnidadDeTrabajo;
using InfraestructuraBase.Repositorios;
using InfraestructuraSpnning.Contexto;

namespace InfraestructuraSpnning.UnidadDeTrabajo
{
    public class UnidadDeTrabajoSpnning: IUnidadDeTrabajoSpinning
    {

         private readonly ContextoSpinning _contexto;

         public UnidadDeTrabajoSpnning(ContextoSpinning contexto)
        {
            _contexto = contexto;
        }

         private IRepositorio<Spinning> _spinningRepositorio;
        public DominioBase.Repositorios.IRepositorio<DominioSpinning.Spinning> SpinningRepositorio
        {
            get { return _spinningRepositorio ?? (_spinningRepositorio = new Repositorio<Spinning>(_contexto)); }
        }

        private IRepositorio<TurnoSpinning> _turnospinningRepositorio;

        public IRepositorio<DominioSpinning.Entidades.TurnoSpinning> TurnoSpinningRepositorio
        {
            get { return _turnospinningRepositorio ?? (_turnospinningRepositorio = new Repositorio<TurnoSpinning>(_contexto)); }

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
