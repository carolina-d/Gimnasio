using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DominioBase;
using DominioBase.Clases;

namespace DominioSeguridad.Entidades
{
    [Table("Empleado")]
    public class Empleado : Entidad
    {
       

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(10)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(250)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(250)]
        public string Nombre { get; set; }

        [NotMapped]
        public string ApyNom
        {
            get { return string.Format("{0} {1}", Apellido, Nombre); }
        }

        [Column(TypeName = "varchar"), MaxLength(10)]
        public string Dni { get; set; }

        [Column(TypeName = "varchar"), MaxLength(400)]
        public string Domicilio { get; set; }


        [Column(TypeName = "varchar"), MaxLength(20)]
        public string Celular { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime FechaNacimiento { get; set; }

        [Column(TypeName = "varchar"), MaxLength(250)]
        public string Mail { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "bit")]
        public bool EstaEliminado { get; set; }



        public long TipoEmpleadoId { get; set; }

       

        public virtual TipoEmpleado TiposEmpleados { get; set; }
        public virtual ICollection<TipoEmpleado> TipoEmpleado { get; set; } 

        public virtual ICollection<Usuario> Usuarios { get; set; }

       // public virtual Clases Clases { get; set; }


     
     
        
    }
}
