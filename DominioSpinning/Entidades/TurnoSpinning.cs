using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase;
using DominioBase.Clases;
using DominioComun.Entidades;


namespace DominioSpinning.Entidades
{
    [Table("TurnoSpinning")]
    public class TurnoSpinning : Entidad
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "datetime")]
        public DateTime Hora { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "decimal")]
        public Decimal Senia { get; set; }

        //propiedades de navegacion

        public ICollection<DatosSocio> Socio { get; set; }

        public ICollection<Clase> Clases { get; set; }
    }
}

