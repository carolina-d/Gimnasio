using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.Comun;
using DominioComun.Entidades;
using PresentacionPlantilla;

namespace PresentacionComun
{
    public partial class BuscarSocio : FormularioBase
    {

        // Lista de Socios filtrados por Telefono o Celular
        List<SocioDTO> listaSocios;

        // Declaracion de Atributo de ClienteDTO
        private SocioDTO socioDTO;

        // Declaracion de Propiedad de ClienteDTO
        public SocioDTO Socio
        {
            get { return socioDTO; }
            private set { socioDTO = value; }
        }

        public BuscarSocio(List<DatosSocio> lista )
        {
            InitializeComponent();

            base.Titulo = "Buscar Cliente";
            this.TituloVentana = string.Empty;

            // Como lista es del tipo cliente, se debe pasar a clienteDTO
            listaSocios = lista.Select(x => new SocioDTO()
            {
                Id = x.Id,
                ApyNombre = x.Apellido + " " + x.Nombre,
                Telefono = x.Telefono,  
                Domicilio = x.Direccion

            }).ToList();

            PoblarGrillaSocio(string.Empty);
        }

        private void PoblarGrillaSocio(string cadenaBuscar)
        {
            var resultado = listaSocios.Where(x => x.ApyNombre.Contains(cadenaBuscar)
                || x.Telefono.Contains(cadenaBuscar)
                || x.Domicilio.Contains(cadenaBuscar))
                .Select(x => new SocioDTO()
                {
                    Id = x.Id,
                    ApyNombre = x.ApyNombre,
                    Telefono = x.Telefono,
                    Domicilio = x.Domicilio
                });

            this.dgvSocio.DataSource = resultado.ToList();

            FormatearGrilla();
        }

        public void FormatearGrilla()
        {
            dgvSocio.Columns["Id"].Visible = false;
               
            dgvSocio.Columns["ApyNombre"].HeaderText = "Apellido y Nombre";
            dgvSocio.Columns["ApyNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSocio.Columns["ApyNombre"].DisplayIndex = 0;
            dgvSocio.Columns["ApyNombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
               
            dgvSocio.Columns["Telefono"].HeaderText = "Teléfono";
            dgvSocio.Columns["Telefono"].Width = 100;
            dgvSocio.Columns["Telefono"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSocio.Columns["Telefono"].DisplayIndex = 1;
               
            dgvSocio.Columns["Domicilio"].HeaderText = "Dirección";
            dgvSocio.Columns["Domicilio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSocio.Columns["Domicilio"].DisplayIndex = 3;
            dgvSocio.Columns["Domicilio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvSocio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var idSocio = (long)dgvSocio["Id", this.dgvSocio.CurrentCell.RowIndex].Value;

            socioDTO = listaSocios.First(x => x.Id == idSocio);

            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PoblarGrillaSocio(this.txtBusqueda.Text);

        }
    }
}
