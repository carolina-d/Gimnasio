using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InfraestructuraBase.Contexto;
using InfraestructuraBase.Repositorios;
using Dominio.Producto.Entidades;
using Dominio.Producto.UnidadDeTrabajo;

namespace Infraestructura.Producto.Contexto
{
    public class ContextoProducto : ContextoBase, IContextoProducto
    {
        private IDbSet<Venta> _venta;
        public System.Data.Entity.IDbSet<Venta> VENTA
        {
            get { return _venta ?? (_venta = Set<Venta>()); }
            set { }
        }

        private IDbSet<DetalleVenta> _detalleVenta;
        public System.Data.Entity.IDbSet<DetalleVenta> DETALLEVENTA
        {
            get { return _detalleVenta ?? (_detalleVenta = Set<DetalleVenta>()); }
            set { }
        }

        private IDbSet<Dominio.Producto.Entidades.Producto> _producto;
        public System.Data.Entity.IDbSet<Dominio.Producto.Entidades.Producto> PRODUCTO
        {
            get { return _producto ?? (_producto = Set<Dominio.Producto.Entidades.Producto>()); }
            set { }
        }

        private IDbSet<Dominio.Producto.Entidades.Proveedor> _proveedor;
        public System.Data.Entity.IDbSet<Dominio.Producto.Entidades.Proveedor> PROVEEDOR
        {
            get { return _proveedor ?? (_proveedor = Set<Dominio.Producto.Entidades.Proveedor>()); }
            set { }
        }

        
    }
}
