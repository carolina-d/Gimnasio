using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Infraestructura.Producto.Contexto
{
    public interface IContextoProducto
    {
        IDbSet<Dominio.Producto.Entidades.DetalleVenta> DETALLEVENTA { get; set; }
        IDbSet<Dominio.Producto.Entidades.Producto> PRODUCTO { get; set; }
        IDbSet<Dominio.Producto.Entidades.Proveedor> PROVEEDOR { get; set; }
        IDbSet<Dominio.Producto.Entidades.Venta> VENTA { get; set; }



    }
}
