using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Producto.Entidades;
using Dominio.Producto.UnidadDeTrabajo;
using PresentacionPlantilla;
using StructureMap;

namespace PresentacionProducto
{
    public partial class _00402_Proveedores_ABM : FormularioABM
    {
        //1- INSTANCIAR LA UNIDAD DE TRABAJO
        private readonly Dominio.Producto.UnidadDeTrabajo.IUnidadDeTabajoProducto _proveedorUow
              = ObjectFactory.GetInstance<IUnidadDeTabajoProducto>();

        private Proveedor Proveedor;

        private string _tipoOperacion = string.Empty;

        public _00402_Proveedores_ABM()
        {
            InitializeComponent();
        }

        public _00402_Proveedores_ABM(string tipoOperacion, long? entidadId)
            :base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            this.Name = "_00402_Proveedor_AMB";
            this.TituloVentana = "Proveedores";
            this.Titulo = "Provedores";
            this.Leyenda = "Aquí Ud podrá dar de Alta, Modificar o Eliminar un Proveedor";

            Inicializador(tipoOperacion, entidadId);

            //// Cargar evento de validacion para datos Obligatorios
            this.txtCuil.Validated += new EventHandler(base.textBox_Validated);
            this.txtNombre.Validated += new EventHandler(base.textBox_Validated);
            this.txtApellido.Validated += new EventHandler(base.textBox_Validated);
            this.txtDireccion.Validated += new EventHandler(base.textBox_Validated);
            this.txtTelefono.Validated += new EventHandler(base.textBox_Validated);
           

            //// Cargar evento de Validacion de Caracteres 
           this.txtNombre.KeyPress += new KeyPressEventHandler(base.textBoxSoloLetras_KeyPress);
           this.txtApellido.KeyPress += new KeyPressEventHandler(base.textBoxSoloLetras_KeyPress);
           this.txtTelefono.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);
           this.txtDireccion.KeyPress += new KeyPressEventHandler(base.textBoxSoloLetras_KeyPress);
            this.txtCuil.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);

             // Color al recibir el Foco
            this.txtNombre.Enter += new EventHandler(base.control_Enter);
            this.txtApellido.Enter += new EventHandler(base.control_Enter);
            this.txtTelefono.Enter += new EventHandler(base.control_Enter);
            this.txtDireccion.Enter += new EventHandler(base.control_Enter);
            this.txtCuil.Enter += new EventHandler(base.control_Enter);

      

            // Color al perder el Foco
            this.txtNombre.Leave += new EventHandler(base.control_Leave);
            this.txtCuil.Leave += new EventHandler(base.control_Leave);
            this.txtApellido.Leave += new EventHandler(base.control_Leave);
            this.txtTelefono.Leave += new EventHandler(base.control_Leave);
            this.txtDireccion.Leave += new EventHandler(base.control_Leave);


            //guarda la operacion que estas por hacer
            this._tipoOperacion = tipoOperacion;

            this.txtApellido.Focus();


             }

        public override void CargarDatos(long? entidadId)
        {
            //1-instancio por medio del proyector
            Proveedor = ObjectFactory.GetInstance<Proveedor>();

            try
            {
                //obtiene el id de la entidad membresia
                Proveedor = _proveedorUow.ProveedorRepositorio.ObtenerPorId(entidadId.Value);

                //le asigna los datos cargados en los texbox a las propiedades
                this.txtNombre.Text = Proveedor.Nombre;
                this.txtCuil.Text = Proveedor.Cuil;
                this.txtApellido.Text = Proveedor.Apellido;
                this.txtTelefono.Text = Proveedor.Telefono;
                this.txtDireccion.Text = Proveedor.Direccion;

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
            var proveedor = _proveedorUow.ProveedorRepositorio.ObtenerTodo(string.Empty);


            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Nuevo)
            {
                if (proveedor.Any(x => x.Cuil.Equals(this.txtCuil.Text)))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtCuil, errorProvider,
                        string.Format("El Número de Cuil {0} ya Existe ", this.txtCuil.Text));
                    return true;
                }
            }

            //controla que al modificar los datos no exista uno igual
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Modificar)
            {

                if (proveedor.Any(x => x.Cuil.Equals(this.txtCuil.Text) && x.Id != Proveedor.Id))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtCuil, errorProvider,
                        string.Format("El Número de Cuil {0} ya Existe ", this.txtCuil.Text));
                    return true;
                }
            }


            return false;

        }


        public override void NuevoRegistro()
        {
            try
            {
                Proveedor = new Proveedor
                {

                    Nombre = this.txtNombre.Text,
                    Cuil = this.txtCuil.Text.ToString(),
                    Apellido = this.txtApellido.Text,
                    Telefono = this.txtTelefono.Text,
                    Direccion = this.txtDireccion.Text,



                };
                //inserta los registros
                _proveedorUow.ProveedorRepositorio.Insertar(Proveedor);
                //recien guarda los campos en la base
                _proveedorUow.Commit();





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
                _proveedorUow.ProveedorRepositorio.Eliminar(Proveedor);
                _proveedorUow.Commit();
            }
            catch (DataException ex)
            {

                Mensaje.Mostrar("El Proveedor seleccionado se encuentra vinculado a otro objeto",
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


                Proveedor.Nombre = this.txtNombre.Text;
                Proveedor.Cuil = this.txtCuil.Text;
                Proveedor.Apellido = this.txtApellido.Text;
                Proveedor.Telefono = this.txtTelefono.Text;
                Proveedor.Direccion = this.txtDireccion.Text;

                //inserta los registros
                _proveedorUow.ProveedorRepositorio.Modificar(Proveedor);
                //recien guarda los campos en la base
                _proveedorUow.Commit();


            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, PresentacionBase.Constante.TipoMensaje.Error);

            }
        }
    }
}
