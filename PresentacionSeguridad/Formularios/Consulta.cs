using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionSeguridad.Formularios
{
    public partial class Consulta : FormBase
    {

        private bool puedeEjecutarComando;

       
        public Consulta()
        {
            InitializeComponent();

            // Color cuando recibe o pierde el foco
            this.txtBuscar.Leave += new EventHandler(this.txt_Leave);
            this.txtBuscar.Enter += new EventHandler(this.txt_Enter);

            this.puedeEjecutarComando = false;
        }

       
        public virtual void FormatearGrilla(DataGridView dgvGrilla)
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                this.dgvGrilla.Columns[i].Visible = false;
            }
        }

        private void dgvGrilla_DataSourceChanged(object sender, EventArgs e)
        {
            this.puedeEjecutarComando = this.dgvGrilla.RowCount > 0;
        }

        public virtual void ActualizarDatos(string cadenaBuscar)
        {

        }

        public virtual bool EjecutarComandoNuevo()
        {
            return true;
        }

        public virtual bool EjecutarComandoModificar()
        {
            return true;
        }

        public virtual bool EjecutarComandoEliminar()
        {
            return true;
        }

        public virtual bool EjecutarComandoImprimir()
        {
            return true;
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.EntidadId = this.dgvGrilla.RowCount > 0 ? Convert.ToInt64(this.dgvGrilla["Id", e.RowIndex].Value) : (long?)null;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(this.txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (puedeEjecutarComando)
            {
                EjecutarComandoImprimir();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (puedeEjecutarComando)
            {
                if (EjecutarComandoModificar())
                {
                    ActualizarDatos(string.Empty);
                }
            }
            else
            {
                PresentacionPlantilla.Mensaje.Mostrar(PresentacionBase.Constante.Mensaje.NoHayDatosCargados,PresentacionPlantilla. Mensaje.Tipo.Informacion);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (puedeEjecutarComando)
            {
                if (EjecutarComandoEliminar())
                {
                    ActualizarDatos(string.Empty);
                }
            }
            else
            {
                PresentacionPlantilla.Mensaje.Mostrar(PresentacionBase.Constante.Mensaje.NoHayDatosCargados,PresentacionPlantilla. Mensaje.Tipo.Informacion);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (EjecutarComandoNuevo())
            {
                ActualizarDatos(string.Empty);
            }
        }

        public virtual void FormularioBase_Load(object sender, EventArgs e)
        {

        }

        public void Consulta_Load(object sender, EventArgs e)
        {
            
        }
    }
}
