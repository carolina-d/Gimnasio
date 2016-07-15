using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Dominio.Caja.Entidades;

namespace Infraestructura.Caja.Contexto
{
    public interface IConextoCaja
    {
        IDbSet<PagoCuota> PAGOCUOTA { get; set; }
        //IDbSet<Promocion> PROMOCION { get; set; }
        IDbSet<Pago> PAGO { get; set; }
        IDbSet<Movimiento> MOVIMIENTO { get; set; }
    }
}
