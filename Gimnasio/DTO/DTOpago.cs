using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimnasio.DTO
{
    public class DTOpago
    {
        public int SocioId { get; set; }
        public string Socio { get; set; }
        public string Membresia { get; set; }
        public string Promocion { get; set; }
        public string Monto { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
