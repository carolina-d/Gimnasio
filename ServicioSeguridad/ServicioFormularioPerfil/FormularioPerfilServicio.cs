using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DominioSeguridad.Entidades;
using DominioSeguridad.UnidadDeTrabajo;

namespace ServicioSeguridad.ServicioFormularioPerfil
{
    public class FormularioPerfilServicio : IFormularioPerfilServicio
    {
        private readonly ISeguridadUnidadDeTrabajo _uowSeguridad;

        public FormularioPerfilServicio(ISeguridadUnidadDeTrabajo uowSeguridad)
        {
            this._uowSeguridad = uowSeguridad;
        }

        public void VincularFormularioPerfil(List<long> listaIdFormulario, long perfilId)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    var perfil = _uowSeguridad.PerfilRepositorio.ObtenerPorId(perfilId, "Formularios");

                    foreach (var id in listaIdFormulario)
                    {
                        var formulario = _uowSeguridad.FormularioRepositorio.ObtenerPorId(id);

                        perfil.Formularios.Add(formulario);
                    }

                    _uowSeguridad.Commit();

                    tran.Complete();
                }
                catch (Exception)
                {
                    tran.Dispose();
                    throw new Exception("Ocurrió un error al vincular un Formulario a un Perfil");
                }
            }
        }

        public void DesvincularFormularioPerfil(List<long> listaIdFormulario, long perfilId)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    var perfil = _uowSeguridad.PerfilRepositorio.ObtenerPorId(perfilId, "Formularios");

                    foreach (var id in listaIdFormulario)
                    {
                        var formulario = _uowSeguridad.FormularioRepositorio.ObtenerPorId(id);

                        perfil.Formularios.Remove(formulario);
                    }

                    _uowSeguridad.Commit();

                    tran.Complete();
                }
                catch (Exception)
                {
                    tran.Dispose();

                    throw new Exception("Ocurrió un error al Desvincular un Formulario de un Perfil");
                }
            }
            
        }

        public IEnumerable<Formulario> MostrarFormulariosNoAsignados(long perfilId, string cadena)
        {
            var perfil = _uowSeguridad.PerfilRepositorio.ObtenerPorId(perfilId, "Formularios");

            if (perfil != null)
            {
                var formularios = _uowSeguridad.FormularioRepositorio.ObtenerTodo()
                    .Except(perfil.Formularios).Where(x => x.Nombre.Contains(cadena));

                return formularios.ToList();
            }
            else
            {
                return _uowSeguridad.FormularioRepositorio.ObtenerPorFiltro(x => x.Id.Equals(-1)).ToList();
            }
        }

        public IEnumerable<Formulario> MostrarFormulariosAsignados(long perfilId, string cadena)
        {
            var perfil = _uowSeguridad.PerfilRepositorio.ObtenerPorId(perfilId, "Formularios");

            if (perfil != null)
            {
                var resultado = perfil.Formularios.Where(x => x.Nombre.Contains(cadena));

                return resultado.ToList();
            }
            else
            {
                return _uowSeguridad.FormularioRepositorio.ObtenerPorFiltro(x => x.Id.Equals(-1)).ToList();
            }
        }
    }
}
