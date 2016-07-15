using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioSeguridad.DTOs;

namespace ServicioSeguridad.ServicioUsuarioPerfil
{
    public interface IUsuarioPerfilServicio
    {
        void VincularUsuarioPerfil(List<long> listaIdUsuario, long perfilId);
        void DesvincularUsuarioPerfil(List<long> listaIdUsuario, long perfilId);

        IEnumerable<UsuarioDTO> MostrarUsuariosNoAsignados(long perfilId, string cadena);
        IEnumerable<UsuarioDTO> MostrarUsuariosAsignados(long perfilId, string cadena);
    }
}
