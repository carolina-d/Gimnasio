using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimnasio.DTO
{
    public class DTOConsultaPago
    {
        public string Id { get; set; }
        public string Socio { get; set; }
        public string Membresia { get; set; }
        public string Monto { get; set; }
        public string FechaPago { get; set; }
        public string FechaVencimiento { get; set; }

    }
}
