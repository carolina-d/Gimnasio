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
using PresentacionPlantilla;

namespace PresentacionSpinning
{
    public partial class _00501_Spinning : FormularioConsulta
    {
        private readonly IUnidadDeTrabajoSpinning _spinningUow;

        public _00501_Spinning()
        {
            InitializeComponent();
        }

          public _00501_Spinning(IUnidadDeTrabajoSpinning spinningUow)
        {
            InitializeComponent();

            this.Name = "_00501_Spinning";
            this.TituloVentana = "Spinning";
            this.Titulo = "Consulta de Bicicletas";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar y Consultar sus Bicicletas";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;

            this._spinningUow = spinningUow;
            this.EstaModoDiccionario = false;

            ActualizarDatosGrilla(string.Empty);
        }

          public override void FormatearGrilla(DataGridView grilla)
          {
              this.dgvBusqueda.Columns["Id"].Visible = false;

              this.dgvBusqueda.Columns["Codigo"].Visible = true;
              this.dgvBusqueda.Columns["Codigo"].HeaderText = "Código";
              this.dgvBusqueda.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
              this.dgvBusqueda.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

              this.dgvBusqueda.Columns["Descripcion"].Visible = true;
              this.dgvBusqueda.Columns["Descripcion"].HeaderText = "Descripción";
              this.dgvBusqueda.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
              this.dgvBusqueda.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

              this.dgvBusqueda.Columns["Estado"].Visible = true;
              this.dgvBusqueda.Columns["Estado"].HeaderText = "Estado";
              this.dgvBusqueda.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
              this.dgvBusqueda.Columns["Estado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

          }

          public override void ActualizarDatosGrilla(string textoBuscar)
          {
              _spinningUow.SpinningRepositorio.RefrescarCambios();

              var resultado = _spinningUow.SpinningRepositorio.ObtenerPorFiltro(x => x.Codigo.Contains(textoBuscar)
                  || x.Descripcion.Contains(textoBuscar) || x.Estado.Contains(textoBuscar)
                  ).ToList();

              this.dgvBusqueda.DataSource = resultado;
              FormatearGrilla(dgvBusqueda);
          }

          public override void BtnNuevo_Click(object sender, EventArgs e)
          {
              if (new _00500_Spinning_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                  DialogResult.Yes) ;
              {
                  ActualizarDatosGrilla(string.Empty);
              }
          }

          public override void BtnModificar_Click(object sender, EventArgs e)
          {
              if (new _00500_Spinning_ABM(PresentacionBase.Constante.TipoOperacion.Modificar,
                  base.EntidadId).ShowDialog() == DialogResult.Yes)
              {
                  ActualizarDatosGrilla(string.Empty);
              }
          }

          public override void BtnEliminar_Click(object sender, EventArgs e)
          {
              if (new _00500_Spinning_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId
                  ).ShowDialog() == DialogResult.Yes)
              {
                  ActualizarDatosGrilla(string.Empty);
              }
          }

          public override void BtnActualizar_Click(object sender, EventArgs e)
          {
              ActualizarDatosGrilla(string.Empty);
          }

          private void _00501_Spinning_Load(object sender, EventArgs e)
          {
              ActualizarDatosGrilla(string.Empty);
              FormatearGrilla(dgvBusqueda);

              this.txtBuscar.Focus();

          }


    }
}
