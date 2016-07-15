using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Caja.Entidades;
using Dominio.Caja.UnidadDeTrabajo;
using DominioComun.UnidadDeTrabajo;
using Gimnasio.DTO;
using InfraestructuraComun.Contexto;
using Presentacion.Caja.Controles;
using StructureMap;
using StructureMap.Pipeline;


namespace Presentacion.Caja
{
    public partial class _00600_ABM_Pago : PresentacionPlantilla.FormularioBase
    {
        ContextoComun contextoComun = new ContextoComun();

        private int pagoId;
        private int empleadoId;
        private int socioId;

        List<DTOpago> listaPago;

       

        private readonly IUnidadDeTrabajoCaja uowCaja = ObjectFactory.GetInstance<IUnidadDeTrabajoCaja>();
        private readonly IUnidadDeTrabajoComun uowComun = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();

        private ctrolBuscarSocio ctrlBuscarSocio;

        public _00600_ABM_Pago()
        {
            InitializeComponent();


            this.TituloVentana = "Pantalla Pagos";
            this.Titulo = "Gestión de Pagos";
            this.Leyenda = "Aquí podrá realizar el Pago de un socio";

            ctrlBuscarSocio = new ctrolBuscarSocio(uowComun)
            {
                Top = 18
            };

            this.pnlSocio.Controls.Add(ctrlBuscarSocio);
        }

        public void PoblarComboMembresia()
        {
            //var membresia = contexto.MEMBRESIA.ToList()

            //this.comboBox1.DataSource = membresia.ToList();


        
        
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Buscar Socios y que cargue sus datos en los text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void _00600_ABM_Pago_Load(object sender, EventArgs e)
        {
            this.dtpFechaVencimiento.MinDate = DateTime.Today;
            var listaSocio = uowComun.DatoSocioRepositorio.ObtenerTodo().ToList();
           // this.cmbSocios.DataSource = listaSocio.ToList();
           // this.cmbSocios.DisplayMember = "Apellido";
           // this.cmbSocios.ValueMember = "Id";

            
            PoblarComboBox(this.cmbPromocion, uowComun.PromocionRepositorio.ObtenerTodo(), "Descripcion", "Id");
            PoblarComboBox(this.cmbMembresia, uowComun.MembresiaRepositorio.ObtenerTodo(), "Descripcion", "Id");
            PoblarComboBox(this.cmbAreaGimnasio, uowComun.AreaGimnasioRepositorio.ObtenerTodo(), "Descripcion", "id");

           // this.txtApellidoPago.Enabled = false;
           //
           // this.txtNombrePago.Enabled = false;
        }

        private void GuardarPago()
        {
            Pago nuevoPago = new Dominio.Caja.Entidades.Pago();
            Movimiento nuevoMovimiento = new Dominio.Caja.Entidades.Movimiento();
            PagoCuota nuevoPagoCuota = new PagoCuota();


            nuevoPago.FechaPago = DateTime.Today;
            nuevoPago.MembresiaId = Convert.ToInt32(this.cmbMembresia.SelectedValue);
            nuevoPago.PromocionId = Convert.ToInt32(this.cmbPromocion.SelectedValue);
            nuevoPago.SocioId = ctrlBuscarSocio.SocioId;
            nuevoPago.MembresiaNombre = this.cmbMembresia.Text;
            nuevoPago.FechaVencimiento = this.dtpFechaVencimiento.Value;
           // nuevoPago.Socio = this.cmbSocios.Text;
            nuevoPago.Monto = Convert.ToDecimal(this.txtPago.Text);
            nuevoPago.AreaGimnasioId = Convert.ToInt32(this.cmbAreaGimnasio.SelectedValue);

           // nuevoPago.Membresia.Id = Convert.ToInt32(cmbMembresia.SelectedValue);
           // nuevoPago.Promocion.Id = Convert.ToInt32(cmbPromocion.SelectedValue);
           // nuevoPago.ApellidoSocio.Id = ctrlBuscarSocio.SocioId;
           // nuevoPago.FechaVencimiento = this.dtpFechaVencimiento.Value;
            

            uowCaja.PagoRepositorio.Insertar(nuevoPago);

            uowCaja.Commit();


            nuevoMovimiento.Fecha = DateTime.Today;
            nuevoMovimiento.PagoId = this.pagoId;
            nuevoMovimiento.Ingreso = Convert.ToDecimal(this.txtPago.Text);



            uowCaja.MovimientoRepositorio.Insertar(nuevoMovimiento);
            uowCaja.Commit();

        }

        private void btnRealizarPago_Click(object sender, EventArgs e)
        {
            GuardarPago();
            MessageBox.Show("El pago se realizo Corrctamente");
            LimpiarDatosFormulario(pnlSocio);
        }
    }
}
