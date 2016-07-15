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

    [Table("Usuario")]
    public class Usuario : Entidad
    {
        [Required, ForeignKey("Empleado")]
        public long EmpleadoId { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(300)]
        public string Password { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "bit")]
        public bool EstaBloqueado { get; set; }

        // Propiedad de Navegacion
        public Empleado Empleado { get; set; }

        [ForeignKey("PerfilId")]
        public ICollection<Perfil> Perfiles { get; set; }
    }
}
