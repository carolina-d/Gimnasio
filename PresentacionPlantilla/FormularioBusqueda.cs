using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionPlantilla
{
    public partial class FormularioBusqueda : FormularioBase
    {

        private bool _modoSeleccion = false;
        private long _entidadId = 0;
        private int _identificador;


        public FormularioBusqueda()
        {
            InitializeComponent();
        }

        public FormularioBusqueda(bool modoSeleccion)
        {
            InitializeComponent();
        }

        public virtual void FormatearGrilla(DataGridView dgvGrilla)
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                this.dgvBusqueda.Columns[i].Visible = false;
            }
        }

        public virtual void ActualizarDatosGrilla(string textoBuscar)
        {

        }

        /// <summary>
        /// Metodo para limpiar las columnas de la grilla
        /// </summary>
        /// <param name="grilla"></param>
        public virtual void LimpiarCamposGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }
        }

        public virtual void FormularioBusqueda_Load(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
            LimpiarCamposGrilla(dgvBusqueda);
        }

        public virtual void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        public virtual void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void dgvBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public virtual void dgvBusqueda_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBusqueda.RowCount > 0)
            {
                if (int.TryParse(this.dgvBusqueda["Id", e.RowIndex].Value.ToString(), out _identificador))
                {
                    EntidadId = _identificador;
                }
                else
                {
                    EntidadId = null;
                }
            }
            else
            {
                EntidadId = null;
            }
        }

        public virtual void dgvBusqueda_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
