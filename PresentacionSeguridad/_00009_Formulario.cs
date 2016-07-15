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
using PresentacionBase;
using PresentacionPlantilla;
using PresentacionSeguridad.Formularios;
using ServicioSeguridad.DTOs;
using ServicioSeguridad.ServicioFormulario;
using ServicioSeguridad.UnidadDeTrabajo;
using StructureMap;

namespace PresentacionSeguridad
{
    public partial class _00009_Formulario : FormBase
    {
        public List<FormularioDTO> listaFormularios;
        private readonly IServicioSeguridadUnidadDeTrabajo seguridadServicio;

        public _00009_Formulario(IServicioSeguridadUnidadDeTrabajo _seguridadServicio)
        {
            InitializeComponent();

            this.seguridadServicio = _seguridadServicio;

            listaFormularios = new List<FormularioDTO>();

            this.Name = "_00009_Formulario";
         
            
        }

        private void ActualizarFormularios(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = listaFormularios
                .Where(x => x.NombreCompleto.Contains(cadenaBuscar))
                .Select(x => new
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Nombre = x.Nombre,
                    NombreCompleto = x.NombreCompleto,
                    BD = x.ExisteBaseDatos ? "SI" : "NO"
                }).ToList();

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            this.dgvGrilla.Columns["Id"].Visible = false;

            this.dgvGrilla.Columns["Codigo"].Width = 150;
            this.dgvGrilla.Columns["Codigo"].HeaderText = "Código";
            this.dgvGrilla.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["Nombre"].HeaderText = "Nombre";
            this.dgvGrilla.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dgvGrilla.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
            this.dgvGrilla.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dgvGrilla.Columns["BD"].Width = 150;
            this.dgvGrilla.Columns["BD"].HeaderText = "Existe Base";
            this.dgvGrilla.Columns["BD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                seguridadServicio.FormularioServicio.InsertarFormulario(listaFormularios);

                listaFormularios.Clear();

                seguridadServicio.FormularioServicio.PoblarFormulariosSistema(ref listaFormularios, PresentacionSeguridad.SeguridadAssembly.SegAssembly);

                ActualizarFormularios(string.Empty);

                this.btnActualizar.Visible = listaFormularios.Any(x => x.ExisteBaseDatos == false);
            }
            catch (Exception ex)
            {
                Mensaje.Mostrar(ex, Mensaje.Tipo.Error);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarFormularios(this.txtBuscar.Text);
        }

        private void _00009_Formulario_Load(object sender, EventArgs e)
        {
            ActualizarFormularios(string.Empty);
            this.btnActualizar.Visible = listaFormularios.Any(x => x.ExisteBaseDatos == false);
        }

      
    }
}
