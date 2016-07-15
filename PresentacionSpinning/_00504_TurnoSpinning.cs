using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioSpinning.UnidadDeTrabajo;
using InfraestructuraComun.UnidadDeTrabajo;
using PresentacionPlantilla;
using PresentacionSpinning.Controles;
using StructureMap;

namespace PresentacionSpinning
{
    public partial class _00504_TurnoSpinning : FormularioBase
    {

        private readonly DominioComun.UnidadDeTrabajo.IUnidadDeTrabajoComun uowComun = ObjectFactory.GetInstance<UnidadDeTrabajoComun>();

        private readonly DominioSpinning.UnidadDeTrabajo.IUnidadDeTrabajoSpinning uowTurnoSpinning = ObjectFactory.GetInstance<IUnidadDeTrabajoSpinning>();

        public ctrlTurnoSpinning CtrlTurnoSpinning;

        public _00504_TurnoSpinning()
        {
            InitializeComponent();

            this.TituloVentana = "Consulta de Turnos de Spinning";
            this.Titulo = "Consulta de Turnos de Spinnning";
            this.Leyenda = "Consultar Turnos Realizdos";

            ActualizarCtrls();
            this.pnlControles.Controls.Clear();

            CtrlTurnoSpinning = new ctrlTurnoSpinning()
            {
                Top = 18
            };


            this.pnlControles.Controls.Add(CtrlTurnoSpinning);
        }

        public void ActualizarCtrls()
        {
            this.pnlControles.Controls.Clear();

            var resultado = uowTurnoSpinning.TurnoSpinningRepositorio.ObtenerTodo().Select(x => new ctrlTurnoSpinning()
            {
                Id = x.Id,
                FechaGraba = x.Fecha,
                Senia = x.Senia,
                ClienteNombre = String.Format("{0} {1}", uowComun.DatoSocioRepositorio.ObtenerPorId(
                x.ClienteId).Apellido, uowComun.DatoSocioRepositorio.ObtenerPorId(x.ClienteId).Nombre)
            });

            pnlControles.Controls.AddRange(resultado.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarCtrls();

        }


        public void BuscarPorFecha()

        {

            var fechita = this.dtpFechaReserva.Value;
            var resultado = uowTurnoSpinning.TurnoSpinningRepositorio.ObtenerPorFiltro(x => x.Fecha.Day == fechita.Day && x.Fecha.Month == fechita.Month && x.Fecha.Year == fechita.Year).Select(x => new ctrlTurnoSpinning()
            {
                Id = x.Id,
                FechaGraba = x.Fecha,
                Senia = x.Senia,
                ClienteNombre = String.Format("{0} {1}", uowComun.DatoSocioRepositorio.ObtenerPorId(
                x.ClienteId).Apellido, uowComun.DatoSocioRepositorio.ObtenerPorId(x.ClienteId).Nombre)
            });

            pnlControles.Controls.AddRange(resultado.ToArray());

        }

        private void dtpFechaReserva_ValueChanged(object sender, EventArgs e)
        {
            BuscarPorFecha();
        }
            

    }
}
