using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Clases;

using System.ComponentModel.DataAnnotations;


namespace Dominio.Caja.Entidades
{
    [Table("PagoCuota")]
    public class PagoCuota : DominioBase.Entidad
    {
        //Propiedades
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public DateTime FechaPago { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public decimal MontoPago { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public decimal Deuda { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public DateTime VencimientoDeuda { get; set; }

        //navegacion

        //public DominioComun.Entidades.DatosSocio SocioId {get; set;}

    }
}
