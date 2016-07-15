using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Producto.Entidades;
using Dominio.Producto.UnidadDeTrabajo;
using Infraestructura.Producto.UnidadDeTrabajo;
using PresentacionPlantilla;

namespace PresentacionProducto
{
    public partial class _00401_Producto : FormularioConsulta
    {
        private readonly IUnidadDeTabajoProducto _prodcutoUow;

        public Producto Producto;

        public _00401_Producto()
        {
            InitializeComponent();
        }

        public _00401_Producto(UnidadDeTrabajoProducto productoUow)
        {
            InitializeComponent();

            this.Name = "_00401_Producto";
            this.TituloVentana = "Producto";
            this.Titulo = "Consulta de Productos";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar un Producto y Consultar sus Datos";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;

            _prodcutoUow = productoUow;
        }

        private void FormatearGrilla()
        {
            this.dgvBusqueda.Columns["Id"].Visible = false;
            //this.dgvBusqueda.Columns["Id"].HeaderText = "Id";
            //this.dgvBusqueda.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //this.dgvBusqueda.Columns["Id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Descripcion"].Visible = true;
            this.dgvBusqueda.Columns["Descripcion"].HeaderText = "Descripcion";
            this.dgvBusqueda.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["PrecioUnitario"].Visible = true;
            this.dgvBusqueda.Columns["PrecioUnitario"].HeaderText = "Precio";
            this.dgvBusqueda.Columns["PrecioUnitario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["PrecioUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Stock"].Visible = true;
            this.dgvBusqueda.Columns["Stock"].HeaderText = "Stcok";
            this.dgvBusqueda.Columns["Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        public override void ActualizarDatosGrilla(string textoBuscar)
        {
            _prodcutoUow.ProductoRepositorio.RefrescarCambios();

            var resultado = _prodcutoUow.ProductoRepositorio.ObtenerPorFiltro(x => x.Codigo.ToString() == textoBuscar
                || x.Descripcion.Contains(textoBuscar)
                ).ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla();
        }

        public override void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00400_Producto_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes) ;
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnModificar_Click(object sender, EventArgs e)
        {
            if (new _00400_Producto_ABM(PresentacionBase.Constante.TipoOperacion.Modificar,
                base.EntidadId).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (new _00400_Producto_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        private void _00401_Producto_Load(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);

        }

    }
}
