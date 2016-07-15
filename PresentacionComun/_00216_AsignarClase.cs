using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioComun.Entidades;
using DominioComun.UnidadDeTrabajo;
using PresentacionBase;
using PresentacionPlantilla;
using StructureMap;

namespace PresentacionComun
{
    public partial class _00216_AsignarClase : FormularioConsulta
    {
        private readonly IUnidadDeTrabajoComun _comunUoW = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();

        private Clase Clases;
        private DatosSocio Socio;

        public long SocioId { get; set; }
        private long _entidadId;

        public _00216_AsignarClase()
        {
            InitializeComponent();
        }

        public _00216_AsignarClase(long entidadId)
        {
            InitializeComponent();

            _entidadId = entidadId;

            //obtengo el Id del socio
            Socio = _comunUoW.DatoSocioRepositorio.ObtenerPorId(entidadId);


            Name = "_00216_AsignarClase";
            TituloVentana = "Socio - Clases";
            Titulo = "Asignar una Clase Nueva al Socio " + Socio.ApyNom;
            Leyenda = "Aquí Ud. podrá asignar una Clase a un Socio";

            ColorTitulo = Color.White;
            ColorLeyenda = Color.WhiteSmoke;

            BtnNuevo.Visible = false;
            BtnModificar.Visible = false;
            //Agrego el boton rutina
            MenuConsulta.Items.Add(CrearBotonClase());
        }

        //Creo el boton agregar rutina en 
        private ToolStripButton CrearBotonClase()
        {
            var btnNuevaClase = new ToolStripButton
            {
                Image = ImagenesFormulario.Carnet,
                ImageTransparentColor = Color.Magenta,
                Name = "btnAgregarRutina",
                Size = new Size(46, 44),
                Text = "Ver Clases",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            btnNuevaClase.Click += btnNuevaClase_Click;

            return btnNuevaClase;
        }


        /// <summary>
        ///     Le digo que abra el form consulta clase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnNuevaClase_Click(object sender, EventArgs e)
        {
            //le paso la uniddad de trabajo y la bandera en true
            var form = new _00217_AgregarClase(_comunUoW,true);//true
            //abro el form
            form.ShowDialog();
            //le asigno el valor del id
            var idClase = form.ObtenerId();

            //verifica q el id no sea nulo
            if (idClase == 0)
                return;

            var nuevaClase = _comunUoW.TipoClaseRepositorio.ObtenerPorId(idClase);
            Socio.TipoClases.Add(nuevaClase);
            _comunUoW.DatoSocioRepositorio.Modificar(Socio);
            _comunUoW.Commit();

            ActualizarDatosGrilla(string.Empty);

        }

        private void FormatearGrilla()
        {
            this.dgvBusqueda.Columns["Codigo"].Visible = true;
            this.dgvBusqueda.Columns["Codigo"].HeaderText = "Código";
            this.dgvBusqueda.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Nombre"].Visible = true;
            this.dgvBusqueda.Columns["Nombre"].HeaderText = "Nombre";
            this.dgvBusqueda.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Precio"].Visible = true;
            this.dgvBusqueda.Columns["Precio"].HeaderText = "Precio";
            this.dgvBusqueda.Columns["Precio"].Width = 100;
            this.dgvBusqueda.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Cupo"].Visible = true;
            this.dgvBusqueda.Columns["Cupo"].HeaderText = "Cupo";
            this.dgvBusqueda.Columns["Cupo"].Width = 100;
            this.dgvBusqueda.Columns["Cupo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }


        public override void ActualizarDatosGrilla(string textoBuscar)
         {
            _comunUoW.DatoSocioRepositorio.RefrescarCambios();
            Socio = _comunUoW.DatoSocioRepositorio.ObtenerPorId(_entidadId, "TipoClases");

            var resultado = Socio.TipoClases.Where(x => x.Nombre.Contains(textoBuscar)).ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla();
        }

        private void _00216_AsignarClase_Load(object sender, EventArgs e)
        {
            this.ActualizarDatosGrilla("");
            base.BtnModificar.Visible = false;
            ImagenTituloPanelSuperior = ImagenesFormulario.Clases;

        }

        public override void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00203_Clase_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes) ;
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvBusqueda.RowCount > 0)
            {
                if (
                    new _00203_Clase_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() ==
                    DialogResult.Yes)
                {
                    ActualizarDatosGrilla(string.Empty);
                }
            }
            else
            {
                MessageBox.Show("No existen Clases para Eliminar", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }

        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }
        
    }
}
