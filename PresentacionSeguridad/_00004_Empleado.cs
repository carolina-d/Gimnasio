using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicacionEmpleado;
using DominioSeguridad.UnidadDeTrabajo;
using PresentacionBase;
using PresentacionPlantilla;

namespace PresentacionSeguridad
{
    public partial class _00004_Empleado : FormularioConsulta
    {
        private readonly ISeguridadUnidadDeTrabajo seguridadUoW;
        public _00004_Empleado()
        {
            InitializeComponent();
        }

        public _00004_Empleado(ISeguridadUnidadDeTrabajo _seguridadUoW)
        {
            InitializeComponent();

            this.Name = "_00104_Empleado";
            this.TituloVentana = "Empleado";
            this.Titulo = "Consulta de Empleados";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar un Empleado y Consultar sus Datos";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;

            seguridadUoW = _seguridadUoW;

            this.EstaModoDiccionario = false;

        }

        private void _00004_Empleado_Load(object sender, EventArgs e)
        {
            FormatearGrilla();

            this.txtBuscar.Focus();
        }

        public override void ActualizarDatosGrilla(string textoBuscar)
        {
            var resultado = seguridadUoW.EmpleadoRepositorio.ObtenerPorFiltro(x => x.Apellido.Contains(textoBuscar)
                                                                                   || x.Nombre.Contains(textoBuscar)
                                                                                   || x.Celular.Contains(textoBuscar)
                                                                                   || x.Dni.Equals(textoBuscar), "TiposEmpleados")
                                                                                   .Select(x=> new EmpleadoDTO
                                                                                   {
                                                                                       Id = x.Id,
                                                                                       Apellido = x.ApyNom,
                                                                                       Direccion = x.Domicilio,
                                                                                       Telefono = Convert.ToInt32(x.Celular),
                                                                                       DNI = Convert.ToInt32(x.Dni),
                                                                                       TipoEmpleado = x.TiposEmpleados.Descripcion
                                                                                   })
                .ToList();

            this.dgvBusqueda.DataSource = resultado;

        }

        private void FormatearGrilla()
        {
            this.dgvBusqueda.Columns["ApyNom"].Visible = true;
            this.dgvBusqueda.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            this.dgvBusqueda.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Dni"].Visible = true;
            this.dgvBusqueda.Columns["Dni"].HeaderText = "DNI";
            this.dgvBusqueda.Columns["Dni"].Width = 100;
            this.dgvBusqueda.Columns["Dni"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Dni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

           // this.dgvBusqueda.Columns["Celular"].Visible = true;
           // this.dgvBusqueda.Columns["Celular"].HeaderText = "Telefono";
           // this.dgvBusqueda.Columns["Celular"].Width = 100;
           // this.dgvBusqueda.Columns["Celular"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
           // this.dgvBusqueda.Columns["Celular"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Direccion"].Visible = true;
            this.dgvBusqueda.Columns["Direccion"].HeaderText = "Dirección";
            this.dgvBusqueda.Columns["Direccion"].Width = 100;
            this.dgvBusqueda.Columns["Direccion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvBusqueda.Columns["Direccion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Descripcion"].Visible = true;
            this.dgvBusqueda.Columns["Descripcion"].HeaderText = "TipoEmpleado";
            this.dgvBusqueda.Columns["Descripcion"].Width = 100;
            this.dgvBusqueda.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvBusqueda.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["FechaNacimiento"].Visible = true;
            this.dgvBusqueda.Columns["FechaNacimiento"].HeaderText = "Fecha de Nac.";
            this.dgvBusqueda.Columns["FechaNacimiento"].Width = 100;
            this.dgvBusqueda.Columns["FechaNacimiento"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvBusqueda.Columns["FechaNacimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

           
        }

        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (new _00003_Empleado_ABM(Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() == DialogResult.Yes)
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
            if (new _00003_Empleado_ABM(Constante.TipoOperacion.Modificar, base.EntidadId).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00003_Empleado_ABM(Constante.TipoOperacion.Nuevo, null).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnSalir_Click(object sender, EventArgs e)
        {
            base.BtnSalir_Click(sender, e);
        }
    }
}
