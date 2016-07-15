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
    public partial class _00207_Membresia_ABM : FormularioABM
    {

        //1- INSTANCIAR LA UNIDAD DE TRABAJO
        private readonly IUnidadDeTrabajoComun comunUoW = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();

        private Membresia membresia;

        private string _tipoOperacion = string.Empty;
        public _00207_Membresia_ABM()
        {
            InitializeComponent();
        }

          /// <summary>
        /// sobreconstructor
        /// </summary>
        public _00207_Membresia_ABM(string tipoOperacion, long? entidadId)
            :base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            this.Name = "_00203_ABM_Membresia";
            this.TituloVentana = "Membresia";
            this.Titulo = "Gestión de Membresias";
            this.Leyenda = "Aquí Ud podrá dar de Alta, Modificar o Eliminar una Membresia";

            Inicializador(tipoOperacion, entidadId);


            //// Cargar evento de validacion para datos Obligatorios
            this.txtCodigo.Validated += new EventHandler(base.textBox_Validated);
            this.txtNombre.Validated += new EventHandler(base.textBox_Validated);
            this.txtDescripcion.Validated += new EventHandler(base.textBox_Validated);
          


            //// Cargar evento de Validacion de Caracteres 
            this.txtNombre.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);
            this.txtDescripcion.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);
            this.txtCodigo.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);
            

            // Color al recibir el Foco
            this.txtNombre.Enter += new EventHandler(base.control_Enter);
            this.txtCodigo.Enter += new EventHandler(base.control_Enter);
            this.txtDescripcion.Enter += new EventHandler(base.control_Enter);


            // Color al perder el Foco
            this.txtNombre.Leave += new EventHandler(base.control_Leave);
            this.txtCodigo.Leave += new EventHandler(base.control_Leave);
            this.txtDescripcion.Leave += new EventHandler(base.control_Leave);



            //guarda la operacion que estas por hacer
            this._tipoOperacion = tipoOperacion;

              ImagenTituloPanelSuperior = ImagenesFormulario.Membresia;

        }


        public override void CargarDatos(long? entidadId)
        {
            //1-instancio por medio del proyector
            membresia = ObjectFactory.GetInstance<Membresia>();

            try
            {
                //obtiene el id de la entidad membresia
                membresia = comunUoW.MembresiaRepositorio.ObtenerPorId(entidadId.Value);

                //le asigna los datos cargados en los texbox a las propiedades
                this.txtCodigo.Text = membresia.Codigo;
                this.txtNombre.Text = membresia.Nombre;
                this.txtDescripcion.Text = membresia.Descripcion;
              
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
            var membresias = comunUoW.MembresiaRepositorio.ObtenerTodo(string.Empty);


            //es`para controlar que los datos nuevos no sean igual a los existentes
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Nuevo)
            {
                if (membresias.Any(x => x.Codigo.Equals(this.txtCodigo.Text)))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El codigo {0} ya Existe ", this.txtCodigo.Text));
                    return true;
                }

                if (membresias.Any(x => x.Nombre.Equals(this.txtCodigo.Text)))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtNombre, errorProvider, string.Format("El Nombre {0} ya Existe ", this.txtNombre.Text));
                    return true;
                }

            }

            //controla que al modificar los datos no exista uno igual
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Modificar)
            {
                if (membresias.Any(x => x.Nombre.Equals(this.txtCodigo.Text) && x.Id != membresia.Id))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El Código {0} ya Existe ", this.txtCodigo.Text));
                    return true;
                }
                if (membresias.Any(x => x.Nombre.Equals(this.txtNombre.Text) && x.Id != membresia.Id))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtNombre, errorProvider, string.Format("El Nombre {0} ya Existe ", this.txtNombre.Text));
                    return true;
                }
                if (membresias.Any(x => x.Descripcion.Contains(this.txtDescripcion.Text) && x.Id != membresia.Id))
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
                membresia = new Membresia
                {
                    Nombre = this.txtNombre.Text,
                    Codigo = this.txtCodigo.Text,
                    Descripcion = this.txtDescripcion.Text
                   
               

                };
                //inserta los registros
                comunUoW.MembresiaRepositorio.Insertar(membresia);
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
                comunUoW.MembresiaRepositorio.Eliminar(membresia);
                comunUoW.MembresiaRepositorio.Commit();
            }
            catch (DataException ex)
            {

                Mensaje.Mostrar("La membresia seleccionada se encuentra vinculada a otro objeto",
                   PresentacionBase.Constante.TipoMensaje.Error);
            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, PresentacionBase. Constante.TipoMensaje.Error);
            }
        }
        
        ///Modifica los datos
        public override void ModificarRegistro()
        {
            try
            {

                membresia.Nombre = this.txtNombre.Text;
                membresia.Codigo = this.txtCodigo.Text;
                membresia.Descripcion = this.txtDescripcion.Text;
                   
               

                
                //inserta los registros
                comunUoW.MembresiaRepositorio.Modificar(membresia);
                //recien guarda los campos en la base
                comunUoW.Commit();


            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, PresentacionBase.Constante.TipoMensaje.Error);

            }
        }
    }
}
