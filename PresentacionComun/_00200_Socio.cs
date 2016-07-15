using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioBase.Clases;
using DominioComun.Entidades;
using DominioComun.UnidadDeTrabajo;
using PresentacionBase;
using Constante = PresentacionBase.Constante;

namespace PresentacionComun
{
    public partial class _00200_Socio : PresentacionPlantilla.FormularioConsulta
    {
        private readonly IUnidadDeTrabajoComun _datosSocioUow;

        public Clase Clases;

        public _00200_Socio()
        {
            InitializeComponent();
        }

        public _00200_Socio(IUnidadDeTrabajoComun datosSocioUow)
        {
            InitializeComponent();

            this.Name = "_00200_Socio";
            this.TituloVentana = "Socios";
            this.Titulo = "Consulta de Socios";
            this.Leyenda = "Aquí Ud. podrá Agregar, Eliminar o Modificar un Socio y Consultar sus Datos";
            this.ColorTitulo = Color.White;
            this.ColorLeyenda = Color.White;

            this._datosSocioUow = datosSocioUow;
            this.EstaModoDiccionario = false;
            //agrego el boton para rutinas
            this.MenuConsulta.Items.Add(CrearBotonRutina());

            this.MenuConsulta.Items.Add(CrearBotonClase());
            ImagenTituloPanelSuperior = ImagenesFormulario.Cliente;



        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            this.dgvBusqueda.Columns["Id"].Visible = false;

                     
            this.dgvBusqueda.Columns["Nombre"].Visible = true;
            this.dgvBusqueda.Columns["Nombre"].HeaderText = "Nombre";
            this.dgvBusqueda.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Apellido"].Visible = true;
            this.dgvBusqueda.Columns["Apellido"].HeaderText = "Apellido";
            this.dgvBusqueda.Columns["Apellido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Apellido"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Direccion"].Visible = true;
            this.dgvBusqueda.Columns["Direccion"].HeaderText = "Dirección";
            this.dgvBusqueda.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Direccion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["Telefono"].Visible = true;
            this.dgvBusqueda.Columns["Telefono"].HeaderText = "Teléfono";
            this.dgvBusqueda.Columns["Telefono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Telefono"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvBusqueda.Columns["FechaNacimiento"].Visible = true;
            this.dgvBusqueda.Columns["FechaNacimiento"].HeaderText = "Fecha de Nacimiento";
            this.dgvBusqueda.Columns["FechaNacimiento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["FechaNacimiento"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            this.dgvBusqueda.Columns["Observacion"].Visible = true;
            this.dgvBusqueda.Columns["Observacion"].HeaderText = "Observaciones";
            this.dgvBusqueda.Columns["Observacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBusqueda.Columns["Observacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
             
        }

    

        public override void ActualizarDatosGrilla(string textoBuscar)
        {
            _datosSocioUow.DatoSocioRepositorio.RefrescarCambios();

            var resultado = _datosSocioUow.DatoSocioRepositorio.ObtenerPorFiltro(x => x.Codigo.Contains(textoBuscar)
                || x.Apellido.Contains(textoBuscar) || x.Direccion.Contains(textoBuscar)
                ).ToList();

            this.dgvBusqueda.DataSource = resultado;
            FormatearGrilla(dgvBusqueda);
        }

        public override void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (new _00201_Socio_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null).ShowDialog() ==
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
                if (new _00201_Socio_ABM(PresentacionBase.Constante.TipoOperacion.Modificar,
               base.EntidadId).ShowDialog() == DialogResult.Yes)
                {
                    //actualiza los datos de la grilla
                    ActualizarDatosGrilla(string.Empty);
                }
            }
                //mensaje en caso de no haber datos en la grilla
            else
            {
                MessageBox.Show("No existen Socios para modificar", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
           
        }

        public override void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvBusqueda.RowCount > 0)
            {
                if (
                    new _00201_Socio_ABM(PresentacionBase.Constante.TipoOperacion.Eliminar, base.EntidadId).ShowDialog() ==
                    DialogResult.Yes)
                {
                    ActualizarDatosGrilla(string.Empty);
                }
            }
            else
            {
                MessageBox.Show("No existen Socios para Eliminar", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                
            }
        }

        public override void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
        }

        

        private void _00200_Socio_Load_1(object sender, EventArgs e)
        {
            ActualizarDatosGrilla(string.Empty);
            FormatearGrilla(dgvBusqueda);
            ImagenTituloPanelSuperior = ImagenesFormulario.Cliente;

            this.txtBuscar.Focus();
            //MarcarVencimiento();

            
        }

        /// <summary>
        /// Obtengo los datos de los Socios para pasarle el id a la rutina y a la clase
        /// </summary>
        /// <returns></returns>
        public DatosSocio ObtenerPSocioSeleccionado()
        {
            int? SocioId = base.EntidadId;
            if (SocioId == null)
                SocioId = 0;

            var resultado = _datosSocioUow.DatoSocioRepositorio.ObtenerTodo().FirstOrDefault(x => x.Id.Equals(SocioId));
            return resultado;
        }

        //Intento de Marcar los socios con vencimiento

        private void MarcarVencimiento()
        {
            //var resultado= _datosSocioUow.DatosSocioRepositorio.ObtenerTodo();

            //resultado.ToList();

            
            //foreach (var item in resultado)
            //{
            //    //var estaVencido = false;

            //    if (item.FechaVencimiento <= DateTime.Today)
            //    {
            //        dgvBusqueda.AlternatingRowsDefaultCellStyle.BackColor = Color.Red;
                    
            //    }
            //    else {
            //        //dgvBusqueda.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
                    
                    
            //    }

               
                
                
            //}
        
        }

        /// <summary>
        /// Creo el boton rutina
        /// </summary>
        /// <returns></returns>
        private ToolStripButton CrearBotonRutina()
        {
            var btnAgregarRutina = new ToolStripButton
            {
                Image = PresentacionBase.ImagenesFormulario.Carnet,
                ImageTransparentColor = System.Drawing.Color.Magenta,
                Name = "btnAgregarRutina",
                Size = new System.Drawing.Size(46, 44),
                Text = "Nueva Rutina",
                TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            };
            btnAgregarRutina.Click += new System.EventHandler(this.btnAgregarRutina_Click);

            return btnAgregarRutina;
        }


        /// <summary>
        /// Le digo que abra el form asignar rutina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnAgregarRutina_Click(object sender, EventArgs e)
        {

            //verifica que haya seleccionado un socio
            if (EntidadId == null)
            {
                MessageBox.Show("No se Selecciono ningun Socio");
                return;
            }

            //le paso como parametro al form el id del socio
            var formRutina = new _00214_AsignarRutina((long)EntidadId);

            //obtengo el id del socio
            var socio = _datosSocioUow.DatoSocioRepositorio.ObtenerPorId(EntidadId.Value);

            // si socio es distinto de null
            if (socio != null)
            {
                //abro el form asignar rutina
                formRutina.ShowDialog();
                formRutina.SocioId = socio.Id;


            }


        }


        /// <summary>
        /// Creo el boton rutina
        /// </summary>
        /// <returns></returns>
        private ToolStripButton CrearBotonClase()
        {
            var btnAgregarClase = new ToolStripButton
            {
                Image = PresentacionBase.ImagenesFormulario.Carnet,
                ImageTransparentColor = System.Drawing.Color.Magenta,
                Name = "btnAgregarClase",
                Size = new System.Drawing.Size(46, 44),
                Text = "Clases",
                TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            };
            btnAgregarClase.Click += new System.EventHandler(this.btnAgregarClase_Click);

            return btnAgregarClase;
        }


        /// <summary>
        /// Le digo que abra el form asignar rutina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnAgregarClase_Click(object sender, EventArgs e)
        {// pone a donde estas coso 

            //verifica que haya seleccionado un socio
            if (EntidadId == null)
            {
                MessageBox.Show("No se Selecciono ningun Socio");
                return;
            }

            //le paso como parametro al form el id del socio
            var formClase = new _00216_AsignarClase((long)EntidadId);//(long)EntidadId

            //obtengo el id del socio
            var socio = _datosSocioUow.DatoSocioRepositorio.ObtenerPorId(EntidadId.Value);

            // si socio es distinto de null
            if (socio != null)
            {
                //abro el form asignar rutina
                formClase.ShowDialog();
                formClase.SocioId = socio.Id;


            }


        }
     
       

    }
}
