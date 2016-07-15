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
using DominioBase.Clases;
using DominioSeguridad.UnidadDeTrabajo;
using PresentacionPlantilla;
using PresentacionSeguridad.Formularios;

namespace PresentacionSeguridad
{
    public partial class _00006_CambiarPassword : FormBase
    {

        private readonly ISeguridadUnidadDeTrabajo seguridadUoW;

        public _00006_CambiarPassword()
        {
            InitializeComponent();
            
        }

        public _00006_CambiarPassword(ISeguridadUnidadDeTrabajo _seguridadUoW)
        {
            InitializeComponent();

            this.Name = "_00006_CambiarPassword";

            this.seguridadUoW = _seguridadUoW;

           
            this.txtPasswordActual.Leave += new EventHandler(txt_Leave);
            this.txtPasswordNueva.Leave += new EventHandler(txt_Leave);
            this.txtRepetirPassword.Leave += new EventHandler(txt_Leave);

            this.txtPasswordActual.Enter += new EventHandler(txt_Enter);
            this.txtPasswordNueva.Enter += new EventHandler(txt_Enter);
            this.txtRepetirPassword.Enter += new EventHandler(txt_Enter);
        }

        private void _00006_CambiarPassword_Load(object sender, EventArgs e)
        {

        }

        private void imgActual_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtPasswordActual.PasswordChar = char.MinValue;
        }

        private void imgNueva_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtPasswordNueva.PasswordChar = char.MinValue;

        }

        private void imgRepetir_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtRepetirPassword.PasswordChar = char.MinValue;

        }

        private void imgRepetir_MouseUp(object sender, MouseEventArgs e)
        {
            this.txtRepetirPassword.PasswordChar = '*';
        }

        private void imgNueva_MouseUp(object sender, MouseEventArgs e)
        {
            this.txtPasswordNueva.PasswordChar = '*';

        }

        private void imgActual_MouseUp(object sender, MouseEventArgs e)
        {
            this.txtPasswordActual.PasswordChar = '*';
            

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            var usuarioActual =
                seguridadUoW.UsuarioRepositorio.ObtenerPorFiltro(x => x.Nombre == Thread.CurrentPrincipal.Identity.Name)
                    .FirstOrDefault();

            if (usuarioActual == null) return;

            if (Encriptar.EncriptarCadena(this.txtPasswordActual.Text) == usuarioActual.Password)
            {
                if (this.txtPasswordNueva.Text == this.txtRepetirPassword.Text)
                {
                    usuarioActual.Password = Encriptar.EncriptarCadena(this.txtPasswordNueva.Text);

                    seguridadUoW.UsuarioRepositorio.Modificar(usuarioActual);
                    seguridadUoW.Commit();

                    Mensaje.Mostrar("La contraseña se actualizó correctamente", Mensaje.Tipo.Informacion);
                    this.Close();
                }
                else
                {
                    Mensaje.Mostrar("La contraseña Nueva no coincide", Mensaje.Tipo.Error);
                    this.txtPasswordNueva.Clear();
                    this.txtRepetirPassword.Clear();
                    this.txtPasswordActual.Focus();
                }
            }
            else
            {
                Mensaje.Mostrar("La contraseña actual no coincide con la del usuario login", Mensaje.Tipo.Error);
                this.txtPasswordActual.Clear();
                this.txtPasswordActual.Focus();
            }
        }
    }
}
