using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioSeguridad.UnidadDeTrabajo;
using PresentacionBase;
using ServicioSeguridad.ServicioSeguridad;
using ServicioSeguridad.UnidadDeTrabajo;

namespace PresentacionSeguridad
{
    public partial class Login : Form
    {
        private readonly IServicioSeguridadUnidadDeTrabajo seguridadServicio;
        private readonly ISeguridadUnidadDeTrabajo seguridadUoW;

        public int CantidadAccesoFallido { get; set; }
        public bool TieneAcceso { get; set; }

        public Login(ISeguridadUnidadDeTrabajo _seguridadUoW,
            IServicioSeguridadUnidadDeTrabajo _seguridadServicio)
        {
            InitializeComponent();

            this.Name = "_00207_Login";

            this.seguridadServicio = _seguridadServicio;
            this.seguridadUoW = _seguridadUoW;
            this.CantidadAccesoFallido = 0;
        }

        private void imgPassword_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtPassword.PasswordChar = char.MinValue;
        }

        private void imgPassword_MouseUp(object sender, MouseEventArgs e)
        {
            this.txtPassword.PasswordChar = '*';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           if (this.txtUsuario.Text == Constante.Seguridad.UsuarioAdmin
                && this.txtPassword.Text == Constante.Seguridad.PasswordAdmin)
            {
                TieneAcceso = true;
                this.Close();
            }
            else
            {
                if (seguridadServicio.SeguridadServicio.TieneAccesoSistema(this.txtUsuario.Text, this.txtPassword.Text))
                {
                    if (!seguridadServicio.UsuarioServicio.VerificarSiEstaBloqueado(this.txtUsuario.Text,
                                                                                    this.txtPassword.Text))
                    {
                        TieneAcceso = true;
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(this.txtUsuario.Text),
                                                                       new string[0]);
                        this.Close();
                    }
                    else
                    {
                        PresentacionPlantilla.Mensaje.Mostrar("El Usuario esta Bloqueado. Comuníquese con el Administrador", PresentacionPlantilla.Mensaje.Tipo.Stop);
                        TieneAcceso = false;
                        this.Close();
                    }
                }
                else
                {
                    CantidadAccesoFallido++;

                    if (CantidadAccesoFallido == 3)
                    {
                        var usuario =
                            seguridadUoW.UsuarioRepositorio.ObtenerPorFiltro(x => x.Nombre == this.txtUsuario.Text).
                                FirstOrDefault();

                        if (usuario != null)
                        {
                           PresentacionPlantilla. Mensaje.Mostrar(
                                "Por razones de Seguridad el Usuario sera Bloqueado. Comuníquese con el Adminsitrador",
                            PresentacionPlantilla.Mensaje.Tipo.Stop);

                            usuario.EstaBloqueado = true;
                            seguridadUoW.UsuarioRepositorio.Modificar(usuario);
                            seguridadUoW.Commit();
                        }

                        TieneAcceso = false;
                        this.Close();
                    }
                    else
                    {
                        PresentacionPlantilla.Mensaje.Mostrar("El Usuario o la Contraseña son Incorrectos", PresentacionPlantilla.Mensaje.Tipo.Error);
                        this.txtPassword.Clear();
                        this.txtPassword.Focus();
                    }
                }
            }
        }
        

        private
            void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
