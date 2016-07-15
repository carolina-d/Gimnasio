using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioBase.Clases;
using DominioBase;

namespace DominioComun.Entidades
{
     [Table("HorarioClase")]   
    public class HorarioClase : Entidad
    {
         [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        // [Column(TypeName = "time"), MaxLength(5)]
         public DateTime Hora { get; set; }

         [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
         [Column(TypeName = "varchar"), MaxLength(30)]
         public string Dias { get; set; }


         

       
        

       

     

    }
}
