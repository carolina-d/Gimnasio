using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Caja.Entidades;
using Dominio.Caja.UnidadDeTrabajo;
using System.Data.Entity;
using InfraestructuraBase.Repositorios;
using Infraestructura.Caja.Contexto;
using DominioBase.Repositorios;

namespace Infraestructura.Caja.UnidadDeTrabajo
{
    public class UnidadDeTrabajoCaja : Dominio.Caja.UnidadDeTrabajo.IUnidadDeTrabajoCaja
    {
        private readonly ContextoCaja _contexto;

        public UnidadDeTrabajoCaja(ContextoCaja contexto)
        {
            _contexto = contexto;
        }

       

        //private IRepositorio<Promocion> _promocionRepositorio;
        //public IRepositorio<Promocion> PromocionRepositorio
        //{
        //    get { return _promocionRepositorio ?? (_promocionRepositorio = new Repositorio<Promocion>(_contexto)); }
        //}

        private IRepositorio<PagoCuota> PagoCuotaRepositorio;
        public IRepositorio<PagoCuota> PagoCueotaRepositorio
        {
            get { return PagoCuotaRepositorio ?? (PagoCuotaRepositorio = new Repositorio<PagoCuota>(_contexto)); }
        }

        private IRepositorio<Pago> pagoRepositorio;
        public IRepositorio<Pago> PagoRepositorio
        {
            get { return pagoRepositorio ?? (pagoRepositorio = new Repositorio<Pago>(_contexto)); }

        }

        private IRepositorio<Movimiento> movimientoRepositorio;
        public IRepositorio<Movimiento> MovimientoRepositorio
        {
            get { return movimientoRepositorio ?? (movimientoRepositorio = new Repositorio<Movimiento>(_contexto)); }

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
