using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSpinning;
using DominioSpinning.Entidades;
using InfraestructuraBase.Contexto;

namespace InfraestructuraSpnning.Contexto
{
    public class ContextoSpinning: ContextoBase, IContextoSpinning
    {

        public IDbSet<Spinning> _Spinning;
        public System.Data.Entity.IDbSet<DominioSpinning.Spinning> SPINNING
        {
            get
            {
                return _Spinning ?? (_Spinning = Set<Spinning>());

            }
            set {}
        }

        protected override void OnModelCreating(DbModelBuilder constructor)
        {
        }

        public IDbSet<TurnoSpinning> _TurnoSpinning;

        public IDbSet<DominioSpinning.Entidades.TurnoSpinning> TURNOSPINNING
        {
            get
            {
                return _TurnoSpinning ?? (_TurnoSpinning = Set<TurnoSpinning>());

            }
            set { }
        }
    }
}
