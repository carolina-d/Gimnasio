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
using DominioBase.Clases;
using DominioComun.Entidades;
using DominioComun.UnidadDeTrabajo;
using PresentacionBase;
using PresentacionPlantilla;
using StructureMap;
using Aplicacion.Comun;


namespace PresentacionComun
{
    public partial class _00201_Socio_ABM : FormularioABM
    {
        private readonly IUnidadDeTrabajoComun comunUoW = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();
        private DatosSocio Socio;

        private string _tipoOperacion = string.Empty;

        public _00201_Socio_ABM()
        {
            InitializeComponent();
        }

        public _00201_Socio_ABM(string tipoOperacion, long? entidadId)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            this.Name = "_00201_ABM_Socio";
            this.TituloVentana = "Socio";
            this.Titulo = "Gestión de Socios";
            this.Leyenda = "Aquí Usted podrá dar de Alta, Modificar o Eliminar un Socio";

            //// Cargar evento de validacion para datos Obligatorios
            this.txtApellido.Validated += new EventHandler(base.textBox_Validated);
            this.txtNombre.Validated += new EventHandler(base.textBox_Validated);
            this.txtDireccion.Validated += new EventHandler(base.textBox_Validated);
            this.txtTelefono.Validated += new EventHandler(base.textBox_Validated);
            this.txtFechaNac.Validated += new EventHandler(base.textBox_Validated);
            this.txtObservaciones.Validated += new EventHandler(base.textBox_Validated);


            //// Cargar evento de Validacion de Caracteres 
             this.txtTelefono.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);
             this.txtNombre.KeyPress += new KeyPressEventHandler(base.textBoxSoloLetras_KeyPress);
             this.txtApellido.KeyPress += new KeyPressEventHandler(base.textBoxSoloLetras_KeyPress);
             this.txtDireccion.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);
            //this.txtFechaNac.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);

            // Color al recibir el Foco
             this.txtApellido.Enter += new EventHandler(base.control_Enter);
             this.txtNombre.Enter += new EventHandler(base.control_Enter);
            this.txtDireccion.Enter += new EventHandler(base.control_Enter);
            this.txtTelefono.Enter += new EventHandler(base.control_Enter);
            this.txtFechaNac.Enter += new EventHandler(base.control_Enter);
            this.txtObservaciones.Enter += new EventHandler(base.control_Enter);


            // Color al perder el Foco
            this.txtApellido.Leave += new EventHandler(base.control_Leave);
            this.txtNombre.Leave += new EventHandler(base.control_Leave);
            this.txtDireccion.Leave += new EventHandler(base.control_Leave);
            this.txtTelefono.Leave += new EventHandler(base.control_Leave);
            this.txtFechaNac.Leave += new EventHandler(base.control_Leave);
            this.txtObservaciones.Leave += new EventHandler(base.control_Leave);
            

                Inicializador(tipoOperacion, entidadId);

            this._tipoOperacion = tipoOperacion;
            ImagenTituloPanelSuperior = ImagenesFormulario.Cliente;

            this.txtCodigo.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            //1-instancio por medio del proyector
            Socio = ObjectFactory.GetInstance<DatosSocio>();
            try
            {
                Socio = comunUoW.DatoSocioRepositorio.ObtenerPorId(entidadId.Value);

                this.txtCodigo.Text = Socio.Codigo;
                this.txtApellido.Text = Socio.Apellido;
                this.txtNombre.Text = Socio.Codigo;
                this.txtDireccion.Text = Socio.Direccion;
                this.txtFechaNac.Text = Socio.FechaNacimiento.ToString();
                this.txtTelefono.Text = Socio.Telefono;
                this.txtObservaciones.Text = Socio.Observacion;
                //this.dtpFechaVencimiento.Text = Socio.FechaVencimiento.ToString();

                this.txtEdad.Text = CalcularEdadSocio.Calcular(Socio.FechaNacimiento, DateTime.Today);

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
            // obtengo todos los grupos de la BD
            var socios = comunUoW.DatoSocioRepositorio.ObtenerTodo(string.Empty);

            //es`para controlar que los datos nuevos no sean igual a los existentes
            if (_tipoOperacion ==PresentacionBase.Constante.TipoOperacion.Nuevo)
            {
                if (socios.Any(x => x.Codigo.Equals(this.txtCodigo.Text)))
                {
                   PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El Código {0} ya Existe ", this.txtCodigo.Text));
                    return true;
                }
               
            }

            //controla que al modificar los datos no exista uno igual
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Modificar)
            {
                if (socios.Any(x => x.Codigo.Equals(this.txtCodigo.Text) && x.Id != Socio.Id))
                {
                   PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El Codigo {0} ya Existe ", this.txtCodigo.Text));
                    return true;
                }

             
            }


            return false;
        }

        public override void NuevoRegistro()
        {
            try
            {
                Socio = new DatosSocio
                {
                    Codigo = this.txtCodigo.Text,
                    Nombre = this.txtNombre.Text,
                    Apellido = this.txtApellido.Text,
                    Direccion = this.txtDireccion.Text,
                    Telefono = this.txtTelefono.Text,
                    FechaNacimiento = this.dtpFechaNacimiento.Value,
                    Observacion =  this.txtObservaciones.Text,
                    
                    
                };

                comunUoW.DatoSocioRepositorio.Insertar(Socio);
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
                comunUoW.DatoSocioRepositorio.Eliminar(Socio);
                comunUoW.DatoSocioRepositorio.Commit();
            }
            catch (DataException ex)
            {

                Mensaje.Mostrar("El socio seleccionado se encuentra vinculado a otro objeto",
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
                Socio.Codigo = this.txtCodigo.Text;
                Socio.Apellido = this.txtApellido.Text;
                Socio.Codigo = this.txtNombre.Text;
                Socio.Direccion = this.txtDireccion.Text;
                Socio.Telefono = this.txtTelefono.Text;
                
                Socio.Observacion = this.txtObservaciones.Text;
                Socio.FechaNacimiento = this.dtpFechaNacimiento.Value;
                

                comunUoW.DatoSocioRepositorio.Modificar(Socio);
                comunUoW.DatoSocioRepositorio.Commit();
                this.txtCodigo.Focus();


            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex,PresentacionBase.Constante.TipoMensaje.Error);

            }
        }

        private void _00201_Socio_ABM_Load(object sender, EventArgs e)
        {
            ImagenTituloPanelSuperior = ImagenesFormulario.Cliente;
            this.txtCodigo.Focus();
            this.dtpFechaNacimiento.MaxDate = DateTime.Today;
        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            this.txtEdad.Text = CalcularEdadSocio.Calcular(((DateTimePicker)sender).Value, DateTime.Today);
        }


    }
}
