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
using PresentacionBase;
using PresentacionPlantilla;
using PresentacionSeguridad.Formularios;
using ServicioSeguridad.UnidadDeTrabajo;

namespace PresentacionSeguridad
{
    public partial class _00010_AsignarUsuarioPerfil : FormBase
    {
        private readonly ISeguridadUnidadDeTrabajo seguridadUoW;
        private readonly IServicioSeguridadUnidadDeTrabajo seguridadServicio;

        private List<long> listaUsuariosNoAsignados;
        private List<long> listaUsuariosAsignados;

        public _00010_AsignarUsuarioPerfil(ISeguridadUnidadDeTrabajo _seguridadUoW,
            IServicioSeguridadUnidadDeTrabajo _seguridadServicio)
        {
            InitializeComponent();

            this.Name = "_00205_AsignarFormularioPerfil";

            this.seguridadUoW = _seguridadUoW;
            this.seguridadServicio = _seguridadServicio;

            listaUsuariosAsignados = new List<long>();
            listaUsuariosNoAsignados = new List<long>();

            this.txtBuscarAsignado.Leave += new EventHandler(txt_Leave);
            this.txtBuscarAsignado.Enter += new EventHandler(txt_Enter);

            this.txtBuscarNoAsignado.Leave += new EventHandler(txt_Leave);
            this.txtBuscarNoAsignado.Enter += new EventHandler(txt_Enter);
        }

