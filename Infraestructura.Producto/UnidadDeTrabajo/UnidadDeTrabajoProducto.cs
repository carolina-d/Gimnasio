using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Repositorios;
using Dominio.Producto.Entidades;
using Dominio.Producto.UnidadDeTrabajo;
using InfraestructuraBase.Repositorios;
using Infraestructura.Producto.Contexto;


namespace Infraestructura.Producto.UnidadDeTrabajo
{
    public class UnidadDeTrabajoProducto : IUnidadDeTabajoProducto
    {
        private readonly ContextoProducto _contexto;

        public UnidadDeTrabajoProducto(ContextoProducto contexto)
        {
            _contexto = contexto;
        }
        


        private IRepositorio<Venta> _ventaRepositorio;
        public IRepositorio<Venta> VentaRepositorio
        {
            get { return _ventaRepositorio ?? (_ventaRepositorio = new Repositorio<Venta>(_contexto)); }
        }

       

        private IRepositorio<Dominio.Producto.Entidades.Producto> _productoRepositorio;
        public IRepositorio<Dominio.Producto.Entidades.Producto> ProductoRepositorio
        {
            get { return _productoRepositorio ?? (_productoRepositorio = new Repositorio<Dominio.Producto.Entidades.Producto>(_contexto)); }
        
        }

        private IRepositorio<Proveedor> _proveedorRepositorio;
        public IRepositorio<Proveedor> ProveedorRepositorio
        {
            get { return _proveedorRepositorio ?? (_proveedorRepositorio = new Repositorio<Proveedor>(_contexto)); }
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public void Disposed()
        {
            _contexto.Dispose();
        }

        private IRepositorio<DetalleVenta> _detalleVentaRepositorio;
        public IRepositorio<DetalleVenta> DetalleVentaRepositorio
        {
            get { return _detalleVentaRepositorio ?? (_detalleVentaRepositorio = new Repositorio<Dominio.Producto.Entidades.DetalleVenta>(_contexto)); }
           
        }
    }
}
