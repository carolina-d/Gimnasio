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
    public partial class _00003_Empleado_ABM : FormularioABM
    {
        private readonly ISeguridadUnidadDeTrabajo seguridadUoW = ObjectFactory.GetInstance<ISeguridadUnidadDeTrabajo>();
        private Empleado empleado;
        private string _tipoOperacion = string.Empty;

        public TipoEmpleado TipoEmpleados { get; set; }


         public _00003_Empleado_ABM()
        {
            InitializeComponent();
        }

         public _00003_Empleado_ABM(string tipoOperacion, long? entidadId)
            :base(tipoOperacion, entidadId)
         {
             InitializeComponent();

             this.Name = "_00105_ABM_Empleado";
             this.TituloVentana = "Empleado";
             this.Titulo = "Gestión de Empleados";
             this.Leyenda = "Aquí Ud podrá dar de Alta, Modificar o Eliminar un Empleado";

             
             this._tipoOperacion = tipoOperacion;

             // Cargar evento de validacion para datos Obligatorios
             this.txtCodigo.Validated += new EventHandler(base.textBox_Validated);
             this.txtApellido.Validated += new EventHandler(base.textBox_Validated);
             this.txtNombre.Validated += new EventHandler(base.textBox_Validated);
             this.txtDNI.Validated += new EventHandler(base.textBox_Validated);
             this.txtTelefono.Validated += new EventHandler(base.textBox_Validated);

             // Cargar evento de Validacion de Caracteres 
             this.txtCodigo.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);
             this.txtApellido.KeyPress += new KeyPressEventHandler(base.textBoxSoloLetras_KeyPress);
             this.txtNombre.KeyPress += new KeyPressEventHandler(base.textBoxSoloLetras_KeyPress);
             this.txtDNI.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);
             this.txtTelefono.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);
            
             // Color al recibir el Foco
             this.txtCodigo.Enter += new EventHandler(base.control_Enter);
             this.txtApellido.Enter += new EventHandler(base.control_Enter);
             this.txtNombre.Enter += new EventHandler(base.control_Enter);
             this.txtDNI.Enter += new EventHandler(base.control_Enter);
             this.txtTelefono.Enter += new EventHandler(base.control_Enter);
             
            // Color al perder el Foco
             this.txtApellido.Leave += new EventHandler(base.control_Leave);
             this.txtDNI.Leave += new EventHandler(base.control_Leave);
             this.txtNombre.Leave += new EventHandler(base.control_Leave);
             this.txtTelefono.Leave += new EventHandler(base.control_Leave);
             this.txtCodigo.Leave += new EventHandler(base.control_Leave);


             this.txtCodigo.Focus();
             Inicializador(tipoOperacion, entidadId);
             PoblarComboBox(cmbTipoEmpleado, seguridadUoW.TipoEmpleadoRepositorio.ObtenerTodo(), "Descripcion", "Id");

         }

        public override void CargarDatos(long? entidadId)
        {
            // Instancion por medio del Inyector el Objeto Grupo
            empleado = ObjectFactory.GetInstance<Empleado>();

            if (entidadId.HasValue)
            {
                empleado = seguridadUoW.EmpleadoRepositorio.ObtenerPorId(entidadId.Value);

                this.txtCodigo.Text = empleado.Codigo;
                this.txtApellido.Text = empleado.Apellido;
                this.txtNombre.Text = empleado.Nombre;
                this.txtDNI.Text = empleado.Dni;
                this.txtTelefono.Text = empleado.Celular;
                this.cmbTipoEmpleado.SelectedValue = empleado.TipoEmpleadoId;

                this.dtpFechaNac.Value = empleado.FechaNacimiento;
               

              }

            else
            {
                Mensaje.Mostrar(new Exception("Error al Cargar los daros"), Constante.TipoMensaje.Error);
            }
        }


        public override void VerificarDatosObligatorios()
        {
            base.VerificarDatosObligatorios();
            this.ValidateChildren();

           if (this.cmbTipoEmpleado.Items.Count <= 0)
            {
                _datosObligatorios = false;
            }
        }

        public override bool VerificarSiExisteDatos()
        {
            // obtengo todos los grupos de la BD
            var Empleados = seguridadUoW.EmpleadoRepositorio.ObtenerTodo(string.Empty);

            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Nuevo)
            {
                if (Empleados.Any(x => x.Codigo.Equals(this.txtCodigo.Text)))
                {
                    Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El Código {0} ya Existe", this.txtCodigo.Text));
                    return true;
                }
                if (Empleados.Any(x => x.Dni.Equals(this.txtDNI.Text)))
                {
                    Constante.Validacion.DatoExistente(this.txtDNI, errorProvider, string.Format("El Dni {0} ya Existe", this.txtDNI.Text));
                    return true;
                }

            }

            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Modificar)
            {
                if (Empleados.Any(x => x.Codigo.Equals(this.txtCodigo.Text) && x.Id != empleado.Id))
                {
                    Constante.Validacion.DatoExistente(this.txtDNI, errorProvider, string.Format("El Código {0} ya Existe", this.txtCodigo.Text));
                    return true;
                }
                if (Empleados.Any(x => x.Dni.Equals(this.txtDNI.Text) && x.Id != empleado.Id))
                {
                    Constante.Validacion.DatoExistente(this.txtDNI, errorProvider, string.Format("El Dni {0} ya Existe", this.txtDNI.Text));
                    return true;
                }

            }

            return false;
        }

        public override void NuevoRegistro()
        {
            try
            {
                empleado = new Empleado
                {
                    Apellido = this.txtApellido.Text,
                    Nombre = this.txtNombre.Text,
                    Dni = this.txtDNI.Text,
                    Celular = this.txtTelefono.Text,
                    Codigo = this.txtCodigo.Text,
                    TipoEmpleadoId = Convert.ToInt32(this.cmbTipoEmpleado.SelectedValue),

                    FechaNacimiento = this.dtpFechaNac.Value
                };

                seguridadUoW.EmpleadoRepositorio.Insertar(empleado);
                seguridadUoW.Commit();

                this.txtApellido.Focus();
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
                seguridadUoW.EmpleadoRepositorio.Eliminar(empleado);
                seguridadUoW.Commit();
            }
            catch (DataException ex)
            {
                Mensaje.Mostrar("El Empleado seleccionado se encuentra vinculado a otro objeto.", Constante.TipoMensaje.Error);
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
                empleado.Codigo = this.txtCodigo.Text;
                empleado.Apellido = this.txtApellido.Text;
                empleado.Nombre = this.txtNombre.Text;
                empleado.Dni = this.txtDNI.Text;
                empleado.Celular = this.txtTelefono.Text;
                
                empleado.TipoEmpleadoId = Convert.ToInt32(this.cmbTipoEmpleado.SelectedValue);
              
                empleado.FechaNacimiento = this.dtpFechaNac.Value;

               seguridadUoW.EmpleadoRepositorio.Modificar(empleado);
               seguridadUoW.Commit();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex, Constante.TipoMensaje.Error);
            }
        }

        private void _00003_Empleado_ABM_Load(object sender, EventArgs e)
        {
            this.dtpFechaNac.MaxDate = DateTime.Today;

        }


    }
}
