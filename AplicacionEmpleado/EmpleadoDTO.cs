using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionEmpleado
{
    public class EmpleadoDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string ApyNom
        {
            get { return string.Format("{0} {1}", Apellido, Nombre); }
        }

        public int DNI { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string TipoEmpleado { get; set; }


      

        
    }
}
