using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ServicioSeguridad.DTOs;

namespace ServicioSeguridad.ServicioFormulario
{
    public interface IFormularioServicio
    {
        //primera version
        void PoblarFormulariosSistema(ref List<FormularioDTO> listaFormularios, Assembly ass);
        void InsertarFormulario(List<FormularioDTO> listaFormularios);


        //void CargarFormularios(ref List<FormularioDTO> _formAsembly);
        //void ActualizarBaseDeDatos(List<FormularioDTO> _listaFormularios);
    }
}
