using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PresentacionSeguridad
{
    public static class SeguridadAssembly
    {
        public static Assembly SegAssembly { get { return Assembly.GetExecutingAssembly(); } }
    }
}
