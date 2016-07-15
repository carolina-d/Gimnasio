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
using DominioComun.UnidadDeTrabajo;
using PresentacionBase;
using PresentacionPlantilla;

namespace PresentacionComun
{
    public partial class _00204_HorarioClase : FormularioConsulta
    {
        private readonly IUnidadDeTrabajoComun _HoraUow;

        public Clase Clases;

        public _00204_HorarioClase()
        {
            InitializeComponent();
        }

        public _00204_HorarioClase(IUnidadDeTrabajoComun HoraUow)
        {
            InitializeComponent();
            this.Name = "_00204_HorarioClase";
            this.TituloVentana = "Horario de las Clases";
            this.Titulo = "Consulta de Horario de Clases";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar el Horario de una clase y Consultar sus Datos";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;

            this.EstaModoDiccionario = false;
            _HoraUow = HoraUow;
            ImagenTituloPanelSuperior = ImagenesFormulario.Horarios;


        }


        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            this.dgvBusqueda.Columns["Id"].Visible = false;

            this.dgvBusqueda.Columns["Dias"].Visible = true;
            this.dgvBusqueda.Columns["Dias"].HeaderText = "Días";
            this.dgvBusqueda.Columns["Dias"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Dias"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Hora"].Visible = true;
            this.dgvBusqueda.Columns["Hora"].HeaderText = "Hora";
            this.dgvBusqueda.Columns["Hora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Hora"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            this.dgvBusqueda.Columns["Clase"].Visible = true;
            this.dgvBusqueda.Columns["Clase"].HeaderText = "Clase";
            this.dgvBusqueda.Columns["Clase"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Clase"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public override void ActualizarDatosGrilla(string textoBuscar)
        {
            _HoraUow.HorarioClaseRepositorio.RefrescarCambios();

            var resultado =
                _HoraUow.HorarioClaseRepositorio.ObtenerPorFiltro(x => x.Dias.Contains(textoBuscar)
                                                                    , "TipoClases,Clase")
                                                                    .Select(x =>  new ClaseDTO()
                                                                    {
                                                                        Id = x.Id,
                                                                        Clase = x.Clase.Nombre,
                                                                        Dias = x.Dias,
                                                                        Hora = x.Hora.ToString()
                                                                       
                                                                    }).ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla(dgvBusqueda);
        }

        public override void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00205_HorarioClase_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes) ;
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnModificar_Click(object sender, EventArgs e)
        {
            if (new _00205_HorarioClase_ABM(PresentacionBase.Constante.TipoOperacion.Modificar,
                base.EntidadId).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (new _00205_HorarioClase_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        private void _00204_HorarioClase_Load(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }
    }
}
