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
    [Table("TipoRutina")]
    public class TipoRutina : Entidad
    {
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(6)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(30)]
        public string Descripcion { get; set; }


        //propiedades de Navegacion
        public virtual ICollection<Rutina> Rutinas { get; set; }

    }
}
