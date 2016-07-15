using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.Comun;
using DominioComun.UnidadDeTrabajo;
using PresentacionBase;
using PresentacionPlantilla;

namespace PresentacionComun
{
    public partial class _00217_AgregarClase : FormularioBusqueda
    {

        private readonly IUnidadDeTrabajoComun _comunUow;
        private bool _modoSeleccion = false;
        private long _entidadId = 0;

        public _00217_AgregarClase()
        {
            InitializeComponent();
        }


        public _00217_AgregarClase(IUnidadDeTrabajoComun comunUow, bool modoSeleccion)
        {
            InitializeComponent();

            _comunUow = comunUow;

            this.Name = "_00300_Rutina";
            this.TituloVentana = "Rutinas";
            this.Titulo = "Consulta de Rutinas";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar una Rutina y Consultar sus Datos";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;

            ActualizarDatosGrilla(string.Empty);

            _modoSeleccion = modoSeleccion;

           if (_modoSeleccion)
            {
                dgvBusqueda.CellContentDoubleClick += dgvBusqueda_DoubleClick;
            }
        }

        //devuelce el id de la clase
        public long ObtenerId()
        {
            return _entidadId;
        }

        private void FormatearGrilla()
        {
           // this.dgvBusqueda.Columns["Codigo"].Visible = true;
           // this.dgvBusqueda.Columns["Codigo"].HeaderText = "Código";
           // this.dgvBusqueda.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           // this.dgvBusqueda.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Nombre"].Visible = true;
            this.dgvBusqueda.Columns["Nombre"].HeaderText = "Nombre";
            this.dgvBusqueda.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Precio"].Visible = true;
            this.dgvBusqueda.Columns["Precio"].HeaderText = "Precio";
            this.dgvBusqueda.Columns["Precio"].Width = 100;
            this.dgvBusqueda.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

           // this.dgvBusqueda.Columns["Cupo"].Visible = true;
           // this.dgvBusqueda.Columns["Cupo"].HeaderText = "Cupo";
           // this.dgvBusqueda.Columns["Cupo"].Width = 100;
           // this.dgvBusqueda.Columns["Cupo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        public void dgvBusqueda_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBusqueda.Rows.Count <= 0)
                return;

            _entidadId = Convert.ToInt32(this.dgvBusqueda["Id", this.dgvBusqueda
                      .CurrentRow.Index].Value);


            // var resultado = _listaRutinas.First(x => x.Id == _entidadId);

            // RutinaSeleccionada = resultado;
            MessageBox.Show("La Clase seleccionada se Agregó correctamente al socio");

            this.Close();

           }

        public override void ActualizarDatosGrilla(string textoBuscar)
        {
            _comunUow.TipoClaseRepositorio.RefrescarCambios();

            var resultado =
                _comunUow.TipoClaseRepositorio.ObtenerPorFiltro(x => x.Nombre.Contains(textoBuscar)
                                                                    )
                                                                    .Select(x => new ClaseSocioDTO()
                                                                    {
                                                                        Id = x.Id,
                                                                        Nombre = x.Nombre,
                                                                        Precio = x.Precio
                                                                        
                                                                        
                                                                    }).ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla();
        }

        public override void btnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00203_Clase_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes) ;
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }


        public override void btnEliminar_Click(object sender, EventArgs e)
        {
            if (new _00203_Clase_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        private void _00217_AgregarClase_Load(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
            ImagenTituloPanelSuperior = ImagenesFormulario.Clases;

        }
        
      
    }
}
