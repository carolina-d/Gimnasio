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
using PresentacionBase;
using PresentacionPlantilla;

namespace PresentacionComun
{
    public partial class _00208_Promocion : FormularioConsulta
    {
        private readonly IUnidadDeTrabajoComun _comunUow;

        public _00208_Promocion()
        {
            InitializeComponent();
        }
           public _00208_Promocion(IUnidadDeTrabajoComun comunUow)
        {
            this.Name = "_00208_Promociones";
            this.TituloVentana = "Promocion";
            this.Titulo = "Consulta de Promociones";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar una Promoción y Consultar sus Datos";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;

            this._comunUow = comunUow;
            this.EstaModoDiccionario = false;
            ImagenTituloPanelSuperior = ImagenesFormulario.Cliente;

        }

        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            this.dgvBusqueda.Columns["Codigo"].Visible = true;
            this.dgvBusqueda.Columns["Codigo"].HeaderText = "Código";
            this.dgvBusqueda.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Descripcion"].Visible = true;
            this.dgvBusqueda.Columns["Descripcion"].HeaderText = "Descripción";
            this.dgvBusqueda.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Precio"].Visible = true;
            this.dgvBusqueda.Columns["Precio"].HeaderText = "Precio";
            this.dgvBusqueda.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

    
            
         
        public override void ActualizarDatosGrilla(string textoBuscar)
        {
            _comunUow.PromocionRepositorio.RefrescarCambios();

            var resultado = _comunUow.PromocionRepositorio.ObtenerPorFiltro(x => x.Codigo.Contains(textoBuscar)
                || x.Descripcion.Contains(textoBuscar)).ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla(dgvBusqueda);
        }

        public override void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00209_Promocion_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes) ;
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvBusqueda.RowCount > 0)
            {
                if (new _00209_Promocion_ABM((PresentacionBase.Constante.TipoOperacion.Modificar),
                   base.EntidadId).ShowDialog() == DialogResult.Yes)
                {
                    ActualizarDatosGrilla(string.Empty);
                }
                
            }
            else
            {
                MessageBox.Show("No existe Promoción para Modificar", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                
            }
          
        }

        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvBusqueda.RowCount > 0)
            {
                if (new _00209_Promocion_ABM((PresentacionBase.Constante.TipoOperacion.Eliminar), base.EntidadId).ShowDialog() == DialogResult.Yes)
                {
                    ActualizarDatosGrilla(string.Empty);
                }
            }
            else
            {
                MessageBox.Show("No existe Promoción para Eliminar", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                
            }
          
        }

        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        private void _00208_Promocion_Load(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
            FormatearGrilla(dgvBusqueda);
        }
    }
}
