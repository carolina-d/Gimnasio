using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DominioBase.Clases;
using DominioSeguridad.Entidades;
using DominioSeguridad.UnidadDeTrabajo;
using ServicioSeguridad.DTOs;
using StructureMap;

namespace ServicioSeguridad.ServicioFormulario
{
    public class FormularioServicio : IFormularioServicio
    {
        private readonly ISeguridadUnidadDeTrabajo seguridadUoW;

        public FormularioServicio(ISeguridadUnidadDeTrabajo _seguridadUoW)
        {
            this.seguridadUoW = _seguridadUoW;
        } 

        public void PoblarFormulariosSistema(ref List<FormularioDTO> listaFormularios, Assembly ass)
        {
            var resultado = seguridadUoW.FormularioRepositorio.ObtenerTodo();

            foreach (Type t in ass.GetTypes())
            {
                if (!t.Name[0].ToString().Equals("_")) continue;

                var formularioDTONuevo = ObjectFactory.GetInstance<FormularioDTO>();

                formularioDTONuevo.Codigo = int.Parse(t.Name.Substring(1, 5));
                formularioDTONuevo.Nombre = t.Name.Substring(7, (t.Name.Length - 7));
                formularioDTONuevo.NombreCompleto = t.Name;
                formularioDTONuevo.ExisteBaseDatos = resultado != null
                                                         ? resultado.Where(x => x.NombreCompleto == t.Name).Any()
                                                         : false;

                listaFormularios.Add(formularioDTONuevo);
            }
        }

        public void InsertarFormulario(List<FormularioDTO> listaFormularios)
        {
              using(var tran = new TransactionScope())
            {
                try
                {
                    foreach (var form in listaFormularios.Where(x => x.ExisteBaseDatos == false))
                    {
                        var formularioNuevo = new Formulario();
                        formularioNuevo.Nombre = form.Nombre;
                        formularioNuevo.NombreCompleto = form.NombreCompleto;
                        formularioNuevo.Codigo = form.Codigo;
                        
                        seguridadUoW.FormularioRepositorio.Insertar(formularioNuevo);
                        seguridadUoW.Commit();
                    }

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();
                    throw new Exception("Ocurrió un Error al Grabar los Formulario");
                }
            }
        }
      }
   }
    


