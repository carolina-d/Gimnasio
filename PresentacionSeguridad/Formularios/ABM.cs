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
    public partial class ABM : FormBase
    {
        private string tipoOperacion;
        private long? entidadId;

        /// <summary>
        /// Propiedad para saber si se realizo alguna operacion (Insertar, Modificar o Eliminar)
        /// </summary>
        public bool RealizoAlgunaOperacion { get; set; }
        public bool LanzadoPorCierre { get; set; }
        public bool LanzadoPorLimpiar { get; set; }

        public ABM()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_tipoOperacion">Tipo de Operacion a realizar (Insertar, Modificar o Eliminar)</param>
        /// <param name="_entidadId">Identificador (Id) de la Entidad</param>
        public ABM(string _tipoOperacion, long? _entidadId)
        {
            InitializeComponent();

            this.tipoOperacion = _tipoOperacion;
            this.entidadId = _entidadId;

            this.RealizoAlgunaOperacion = false;
            this.LanzadoPorCierre = false;
            this.LanzadoPorLimpiar = false;

  

            switch (_tipoOperacion)
            {
                case PresentacionBase.Constante.TipoOperacion.Nuevo:
                   // this.btnEjecutar.Image = Constante.ImagenControl.BotonGuardar;
                    this.btnEjecutar.Text = "Guardar";
                    this.Text = "Nuevo";
                    break;
                case PresentacionBase.Constante.TipoOperacion.Eliminar:
                   // this.btnEjecutar.Image = Constante.ImagenControl.BotonEliminar;
                    this.btnEjecutar.Text = "Eliminar";
                    this.Text = "Eliminar";
                    break;
                case PresentacionBase. Constante.TipoOperacion.Modificar:
                    //this.btnEjecutar.Image = Constante.ImagenControl.BotonModificar;
                    this.btnEjecutar.Text = "Guardar";
                    this.Text = "Modificación";
                    break;
            }
        }

        public virtual void Init(string _tipoOperacion, long? _entidadId)
        {
            switch (_tipoOperacion)
            {
                case PresentacionBase.Constante.TipoOperacion.Nuevo:
                    LimpiarDatos(this);
                    ObtenerSiguienteCodigo();
                    break;
                case PresentacionBase.Constante.TipoOperacion.Eliminar:
                    this.btnLimpiar.Visible = false;
                    ActivarControles(this, false);
                    CargarDatos(_entidadId);
                    break;
                case PresentacionBase.Constante.TipoOperacion.Modificar:
                    CargarDatos(_entidadId);
                    break;
            }
        }

        public override void LimpiarDatos(object obj)
        {
            base.LimpiarDatos(obj);
            ObtenerSiguienteCodigo();
        }

        public virtual void CargarDatos(long? _entidadId)
        {

        }


        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (!VerificarDatosObligatorios()) return;

            switch (this.tipoOperacion)
            {
                case PresentacionBase.Constante.TipoOperacion.Nuevo:
                    if (!VerificarSiExiste())
                    {
                        EjecutarComandoNuevo();
                        RealizoAlgunaOperacion = true;
                        LimpiarDatos(this);
                    }
                    break;
                case PresentacionBase.Constante.TipoOperacion.Modificar:
                    if (!VerificarSiExiste())
                    {
                        EjecutarComandoModificar();
                        RealizoAlgunaOperacion = true;
                        this.Close();
                    }
                    break;
                case PresentacionBase.Constante.TipoOperacion.Eliminar:
                    EjecutarComandoEliminar();
                    RealizoAlgunaOperacion = true;
                    this.Close();
                    break;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (PresentacionBase.Constante.TipoOperacion.Eliminar != this.tipoOperacion)
            {
                LimpiarDatos(this);
            }
            LanzadoPorLimpiar = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void ObtenerSiguienteCodigo()
        {

        }

        public virtual void EjecutarComandoEliminar()
        {

        }

        public virtual void EjecutarComandoModificar()
        {

        }

        public virtual void EjecutarComandoNuevo()
        {

        }

        public virtual bool VerificarSiExiste()
        {
            return false;
        }

        public virtual bool VerificarDatosObligatorios()
        {
            return true;
        }

        private void ABM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (RealizoAlgunaOperacion) return;

            var mensaje = string.Empty;

            switch (this.tipoOperacion)
            {
                case PresentacionBase.Constante.TipoOperacion.Nuevo:
                    mensaje = "Desea guardar los datos";
                    break;
                case PresentacionBase.Constante.TipoOperacion.Eliminar:
                    mensaje = "Desea Eliminar los datos";
                    break;
                case PresentacionBase.Constante.TipoOperacion.Modificar:
                    mensaje = "Desea Modificar los datos";
                    break;
            }

            if (PresentacionPlantilla.Mensaje.Mostrar(mensaje, PresentacionPlantilla.Mensaje.Tipo.Pregunta) != System.Windows.Forms.DialogResult.Yes) return;

            if (PresentacionBase.Constante.TipoOperacion.Nuevo == this.tipoOperacion
                || LanzadoPorLimpiar)
            {
                e.Cancel = true;
            }

            this.LanzadoPorCierre = true;
            this.btnEjecutar.PerformClick();
        }

    }
}
