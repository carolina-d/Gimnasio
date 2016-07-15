using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioBase;
using DominioBase.Clases;

namespace DominioSeguridad.Entidades
{
    [Table("Formulario")]
    public class Formulario : Entidad
    {
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(250)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(250)]
        public string NombreCompleto { get; set; }

        [ForeignKey("PerfilId")]
        public ICollection<Perfil> Perfiles { get; set; }
    }
}
