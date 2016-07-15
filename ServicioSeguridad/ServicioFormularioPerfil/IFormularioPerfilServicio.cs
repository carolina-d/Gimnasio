using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSeguridad.Entidades;

namespace ServicioSeguridad.ServicioFormularioPerfil
{
    public interface IFormularioPerfilServicio
    {
        void VincularFormularioPerfil(List<long> listaIdFormulario, long perfilId);
        void DesvincularFormularioPerfil(List<long> listaIdFormulario, long perfilId);

        IEnumerable<Formulario> MostrarFormulariosNoAsignados(long perfilId, string cadena);
        IEnumerable<Formulario> MostrarFormulariosAsignados(long perfilId, string cadena);
    }
}
