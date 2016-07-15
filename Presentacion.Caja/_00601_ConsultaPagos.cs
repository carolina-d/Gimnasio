using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Caja.UnidadDeTrabajo;
using Gimnasio.DTO;
using PresentacionPlantilla;
using StructureMap;

namespace Presentacion.Caja
{
    public partial class _00601_ConsultaPagos : FormularioBase
    {
        Dominio.Caja.Entidades.Pago pago = new Dominio.Caja.Entidades.Pago();

        private readonly Dominio.Caja.UnidadDeTrabajo.IUnidadDeTrabajoCaja uowConsultaPagos = ObjectFactory.GetInstance<IUnidadDeTrabajoCaja>();

        public _00601_ConsultaPagos()
        {
            InitializeComponent();

            this.TituloVentana = "Consulta de Pagos";
            this.Titulo = "Consulta de Pagos";
            this.Leyenda = "Consultar Pagos Realizdos";
        }

        private void PoblarGrillaPagos(string textoBuscar, int total)
        {
            uowConsultaPagos.PagoRepositorio.RefrescarCambios();

            var resultado =
                uowConsultaPagos.PagoRepositorio.ObtenerPorFiltro(x => x.Membresia.Nombre.Contains(textoBuscar)
                                                                       || x.Monto.Equals(total)
                                                                       ).ToList();
              

          

            this.dgvConsultaPago.DataSource = resultado;

        }

        private void _00601_ConsultaPagos_Load(object sender, EventArgs e)
        {
            PoblarGrillaPagos(string.Empty, int.MaxValue);
        }
    }
}
