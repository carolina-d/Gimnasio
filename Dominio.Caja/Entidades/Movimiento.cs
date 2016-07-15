using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase;
using System.ComponentModel.DataAnnotations;
using DominioBase.Clases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Caja.Entidades
{
    [Table("Movimiento")]
   public class Movimiento : Entidad
    {
        //Propiedades

        //[Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public decimal Ingreso { get; set; }

        public decimal Egreso { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public int PagoId { get; set; }

        //navegabilidad
        public virtual Pago Pago { get; set; }
        //publi  virtual Venta 
    }
}
