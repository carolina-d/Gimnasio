using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DominioBase.Clases;
using DominioComun.Entidades;


namespace DominioComun.Entidades
{
    [Table("DatosSocio")]
    
    public class DatosSocio : DominioBase.Entidad
    {
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(6)]
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

        
        public string Telefono { get; set; }

       
        public string Observacion { get; set; }

        [NotMapped]
        public string ApyNom
        {
            get { return string.Format("{0} {1}", Apellido, Nombre); }
        }

        [NotMapped]
        public string Edad
        {
            get
            {
                return Aplicacion.Comun.CalcularEdadSocio.Calcular(FechaNacimiento, DateTime.Today);
            }
        }

        //propiedades de naegacion
        public virtual ICollection<Clase> Clases { get; set; }
        
        public virtual ICollection<Promocion> Promociones { get; set; }
        public virtual ICollection<Membresia> Membresias { get; set; }
        public virtual ICollection<Rutina> Rutinas { get; set; }


        



    }
}
