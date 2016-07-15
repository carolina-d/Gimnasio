using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using DominioSeguridad.UnidadDeTrabajo;
using PresentacionBase;
using PresentacionPlantilla;
using ServicioSeguridad.UnidadDeTrabajo;

namespace PresentacionSeguridad
{
    public partial class _00005_Usuario : FormularioBase
    {
        private readonly ISeguridadUnidadDeTrabajo seguridadUoW;
        private readonly IServicioSeguridadUnidadDeTrabajo seguridadServicio;

        private List<long> listaIds;

        public _00005_Usuario()
        {
            InitializeComponent();
        }

        public _00005_Usuario(ISeguridadUnidadDeTrabajo _seguridadUoW,
            IServicioSeguridadUnidadDeTrabajo _seguridadServicio)
        {
            InitializeComponent();

            this.Name = "_00200_Usuario";
            this.TituloVentana = "Usuarios";
            this.Titulo = "Usuarios de Sistema";
            this.Leyenda = "Aquí Ud. podrá Crear, Eliminar o Bloquear un Usuario y restablecer su contraseña";

            this.ColorTitulo = Color.Black;
            this.ColorLeyenda = Color.Gray;


            this.seguridadUoW = _seguridadUoW;
            this.seguridadServicio = _seguridadServicio;

            this.listaIds = new List<long>();


            // Cargar evento de Validacion de Caracteres 
            this.txtBuscar.KeyPress += new KeyPressEventHandler(base.textBoxLetrasNumeros_KeyPress);

            // Color al recibir el Foco
            this.txtBuscar.Enter += new EventHandler(base.control_Enter);

            // Color al perder el Foco
            this.txtBuscar.Leave += new EventHandler(base.control_Leave);
            ActualizarDatos(string.Empty);

            
         
            


        }

