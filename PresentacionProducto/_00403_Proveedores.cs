using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Producto.UnidadDeTrabajo;
using PresentacionPlantilla;

namespace PresentacionProducto
{
    public partial class _00403_Proveedores : FormularioConsulta
    {

        private readonly IUnidadDeTabajoProducto _proveedorUow;

        public _00403_Proveedores()
        {
            InitializeComponent();
        }

        public _00403_Proveedores(IUnidadDeTabajoProducto proveedorUow)
        {
            InitializeComponent();

            this.Name = "_0602_Proveedor";
            this.TituloVentana = "Proveedor";
            this.Titulo = "Consulta de Proveedor";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar un Socio y Consultar sus Proveedores";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;

            this._proveedorUow = proveedorUow;
            this.EstaModoDiccionario = false;


        }

        
        public override void FormatearGrilla(DataGridView grilla)
        {
            this.dgvBusqueda.Columns["Id"].Visible = false;

            this.dgvBusqueda.Columns["Cuil"].Visible = true;
            this.dgvBusqueda.Columns["Cuil"].HeaderText = "Cuil";
            this.dgvBusqueda.Columns["Cuil"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Cuil"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Apellido"].Visible = true;
            this.dgvBusqueda.Columns["Apellido"].HeaderText = "Apellido";
            this.dgvBusqueda.Columns["Apellido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Apellido"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Nombre"].Visible = true;
            this.dgvBusqueda.Columns["Nombre"].HeaderText = "Nombre";
            this.dgvBusqueda.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Direccion"].Visible = true;
            this.dgvBusqueda.Columns["Direccion"].HeaderText = "Dirección";
            this.dgvBusqueda.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Direccion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            this.dgvBusqueda.Columns["Telefono"].Visible = true;
            this.dgvBusqueda.Columns["Telefono"].HeaderText = "Teléfono";
            this.dgvBusqueda.Columns["Telefono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Telefono"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        
        public override void ActualizarDatosGrilla(string textoBuscar)
        {


            var resultado = _proveedorUow.ProveedorRepositorio.ObtenerPorFiltro(x => x.Nombre.Contains(textoBuscar) ||
                                                                                       x.Apellido.Contains(textoBuscar)||
                                                                                       x.Direccion.Contains(textoBuscar) 
                                                                                       

                ).ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla(dgvBusqueda);
        }

         public override void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00402_Proveedores_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes) ;
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }
        
        public override void BtnModificar_Click(object sender, EventArgs e)
        {
            if (new _00402_Proveedores_ABM(PresentacionBase.Constante.TipoOperacion.Modificar,
                base.EntidadId).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }
        
        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (new _00402_Proveedores_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() ==
                DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }
        
        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        private void _00403_Proveedores_Load(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }
    }
}
