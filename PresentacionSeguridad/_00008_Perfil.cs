using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioSeguridad.UnidadDeTrabajo;
using PresentacionPlantilla;
using ServicioSeguridad.UnidadDeTrabajo;

namespace PresentacionSeguridad
{
    public partial class _00008_Perfil : Formularios.Consulta
    {
        private readonly ISeguridadUnidadDeTrabajo seguridadUoW;
        private readonly IServicioSeguridadUnidadDeTrabajo servicioSeguridad;

        public _00008_Perfil()
        {
            InitializeComponent();
        }

        public _00008_Perfil(ISeguridadUnidadDeTrabajo _seguridadUoW,
            IServicioSeguridadUnidadDeTrabajo _servicioSeguridad)
        {
            InitializeComponent();
            this.Name = "_00007_Perfil";
            this.seguridadUoW = _seguridadUoW;
            this.servicioSeguridad = _servicioSeguridad;
           
        }

        public override void FormularioBase_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
            
        }

        private void TieneAccesoFormulario(Form formulario)
        {
            if (servicioSeguridad.SeguridadServicio.TienePermiso(formulario.Name, Thread.CurrentPrincipal.Identity.Name))
            {
                formulario.ShowDialog();
            }
            else
            {
                Mensaje.Mostrar("Acceso Denegado", Mensaje.Tipo.Informacion);
            }
        }

        public override void ActualizarDatos(string cadenaBuscar)
        {
            int codigo = -1;

            int.TryParse(cadenaBuscar, out codigo);

            var resultado = seguridadUoW.PerfilRepositorio.ObtenerPorFiltro(x => x.Descripcion.Contains(cadenaBuscar)
                                                                                 || x.Codigo == codigo)
                .OrderBy(x => x.Codigo).ToList();

            this.dgvGrilla.DataSource = resultado;
            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            this.dgvGrilla.Columns["Codigo"].Visible = true;
            this.dgvGrilla.Columns["Codigo"].Width = 150;
            this.dgvGrilla.Columns["Codigo"].HeaderText = "Código";
            this.dgvGrilla.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["Descripcion"].Visible = true;
            this.dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvGrilla.Columns["Descripcion"].HeaderText = "Descripciónn";
            this.dgvGrilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override bool EjecutarComandoNuevo()
        {
            var formulario = new _00007_Perfil_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            TieneAccesoFormulario(formulario);

            return formulario.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComandoEliminar()
        {
            var formulario = new _00007_Perfil_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId);
            TieneAccesoFormulario(formulario);

            return formulario.RealizoAlgunaOperacion;
        }

        public override bool EjecutarComandoModificar()
        {
            var formulario = new _00007_Perfil_ABM(PresentacionBase.Constante.TipoOperacion.Modificar, base.EntidadId);
            TieneAccesoFormulario(formulario);

            return formulario.RealizoAlgunaOperacion;
        }

        private void _00008_Perfil_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

    }
}
