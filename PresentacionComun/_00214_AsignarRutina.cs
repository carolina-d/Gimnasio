using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using DominioComun.Entidades;
using DominioComun.UnidadDeTrabajo;
using PresentacionBase;
using PresentacionPlantilla;
using StructureMap;

namespace PresentacionComun
{
    public partial class _00214_AsignarRutina : FormularioConsulta
    {
        private readonly IUnidadDeTrabajoComun _comunUoW = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();
       
        private Rutina Rutinas;
        private DatosSocio Socio;

        private long _entidadId;


        public _00214_AsignarRutina()
        {
            InitializeComponent();
        }


        public _00214_AsignarRutina(long entidadId)
        {
            InitializeComponent();

            _entidadId = entidadId;

            //obtengo el Id del socio
            Socio = _comunUoW.DatoSocioRepositorio.ObtenerPorId(entidadId);


            Name = "_00215_AsignarRutinaSocio";
            TituloVentana = "Socio - Rutina";
            Titulo = "Asignar Rutina al Socio " + Socio.ApyNom;
            Leyenda = "Aquí Ud. podrá asignar una Rutina a un Socio";

            ColorTitulo = Color.White;
            ColorLeyenda = Color.WhiteSmoke;

            BtnModificar.Visible = false;
            BtnNuevo.Visible = false;
        //Agrego el boton rutina
            MenuConsulta.Items.Add(CrearBotonRutina());
        }

        #region BotoncitoDinamico

       //Creo el boton agregar rutina en 
       private ToolStripButton CrearBotonRutina()
       {
           var btnNuevaRutina = new ToolStripButton
           {
               Image = ImagenesFormulario.Carnet,
               ImageTransparentColor = Color.Magenta,
               Name = "btnAgregarRutina",
               Size = new Size(46, 44),
               Text = "Seleccionar Rutina",
               TextImageRelation = TextImageRelation.ImageAboveText
           };
           btnNuevaRutina.Click += btnNuevaRutina_Click;
      
           return btnNuevaRutina;
       }


        /// <summary>
        ///     Le digo que abra el form asignar rutina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnNuevaRutina_Click(object sender, EventArgs e)
        {
            var form = new AgregarRutina(_comunUoW, true);//true
            form.ShowDialog();
            var idRutina = form.ObtenerId();

            if(idRutina == 0)
                return;

            var nuevaRutina = _comunUoW.RutinaRepositorio.ObtenerPorId(idRutina);
            Socio.Rutinas.Add(nuevaRutina);
            _comunUoW.DatoSocioRepositorio.Modificar(Socio);
            _comunUoW.Commit();

            ActualizarDatosGrilla(string.Empty);
            
        }

        #endregion

        public long SocioId { get; set; }


        public override void FormatearGrilla(DataGridView grilla)
        {
           // this.dgvBusqueda.Columns["Id"].Visible = false;
            
            this.dgvBusqueda.Columns["Nombre"].Visible = true;
            this.dgvBusqueda.Columns["Nombre"].HeaderText = "Nombre";
            this.dgvBusqueda.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Descripcion"].Visible = true;
            this.dgvBusqueda.Columns["Descripcion"].HeaderText = "Descripción";
            this.dgvBusqueda.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Dias"].Visible = true;
            this.dgvBusqueda.Columns["Dias"].HeaderText = "Dias";
            this.dgvBusqueda.Columns["Dias"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Dias"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Series"].Visible = true;
            this.dgvBusqueda.Columns["Series"].HeaderText = "Serie";
            this.dgvBusqueda.Columns["Series"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Series"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Repeticiones"].Visible = true;
            this.dgvBusqueda.Columns["Repeticiones"].HeaderText = "Repeticiones";
            this.dgvBusqueda.Columns["Repeticiones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Repeticiones"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        
        public override void ActualizarDatosGrilla(string textoBuscar)
        {
            _comunUoW.DatoSocioRepositorio.RefrescarCambios();
            Socio = _comunUoW.DatoSocioRepositorio.ObtenerPorId(_entidadId,"Rutinas");

            var resultado = Socio.Rutinas.Where(x => x.Nombre.Contains(textoBuscar)).ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla(dgvBusqueda);
        }


        private void _00215_asignarRutina_Load(object sender, EventArgs e)
        {
            this.ActualizarDatosGrilla("");
            base.BtnModificar.Visible = false;
            ImagenTituloPanelSuperior = ImagenesFormulario.AsignarRutina;

        }

      
        public override void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00213_Rutina_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes);
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }
        
        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvBusqueda.RowCount > 0)
            {
                if (
                    new _00213_Rutina_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() ==
                    DialogResult.Yes)
                {
                    ActualizarDatosGrilla(string.Empty);
                }
            }
            else
            {
                MessageBox.Show("No existen Rutinas para Eliminar", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                
            }
        }

        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }
        
    }
}