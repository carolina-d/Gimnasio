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
using PresentacionPlantilla;
using AplicacionConexion;


namespace PresentacionSeguridad
{
    public partial class ConfiguracionBaseDatos : FormularioBase
    {
        public ConfiguracionBaseDatos()
        {
            InitializeComponent();

            this.Name = "_00209_ConfiguracionServidorBaseDatos";
            this.TituloVentana = "Configuración";
            this.Titulo = "Configuración del Servidor de Base de Datos";
            this.Leyenda = "Aquí Ud. podrá configurar la IP o DNS del servidor de la Base de Datos";

            this.ColorTitulo = Color.Black;
            this.ColorLeyenda = Color.Gray;

            this.UsuarioLogin = Thread.CurrentPrincipal.Identity.Name;

           

            //// Cargar evento de Validacion de Caracteres 
            //this.txtBuscar.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);

            //// Color al recibir el Foco
            //this.txtBuscar.Enter += new EventHandler(base.control_Enter);

            //// Color al perder el Foco
            //this.txtBuscar.Leave += new EventHandler(base.control_Leave);
        }

        private void ConfiguracionBaseDatos_Load(object sender, EventArgs e)
        {
            this.txtServidor.Text = Configuracion.Default.Servidor;
            this.txtBaseDatos.Text = Configuracion.Default.BaseDatos;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            AplicacionConexion.Configuracion.Default.Servidor = this.txtServidor.Text;
            Configuracion.Default.BaseDatos = this.txtBaseDatos.Text;
            Configuracion.Default.Save();
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
