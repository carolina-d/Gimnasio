using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DominioBase.Clases;

namespace Dominio.Producto.Entidades
{
    [Table("DetalleVenta")]
    public class DetalleVenta : DominioBase.Entidad
    {
        //Propiedades
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public decimal SubTotal { get; set; }
        
        //navegacion 
     


    }
}
