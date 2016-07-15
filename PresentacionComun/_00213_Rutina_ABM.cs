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
using System.Transactions;


namespace PresentacionComun
{
    public partial class _00213_Rutina_ABM : FormularioABM
    {
        private readonly IUnidadDeTrabajoComun comunUoW = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();
        private Rutina Rutinas;
        private TipoRutina tipoRutina;

        private string _tipoOperacion = string.Empty;

        public _00213_Rutina_ABM()
        {
            InitializeComponent();
        }

         public _00213_Rutina_ABM(string tipoOperacion, long? entidadId)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            this.Name = "_00213_ABM_Rutina";
            this.TituloVentana = "Rutina";
            this.Titulo = "Gestión de Rutinas";
            this.Leyenda = "Aquí Ud podrá dar de Alta, Modificar o Eliminar una Rutina";

            //// Cargar evento de validacion para datos Obligatorios
            this.txtNombre.Validated += new EventHandler(base.textBox_Validated);
            this.txtDescripcion.Validated += new EventHandler(base.textBox_Validated);
             this.txtDias.Validated += new EventHandler(base.textBox_Validated);
             this.txtRepeticiones.Validated += new EventHandler(base.textBox_Validated);
             this.txtSeries.Validated += new EventHandler(base.textBox_Validated);



            //// Cargar evento de Validacion de Caracteres 
            this.txtNombre.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);
            this.txtDescripcion.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);
            this.txtDias.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);
            this.txtRepeticiones.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);
             this.txtSeries.KeyPress += new KeyPressEventHandler(base.textBoxSoloNumeros_KeyPress);
           

            // Color al recibir el Foco
            this.txtNombre.Enter += new EventHandler(base.control_Enter);
            this.txtDescripcion.Enter += new EventHandler(base.control_Enter);
            this.txtDias.Enter += new EventHandler(base.control_Enter);
            this.txtRepeticiones.Enter += new EventHandler(base.control_Enter);
            this.txtSeries.Enter += new EventHandler(base.control_Enter);

             
            // Color al perder el Foco
            this.txtNombre.Enter += new EventHandler(base.control_Leave);
            this.txtDescripcion.Enter += new EventHandler(base.control_Leave);
            this.txtDias.Enter += new EventHandler(base.control_Leave);
            this.txtRepeticiones.Enter += new EventHandler(base.control_Leave);
            this.txtSeries.Enter += new EventHandler(base.control_Leave);

            

            Inicializador(tipoOperacion, entidadId);

            this._tipoOperacion = tipoOperacion;
           
            PoblarComboBox(cmbTipoRutina, comunUoW.TipoRutinaRepositorio.ObtenerTodo(), "Descripcion", "Id");

             this.txtNombre.Focus();

             ImagenTituloPanelSuperior = ImagenesFormulario.TipoRutina;


        }

        public override void CargarDatos(long? entidadId)
        {
            if (cmbTipoRutina.Items.Count > 0)
                this.cmbTipoRutina.SelectedIndex = Convert.ToInt32(Rutinas.TipoRutinaId);

          
            Rutinas = ObjectFactory.GetInstance<Rutina>();
            try
            {
                Rutinas = comunUoW.RutinaRepositorio.ObtenerPorId(entidadId.Value);

                this.txtNombre.Text = Rutinas.Nombre;
                //this.dtpFecha.Value = Rutinas.Fecha;
                this.dtpFecha.MaxDate = DateTime.Today;
                this.txtDias.Text = Rutinas.Dias;
                this.txtDescripcion.Text = Rutinas.Descripcion;
                this.txtSeries.Text = Rutinas.Series.ToString();
                this.txtRepeticiones.Text = Rutinas.Repeticiones.ToString();

                this.cmbTipoRutina.SelectedValue = Rutinas.TipoRutinaId;

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
            // obtengo todos los grupos de la BD
            var rutina = comunUoW.RutinaRepositorio.ObtenerTodo(string.Empty);

            //es`para controlar que los datos nuevos no sean igual a los existentes
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Nuevo)
            {
                if (rutina.Any(x => x.Nombre.Equals(this.txtNombre.Text)))
                {
                     Constante.Validacion.DatoExistente(this.txtNombre, errorProvider, string.Format("El Nombre {0} ya Existe ", this.txtNombre.Text));
                    return true;
                }

            }

            //controla que al modificar los datos no exista uno igual
            if (_tipoOperacion == PresentacionBase.Constante.TipoOperacion.Modificar)
            {
                  if (rutina.Any(x => x.Nombre.Equals(this.txtNombre.Text) && x.Id != Rutinas.Id))
                  {
                      Constante.Validacion.DatoExistente(this.txtNombre, errorProvider, string.Format("El Nombre {0} ya Existe ", this.txtNombre.Text));
                      return true;
                  }
                  if (rutina.Any(x => x.Descripcion.Equals(this.txtDescripcion.Text) && x.Id != Rutinas.Id))
                  {
                      Constante.Validacion.DatoExistente(this.txtDescripcion, errorProvider, string.Format("El Ejercicio {0} ya Existe ", this.txtDescripcion.Text));
                      return true;
                  }
            }


            return false;
        }

        public override void NuevoRegistro()
        {
            try
            {
                Rutinas = new Rutina

                {
                    Nombre = this.txtNombre.Text,
                   // Fecha = this.dtpFecha.Value,
                    Dias = this.txtDias.Text,
                    Descripcion = this.txtDescripcion.Text,
                    Series = Convert.ToInt32(txtSeries.Text),
                    Repeticiones = Convert.ToInt32(txtRepeticiones.Text),
                    TipoRutinaId = Convert.ToInt32(cmbTipoRutina.SelectedValue)


                };

                    comunUoW.RutinaRepositorio.Insertar(Rutinas);
                    comunUoW.RutinaRepositorio.Commit();

                this.txtNombre.Focus();

                    


                    this.txtNombre.Focus();
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
                comunUoW.RutinaRepositorio.Eliminar(Rutinas);
                comunUoW.RutinaRepositorio.Commit();

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
               
                    Rutinas.Nombre = this.txtNombre.Text;
                   // Rutinas.Fecha = this.dtpFecha.Value;
                    Rutinas.Dias = this.txtDias.Text;
                    Rutinas.Descripcion = this.txtDescripcion.Text;
                    Rutinas.Series = Convert.ToInt32(this.txtSeries.Text);
                    Rutinas.Repeticiones = Convert.ToInt32(txtSeries.Text);

                    Rutinas.TipoRutinaId = Convert.ToInt32(cmbTipoRutina.SelectedValue);

                    comunUoW.RutinaRepositorio.Modificar(Rutinas);
                    comunUoW.Commit();

                  


                    this.txtNombre.Focus();
                

            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex,PresentacionBase.Constante.TipoMensaje.Error);
            }
        }

      

        private void _00213_Rutina_ABM_Load(object sender, EventArgs e)
        {
            this.dtpFecha.MaxDate = DateTime.Today;

        }

        private void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            var fNueva = new _00211_TipoRutina_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            fNueva.ShowDialog();
            ActualizarDatosGrilla(string.Empty);
        }
    }
}
