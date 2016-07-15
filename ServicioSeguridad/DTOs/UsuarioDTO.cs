using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSeguridad.DTOs
{
    public class UsuarioDTO
    {
        public long Id { get; set; }
        public long EmpleadoId { get; set; }
        public string ApyNom { get; set; }
        public string Usuario { get; set; }
        public string EstaBloqueado { get; set; }
    }
}
