using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Presentacion.Caja
{
   public static class CajaAssembly
    {
        public static Assembly SegAssembly { get { return Assembly.GetExecutingAssembly(); } } 
    }
}
