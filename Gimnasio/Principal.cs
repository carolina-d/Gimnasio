using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioBase.Clases;
using DominioSeguridad.UnidadDeTrabajo;
using Presentacion.Caja;
using PresentacionComun;
using PresentacionProducto;
using PresentacionSeguridad;
using PresentacionSpinning;
using ServicioSeguridad.DTOs;
using ServicioSeguridad.ServicioSeguridad;
using ServicioSeguridad.UnidadDeTrabajo;
using StructureMap;
 



namespace Gimnasio
{
    public partial class Principal : Form
    {
        private readonly IServicioSeguridadUnidadDeTrabajo servicioSeguridad;
        private bool menuAbierto;


        public Principal(IServicioSeguridadUnidadDeTrabajo _servicioSeguridad)
        {
            InitializeComponent();

            this.servicioSeguridad = _servicioSeguridad;
            this.menuAbierto = false;
        }



        private void TieneAccesoFormulario(Form formulario)
        {
            if (servicioSeguridad.SeguridadServicio.TienePermiso(formulario.Name, Thread.CurrentPrincipal.Identity.Name))
            {
                formulario.ShowDialog();
            }
            else
            {
                PresentacionPlantilla.Mensaje.Mostrar("Acceso Denegado",PresentacionPlantilla. Mensaje.Tipo.Informacion);
            }
        }


        private void LoginUsuario()
        {
            var fLogin = ObjectFactory.GetInstance<Login>();
            fLogin.ShowDialog();

            if (!fLogin.TieneAcceso)
            {
                Application.Exit();
            }
        }
      

        private void Principal_Load(object sender, EventArgs e)
        {
            var fLogin = ObjectFactory.GetInstance<Login>();
            fLogin.ShowDialog();

            if (!fLogin.TieneAcceso)
            {
                Application.Exit();
            }
        }

        private void nuevoSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoSocio = new _00201_Socio_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            fNuevoSocio.ShowDialog();
        }

        private void consultaSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<PresentacionComun._00200_Socio>();
            formConsulta.ShowDialog();
        }

        private void nuevaMembresiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoSocio = new _00207_Membresia_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            fNuevoSocio.ShowDialog();
        }

        private void consultaDeMembresiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<PresentacionComun._00206_Membresia>();
            formConsulta.ShowDialog();
        }

        private void nuevaPromocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevo = new _00209_Promocion_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            fNuevo.ShowDialog();
        }

        private void consultaDePromocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<PresentacionComun._00208_Promocion>();
            formConsulta.ShowDialog();
        }

        private void nuevoTipoDeRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevo = new _00211_TipoRutina_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            fNuevo.ShowDialog();
        }

        private void consultaTipoDeRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<PresentacionComun._00210_TipoRutina>();
            formConsulta.ShowDialog();
        }

        private void nuevaRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNueva = new _00213_Rutina_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            formNueva.ShowDialog();
        }

        private void consultaRutinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<_00212_Rutina>();
            formConsulta.ShowDialog();
            
        }

        private void nuevaClaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNueva = new _00203_Clase_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            formNueva.ShowDialog();
        }

        private void consultaClasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<PresentacionComun._00202_Clase>();
            formConsulta.ShowDialog();
        }

        private void agregarHorarioALaClaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNueva = new _00205_HorarioClase_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            formNueva.ShowDialog();
        }

        private void consultaHorarioClaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<PresentacionComun._00204_HorarioClase>();
            formConsulta.ShowDialog();
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNueva = new _00003_Empleado_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            formNueva.ShowDialog();
        }

        private void consultaEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<PresentacionSeguridad._00004_Empleado>();
            formConsulta.ShowDialog();
        }

        private void nuevoPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nuevoPago = new PantallaPago();
            nuevoPago.ShowDialog();

            //var pago = new PantallaPago();
            //pago.ShowDialog();
        }

        private void consultaPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var consulPago = new ConsultaPagos();
            consulPago.ShowDialog();
        }

        private void asignarClaseAlSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ;
        }

        private void asignarUnaRutinaAlSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNuevo = new _00214_AsignarRutina();
            formNuevo.ShowDialog();
        }

        private void nuevaBicicletasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNueva = new _00500_Spinning_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            formNueva.ShowDialog();
        }

        private void consultaDeBicicletasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<PresentacionSpinning._00501_Spinning>();
            formConsulta.ShowDialog();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNueva = new _00400_Producto_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            formNueva.ShowDialog();
        }

        private void consultaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<_00401_Producto>();
            formConsulta.ShowDialog();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoProvedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNueva = new _00402_Proveedores_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            formNueva.ShowDialog();
        }

        private void consultaProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<_00403_Proveedores>();
            formConsulta.ShowDialog();
        }

        private void nuevoTipoDeEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNueva = new _00012_TipoEmpleado_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            formNueva.ShowDialog();
        }

        private void consultaDeTiposDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<_00013_TipoEmpleado>();
            formConsulta.ShowDialog();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoTurnoSpinningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNueva = new _00503_TurnoSpinning_ABM(PresentacionBase.Constante.TipoOperacion.Nuevo, null);
            formNueva.ShowDialog();
        }

        private void consultaTurnosSpinningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formConsulta = ObjectFactory.GetInstance<_00504_TurnoSpinning>();
            formConsulta.ShowDialog();
        }

        private void consultaMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var movimiento = new ConsultaMovimiento();
            movimiento.ShowDialog();
        }

    



    }
}
