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
    public partial class _00206_Membresia : FormularioConsulta
    {
        private readonly IUnidadDeTrabajoComun _membresiUow;

        public _00206_Membresia()
        {
            InitializeComponent();
        }

        public _00206_Membresia(IUnidadDeTrabajoComun membresiUow)
        {
            InitializeComponent();

            this.Name = "_00200_Socio";
            this.TituloVentana = "Socios";
            this.Titulo = "Consulta de Socios";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar un Socio y Consultar sus Datos";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;

            this._membresiUow = membresiUow;
            this.EstaModoDiccionario = false;


            ImagenTituloPanelSuperior = ImagenesFormulario.Membresia;


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

            this.dgvBusqueda.Columns["Nombre"].Visible = true;
            this.dgvBusqueda.Columns["Nombre"].HeaderText = "Nombre";
            this.dgvBusqueda.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }



        public override void ActualizarDatosGrilla(string textoBuscar)
        {
            _membresiUow.MembresiaRepositorio.RefrescarCambios();

            var resultado = _membresiUow.MembresiaRepositorio.ObtenerPorFiltro(x => x.Nombre.Contains(textoBuscar)
                                                                                       ||
                                                                                       x.Codigo.Contains(textoBuscar) ||
                                                                                       x.Descripcion.Contains(textoBuscar)
                ).ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla(dgvBusqueda);
        }

        public override void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00207_Membresia_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes) ;
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnModificar_Click(object sender, EventArgs e)
        {
            if (new _00207_Membresia_ABM(PresentacionBase.Constante.TipoOperacion.Modificar,
                base.EntidadId).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (new _00207_Membresia_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() ==
                DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }



      

        private void _00206_Membresia_Load(object sender, System.EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
            FormatearGrilla(dgvBusqueda);

            this.txtBuscar.Focus();
        }

      
        }
    }
