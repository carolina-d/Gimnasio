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
    public partial class AgregarRutina : FormularioBusqueda
    {

        private readonly IUnidadDeTrabajoComun _comunUow;
        private bool _modoSeleccion = false;
        private long _entidadId = 0;

        public Rutina RutinaSeleccionada { get; set; }

        private List<Rutina> _listaRutinas;

        public AgregarRutina(List<Rutina> ListaRutinas)
        {
            InitializeComponent();
            _listaRutinas = ListaRutinas;
        }

        public AgregarRutina(IUnidadDeTrabajoComun comunUow, bool modoSeleccion)
        {
            InitializeComponent();
            _comunUow = comunUow;
           

            this.Name = "_00300_Rutina";
            this.TituloVentana = "Rutinas";
            this.Titulo = "Consulta de Rutinas";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar una Rutina y Consultar sus Datos";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;
            
            ActualizarDatosGrilla(string.Empty);

            _modoSeleccion = modoSeleccion;


            if (_modoSeleccion)
            {
                dgvBusqueda.CellContentDoubleClick += dgvBusqueda_DoubleClick;
            }
            
        }


        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            this.dgvBusqueda.Columns["Id"].Visible = false;

            this.dgvBusqueda.Columns["Nombre"].Visible = true;
            this.dgvBusqueda.Columns["Nombre"].HeaderText = "Nombre";
            this.dgvBusqueda.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

          
            this.dgvBusqueda.Columns["Descripcion"].Visible = true;
            this.dgvBusqueda.Columns["Descripcion"].HeaderText = "Descripción";
            this.dgvBusqueda.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Descripcion"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Dias"].Visible = true;
            this.dgvBusqueda.Columns["Dias"].HeaderText = "Dias";
            this.dgvBusqueda.Columns["Dias"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Dias"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Repeticiones"].Visible = true;
            this.dgvBusqueda.Columns["Repeticiones"].HeaderText = "Repeticiones";
            this.dgvBusqueda.Columns["Repeticiones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Repeticiones"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Series"].Visible = true;
            this.dgvBusqueda.Columns["Series"].HeaderText = "Series";
            this.dgvBusqueda.Columns["Series"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Series"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            this.dgvBusqueda.Columns["TipoRutina"].Visible = true;
            this.dgvBusqueda.Columns["TipoRutina"].HeaderText = "Tipo de Rutina";
            this.dgvBusqueda.Columns["TipoRutina"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["TipoRutina"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


        }
      
          public void dgvBusqueda_DoubleClick(object sender, EventArgs e)
          {
             // if(dgvBusqueda.Rows.Count <= 0)
             //     return;
             //
             //var indice = dgvBusqueda.CurrentRow.Index;
             // _entidadId = Convert.ToInt64(dgvBusqueda["Id", indice].Value);
             //
             // this.Close();

              if (dgvBusqueda.RowCount > 0)
              {
                   _entidadId = Convert.ToInt32(this.dgvBusqueda["Id", this.dgvBusqueda
                       .CurrentRow.Index].Value);


                  // var resultado = _listaRutinas.First(x => x.Id == _entidadId);

                 // RutinaSeleccionada = resultado;
                  MessageBox.Show("La rutina se Agrego correctamente al socio");

              
                  //this.Close();

              }
              
          }

          public long ObtenerId()
          {
              return _entidadId;
          }

      
        public override void ActualizarDatosGrilla(string textoBuscar)
        {
            _comunUow.RutinaRepositorio.RefrescarCambios();

            var resultado =
                _comunUow.RutinaRepositorio.ObtenerPorFiltro(x => x.Nombre.Contains(textoBuscar)||
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

        public override void btnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00213_Rutina_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
                DialogResult.Yes);
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

    
        public override void btnEliminar_Click(object sender, EventArgs e)
        {
            if (new _00213_Rutina_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() == DialogResult.Yes)
            {
                ActualizarDatosGrilla(string.Empty);
            }
        }

        public override void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }
        

        private void AgregarRutina_Load(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
            FormatearGrilla(dgvBusqueda);
            ImagenTituloPanelSuperior = ImagenesFormulario.AgregarRutina;

        }
    }
}
