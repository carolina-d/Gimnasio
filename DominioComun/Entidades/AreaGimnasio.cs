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
        [Table("AreaGimnasio")]

    public class AreaGimnasio : Entidad
    {
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "int")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(20)]
        public string Descripcion { get; set; }

    }
}
