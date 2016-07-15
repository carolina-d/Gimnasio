using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Caja.Contexto;
using Dominio.Caja.Entidades;
using Dominio.Caja.UnidadDeTrabajo;
using DominioBase.Repositorios;
using InfraestructuraBase.Contexto;
using InfraestructuraBase.Repositorios;
using System.Data.Entity;
using Infraestructura.Caja.Contexto;

namespace Infraestructura.Caja.Contexto
{
    public class ContextoCaja : InfraestructuraBase.Contexto.ContextoBase, IConextoCaja

    {

        //private IDbSet<Venta> _venta;
        //public System.Data.Entity.IDbSet<Venta> VENTA
        //{
        //    get { return _venta ?? (_venta = Set<Venta>()); }
        //    set { }
        //

        private IDbSet<Movimiento> Movimiento;
        public IDbSet<Movimiento> MOVIMIENTO
        {
            get { return Movimiento ?? (Movimiento = Set<Movimiento>()); }
            set { }

        }

        private IDbSet<PagoCuota> PagoCuota;
        public IDbSet<PagoCuota> PAGOCUOTA
        {
            get { return PagoCuota ?? (PagoCuota = Set<PagoCuota>()); }
            set { }
        }

       // private IDbSet<Promocion> Promocion;
       // public IDbSet<Promocion> PROMOCION
       // {
       //     get { return Promocion ?? (Promocion = Set<Promocion>()); }
       //     set { }
       // }

        private IDbSet<Pago> Pago;
        public IDbSet<Pago> PAGO
        {
            get { return Pago ?? (Pago = Set<Pago>()); }
            set { }

        }
    }
}
