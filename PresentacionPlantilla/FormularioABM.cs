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
    public partial class FormularioABM : FormularioBase
    {
        // Declaracion de Variables Privadas
        private string _tipoOperacion;
        private bool _realizoAlgunaOperacion;

        public FormularioABM()
        {
            InitializeComponent();
        }


        public FormularioABM(string tipoOperacion, long? entidadId)
        {
            InitializeComponent();

            AsignarImagenBotones();
        }

        public virtual void AsignarImagenBotones()
        {
            
           
        }

        public virtual void Inicializador(string tipoOperacion, long? entidadId)
        {
            _realizoAlgunaOperacion = false;
            _tipoOperacion = tipoOperacion;
            LimpiarDatosFormulario();

            if (tipoOperacion == Constante.TipoOperacion.Nuevo)
            {
                this.BtnGrabar.Text = "Grabar";
            }
            else if (tipoOperacion == Constante.TipoOperacion.Modificar)
            {
                this.BtnGrabar.Text = Constante.TipoOperacion.Modificar;
                CargarDatos(entidadId);
            }
            else if (tipoOperacion == Constante.TipoOperacion.Eliminar)
            {
                this.BtnGrabar.Text = Constante.TipoOperacion.Eliminar;
                CargarDatos(entidadId);
                ActivarControles(false);
            }
        }

        public virtual void CargarDatos(long? entidadId)
        {
            // Este metodo se debe Reescribir en cada formulario
        }

        public virtual void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void BtnGrabar_Click(object sender, EventArgs e)
        {
            EfectuarLosCambios();
        }

        public virtual void BtnLimpiar_Click(object sender, EventArgs e)
        {
            if (_tipoOperacion != Constante.TipoOperacion.Eliminar)
                LimpiarDatosFormulario();
        }

        private void EfectuarLosCambios()
        {
            VerificarDatosObligatorios();

            switch (_tipoOperacion)
            {
                case Constante.TipoOperacion.Nuevo:
                    if (_datosObligatorios)
                    {
                        if (!VerificarSiExisteDatos())
                        {
                            NuevoRegistro();
                            _realizoAlgunaOperacion = true;
                            LimpiarDatosFormulario();
                        }
                    }
                    break;
                case Constante.TipoOperacion.Eliminar:
                    if (Mensaje.Mostrar("Esta seguro de Eliminar el registro seleccionado?", Constante.TipoMensaje.Pregunta) ==
                        DialogResult.Yes)
                    {
                        EliminarRegistro();
                        _realizoAlgunaOperacion = true;
                    }
                    this.Close();
                    break;
                case Constante.TipoOperacion.Modificar:
                    if (_datosObligatorios)
                    {
                        if (!VerificarSiExisteDatos())
                        {
                            ModificarRegistro();
                            _realizoAlgunaOperacion = true;
                            this.Close();
                        }
                    }
                    break;
            }
        }

        // <summary>
        // Metodo para Verificar si estan todos los Datos Obligatorios cargados
        // </summary>
        // <returns>retorna True si cumple con todos los campos Obligatorios</returns>
        public virtual void VerificarDatosObligatorios()
        {
            _datosObligatorios = true;
            errorProvider.Clear();
        }

        public virtual bool VerificarSiExisteDatos()
        {
            return true;
        }

        /// <summary>
        /// Metodo para modificar los registros
        /// </summary>
        public virtual void ModificarRegistro()
        {
        }

        /// <summary>
        /// Metodo para Eliminar los Registros
        /// </summary>
        public virtual void EliminarRegistro()
        {
        }

        /// <summary>
        /// Metodo para un nuevo registro
        /// </summary>
        public virtual void NuevoRegistro()
        {
        }

        private void FormularioBaseABM_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = _realizoAlgunaOperacion ? DialogResult.Yes : DialogResult.No;
        }

        public void FormularioABM_Load(object sender, EventArgs e)
        {
        
        }

        public virtual void ActualizarDatosGrilla(string textoBuscar)
        {

        }



    }
}
