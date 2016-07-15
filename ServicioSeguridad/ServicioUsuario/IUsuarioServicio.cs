using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioSeguridad.ServicioUsuario
{
    public interface IUsuarioServicio
    {
        bool CrearUsuario(List<long> _listaIds);
        bool BloquearUsuario(List<long> _listaIds);
        bool ReiniciarPassword(List<long> _listaIds);

        bool VerificarSiEstaBloqueado(string usuario, string password);
    }
}
