using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioSeguridad.UnidadDeTrabajo;
using PresentacionPlantilla;

namespace PresentacionSeguridad
{
    public partial class _00013_TipoEmpleado : FormularioConsulta
    {
        private readonly ISeguridadUnidadDeTrabajo _seguridadUoW;

        public _00013_TipoEmpleado()
        {
            InitializeComponent();
        }

         public _00013_TipoEmpleado(ISeguridadUnidadDeTrabajo seguridadUoW)
        {
            InitializeComponent();

            this.Name = "_00013_TipoEmpleado";
            this.TituloVentana = "Empleado";
            this.Titulo = "Consulta de Empleados";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar un Tipo de Empleado y Consultar sus Datos";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;

            _seguridadUoW = seguridadUoW;

            this.EstaModoDiccionario = false;

        }


         public override void ActualizarDatosGrilla(string textoBuscar)
         {
             var resultado = _seguridadUoW.TipoEmpleadoRepositorio.ObtenerPorFiltro(x=> x.Descripcion.Contains(textoBuscar)).ToList();

             this.dgvBusqueda.DataSource = resultado;
             FormatearGrilla();
         }

         private void FormatearGrilla()
         {
             this.dgvBusqueda.Columns["Codigo"].Visible = true;
             this.dgvBusqueda.Columns["Codigo"].HeaderText = "Codigo";
             this.dgvBusqueda.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             this.dgvBusqueda.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

             this.dgvBusqueda.Columns["Descripcion"].Visible = true;
             this.dgvBusqueda.Columns["Descripcion"].HeaderText = "Descripción";
             this.dgvBusqueda.Columns["Descripcion"].Width = 100;
             this.dgvBusqueda.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
             this.dgvBusqueda.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

             this.dgvBusqueda.Columns["Sueldo"].Visible = true;
             this.dgvBusqueda.Columns["Sueldo"].HeaderText = "Sueldo";
             this.dgvBusqueda.Columns["Sueldo"].Width = 100;
             this.dgvBusqueda.Columns["Sueldo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
             this.dgvBusqueda.Columns["Sueldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


         }

         public override void BtnActualizar_Click(object sender, EventArgs e)
         {
             ActualizarDatosGrilla(string.Empty);
         }

         public override void BtnEliminar_Click(object sender, EventArgs e)
         {
             if (new _00012_TipoEmpleado_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() == DialogResult.Yes)
             {
                 ActualizarDatosGrilla(string.Empty);
             }
         }

         public override void BtnImprimir_Click(object sender, EventArgs e)
         {
             base.BtnImprimir_Click(sender, e);
         }

         public override void BtnModificar_Click(object sender, EventArgs e)
         {
             if (new _00012_TipoEmpleado_ABM(PresentacionBase.Constante.TipoOperacion.Modificar, base.EntidadId).ShowDialog() == DialogResult.Yes)
             {
                 ActualizarDatosGrilla(string.Empty);
             }
         }

         public override void BtnNuevo_Click(object sender, EventArgs e)
         {
             if (new _00012_TipoEmpleado_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() == DialogResult.Yes)
             {
                 ActualizarDatosGrilla(string.Empty);
             }
         }

         public override void BtnSalir_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void _00013_TipoEmpleado_Load(object sender, EventArgs e)
         {
             ActualizarDatosGrilla(string.Empty);
         }
    }
}
