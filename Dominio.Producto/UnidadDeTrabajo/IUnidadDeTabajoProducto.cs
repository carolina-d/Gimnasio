using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Repositorios;


namespace Dominio.Producto.UnidadDeTrabajo
{
    public interface IUnidadDeTabajoProducto
    {
        IRepositorio<Producto.Entidades.Producto> ProductoRepositorio { get; }
        IRepositorio<Producto.Entidades.Proveedor> ProveedorRepositorio { get; }
        IRepositorio<Producto.Entidades.Venta> VentaRepositorio { get; }
        IRepositorio<Producto.Entidades.DetalleVenta> DetalleVentaRepositorio { get; }

        void Commit();
        void Disposed();
    }
}
