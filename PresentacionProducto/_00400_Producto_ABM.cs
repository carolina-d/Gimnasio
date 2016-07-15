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
    public partial class _00400_Producto_ABM : FormularioABM
    {
        private readonly Dominio.Producto.UnidadDeTrabajo.IUnidadDeTabajoProducto productoUWO
         = ObjectFactory.GetInstance<IUnidadDeTabajoProducto>();

        private Producto Producto;

        private string _tipoOperacion = string.Empty;

        public _00400_Producto_ABM()
        {
            InitializeComponent();
        }

        public _00400_Producto_ABM(string tipoOperacion, long? entidadId)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            this.Name = "_00203_ABM_Producto";
            this.TituloVentana = "Productos";
            this.Titulo = "ABM de Productos";
            this.Leyenda = "Aquí Ud podrá dar de Alta, Modificar o Eliminar un Producto";

            Inicializador(tipoOperacion, entidadId);

            //// Cargar evento de validacion para datos Obligatorios
            this.txtCodigoProducto.Validated += new EventHandler(base.textBox_Validated);
            this.txtDescripcion.Validated += new EventHandler(base.textBox_Validated);


            //// Cargar evento de Validacion de Caracteres 
            this.txtCodigoProducto.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);
            this.txtDescripcion.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);



            // Color al recibir el Foco
            this.txtCodigoProducto.Enter += new EventHandler(base.control_Enter);
            this.nudPrecio.Enter += new EventHandler(base.control_Enter);
            this.txtDescripcion.Enter += new EventHandler(base.control_Enter);
            this.nudStock.Enter += new EventHandler(base.control_Enter);

            // Color al perder el Foco
            this.txtCodigoProducto.Leave += new EventHandler(base.control_Leave);
            this.nudPrecio.Leave += new EventHandler(base.control_Leave);
            this.txtDescripcion.Leave += new EventHandler(base.control_Leave);
            this.nudStock.Leave += new EventHandler(base.control_Leave);


            this._tipoOperacion = tipoOperacion;
        }
        public override void CargarDatos(long? entidadId)
        {
            Producto = ObjectFactory.GetInstance<Producto>();
            try
            {
                Producto = productoUWO.ProductoRepositorio.ObtenerPorId(entidadId.Value);

                this.txtCodigoProducto.Text = Producto.Codigo.ToString();
                this.txtDescripcion.Text = Producto.Descripcion;
                this.nudPrecio.Value = Producto.PrecioUnitario;
                this.nudStock.Value = Producto.Stock;
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
            var producto = productoUWO.ProductoRepositorio.ObtenerTodo(string.Empty);

            
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Nuevo)
            {
                if (producto.Any(x => x.Codigo.Equals(this.txtCodigoProducto.Text)))
                {
                   PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigoProducto, errorProvider, string.Format("El código {0} ya Existe ", this.txtCodigoProducto.Text));
                    return true;
                }
                if (producto.Any(x => x.Descripcion.Equals(this.txtDescripcion.Text)))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtDescripcion, errorProvider, string.Format("La Descripcion {0} ya Existe ", this.txtDescripcion.Text));
                    return true;
                }

            }

            //controla que al modificar los datos no exista uno igual
             if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Modificar)
             {
                 
                 if (producto.Any(x => x.Codigo.Equals(this.txtCodigoProducto.Text) && x.Id != Producto.Id))
                 {
                     PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigoProducto, errorProvider, string.Format("El código {0} ya Existe ", this.txtCodigoProducto.Text));
                     return true;
                 }
                 if (producto.Any(x => x.Descripcion.Equals(this.txtDescripcion.Text)))
                 {
                     PresentacionBase.Constante.Validacion.DatoExistente(this.txtDescripcion, errorProvider, string.Format("La descripcion {0} ya Existe ", this.txtDescripcion.Text));
                     return true;
                 }
             }


            return false;

        }

        public override void NuevoRegistro()
        {
            try
            {
                Producto = new Producto
                {
                    Codigo = Convert.ToInt32(this.txtCodigoProducto.Text),
                    Descripcion = this.txtDescripcion.Text,
                    PrecioUnitario = this.nudPrecio.Value,
                    Stock = Convert.ToInt32(this.nudStock.Value)


                };

                productoUWO.ProductoRepositorio.Insertar(Producto);
                productoUWO.Commit();
                this.nudPrecio.Value = 0;
                this.nudStock.Value = 0;


                this.txtCodigoProducto.Focus();

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
                productoUWO.ProductoRepositorio.Eliminar(Producto);
                productoUWO.ProductoRepositorio.Commit();
            }
            catch (DataException ex)
            {

                Mensaje.Mostrar("El producto seleccionado se encuentra vinculada a otro objeto",
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
                Producto.Codigo = Convert.ToInt32(this.txtCodigoProducto.Text);
                Producto.Descripcion = this.txtDescripcion.Text;
                Producto.PrecioUnitario = nudPrecio.Value;
                Producto.Stock = Convert.ToInt32(nudPrecio.Value);



                productoUWO.ProductoRepositorio.Modificar(Producto);
                productoUWO.ProductoRepositorio.Commit();


            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex,PresentacionBase.Constante.TipoMensaje.Error);

            }
        }



        private void _00400_Producto_ABM_Load(object sender, EventArgs e)
        {

        }
    }
}
