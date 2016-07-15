using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioComun.UnidadDeTrabajo;
using PresentacionBase;
using PresentacionPlantilla;
using Aplicacion.Comun;
using StructureMap;

namespace PresentacionComun
{
    public partial class _00212_Rutina : FormularioConsulta
    {
        private readonly IUnidadDeTrabajoComun _datosRutinaUow;

        public _00212_Rutina()
        {
            InitializeComponent();
        }

        public _00212_Rutina(IUnidadDeTrabajoComun datosRutinaUow)
        {
              InitializeComponent();

              this.Name = "_00300_Rutina";
              this.TituloVentana = "Rutinas";
              this.Titulo = "Consulta de Rutinas";
              this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar una Rutina y Consultar sus Datos";
              this.ColorTitulo = Color.White;
              this.ColorLeyenda = Color.White;


              this.EstaModoDiccionario = false;
            _datosRutinaUow = datosRutinaUow;
            ImagenTituloPanelSuperior = ImagenesFormulario.Cliente;

            
        }


         

        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            this.dgvBusqueda.Columns["Id"].Visible = false;

            this.dgvBusqueda.Columns["Nombre"].Visible = true;
            this.dgvBusqueda.Columns["Nombre"].HeaderText = "Nombre";
            this.dgvBusqueda.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

           // this.dgvBusqueda.Columns["Fecha"].Visible = true;
           // this.dgvBusqueda.Columns["Fecha"].HeaderText = "Fecha";
           // this.dgvBusqueda.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           // this.dgvBusqueda.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Descripcion"].Visible = true;
            this.dgvBusqueda.Columns["Descripcion"].HeaderText = "Descripción";
            this.dgvBusqueda.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Dias"].Visible = true;
            this.dgvBusqueda.Columns["Dias"].HeaderText = "Dias";
            this.dgvBusqueda.Columns["Dias"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Dias"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Repeticiones"].Visible = true;
            this.dgvBusqueda.Columns["Repeticiones"].HeaderText = "Repeticiones";
            this.dgvBusqueda.Columns["Repeticiones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Repeticiones"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Series"].Visible = true;
            this.dgvBusqueda.Columns["Series"].HeaderText = "Series";
            this.dgvBusqueda.Columns["Series"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Series"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            this.dgvBusqueda.Columns["TipoRutina"].Visible = true;
            this.dgvBusqueda.Columns["TipoRutina"].HeaderText = "Tipo de Rutina";
            this.dgvBusqueda.Columns["TipoRutina"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["TipoRutina"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
       
        
        }

    
         
        public override void ActualizarDatosGrilla(string textoBuscar)
        {
            _datosRutinaUow.RutinaRepositorio.RefrescarCambios();

            var resultado =
                _datosRutinaUow.RutinaRepositorio.ObtenerPorFiltro(x => x.Nombre.Contains(textoBuscar)||
                                                                    x.Descripcion.Contains(textoBuscar),"TipoRutina")
                                                                    .Select(x=> new RutinaDTO
                                                                    {
                                                                        Id= x.Id,
                                                                        Nombre = x.Nombre,
                                                                        Descripcion = x.Descripcion,
                                                                        //Fecha =  x.Fecha,
                                                                        Dias = x.Dias,
                                                                        Series = x.Series,
                                                                        Repeticiones = x.Repeticiones,
                                                                        TipoRutina = x.TipoRutina.Descripcion//no lo muestra
                                                                        
                                                                    }).ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla(dgvBusqueda);
        }

        public override void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00213_Rutina_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes);
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void BtnModificar_Click(object sender, EventArgs e)
        {
            //si hay datos cargados en la grilla
            if (dgvBusqueda.RowCount > 0)
            {
                //abre el formulario
                if (new _00213_Rutina_ABM(PresentacionBase.Constante.TipoOperacion.Modificar,
               base.EntidadId).ShowDialog() == DialogResult.Yes)
                {
                    //actualiza los datos de la grilla
                    ActualizarDatosGrilla(string.Empty);
                }
            }
            //mensaje en caso de no haber datos en la grilla
            else
            {
                MessageBox.Show("No hay Rutinas cargadas para modificar", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            //si hay datos cargados en la grilla
            if (dgvBusqueda.RowCount > 0)
            {
                //abre el formulario
                if (new _00213_Rutina_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar,
               base.EntidadId).ShowDialog() == DialogResult.Yes)
                {
                    //actualiza los datos de la grilla
                    ActualizarDatosGrilla(string.Empty);
                }
            }
            //mensaje en caso de no haber datos en la grilla
            else
            {
                MessageBox.Show("No hay Rutinas cargadas para Eliminar", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        private void _00212_Rutina_Load(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }
    }
}
