using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentacionSpinning.DTO
{
    public class DTOTurnoSpinning
    {
        public int SocioId { get; set; }
        public string Socio { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Hora { get; set; }
        public string Monto { get; set; }
    }
}
