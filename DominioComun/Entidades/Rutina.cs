using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase;
using DominioBase.Clases;
using DominioSeguridad.Entidades;

namespace DominioComun.Entidades
{
    [Table("Rutina")]
    public class Rutina : Entidad
    {

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(30)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(30)]
        public string Dias { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(100)]
        public string Descripcion { get; set; }


        // [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        // [Column(TypeName = "datetime")]
        // public DateTime Fecha { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public int Series { get; set; }


        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public int Repeticiones { get; set; }

        //propiedades de Navegacion
        public long TipoRutinaId { get; set; }
        public virtual Empleado Empleados { get; set; }
        public virtual TipoRutina TipoRutina { get; set; }
        public virtual ICollection<DatosSocio> Socios { get; set; }
    }

}
