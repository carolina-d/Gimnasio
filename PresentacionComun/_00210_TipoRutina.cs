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
    public partial class _00210_TipoRutina : FormularioConsulta
    {
        private readonly IUnidadDeTrabajoComun _datosTipoRutinaUow;

        public _00210_TipoRutina()
        {
            InitializeComponent();
        }

        
        public _00210_TipoRutina(IUnidadDeTrabajoComun datosTipoRutinaUow)
        {
            InitializeComponent();

            this.Name = " _00400_TipoRutina";
            this.TituloVentana = "Tipos de Rutinas";
            this.Titulo = "Consulta de Tipos de Rutinas";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar un Tipo de Rutina y Consultar sus Datos";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.WhiteSmoke;

            this._datosTipoRutinaUow = datosTipoRutinaUow;
            this.EstaModoDiccionario = false;
            

        }

        private void FormatearGrilla()
        {
            this.dgvBusqueda.Columns["Codigo"].Visible = true;
            this.dgvBusqueda.Columns["Codigo"].HeaderText = "Codigo";
            this.dgvBusqueda.Columns["Codigo"].Width = 100;
            this.dgvBusqueda.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvBusqueda.Columns["Codigo"].DisplayIndex = 0;

            this.dgvBusqueda.Columns["Descripcion"].Visible = true;
            this.dgvBusqueda.Columns["Descripcion"].HeaderText = "Descripcion";
            this.dgvBusqueda.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvBusqueda.Columns["Descripcion"].DisplayIndex = 1;
        }

        public override void ActualizarDatosGrilla(string textoBuscar)
        {
            _datosTipoRutinaUow.TipoRutinaRepositorio.RefrescarCambios();

            var resultado =
                _datosTipoRutinaUow.TipoRutinaRepositorio.ObtenerPorFiltro(x => x.Descripcion.Contains(textoBuscar))
                    .ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla();
        }

        public override void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00211_TipoRutina_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes) ;
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnModificar_Click(object sender, EventArgs e)
        {
            if (new _00211_TipoRutina_ABM(PresentacionBase.Constante.TipoOperacion.Modificar,
                base.EntidadId).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (new _00211_TipoRutina_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        private void _00210_TipoRutina_Load(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
            FormatearGrilla();
            this.txtBuscar.Focus();
            ImagenTituloPanelSuperior = ImagenesFormulario.TipoRutina;

        }
        


    }
}
