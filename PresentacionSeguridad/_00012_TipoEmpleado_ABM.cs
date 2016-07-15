using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioSeguridad.Entidades;
using DominioSeguridad.UnidadDeTrabajo;
using PresentacionPlantilla;
using StructureMap;

namespace PresentacionSeguridad
{
    public partial class _00012_TipoEmpleado_ABM : FormularioABM
    {
        private readonly ISeguridadUnidadDeTrabajo _seguridadUoW = ObjectFactory.GetInstance<ISeguridadUnidadDeTrabajo>();
        private TipoEmpleado Tipoempleados;
        private string _tipoOperacion = string.Empty;

        public _00012_TipoEmpleado_ABM()
        {
            InitializeComponent();
        }

        public _00012_TipoEmpleado_ABM(string tipoOperacion, long? entidadId)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            this.Name = "_00012_ABM_TipoEmpleado";
            this.TituloVentana = "TipoDeEmpleado";
            this.Titulo = "Gestión de Tipos de Empleado";
            this.Leyenda = "Aquí Ud podrá dar de Alta, Modificar o Eliminar un Tipo de Empleado";

            
           // Cargar evento de validacion para datos Obligatorios
            this.txtDescripción.Validated += new EventHandler(base.textBox_Validated);
            this.txtCodigo.Validated += new EventHandler(base.textBox_Validated);
           // this.nudSueldo.Validated += new EventHandler(base.textBox_Validated);
           

            // Cargar evento de Validacion de Caracteres 
            this.txtDescripción.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);
            this.txtCodigo.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);
            
            

            // Color al recibir el Foco
            this.txtCodigo.Enter += new EventHandler(base.control_Enter);
            this.txtDescripción.Enter += new EventHandler(base.control_Enter);
            this.nudSueldo.Enter += new EventHandler(base.control_Enter);
            

            // Color al perder el Foco
            this.txtDescripción.Leave += new EventHandler(base.control_Leave);
            this.nudSueldo.Leave += new EventHandler(base.control_Leave);
           this.txtCodigo.Leave += new EventHandler(base.control_Leave);


           this._tipoOperacion = tipoOperacion;
           Inicializador(tipoOperacion, entidadId);
        }

        public override void CargarDatos(long? entidadId)
        {
            // Instancion por medio del Inyector el Objeto Grupo
            Tipoempleados = ObjectFactory.GetInstance<TipoEmpleado>();

            if (entidadId.HasValue)
            {
                Tipoempleados = _seguridadUoW.TipoEmpleadoRepositorio.ObtenerPorId(entidadId.Value);

                this.txtCodigo.Text = Tipoempleados.Codigo.ToString();
                this.txtDescripción.Text = Tipoempleados.Descripcion;
                this.nudSueldo.Value = Tipoempleados.Sueldo;
         

                this.txtCodigo.Focus();


            }

            else
            {
                Mensaje.Mostrar(new Exception("Error al Cargar los daros"),PresentacionBase.Constante.TipoMensaje.Error);
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
            var tipoEmpleados = _seguridadUoW.EmpleadoRepositorio.ObtenerTodo(string.Empty);

            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Nuevo)
            {
                if (tipoEmpleados.Any(x => x.Codigo.Equals(this.txtCodigo.Text)))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El Código {0} ya Existe", this.txtCodigo.Text));
                    return true;
                }
                if (tipoEmpleados.Any(x => x.Dni.Equals(this.txtDescripción.Text)))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtDescripción, errorProvider, string.Format("La Descripción {0} ya Existe", this.txtDescripción.Text));
                    return true;
                }

            }

            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Modificar)
            {
                if (tipoEmpleados.Any(x => x.Codigo.Equals(this.txtCodigo.Text) && x.Id != Tipoempleados.Id))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtCodigo, errorProvider, string.Format("El Código {0} ya Existe", this.txtCodigo.Text));
                    return true;
                }
                if (tipoEmpleados.Any(x => x.Dni.Equals(this.txtDescripción.Text) && x.Id != Tipoempleados.Id))
                {
                    PresentacionBase.Constante.Validacion.DatoExistente(this.txtDescripción, errorProvider, string.Format("La Descripción {0} ya Existe", this.txtDescripción.Text));
                    return true;
                }

            }

            return false;
        }

        public override void NuevoRegistro()
        {
            try
            {
                Tipoempleados = new TipoEmpleado
                {
                    Codigo = Convert.ToInt32(txtCodigo.Text),
                    Descripcion = this.txtDescripción.Text,
                    Sueldo =  Convert.ToInt32(nudSueldo.Value)

                };



                _seguridadUoW.TipoEmpleadoRepositorio.Insertar(Tipoempleados);
                _seguridadUoW.Commit();

                
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
                _seguridadUoW.TipoEmpleadoRepositorio.Eliminar(Tipoempleados);
                _seguridadUoW.Commit();
            }
            catch (DataException ex)
            {
                Mensaje.Mostrar("El Tipo de Empleado seleccionado se encuentra vinculado a otro objeto.", PresentacionBase.Constante.TipoMensaje.Error);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex, PresentacionBase.Constante.TipoMensaje.Error);
            }
        }

        public override void ModificarRegistro()
        {
            try
            {
                Tipoempleados.Codigo = Convert.ToInt32(this.txtCodigo.Text);
                Tipoempleados.Descripcion = this.txtDescripción.Text;
                Tipoempleados.Sueldo = Convert.ToInt32(nudSueldo.Value);

                _seguridadUoW.TipoEmpleadoRepositorio.Modificar(Tipoempleados);
                _seguridadUoW.Commit();
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex, PresentacionBase.Constante.TipoMensaje.Error);
            }
        }

    }
}
