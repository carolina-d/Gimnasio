using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase;
using System.ComponentModel.DataAnnotations.Schema;
using DominioBase.Clases;

namespace DominioComun.Entidades
{
    [Table("TipoRutina")]
    public class TipoRutina : Entidad
    {
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public string Descripcion { get; set; }


        //propiedades de Navegacion
        public virtual ICollection<Rutina> Rutinas { get; set; } 
     
    }
}
