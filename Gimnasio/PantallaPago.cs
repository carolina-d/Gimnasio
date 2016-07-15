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
using DominioComun.UnidadDeTrabajo;
using InfraestructuraComun.Contexto;
using PresentacionPlantilla;
using PresentacionPlantilla.Properties;
using PresentacionPlantilla.Clases;
using Dominio.Caja.UnidadDeTrabajo;
using StructureMap;

namespace Gimnasio
{
    public partial class PantallaPago : FormularioBase
    {
        ContextoComun contextoComun = new ContextoComun();

        private int pagoId;
        private int empleadoId;
        private int socioId;

        List<DTO.DTOpago> listaPago;


        private readonly IUnidadDeTrabajoCaja uowCaja = ObjectFactory.GetInstance<IUnidadDeTrabajoCaja>();
        private readonly IUnidadDeTrabajoComun uowComun = ObjectFactory.GetInstance<IUnidadDeTrabajoComun>();



        public PantallaPago()
        {
            InitializeComponent();

            this.TituloVentana = "Pantalla Pagos";
            this.Titulo = "Gestión de Pagos";
            this.Leyenda = "Aquí podrá realizar el Pago de un socio";
        }

        private void PantallaPagos_Load(object sender, EventArgs e)
        {
            this.dtpFechaVencimiento.MinDate = DateTime.Today;
            var listaSocio = uowComun.DatoSocioRepositorio.ObtenerTodo().ToList();
            this.cmbSocios.DataSource = listaSocio.ToList();
            this.cmbSocios.DisplayMember = "Apellido";
            this.cmbSocios.ValueMember = "Id";




            PoblarComboBox(this.cmbPromocion, uowComun.PromocionRepositorio.ObtenerTodo(), "Descripcion", "Id");
            PoblarComboBox(this.cmbMembresia, uowComun.MembresiaRepositorio.ObtenerTodo(), "Descripcion", "Id");
            PoblarComboBox(this.cmbAreaGimnasio, uowComun.AreaGimnasioRepositorio.ObtenerTodo(), "Descripcion", "id");

            this.txtApellidoPago.Enabled = false;

            this.txtNombrePago.Enabled = false;
        }

        private void guardarPago()
        {
            Pago nuevoPago = new Dominio.Caja.Entidades.Pago();
            Movimiento nuevoMovimiento = new Dominio.Caja.Entidades.Movimiento();
            PagoCuota nuevoPagoCuota = new PagoCuota();

            nuevoPago.FechaPago = DateTime.Today;
            nuevoPago.MembresiaId = Convert.ToInt32(this.cmbMembresia.SelectedValue);
            nuevoPago.PromocionId = Convert.ToInt32(this.cmbPromocion.SelectedValue);
            nuevoPago.SocioId = Convert.ToInt32(this.cmbSocios.SelectedValue);
            nuevoPago.MembresiaNombre = this.cmbMembresia.Text;
            nuevoPago.FechaVencimiento = this.dtpFechaVencimiento.Value;
            nuevoPago.Socio = this.cmbSocios.Text;
            nuevoPago.Monto = Convert.ToDecimal(this.txtPago.Text);
            nuevoPago.AreaGimnasioId = Convert.ToInt32(this.cmbAreaGimnasio.SelectedValue);

            uowCaja.PagoRepositorio.Insertar(nuevoPago);

            uowCaja.Commit();


            nuevoMovimiento.Fecha = DateTime.Today;
            nuevoMovimiento.PagoId = this.pagoId;
            nuevoMovimiento.Ingreso = Convert.ToDecimal(this.txtPago.Text);



            uowCaja.MovimientoRepositorio.Insertar(nuevoMovimiento);
            uowCaja.Commit();
        }

        /// <summary>
        /// Guardar Pago
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            guardarPago();
           
        }

        private void PoblarCombopromocion()
        {

            var promocion = uowComun.PromocionRepositorio.ObtenerTodo().ToList();

            this.cmbPromocion.DataSource = promocion.ToList();

            this.cmbPromocion.DisplayMember = "Descripcion";
            this.cmbPromocion.ValueMember = "Id";
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (
               MessageBox.Show("¿Está seguro que desea guardar el pago", "ADVERTENCIA",
                   MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            guardarPago();
            MessageBox.Show("El pago fue guardado con exito");
            LimpiarCampos();
        }

        private void cmbSocios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbSocios.ValueMember = "Id";
            var resultad = uowComun.DatoSocioRepositorio.ObtenerPorId((long)this.cmbSocios.SelectedValue);
            this.txtApellidoPago.Text = resultad.Apellido;
            this.txtNombrePago.Text = resultad.Nombre;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            //ActualizarFechaVencimientoDOSMeses(this.txtFechaVencimiento.Text);
        }

      
        
        private void txtNombrePago_TextChanged(object sender, EventArgs e)
        {

        }

        public void AsignarMonto()
        {
            long promocionId = Convert.ToInt32(this.cmbPromocion.SelectedValue);

            var resultado = uowComun.PromocionRepositorio.ObtenerPorFiltro(x => x.Id == promocionId);


         }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var socio = new PresentacionComun._00201_Socio_ABM();
            socio.ShowDialog();
        }

        private void cmbPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {

            //var resultado = uowComun.DatosSocioRepositorio.ObtenerPorId(long.Parse(this.cmbPromocion.ValueMember), "Promocion");

            //this.txtPago.Text = resultado.Promocion.Precio.ToString();




        }

       

        private void LimpiarCampos()
        {
            this.txtApellidoPago.Clear();
            this.txtNombrePago.Clear();
            this.txtPago.Clear();
            this.cmbSocios.Focus();

        }

       

      
        
    }
}
