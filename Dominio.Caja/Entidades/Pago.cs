using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase;
using Dominio.Caja.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DominioBase.Clases;
using DominioComun.Entidades;


namespace Dominio.Caja.Entidades
{
    [Table("Pago")]
    public class Pago : Entidad
    {
        //Propiedades
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public DateTime FechaPago { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public int PromocionId { get; set; }
       
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public int MembresiaId { get; set; }
       
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public long SocioId { get; set; }

        public string Socio { get; set; }

        public string MembresiaNombre { get; set; }

        public decimal Monto { get; set; }

        //    public int CuotaId { get; set; }

        public int AreaGimnasioId { get; set; }

        public DateTime FechaVencimiento { get; set; }

        //navegabilidad

         public virtual AreaGimnasio AreaGimnasio { get; set; }
        public virtual Promocion Promocion { get; set; }
        public virtual DatosSocio ApellidoSocio { get; set; }
        public virtual Membresia Membresia { get; set; }
        //public virtual Cuota CuotaId {get; set;}


    }
}
