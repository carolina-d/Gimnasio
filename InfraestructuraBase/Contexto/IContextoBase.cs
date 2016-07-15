using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructuraBase.Contexto
{
    public interface IContextoBase
    {
        int ExecuteSqlCommand(string sqlCommand, params object[] param);
    }
}
