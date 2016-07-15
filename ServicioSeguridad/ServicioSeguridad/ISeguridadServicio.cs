using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSeguridad.ServicioSeguridad
{

    public interface ISeguridadServicio
    {
        bool TieneAccesoSistema(string usuarioLogin, string password);
        bool TienePermiso(string nombreFormulario, string usuarioLogin);
    }
}
