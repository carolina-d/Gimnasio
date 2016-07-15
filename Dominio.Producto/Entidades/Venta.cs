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
   [Table("Venta")]
   public class Venta : DominioBase.Entidad
    {
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]

        public int NumeroVenta { get; set; }
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public decimal Total { get; set; }

     

    }
}
