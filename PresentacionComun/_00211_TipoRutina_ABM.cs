using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioComun.Entidades;
using DominioComun.UnidadDeTrabajo;
using PresentacionBase;
using PresentacionPlantilla;
using StructureMap;

namespace PresentacionComun
{
    public partial class _00211_TipoRutina_ABM : FormularioABM
    {
        private readonly IUnidadDeTrabajoComun comunUoW = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();
        private TipoRutina TipoRutina;

        private string _tipoOperacion = string.Empty;
        public _00211_TipoRutina_ABM()
        {
            InitializeComponent();
        }

          public _00211_TipoRutina_ABM(string tipoOperacion, long? entidadId)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            this.Name = "_00211_ABM_TipoRutina";
            this.TituloVentana = "Tipo de Rutinas";
            this.Titulo = "Tipos de Rutina";
            this.Leyenda = "Aquí Ud podrá dar de Alta, Modificar o Eliminar un Tipo de Rutina";

            //// Cargar evento de Validacion de Caracteres 
            this.txtDescripcion.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);
            this.txtCodigo.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);


            // Color al recibir el Foco
            this.txtCodigo.Enter += new EventHandler(base.control_Enter);
            this.txtDescripcion.Enter += new EventHandler(base.control_Enter);


            // Color al perder el Foco
            this.txtCodigo.Leave += new EventHandler(base.control_Leave);
            this.txtDescripcion.Leave += new EventHandler(base.control_Leave);

              
            Inicializador(tipoOperacion, entidadId);

            this._tipoOperacion = tipoOperacion;
              ImagenTituloPanelSuperior = ImagenesFormulario.TipoRutina;

        }

        public override void CargarDatos(long? entidadId)
        {
            TipoRutina = ObjectFactory.GetInstance<TipoRutina>();
            try
            {
                TipoRutina = comunUoW.TipoRutinaRepositorio.ObtenerPorId(entidadId.Value);

                this.txtCodigo.Text = TipoRutina.Codigo;
                this.txtDescripcion.Text = TipoRutina.Descripcion;

            }
            catch (Exception)
            {

                Mensaje.Mostrar(new Exception("Error al cargar los Datos"), PresentacionBase.Constante.TipoMensaje.Error); 
            }
        }

        public override void VerificarDatosObligatorios()
        {
            base.VerificarDatosObligatorios();
            this.ValidateChildren();
        }

        public override bool VerificarSiExisteDatos()
        {
            var tipoRutina = comunUoW.TipoRutinaRepositorio.ObtenerTodo(string.Empty);

            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Nuevo)
            {
                if (tipoRutina.Any(x => x.Codigo.Equals(this.txtCodigo.Text)))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider,
                        string.Format("El Código {0} ya Existe ", this.txtCodigo.Text));
                    return true;
                }

                if (tipoRutina.Any(x => x.Descripcion.Equals(this.txtCodigo.Text)))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtDescripcion, errorProvider,
                        string.Format("La Descripción {0} ya Existe ", this.txtDescripcion.Text));
                    return true;
                }

            }

            //controla que al modificar los datos no exista uno igual
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Modificar)
            {
                if (tipoRutina.Any(x => x.Codigo.Equals(this.txtCodigo.Text) && x.Id != TipoRutina.Id))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El Código {0} ya Existe ", this.txtCodigo.Text));
                    return true;
                }

                if (tipoRutina.Any(x => x.Descripcion.Contains(this.txtDescripcion.Text) && x.Id != TipoRutina.Id))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtDescripcion, errorProvider, string.Format("La Descripción {0} ya Existe ", this.txtDescripcion.Text));
                    return true;
                }
            }
            return false;
        }

        public override void NuevoRegistro()
        {
            try
            {
                TipoRutina = new TipoRutina
                {
                    Codigo = this.txtCodigo.Text,
                    Descripcion = this.txtDescripcion.Text,
                };

                comunUoW.TipoRutinaRepositorio.Insertar(TipoRutina);
                comunUoW.Commit();

                this.txtCodigo.Focus();

            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, PresentacionBase.Constante.TipoMensaje.Error);
            }

        }

        public override void EliminarRegistro()
        {
            try
            {
                comunUoW.TipoRutinaRepositorio.Eliminar(TipoRutina);
                comunUoW.TipoRutinaRepositorio.Commit();

            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex,PresentacionBase.Constante.TipoMensaje.Error);
            }
        }

        public override void ModificarRegistro()
        {
            try
            {
                TipoRutina.Codigo = this.txtCodigo.Text;
                TipoRutina.Descripcion = this.txtDescripcion.Text;

                comunUoW.TipoRutinaRepositorio.Modificar(TipoRutina);
                comunUoW.TipoRutinaRepositorio.Commit();

            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, PresentacionBase.Constante.TipoMensaje.Error);
            }
        }

        private void _00211_TipoRutina_ABM_Load(object sender, EventArgs e)
        {

        }
    }
}