        private void MarcarItems(DataGridView dgv, string columna, bool estado)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv[columna, i].Value = estado;
            }
        }

        private void TieneAccesoFormulario(Form formulario)
        {
            if (seguridadServicio.SeguridadServicio.TienePermiso(formulario.Name, Thread.CurrentPrincipal.Identity.Name))
            {
                formulario.ShowDialog();
            }
            else
            {
                Mensaje.Mostrar("Acceso Denegado", Mensaje.Tipo.Informacion);
            }
        }

        private void PoblarComboBox()
        {
            this.cmbPerfil.DataSource = seguridadUoW.PerfilRepositorio.ObtenerTodo().ToList();
            this.cmbPerfil.DisplayMember = "Descripcion";
            this.cmbPerfil.ValueMember = "Id";
        }

        private void PoblarUsuarioNoAsignado(string cadenaBuscar, long perfilId)
        {
            var resultado = seguridadServicio.UsuarioPerfilServicio.MostrarUsuariosNoAsignados(perfilId, cadenaBuscar);

            this.dgvGrillaNoAsignado.DataSource = resultado.ToList();

            for (int i = 0; i < this.dgvGrillaNoAsignado.Columns.Count; i++)
            {
                this.dgvGrillaNoAsignado.Columns[i].Visible = false;
            }

            this.dgvGrillaNoAsignado.Columns["ItemNoAsignados"].Visible = true;
            this.dgvGrillaNoAsignado.Columns["ItemNoAsignados"].Width = 40;
            this.dgvGrillaNoAsignado.Columns["ItemNoAsignados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrillaNoAsignado.Columns["ApyNom"].Visible = true;
            this.dgvGrillaNoAsignado.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvGrillaNoAsignado.Columns["ApyNom"].HeaderText = "Apellido y Nombre";

            this.dgvGrillaNoAsignado.Columns["Usuario"].Visible = true;
            this.dgvGrillaNoAsignado.Columns["Usuario"].Width = 100;
            this.dgvGrillaNoAsignado.Columns["Usuario"].HeaderText = "Usuario";

            this.dgvGrillaNoAsignado.Columns["EstaBloqueado"].Visible = true;
            this.dgvGrillaNoAsignado.Columns["EstaBloqueado"].Width = 40;
            this.dgvGrillaNoAsignado.Columns["EstaBloqueado"].HeaderText = "Bloq.";
            this.dgvGrillaNoAsignado.Columns["EstaBloqueado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void PoblarUsuarioAsignado(string cadenaBuscar, long perfilId)
        {
            var resultado = seguridadServicio.UsuarioPerfilServicio.MostrarUsuariosAsignados(perfilId, cadenaBuscar);

            this.dgvGrillaAsignado.DataSource = resultado.ToList();

            for (int i = 0; i < this.dgvGrillaAsignado.Columns.Count; i++)
            {
                this.dgvGrillaAsignado.Columns[i].Visible = false;
            }

            this.dgvGrillaAsignado.Columns["ItemAsignados"].Visible = true;
            this.dgvGrillaAsignado.Columns["ItemAsignados"].Width = 40;
            this.dgvGrillaAsignado.Columns["ItemAsignados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrillaAsignado.Columns["ApyNom"].Visible = true;
            this.dgvGrillaAsignado.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvGrillaAsignado.Columns["ApyNom"].HeaderText = "Apellido y Nombre";

            this.dgvGrillaAsignado.Columns["Usuario"].Visible = true;
            this.dgvGrillaAsignado.Columns["Usuario"].Width = 100;
            this.dgvGrillaAsignado.Columns["Usuario"].HeaderText = "Usuario";

            this.dgvGrillaAsignado.Columns["EstaBloqueado"].Visible = true;
            this.dgvGrillaAsignado.Columns["EstaBloqueado"].Width = 40;
            this.dgvGrillaAsignado.Columns["EstaBloqueado"].HeaderText = "Bloq.";
            this.dgvGrillaAsignado.Columns["EstaBloqueado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                listaUsuariosNoAsignados.Clear();

                for (int i = 0; i < this.dgvGrillaNoAsignado.RowCount; i++)
                {
                    if (Convert.ToBoolean(this.dgvGrillaNoAsignado["ItemNoAsignados", i].Value))
                    {
                        listaUsuariosNoAsignados.Add(Convert.ToInt64(this.dgvGrillaNoAsignado["Id", i].Value));
                    }
                }

                seguridadServicio.UsuarioPerfilServicio.
                    VincularUsuarioPerfil(listaUsuariosNoAsignados, Convert.ToInt64(this.cmbPerfil.SelectedValue));

                PoblarUsuarioNoAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
                PoblarUsuarioAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex, Mensaje.Tipo.Error);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                listaUsuariosAsignados.Clear();

                for (int i = 0; i < this.dgvGrillaAsignado.RowCount; i++)
                {
                    if (Convert.ToBoolean(this.dgvGrillaAsignado["ItemAsignados", i].Value))
                    {
                        listaUsuariosAsignados.Add(Convert.ToInt64(this.dgvGrillaAsignado["Id", i].Value));
                    }
                }

                seguridadServicio.UsuarioPerfilServicio.
                    DesvincularUsuarioPerfil(listaUsuariosAsignados, Convert.ToInt64(this.cmbPerfil.SelectedValue));

                PoblarUsuarioNoAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
                PoblarUsuarioAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex, Mensaje.Tipo.Error);
            }
        }

        private void btnMarcarNoAsignado_Click(object sender, EventArgs e)
        {
            MarcarItems(this.dgvGrillaNoAsignado, "ItemNoAsignados", true);
        }

        private void btnDesmarcarNoAsignado_Click(object sender, EventArgs e)
        {
            MarcarItems(this.dgvGrillaNoAsignado, "ItemNoAsignados", false);

        }

        private void btnBuscarNoAsignado_Click(object sender, EventArgs e)
        {

            if (this.cmbPerfil.Items.Count > 0)
            {
                PoblarUsuarioNoAsignado(this.txtBuscarNoAsignado.Text, Convert.ToInt64(this.cmbPerfil.SelectedValue));
            }

        }

        private void _00010_AsignarUsuarioPerfil_Load(object sender, EventArgs e)
        {
            PoblarComboBox();

            if (this.cmbPerfil.Items.Count > 0)
            {
                PoblarUsuarioNoAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
                PoblarUsuarioAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
            }
        }

        private void btnNuevoPerfil_Click(object sender, EventArgs e)
        {

            var fNuevoPerfil = new _00007_Perfil_ABM(Constante.TipoOperacion.Nuevo, null);
            TieneAccesoFormulario(fNuevoPerfil);

            if (fNuevoPerfil.RealizoAlgunaOperacion)
            {
                PoblarComboBox();

                if (this.cmbPerfil.Items.Count > 0)
                {
                    PoblarUsuarioNoAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
                    PoblarUsuarioAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
                }
            }

        }

        private void cmbPerfil_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbPerfil.Items.Count > 0)
            {
                PoblarUsuarioNoAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
                PoblarUsuarioAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
            }
        }

        private void btnMarcarAsignado_Click(object sender, EventArgs e)
        {
            MarcarItems(this.dgvGrillaAsignado, "ItemAsignados", true);

        }

        private void btnDesmarcarAsignado_Click(object sender, EventArgs e)
        {
            MarcarItems(this.dgvGrillaAsignado, "ItemAsignados", false);

        }

        private void btnBuscarAsignado_Click(object sender, EventArgs e)
        {
            if (this.cmbPerfil.Items.Count > 0)
            {
                PoblarUsuarioAsignado(this.txtBuscarAsignado.Text, Convert.ToInt64(this.cmbPerfil.SelectedValue));
            }
        }

        private void dgvGrillaNoAsignado_DataSourceChanged(object sender, EventArgs e)
        {
            this.btnAgregar.Enabled = this.dgvGrillaNoAsignado.RowCount > 0;
            
        }

        private void dgvGrillaAsignado_DataSourceChanged(object sender, EventArgs e)
        {
            this.btnQuitar.Enabled = this.dgvGrillaAsignado.RowCount > 0;

        }

        private void dgvGrillaNoAsignado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).RowCount <= 0) return;

            if (e.RowIndex >= 0)
            {
                ((DataGridView)sender).EndEdit();
            }
        }
    }
}
