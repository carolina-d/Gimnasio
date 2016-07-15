using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioSeguridad.Entidades;
using DominioSeguridad.UnidadDeTrabajo;
using PresentacionBase;
using PresentacionPlantilla;
using StructureMap;

namespace PresentacionSeguridad
{
    public partial class _00007_Perfil_ABM : Formularios.ABM
    {
        private readonly ISeguridadUnidadDeTrabajo seguridadUoW = ObjectFactory.GetInstance<ISeguridadUnidadDeTrabajo>();
        private Perfil perfil;

        private string _tipoOperacion = string.Empty;

        public _00007_Perfil_ABM()
        {
            InitializeComponent();
        }


        public _00007_Perfil_ABM(string _tipoOperacion, long? _entidadId)
            : base(_tipoOperacion, _entidadId)
        {
            InitializeComponent();

            this.Name = "_00008_ABM_Perfil";
            this.perfil = new Perfil();

            // Color cuando recibe el foco
            this.txtCodigo.Enter += new EventHandler(this.txt_Enter);
            this.txtDescripcion.Enter += new EventHandler(this.txt_Enter);

            // Color cuando pierde el foco
            this.txtCodigo.Leave += new EventHandler(this.txt_Leave);
            this.txtDescripcion.Leave += new EventHandler(this.txt_Leave);

            this.Init(_tipoOperacion, _entidadId);

        }

       
       public override void CargarDatos(long? _entidadId)
        {
            perfil = seguridadUoW.PerfilRepositorio.ObtenerPorId(_entidadId.Value);

            this.txtCodigo.Text = perfil.Codigo.ToString();
            this.txtDescripcion.Text = perfil.Descripcion;
        }

        public override void ObtenerSiguienteCodigo()
        {
            var resultado = seguridadUoW.PerfilRepositorio.ObtenerTodo();

            if (resultado != null && resultado.Any())
            {
                this.txtCodigo.Text =
                    (resultado.Max(x => x.Codigo) + 1).ToString();
            }
            else
            {
                this.txtCodigo.Text = 1.ToString();
            }

            this.txtDescripcion.Focus();
        }
        
        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                Mensaje.Mostrar("Por favor ingrese un código", Mensaje.Tipo.Error);
                this.txtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                Mensaje.Mostrar("Por favor ingrese una descripción", Mensaje.Tipo.Error);
                this.txtDescripcion.Focus();
                return false;
            }

            return true;
        }

        public override bool VerificarSiExiste()
        {
            int codigo = -1;
            int.TryParse(this.txtCodigo.Text, out codigo);

            var resultado = seguridadUoW.PerfilRepositorio.ObtenerTodo();

            if(resultado.Any(x=>x.Codigo == codigo && x.Id != perfil.Id))
            {
                Mensaje.Mostrar("El código ya Existe", Mensaje.Tipo.Informacion);
                return true;
            }
            
            if (resultado.Any(x => x.Descripcion == this.txtDescripcion.Text && x.Id != perfil.Id))
            {
                Mensaje.Mostrar("La descripción ya Existe", Mensaje.Tipo.Informacion);
                return true;
            }

            return false;
        }

        public override void EjecutarComandoNuevo()
        {
            try
            {
                perfil.Codigo = int.Parse(this.txtCodigo.Text);
                perfil.Descripcion = this.txtDescripcion.Text;

                seguridadUoW.PerfilRepositorio.Insertar(perfil);
                seguridadUoW.Commit();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar("Ocurrió un error al grabar los datos", Mensaje.Tipo.Stop);
                this.txtCodigo.Focus();
            }
        }

        public override void EjecutarComandoModificar()
        {
            try
            {
                perfil.Codigo = int.Parse(this.txtCodigo.Text);
                perfil.Descripcion = this.txtDescripcion.Text;

                seguridadUoW.PerfilRepositorio.Modificar(perfil);
                seguridadUoW.Commit();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar("Ocurrió un error al modificar los datos", Mensaje.Tipo.Stop);
                this.txtCodigo.Focus();
            } 
        }

        public override void EjecutarComandoEliminar()
        {
            try
            {
                if (!this.LanzadoPorCierre)
                {
                    if (Mensaje.Mostrar("Esta seguro de eliminar los datos?", Mensaje.Tipo.Pregunta) !=
                        System.Windows.Forms.DialogResult.Yes) return;

                    seguridadUoW.PerfilRepositorio.Eliminar(perfil);
                    seguridadUoW.Commit();
                }
                else
                {
                    seguridadUoW.PerfilRepositorio.Eliminar(perfil);
                    seguridadUoW.Commit();
                }
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar("Ocurrió un error al Eliminar los datos", Mensaje.Tipo.Stop);
                this.txtCodigo.Focus();
            } 
        }
    }
}
