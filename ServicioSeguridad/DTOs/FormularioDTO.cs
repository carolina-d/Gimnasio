using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSeguridad.DTOs
{
    public class FormularioDTO
    {
        public long? Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string NombreCompleto { get; set; }
        public bool ExisteBaseDatos { get; set; }
    }
}
