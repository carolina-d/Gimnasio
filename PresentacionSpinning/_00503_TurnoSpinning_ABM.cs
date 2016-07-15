using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioComun.UnidadDeTrabajo;
using DominioSpinning.Entidades;
using DominioSpinning.UnidadDeTrabajo;
using InfraestructuraComun.Contexto;
using PresentacionPlantilla;
using PresentacionSpinning.Controles;
using PresentacionSpinning.DTO;
using StructureMap;

namespace PresentacionSpinning
{
    public partial class _00503_TurnoSpinning_ABM : FormularioABM
    {
        ContextoComun contextoComun = new ContextoComun();

        private long turnoId;
        private long empleadoId;
        private long socioId;

        List<DTOTurnoSpinning> listaTurnoSpinnings;

        private readonly IUnidadDeTrabajoSpinning uowTurnoSpinning = ObjectFactory.GetInstance<IUnidadDeTrabajoSpinning>();
        private readonly IUnidadDeTrabajoComun uowComun = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();

        private ctrolBuscarSocio ctrlBuscarSocio;

        private string _tipoOperacion;

        private TurnoSpinning turnoSpinning;

        public _00503_TurnoSpinning_ABM()
        {
            InitializeComponent();
        }

        public _00503_TurnoSpinning_ABM(string tipoOperacion, long? entidadId)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            this.TituloVentana = "Pantalla Turno de Spinning";
            this.Titulo = "Gestión de Turno de Spinning";
            this.Leyenda = "Aquí podrá Gestionar los Turnos de Spinning del Socio";

            ctrlBuscarSocio = new ctrolBuscarSocio(uowComun)
            {
                Top = 18
            };

            this.pnlSocio.Controls.Add(ctrlBuscarSocio);

            this._tipoOperacion = tipoOperacion;
        }

        
        public override void EliminarRegistro()
        {
            try
            {
                uowTurnoSpinning.TurnoSpinningRepositorio.Eliminar(turnoSpinning);
                uowTurnoSpinning.TurnoSpinningRepositorio.Commit();
            }
            catch (DataException ex)
            {

                Mensaje.Mostrar("El Turno seleccionado se encuentra vinculada a otro objeto",
                    PresentacionBase.Constante.TipoMensaje.Error);
            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex, PresentacionBase.Constante.TipoMensaje.Error);
            }
            }
        public override void BtnGrabar_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        public override void BtnLimpiar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }

        private void _00503_TurnoSpinning_ABM_Load(object sender, EventArgs e)
        {
            BtnLimpiar.Visible = false;
            
        }


        public void Insertar()
        {

            try
            {

                turnoSpinning = new TurnoSpinning();

                turnoSpinning.ClienteId = Convert.ToInt32(this.ctrlBuscarSocio.SocioId);
                turnoSpinning.Fecha = this.dtpFechaReserva.Value;
                turnoSpinning.Senia = this.nudSenia.Value;
                turnoSpinning.Hora = Convert.ToDateTime(this.mtbHora.Text);

                uowTurnoSpinning.TurnoSpinningRepositorio.Insertar(turnoSpinning);
                uowTurnoSpinning.Commit();

                this.Close();
            }
            catch
            {
                MessageBox.Show("Esta aca no anda Suerte ");

                // Mensaje.Mostrar(Constante.TipoMensaje.Error +
                //     "Ocurrió un Error al grabar los datos de la Reserva");
            }
        }
        public bool VerificarDatosExistentes()
        {
            return false;
        }

        public bool VerificarDatosObligatorios()
        {
            if (this.ctrlBuscarSocio.SocioId != -1)
                return true;

            return false;
        }

        private void _00503_TurnoSpinning_ABM_FormClosing(object sender, FormClosingEventArgs e)
        {
            uowTurnoSpinning.Disposed();

        }

        private void btnConsultaClase_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<PresentacionComun._00204_HorarioClase>();
            formConsulta.ShowDialog();
            ActualizarDatosGrilla(string.Empty);
        }

    }
}