        private void ActualizarDatos(string cadenaBuscar)
        {
            seguridadUoW.UsuarioRepositorio.RefrescarCambios();

            var resultado = seguridadUoW.EmpleadoRepositorio.ObtenerPorFiltro(x => x.Dni == cadenaBuscar
                                                                                   || x.Apellido.Contains(cadenaBuscar)
                                                                                   || x.Nombre.Contains(cadenaBuscar),
                                                                              "Usuarios");

            this.dgvUsuario.DataSource = resultado.Select(x => new
            {
                Id = x.Id,
                ApyNom = x.ApyNom,
                UsuarioId = x.Usuarios.Any()
                ? x.Usuarios.First().Id : -1,
                Usuario = x.Usuarios.Any()
                ? x.Usuarios.First().Nombre
                : "NO Asignado",
                EstaBloqueado = x.Usuarios.Any()
                ? x.Usuarios.First().EstaBloqueado ? "SI" : "NO"
                : "NO",
                TieneUsuario = x.Usuarios.Any()
                ? "SI"
                : "NO"
            }).ToList();
            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            this.dgvUsuario.Columns["Id"].Visible = false;
            this.dgvUsuario.Columns["TieneUsuario"].Visible = false;
            this.dgvUsuario.Columns["UsuarioId"].Visible = false;
                    
            this.dgvUsuario.Columns["Legajo"].Visible = true;
            this.dgvUsuario.Columns["Legajo"].Width = 70;
            this.dgvUsuario.Columns["Legajo"].HeaderText = "Legajo";
            this.dgvUsuario.Columns["Legajo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    
            this.dgvUsuario.Columns["ApyNom"].Visible = true;
            this.dgvUsuario.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvUsuario.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            this.dgvUsuario.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    
            this.dgvUsuario.Columns["Usuario"].Visible = true;
            this.dgvUsuario.Columns["Usuario"].Width = 150;
            this.dgvUsuario.Columns["Usuario"].HeaderText = "Usuario";
            this.dgvUsuario.Columns["Usuario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    
            this.dgvUsuario.Columns["EstaBloqueado"].Visible = true;
            this.dgvUsuario.Columns["EstaBloqueado"].Width = 70;
            this.dgvUsuario.Columns["EstaBloqueado"].HeaderText = "Bloqueado";
            this.dgvUsuario.Columns["EstaBloqueado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvUsuario.Columns["EstaBloqueado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        
         private void MarcarItem(bool estado)
        {
            for (int i = 0; i < this.dgvUsuario.RowCount; i++)
            {
                this.dgvUsuario["Item", i].Value = estado;
            }
        }

       

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            listaIds.Clear();

            for (var i = 0; i < this.dgvUsuario.RowCount; i++)
            {
                if (Convert.ToBoolean(this.dgvUsuario["Item", i].Value) && this.dgvUsuario["Usuario", i].Value.ToString() == "NO Asignado")
                {
                    listaIds.Add(Convert.ToInt64(this.dgvUsuario["Id", i].Value));
                }
            }

            if (listaIds.Any())
            {
                try
                {
                    if (seguridadServicio.UsuarioServicio.CrearUsuario(listaIds))
                    {
                        Mensaje.Mostrar("Los Usuario se crearon correctamente", Mensaje.Tipo.Informacion);
                        ActualizarDatos(string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    Mensaje.Mostrar(ex, Mensaje.Tipo.Informacion);
                }
            }
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            listaIds.Clear();

            for (var i = 0; i < this.dgvUsuario.RowCount; i++)
            {
                if (Convert.ToBoolean(this.dgvUsuario["Item", i].Value) && this.dgvUsuario["Usuario", i].Value.ToString() != "NO Asignado")
                {
                    listaIds.Add(Convert.ToInt64(this.dgvUsuario["UsuarioId", i].Value));
                }
            }

            if (listaIds.Any())
            {
                try
                {
                    if (seguridadServicio.UsuarioServicio.ReiniciarPassword(listaIds))
                    {
                        Mensaje.Mostrar("La contraseña de los Usuarios se resetearon correctamente", Mensaje.Tipo.Informacion);
                        ActualizarDatos(string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    Mensaje.Mostrar(ex, Mensaje.Tipo.Informacion);
                }
            }
        }

      
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBusar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(this.txtBuscar.Text);
        }

        private void _00005_Usuario_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).RowCount <= 0) return;

            if (e.RowIndex >= 0)
            {
                ((DataGridView)sender).EndEdit();
            }
        }

        public void MarcarTodo()
        {
            MarcarItems(this.dgvUsuario, "Item", true);
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            this.txtBuscar.BackColor = Constante.ColorControl.ColorSinFoco;
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            this.txtBuscar.BackColor = Constante.ColorControl.ColorConFoco;
        }

     

        private void btnBloquear_Click(object sender, EventArgs e)
        {
           listaIds.Clear();

            for (var i = 0; i < this.dgvUsuario.RowCount; i++)
            {
                if (Convert.ToBoolean(this.dgvUsuario["Item", i].Value) && this.dgvUsuario["Usuario", i].Value.ToString() != "NO Asignado")
                {
                    listaIds.Add(Convert.ToInt64(this.dgvUsuario["UsuarioId", i].Value));
                }
            }

            if (listaIds.Any())
            {
                try
                {
                    if (seguridadServicio.UsuarioServicio.BloquearUsuario(listaIds))
                    {
                        Mensaje.Mostrar("Los Usuario se bloquearon/desbloquearon correctamente", Mensaje.Tipo.Informacion);
                        ActualizarDatos(string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    Mensaje.Mostrar(ex, Mensaje.Tipo.Informacion);
                }
            }
       }

        

        private void btnMarcarTodo_Click(object sender, EventArgs e)
        {
            MarcarItem(true);
        }

        private void btnDesmarcarTodo_Click(object sender, EventArgs e)
        {
            MarcarItem(true);
        }
    }
}
