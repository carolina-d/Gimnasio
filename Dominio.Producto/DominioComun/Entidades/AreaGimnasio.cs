using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase;
using DominioBase.Clases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DominioComun.Entidades
{
    [Table("AreaGimnasio")]

    public class AreaGimnasio : Entidad
    {

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public int Codigo { get; set; }
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public string Descripcion { get; set; }


    }
}
