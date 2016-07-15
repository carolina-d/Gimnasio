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
using PresentacionSeguridad.Formularios;
using ServicioSeguridad.ServicioFormulario;
using ServicioSeguridad.ServicioFormularioPerfil;
using ServicioSeguridad.ServicioSeguridad;
using ServicioSeguridad.UnidadDeTrabajo;

namespace PresentacionSeguridad
{
    public partial class _00011_AsignarFormularioPerfil : FormBase
    {

        private readonly ISeguridadUnidadDeTrabajo seguridadUoW;
        private readonly IServicioSeguridadUnidadDeTrabajo seguridadServicio;

        private List<long> listaFormulariosNoAsignados;
        private List<long> listaFormulariosAsignados;

        public _00011_AsignarFormularioPerfil()
        {
            InitializeComponent();
        }

        public _00011_AsignarFormularioPerfil(ISeguridadUnidadDeTrabajo _seguridadUoW,
            IServicioSeguridadUnidadDeTrabajo _seguridadServicio)
        {
            InitializeComponent();

            this.Name = "_00011_AsignarFormularioPerfil";

            this.seguridadUoW = _seguridadUoW;
            this.seguridadServicio = _seguridadServicio;

            listaFormulariosAsignados = new List<long>();
            listaFormulariosNoAsignados = new List<long>();

     
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

        private void PoblarComboBox()
        {
            this.cmbPerfil.DataSource = seguridadUoW.PerfilRepositorio.ObtenerTodo().ToList();
            this.cmbPerfil.DisplayMember = "Descripcion";
            this.cmbPerfil.ValueMember = "Id";
        }

        private void PoblarFormularioNoAsignado(string cadenaBuscar, long perfilId)
        {
            var resultado = seguridadServicio.FormularioPerfilServicio.MostrarFormulariosNoAsignados(perfilId, cadenaBuscar);

            this.dgvGrillaNoAsignado.DataSource = resultado.ToList();

            for (int i = 0; i < this.dgvGrillaNoAsignado.Columns.Count; i++)
            {
                this.dgvGrillaNoAsignado.Columns[i].Visible = false;
            }

            this.dgvGrillaNoAsignado.Columns["ItemNoAsignados"].Visible = true;
            this.dgvGrillaNoAsignado.Columns["ItemNoAsignados"].Width = 40;
            this.dgvGrillaNoAsignado.Columns["ItemNoAsignados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrillaNoAsignado.Columns["Nombre"].Visible = true;
            this.dgvGrillaNoAsignado.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvGrillaNoAsignado.Columns["Nombre"].HeaderText = "Formulario";
        }

        private void PoblarFormularioAsignado(string cadenaBuscar, long perfilId)
        {
            var resultado = seguridadServicio.FormularioPerfilServicio.MostrarFormulariosAsignados(perfilId, cadenaBuscar);

            this.dgvGrillaAsignado.DataSource = resultado.ToList();

            for (int i = 0; i < this.dgvGrillaAsignado.Columns.Count; i++)
            {
                this.dgvGrillaAsignado.Columns[i].Visible = false;
            }

            this.dgvGrillaAsignado.Columns["ItemAsignados"].Visible = true;
            this.dgvGrillaAsignado.Columns["ItemAsignados"].Width = 40;
            this.dgvGrillaAsignado.Columns["ItemAsignados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrillaAsignado.Columns["Nombre"].Visible = true;
            this.dgvGrillaAsignado.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvGrillaAsignado.Columns["Nombre"].HeaderText = "Nombre";
        }

        private void _00011_AsignarFormularioPerfil_Load(object sender, EventArgs e)
        {
            PoblarComboBox();

            if (this.cmbPerfil.Items.Count > 0)
            {
                PoblarFormularioNoAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
                PoblarFormularioAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
            }
        }

        private void ActualizarDatosNoAsignados(string cadena)
        {
            
        }

        private void ActualizarDatosAsignados(string cadena)
        {
        }

        private void btnNuevoPerfil_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBuscarNoAsignado_Click(object sender, EventArgs e)
        {
            if (this.cmbPerfil.Items.Count > 0)
            {
                PoblarFormularioNoAsignado(this.txtBuscarNoAsignado.Text, Convert.ToInt64(this.cmbPerfil.SelectedValue));
            }
        }

        private void btnBuscarAsignado_Click(object sender, EventArgs e)
        {
            if (this.cmbPerfil.Items.Count > 0)
            {
                PoblarFormularioAsignado(this.txtBuscarAsignado.Text, Convert.ToInt64(this.cmbPerfil.SelectedValue));
            }
        }

        private void cmbPerfil_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbPerfil.Items.Count > 0)
            {
                PoblarFormularioNoAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
                PoblarFormularioAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
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

        private void btnMarcarAsignado_Click(object sender, EventArgs e)
        {
            MarcarItems(this.dgvGrillaAsignado, "ItemAsignados", true);
        }

        private void btnDesmarcarAsignado_Click(object sender, EventArgs e)
        {
            MarcarItems(this.dgvGrillaAsignado, "ItemAsignados", false);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).RowCount <= 0) return;

            if (e.RowIndex >= 0)
            {
                ((DataGridView)sender).EndEdit();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                listaFormulariosNoAsignados.Clear();

                for (int i = 0; i < this.dgvGrillaNoAsignado.RowCount; i++)
                {
                    if (Convert.ToBoolean(this.dgvGrillaNoAsignado["ItemNoAsignados", i].Value))
                    {
                        listaFormulariosNoAsignados.Add(Convert.ToInt64(this.dgvGrillaNoAsignado["Id", i].Value));
                    }
                }

                seguridadServicio.FormularioPerfilServicio.
                    VincularFormularioPerfil(listaFormulariosNoAsignados, Convert.ToInt64(this.cmbPerfil.SelectedValue));

                PoblarFormularioNoAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
                PoblarFormularioAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
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
                listaFormulariosAsignados.Clear();

                for (int i = 0; i < this.dgvGrillaAsignado.RowCount; i++)
                {
                    if (Convert.ToBoolean(this.dgvGrillaAsignado["ItemAsignados", i].Value))
                    {
                        listaFormulariosAsignados.Add(Convert.ToInt64(this.dgvGrillaAsignado["Id", i].Value));
                    }
                }

                seguridadServicio.FormularioPerfilServicio.
                    DesvincularFormularioPerfil(listaFormulariosAsignados, Convert.ToInt64(this.cmbPerfil.SelectedValue));

                PoblarFormularioNoAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
                PoblarFormularioAsignado(string.Empty, Convert.ToInt64(this.cmbPerfil.SelectedValue));
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex, Mensaje.Tipo.Error);
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

        private void dgvGrillaAsignado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).RowCount <= 0) return;

            if (e.RowIndex >= 0)
            {
                ((DataGridView)sender).EndEdit();
            }
        }

    }
}
