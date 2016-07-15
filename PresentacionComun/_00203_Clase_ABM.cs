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
    public partial class _00203_Clase_ABM : FormularioABM
    {

        private readonly IUnidadDeTrabajoComun comunUoW = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();
        private Clase Clase;
        

        private string _tipoOperacion = string.Empty;

        public _00203_Clase_ABM()
        {
            InitializeComponent();
        }

        public _00203_Clase_ABM(string tipoOperacion, long? entidadId)
            :base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            this.Name = "_00203_ABM_TipoClase";
            this.TituloVentana = "Clase";
            this.Titulo = "Gestión de Clases";
            this.Leyenda = "Aquí Ud podrá dar de Alta, Modificar o Eliminar una Clase";

            this._tipoOperacion = tipoOperacion;

            // Cargar evento de validacion para datos Obligatorios
            this.txtCodigo.Validated += new EventHandler(base.textBox_Validated);
            this.txtNombre.Validated += new EventHandler(base.textBox_Validated);
            

            // Cargar evento de Validacion de Caracteres 
            this.txtCodigo.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);
            this.txtNombre.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);
            
            // Color al recibir el Foco
            this.txtCodigo.Enter += new EventHandler(base.control_Enter);
            this.txtNombre.Enter += new EventHandler(base.control_Enter);
            this.nudPrecio.Enter += new EventHandler(base.control_Enter);
          
            // Color al perder el Foco
            this.txtCodigo.Leave += new EventHandler(base.control_Leave);
            this.txtNombre.Leave += new EventHandler(base.control_Leave);
            this.nudPrecio.Leave += new EventHandler(base.control_Leave);

            this._tipoOperacion = tipoOperacion;
            Inicializador(tipoOperacion, entidadId);
            ImagenTituloPanelSuperior = ImagenesFormulario.Clases;



        }

        public override void CargarDatos(long? entidadId)
        {
            Clase = ObjectFactory.GetInstance<Clase>();
            try
            {
                Clase = comunUoW.TipoClaseRepositorio.ObtenerPorId(entidadId.Value);

                this.txtCodigo.Text = Clase.Codigo;
                this.txtNombre.Text = Clase.Nombre;
                this.nudPrecio.Value = Clase.Precio;
                this.nudCupo.Value = Clase.Cupo;
            }
            catch (Exception)
            {

                Mensaje.Mostrar(new Exception("Error al cargar los Datos"), Constante.TipoMensaje.Error);
                
            }
        }

        public override void VerificarDatosObligatorios()
        {
            base.VerificarDatosObligatorios();
            this.ValidateChildren();
        }

        public override bool VerificarSiExisteDatos()
        {
            var tiposClases = comunUoW.TipoClaseRepositorio.ObtenerTodo(string.Empty);

            //es`para controlar que los datos nuevos no sean igual a los existentes
            if (_tipoOperacion == Constante.TipoOperacion.Nuevo)
            {
                if (tiposClases.Any(x => x.Codigo.Equals(this.txtCodigo.Text)))
                {
                    Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El código {0} ya Existe ", this.txtCodigo.Text));
                    return true;
                }
                if (tiposClases.Any(x => x.Nombre.Equals(this.txtNombre.Text)))
                {
                    Constante.Validacion.DatoExistente(this.txtNombre, errorProvider, string.Format("La clase {0} ya Existe ", this.txtNombre.Text));
                    return true;
                }

            }
            //controla que al modificar los datos no exista uno igual
            if (_tipoOperacion == Constante.TipoOperacion.Modificar)
            {
                if (tiposClases.Any(x => x.Codigo.Equals(this.txtCodigo.Text) && x.Id != Clase.Id))
                {
                    Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El código {0} ya Existe ", this.txtCodigo.Text));
                    return true;
                }
                if (tiposClases.Any(x => x.Nombre.Equals(this.txtNombre.Text) && x.Id != Clase.Id))
                {
                    Constante.Validacion.DatoExistente(this.txtNombre, errorProvider, string.Format("La clase {0} ya Existe ", this.txtNombre.Text));
                    return true;
                }
            }



            return false;
            
        }

        public override void NuevoRegistro()
        {
            try
            {
                Clase = new Clase
                {
                    Codigo = this.txtCodigo.Text,
                    Nombre = this.txtNombre.Text,
                    Precio = Convert.ToInt32(this.nudPrecio.Value),
                    Cupo = Convert.ToInt32(this.nudCupo.Value),
                    

                };

                comunUoW.TipoClaseRepositorio.Insertar(Clase);
                comunUoW.Commit();
                this.nudCupo.Value = 0;
                this.nudPrecio.Value = 0;


                this.txtCodigo.Focus();

            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, Constante.TipoMensaje.Error);
            }
        }

        public override void EliminarRegistro()
        {


            try
            {
                comunUoW.TipoClaseRepositorio.Eliminar(Clase);
                comunUoW.TipoClaseRepositorio.Commit();
            }
            catch (DataException ex)
            {

                Mensaje.Mostrar("El socio seleccionado se encuentra vinculada a otro objeto",
                    Constante.TipoMensaje.Error);
            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, Constante.TipoMensaje.Error);
            }
        }

        public override void ModificarRegistro()
        {
            try
            {
                Clase.Codigo = this.txtCodigo.Text;
                Clase.Nombre = this.txtNombre.Text;
                Clase.Precio = Convert.ToInt32(nudPrecio.Value);
                Clase.Cupo = Convert.ToInt32(nudCupo.Value);



                comunUoW.TipoClaseRepositorio.Modificar(Clase);
                comunUoW.TipoClaseRepositorio.Commit();


            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, Constante.TipoMensaje.Error);

            }
        }

    }
}
