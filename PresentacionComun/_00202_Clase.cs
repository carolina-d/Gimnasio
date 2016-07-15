using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioComun.Entidades;
using DominioComun.UnidadDeTrabajo;
using PresentacionBase;
using PresentacionPlantilla;
using StructureMap;

namespace PresentacionComun
{
    public partial class _00202_Clase : FormularioConsulta
    {
        private readonly IUnidadDeTrabajoComun _comunUow;

        public Clase TipoClases;

        public long ClaseId;

        public _00202_Clase(IUnidadDeTrabajoComun comunUoW)
        {
            InitializeComponent();

            this.Name = "_00202_Clase";
            this.TituloVentana = "Clase";
            this.Titulo = "Consulta de Clases";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar una Clase y Consultar sus Datos";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;

            this._comunUow = comunUoW;
            this.EstaModoDiccionario = false;
           // this.MenuConsulta.Items.Add(CrearBotonAgregarHorario());
            


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
            _comunUow.TipoClaseRepositorio.RefrescarCambios();

            var resultado = _comunUow.TipoClaseRepositorio.ObtenerPorFiltro(x => x.Codigo.Contains(textoBuscar)
                || x.Nombre.Contains(textoBuscar)).ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla();
        }

      /*  private void TieneAccesoFormulario(Form formulario)
        {
            if (_comunUow.TipoClaseRepositorio.TienePermiso(formulario.Name, Thread.CurrentPrincipal.Identity.Name))
            {
                formulario.ShowDialog();
            }
            else
            {
                Mensaje.Mostrar("Acceso Denegado", Mensaje.Tipo.Informacion);
            }
        }*/

        public override void BtnNuevo_Click(object sender, EventArgs e)
        {
             if (new _00203_Clase_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes) ;
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvBusqueda.RowCount > 0)
            {
                if (new _00203_Clase_ABM(PresentacionBase.Constante.TipoOperacion.Modificar,
                 base.EntidadId).ShowDialog() == DialogResult.Yes)
                {
                    ActualizarDatosGrilla(string.Empty);
                } 
            }
            else
            {
                MessageBox.Show("No existe Clases para Modificar", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                
            }
             
        }

        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvBusqueda.RowCount > 0)
            {
                if (new _00203_Clase_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() == DialogResult.Yes)
                {
                    ActualizarDatosGrilla(string.Empty);
                }
            }
            else
            {
                MessageBox.Show("No existe Clases para Eliminar", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                
            }
          
        }

        public override void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _00202_TipoClase_Load(object sender, EventArgs e)
        {
            FormatearGrilla();
            ActualizarDatosGrilla(string.Empty);

            this.txtBuscar.Focus();
        }

       // private ToolStripButton CrearBotonAgregarHorario()
       // {
       //     var btnAgregarHorario = new ToolStripButton
       //     {
       //         Image = PresentacionBase.ImagenesFormulario.Carnet,
       //         ImageTransparentColor = System.Drawing.Color.Magenta,
       //         Name = "btnAgregarHorario",
       //         Size = new System.Drawing.Size(46, 44),
       //         Text = "Agregar Horario",
       //         TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
       //     };
       //     btnAgregarHorario.Click += new System.EventHandler(this.btnAgregarHorario_Click);
       //
       //     return btnAgregarHorario;
       // }
       //
       //
       //
       // public virtual void btnAgregarHorario_Click(object sender, EventArgs e)
       // {
       //
       //     var formHorario = new _00205_HorarioClase_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo,
       //         null);
       //
       //     if (EntidadId == null)
       //     {
       //         MessageBox.Show("No se Selecciono ninguna Clase");
       //         return;
       //     }
       //         
       //
       //     var clase = _comunUow.TipoClaseRepositorio.ObtenerPorId(EntidadId.Value);
       //
       //     if (clase != null)
       //     {
       //
       //         formHorario.ShowDialog();
       //         formHorario.claseId = TipoClases.Id;
       //         
       //
       //     }
       //
       //     
       // }


        public Clase ObtenerClaseSeleccionada()
        {
            long? ClaseId  = base.EntidadId;
            if (ClaseId == null)
                ClaseId = 0;

            var resultado = _comunUow.TipoClaseRepositorio.ObtenerTodo().FirstOrDefault(x => x.Id.Equals(ClaseId));
          
            return resultado;
        }
    }
}
