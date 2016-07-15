using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PresentacionComun
{
   public static class ComunAssembly
    {
        public static Assembly SegAssembly { get { return Assembly.GetExecutingAssembly(); } } 
 
    }
}
