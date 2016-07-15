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
    public partial class _00205_HorarioClase_ABM : FormularioABM
    {
        private readonly IUnidadDeTrabajoComun comunUoW = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();

        public Clase Clases;
        public HorarioClase Horario;

        private string _tipoOperacion = string.Empty;

        public DateTimePicker time { get; set; }

        public long? claseId { get; set; }

        public _00205_HorarioClase_ABM()
        {
            InitializeComponent();
        }

       
        public _00205_HorarioClase_ABM(string tipoOperacion, long? entidadId)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();


            this.Name = "_00205_ABM_HorarioClase";
            this.TituloVentana = "Horario de Clase";
            this.Titulo = "Gestión de Horarios de Clases";
            this.Leyenda = "Aquí Ud podrá dar de Alta, Modificar o Eliminar el Horario una de clases";

            this._tipoOperacion = tipoOperacion;

            

            Inicializador(tipoOperacion, entidadId);

            PoblarComboBox(cmbClase, comunUoW.TipoClaseRepositorio.ObtenerTodo(), "Nombre", "Id");


            PoblarDias(cmbDias);
            ImagenTituloPanelSuperior = ImagenesFormulario.Horarios;


            
        }

        


        //lista para cargar el combo box con lso dias de la semana      
        public enum Dias
        {
            Lunes,
            Martes,
            Miercoles,
            Jueves,
            Viernes,
            Sabado,
            Domingo
        }

        //pueblo el combo con los dias
        public void PoblarDias(ComboBox cmb)
        {
            cmb.DataSource = System.Enum.GetValues(typeof(Dias));
        }


        public override void CargarDatos(long? entidadId)
        {
            Horario = ObjectFactory.GetInstance<HorarioClase>();
            try
            {
                Horario = comunUoW.HorarioClaseRepositorio.ObtenerPorId(entidadId.Value);

                this.cmbDias.Text = Horario.Dias;
                dtpHora.Value = Horario.Hora;
                this.cmbClase.SelectedValue = Horario.ClaseId;

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
            var hora = comunUoW.HorarioClaseRepositorio.ObtenerTodo(string.Empty);

            //es`para controlar que los datos nuevos no sean igual a los existentes
            if (_tipoOperacion == Constante.TipoOperacion.Nuevo)
            {
                if (hora.Any(x => x.Dias.Equals(this.cmbDias.Text) && (x.Hora.Equals(this.dtpHora.Value))))
                {
                    Constante.Validacion.DatoExistenteCmb(this.cmbDias, errorProvider, string.Format("El Día {0}, la Hora {1} y la Clase {2} ya existen ", this.cmbDias.Text, this.dtpHora.Value,this.cmbClase.Text));
                    return true;
                }
             

            }

            //controla que al modificar los datos no exista uno igual
            if (_tipoOperacion == Constante.TipoOperacion.Modificar)
            {
                if (hora.Any(x => x.Dias.Equals(this.cmbDias.Text) && (x.Hora.Equals(this.dtpHora.Value) && (x.Clase.Nombre.Equals(this.cmbClase.Text)) && x.Id != EntidadId)))
                {
                  
                 Constante.Validacion.DatoExistenteCmb(this.cmbDias, errorProvider, string.Format("El Día {0}, la Hora {1} y La Clase {2} ya existen ", this.cmbDias.Text, this.dtpHora.Value, cmbClase.Text));

                    return true;
                }
              
            }


            return false;

        }

        public override void NuevoRegistro()
        {
            try
            {
                Horario = new HorarioClase
                {

                    Dias = this.cmbDias.Text,
                    Hora = this.dtpHora.Value,
                    ClaseId = Convert.ToInt32(cmbClase.SelectedValue),

                };

                comunUoW.HorarioClaseRepositorio.Insertar(Horario);
                comunUoW.HorarioClaseRepositorio.Commit();

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
               comunUoW.HorarioClaseRepositorio.Eliminar(Horario);
                comunUoW.HorarioClaseRepositorio.Commit();
            }
            catch (DataException ex)
            {

                Mensaje.Mostrar("La hora seleccionado se encuentra vinculada a otro objeto",
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

                Horario.Dias = this.cmbDias.Text;
                Horario.Hora = this.dtpHora.Value;
                Horario.ClaseId = Convert.ToInt32(cmbClase.SelectedValue);
               

                comunUoW.HorarioClaseRepositorio.Modificar(Horario);
                comunUoW.HorarioClaseRepositorio.Commit();


            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, Constante.TipoMensaje.Error);

            }
        }

     

        private void _00205_HorarioClase_ABM_Load(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        private void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<PresentacionComun._00202_Clase>();
            formConsulta.ShowDialog();
            ActualizarDatosGrilla(string.Empty);
        }
    }
}
