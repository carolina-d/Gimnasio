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

namespace DominioSeguridad.Entidades
{
    [Table("Perfil")]
    public class Perfil : Entidad
    {
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(250)]
        public string Descripcion { get; set; }

        [ForeignKey("UsuarioId")]
        public ICollection<Usuario> Usuarios { get; set; }

        [ForeignKey("FormularioId")]
        public ICollection<Formulario> Formularios { get; set; }
    }
}
