using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioSpinning.UnidadDeTrabajo;
using StructureMap;

namespace PresentacionSpinning.Controles
{
    public partial class ctrlTurnoSpinning : UserControl
    {

        private readonly DominioSpinning.UnidadDeTrabajo.IUnidadDeTrabajoSpinning uowTurnoSpinning = ObjectFactory.GetInstance<IUnidadDeTrabajoSpinning>();

        public long Id { get; set; }

        public string ClienteNombre { set { this.lblCliente.Text = value; } }

        public DateTime FechaGraba { set { this.lblFechaSistema.Text = string.Format("Fecha: {0}/{1}/{2}", value.Day, value.Month, value.Year); } }

        public decimal Senia { set { this.lblSenia.Text = string.Format("Seña: {0}", value); } }

        public ctrlTurnoSpinning()
        {
            InitializeComponent();
        }
    }
}
