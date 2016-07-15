using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DominioBase.Clases;

namespace Dominio.Producto.Entidades
{
    [Table("Proveedor")]
    public class Proveedor : DominioBase.Entidad
    {
        //Popiedades
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(20)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(20)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        [Column(TypeName = "varchar"), MaxLength(20)]
        public string Direccion { get; set; }

        public string Telefono { get; set; }
        [Required(ErrorMessage = Constante.Mensaje.CampoObligatorio)]
        public string Cuil { get; set; }

        //navegacion

        public virtual ICollection<Producto> Productos { get; set; }
        

    }
}
