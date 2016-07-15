using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentacionBase;

namespace PresentacionPlantilla
{
    public partial class FormularioConsulta : FormularioBase
    {
        private int _identificador;

        public bool EstaModoDiccionario
           {
            set
            {
                this.BtnEliminar.Visible = !value;
                this.BtnModificar.Visible = !value;
                this.BtnNuevo.Visible = !value;
                this.Separador.Visible = !value;
            }
        }

        public virtual void FormatearGrilla(DataGridView dgvGrilla)
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                this.dgvBusqueda.Columns[i].Visible = false;
            }
        }

        public FormularioConsulta()
        {
            InitializeComponent();
        }
        public virtual void AsignarImagenBotones()
        {
            this.BtnNuevo.Image = ImagenesFormulario.Nuevo;
            this.BtnModificar.Image = ImagenesFormulario.Modificar;
            //this.BtnEliminar.Image= ImagenesFormulario.B;
            this.BtnActualizar.Image = ImagenesFormulario.Actualizar;
            this.BtnImprimir.Image = ImagenesFormulario.Imprimir;
            

            this.imgBuscar.Image = ImagenesFormulario.Buscar;
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

        public virtual void FormularioConsulta_Load(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
            LimpiarCamposGrilla(dgvBusqueda);
        }

        public virtual void BtnNuevo_Click(object sender, EventArgs e)
        {

        }

        public virtual void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        public virtual void BtnEliminar_Click(object sender, EventArgs e)
        {

        }

        public virtual void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        public virtual void BtnImprimir_Click(object sender, EventArgs e)
        {

        }

        public virtual void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(this.txtBuscar.Text);

        }

        public override void control_Enter(object sender, EventArgs e)
        {
            base.control_Enter(sender, e);
        }

        public override void control_Leave(object sender, EventArgs e)
        {
            base.control_Leave(sender, e);
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

        public virtual void dgvBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public virtual void dgvBusqueda_DoubleClick(object sender, EventArgs e)
        {
            

            if (VScroll)
            {

            }
        }

    }
}
