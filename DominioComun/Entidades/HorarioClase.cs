using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase;
using DominioBase.Clases;

namespace DominioComun.Entidades
{
    [Table("HorarioClase")]
    public class HorarioClase : Entidad
    {
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]

        public DateTime Hora { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(30)]
        public string Dias { get; set; }

        //propiedad de navegacion
        public virtual ICollection<Clase> TipoClases { get; set; }
        public virtual Clase Clase { get; set; }

        public long ClaseId { get; set; }


    }
}
