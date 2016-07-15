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
    public interface IContextoSpinning
    {

        IDbSet<Spinning> SPINNING { get; set; }
        IDbSet<TurnoSpinning> TURNOSPINNING { get; set; }
    }
}
