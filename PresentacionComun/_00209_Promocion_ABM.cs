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
    public partial class _00209_Promocion_ABM : FormularioABM 
    {
        //1- INSTANCIAR LA UNIDAD DE TRABAJO
        private readonly IUnidadDeTrabajoComun comunUoW = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();

        private Promocion promocion;

        private string _tipoOperacion = string.Empty;
        public _00209_Promocion_ABM()
        {
            InitializeComponent();
        }

        public _00209_Promocion_ABM(string tipoOperacion, long? entidadId)
            :base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            this.Name = "_00203_ABM_Promocion";
            this.TituloVentana = "Promociones";
            this.Titulo = "Promociones";
            this.Leyenda = "Aquí Ud podrá dar de Alta, Modificar o Eliminar una Promoción";

            Inicializador(tipoOperacion, entidadId);


            //// Cargar evento de validacion para datos Obligatorios
            this.txtCodigo.Validated += new EventHandler(base.textBox_Validated);
           this.txtDescripcion.Validated += new EventHandler(base.textBox_Validated);



            //// Cargar evento de Validacion de Caracteres 
           this.txtDescripcion.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);
            this.txtCodigo.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);

            // Color al recibir el Foco
            this.nudPrecio.Enter += new EventHandler(base.control_Enter);
            this.txtCodigo.Enter += new EventHandler(base.control_Enter);
            this.txtDescripcion.Enter += new EventHandler(base.control_Enter);


            // Color al perder el Foco
            this.nudPrecio.Leave += new EventHandler(base.control_Leave);
            this.txtCodigo.Leave += new EventHandler(base.control_Leave);
            this.txtDescripcion.Leave += new EventHandler(base.control_Leave);

            
            //guarda la operacion que estas por hacer
            this._tipoOperacion = tipoOperacion;
            ImagenTituloPanelSuperior = ImagenesFormulario.Promocion;

            this.txtCodigo.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            //1-instancio por medio del proyector
            promocion = ObjectFactory.GetInstance<Promocion>();

            try
            {
                //obtiene el id de la entidad membresia
                promocion = comunUoW.PromocionRepositorio.ObtenerPorId(entidadId.Value);

                //le asigna los datos cargados en los texbox a las propiedades
                this.txtCodigo.Text = promocion.Codigo;
                this.nudPrecio.Value = promocion.Precio;
                this.txtDescripcion.Text = promocion.Descripcion;

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
            var promociones = comunUoW.PromocionRepositorio.ObtenerTodo(string.Empty);


            //es`para controlar que los datos nuevos no sean igual a los existentes
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Nuevo)
            {
                if (promociones.Any(x => x.Codigo.Equals(this.txtCodigo.Text)))
                {
                   PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El Código {0} ya Existe ", this.txtCodigo.Text));
                    return true;
                }

                if (promociones.Any(x => x.Descripcion.Equals(this.txtCodigo.Text)))
                {
                   PresentacionBase.Constante.Validacion.DatoExistente(this.txtDescripcion, errorProvider, string.Format("El Nombre {0} ya Existe ", this.txtDescripcion.Text));
                    return true;
                }

            }

            //controla que al modificar los datos no exista uno igual
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Modificar)
            {
                if (promociones.Any(x => x.Codigo.Equals(this.txtCodigo.Text) && x.Id != promocion.Id))
                {
                   PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El Código {0} ya Existe ", this.txtCodigo.Text));
                    return true;
                }

                if (promociones.Any(x => x.Descripcion.Contains(this.txtDescripcion.Text) && x.Id != promocion.Id))
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
                promocion = new Promocion
                {
                    Precio = Convert.ToInt32(nudPrecio.Value),
                    Codigo = this.txtCodigo.Text,
                    Descripcion = this.txtDescripcion.Text



                };
                //inserta los registros
                comunUoW.PromocionRepositorio.Insertar(promocion);
                //recien guarda los campos en la base
                comunUoW.Commit();



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
                comunUoW.PromocionRepositorio.Eliminar(promocion);
                comunUoW.PromocionRepositorio.Commit();
            }
            catch (DataException ex)
            {

                Mensaje.Mostrar("La promoción seleccionada se encuentra vinculada a otro objeto",
                   PresentacionBase.Constante.TipoMensaje.Error);
            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, PresentacionBase.Constante.TipoMensaje.Error);
            }
        }

        ///Modifica los datos
        public override void ModificarRegistro()
        {
            try
            {

                promocion.Precio = Convert.ToInt32(nudPrecio.Value);
                promocion.Descripcion = this.txtDescripcion.Text;
                promocion.Codigo = this.txtCodigo.Text;


                //inserta los registros
                comunUoW.PromocionRepositorio.Modificar(promocion);
                //recien guarda los campos en la base
                comunUoW.PromocionRepositorio.Commit();


            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, PresentacionBase.Constante.TipoMensaje.Error);

            }
        }

        private void _00209_Promocion_ABM_Load(object sender, EventArgs e)
        {

        }
    }
}
