using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioSpinning;
using DominioSpinning.UnidadDeTrabajo;
using PresentacionPlantilla;
using StructureMap;

namespace PresentacionSpinning
{
    public partial class _00500_Spinning_ABM : FormularioABM
    {
        private readonly IUnidadDeTrabajoSpinning comunUoW = ObjectFactory.GetInstance<IUnidadDeTrabajoSpinning>();

        private Spinning spinning;

        private string _tipoOperacion = string.Empty;

       
        public _00500_Spinning_ABM()
        {
            InitializeComponent();
        }

        public _00500_Spinning_ABM(string tipoOperacion, long? entidadId)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();


            this.Name = "_00214_Spinning_ABM";
            this.TituloVentana = "Spinning";
            this.Titulo = "Gestión de Spinning";
            this.Leyenda = "Aquí Ud podrá dar de Alta, Modificar o Eliminar una Bicicleta";

            this._tipoOperacion = tipoOperacion;

            // Cargar evento de validacion para datos Obligatorios
            this.txtCodigo.Validated += new EventHandler(base.textBox_Validated);
            this.txtDescripcion.Validated += new EventHandler(base.textBox_Validated);

            PoblarEstado(cmbEstado);

            // Cargar evento de Validacion de Caracteres 
            this.txtCodigo.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);
            this.txtDescripcion.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);

            // Color al recibir el Foco
            this.txtCodigo.Enter += new EventHandler(base.control_Enter);
            this.txtDescripcion.Enter += new EventHandler(base.control_Enter);
            this.cmbEstado.Enter += new EventHandler(base.control_Enter);

            // Color al perder el Foco
            this.txtCodigo.Leave += new EventHandler(base.control_Leave);
            this.txtDescripcion.Leave += new EventHandler(base.control_Leave);
            this.cmbEstado.Leave += new EventHandler(base.control_Leave);

            this._tipoOperacion = tipoOperacion;

            Inicializador(tipoOperacion, entidadId);
            this.txtCodigo.Focus();

        }

        //lista para cargar el combo box con los tipos de estados
        public enum Estados
        {
            Disponible,
            NoDisponible
        }

        //pueblo el combo con los estados
        public void PoblarEstado(ComboBox cmb)
        {
            cmb.DataSource = System.Enum.GetValues(typeof(Estados));
        }

        public override void CargarDatos(long? entidadId)
        {
            spinning = ObjectFactory.GetInstance<Spinning>();

            try
            {
                spinning = comunUoW.SpinningRepositorio.ObtenerPorId(entidadId.Value);

                this.txtCodigo.Text = spinning.Codigo;
                this.txtDescripcion.Text = spinning.Descripcion;
                this.cmbEstado.Text = spinning.Estado;
            }
            catch (Exception)
            {

                Mensaje.Mostrar(new Exception("Error al cargar los Datos"),PresentacionBase.Constante.TipoMensaje.Error);

            }
        }

        public override void VerificarDatosObligatorios()
        {
            base.VerificarDatosObligatorios();
            this.ValidateChildren();
        }

        public override bool VerificarSiExisteDatos()
        {
            var Spinning = comunUoW.SpinningRepositorio.ObtenerTodo(string.Empty);

            //es`para controlar que los datos nuevos no sean igual a los existentes
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Nuevo)
            {
                if (Spinning.Any(x => x.Codigo.Equals(this.txtCodigo.Text)))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El código {0} ya Existe ", this.txtCodigo));
                    return true;
                }
                 if (Spinning.Any(x => x.Descripcion.Equals(this.txtDescripcion.Text)))
                 {
                   PresentacionBase.Constante.Validacion.DatoExistente(this.txtDescripcion, errorProvider, string.Format("La Descripción {0} ya Existe ", this.txtDescripcion.Text));
                     return true;
                 }

            }

            //controla que al modificar los datos no exista uno igual
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Modificar)
            {
                if (Spinning.Any(x => x.Codigo.Equals(this.txtCodigo.Text)&& x.Id != spinning.Id))
                {
                   PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El código {0} ya Existe ", this.txtCodigo.Text));
                    return true;
                }
                /*  if (tiposClases.Any(x => x.Nombre.Equals(this.txtHora.Text)))
                  {
                      Constante.Validacion.DatoExistente(this.txtHora, errorProvider, string.Format("La clase {0} ya Existe ", this.txtHora.Text));
                      return true;
                  }*/
            }


            return false;

        }

        public override void NuevoRegistro()
        {

            try
            {

                spinning = ObjectFactory.GetInstance<Spinning>();

                spinning.Codigo = this.txtCodigo.Text;
                spinning.Descripcion = this.txtDescripcion.Text;
                spinning.Estado = this.cmbEstado.Text;


                comunUoW.SpinningRepositorio.Insertar(spinning);
                comunUoW.SpinningRepositorio.Commit();
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
                comunUoW.SpinningRepositorio.Eliminar(spinning);
                comunUoW.SpinningRepositorio.Commit();
            }
            catch (DataException ex)
            {

                Mensaje.Mostrar("La bici seleccionado se encuentra vinculada a otro objeto",
                    PresentacionBase.Constante.TipoMensaje.Error);
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
                spinning.Codigo = this.txtCodigo.Text;
                spinning.Descripcion = this.txtDescripcion.Text;
                spinning.Estado = this.cmbEstado.Text;


                comunUoW.SpinningRepositorio.Modificar(spinning);
                comunUoW.SpinningRepositorio.Commit();


            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex,PresentacionBase.Constante.TipoMensaje.Error);

            }
        }
    }
}
