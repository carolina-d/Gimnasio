using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Repositorios;
using Dominio.Caja.Entidades;

namespace Dominio.Caja.UnidadDeTrabajo
{
  public  interface IUnidadDeTrabajoCaja
    {
        IRepositorio<PagoCuota> PagoCueotaRepositorio { get; }
        //IRepositorio<Promocion> PromocionRepositorio { get; }
        IRepositorio<Pago> PagoRepositorio { get; }
        IRepositorio<Movimiento> MovimientoRepositorio { get; }

        void Commit();
        void Disposed();
    }
}
