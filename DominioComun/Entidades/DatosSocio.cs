using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase.Clases;

namespace DominioComun.Entidades
{
    [Table("DatosSocio")]
    
    public class DatosSocio : DominioBase.Entidad
    {
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(30)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(30)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(30)]        
        public string Apellido { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(30)]        
        public string Direccion { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage =  Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "int")]
        public int Dni { get; set; }

        public string Telefono { get; set; }

       public string Observacion { get; set; }

        public int PromocionId { get; set; }

        [NotMapped]
        public string ApyNom
        {
            get { return string.Format("{0} {1}", Apellido, Codigo); }
        }

        
        //propiedades de naegacion
        public virtual ICollection<Clase> TipoClases { get; set; }
        public virtual ICollection<Promocion> Promocion { get; set; }
        public virtual ICollection<Membresia> Membresias { get; set; }
        public virtual ICollection<Rutina> Rutinas { get; set; }

  }
}


