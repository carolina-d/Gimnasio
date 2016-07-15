using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Clases;
using System.ComponentModel.DataAnnotations;


namespace Dominio.Producto.Entidades
{
    [Table("Producto")]
   public class Producto : DominioBase.Entidad
    {
       //Entidades

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
       public int Codigo { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
       public string Descripcion { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
       public decimal PrecioUnitario { get; set; }

       public int Stock { get; set; }

       //navegacion

       public virtual ICollection<Proveedor> Proveedores {get; set; }
    }
}
