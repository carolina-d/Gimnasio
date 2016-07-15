using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Caja.UnidadDeTrabajo;
using PresentacionPlantilla;
using StructureMap;

namespace Gimnasio
{
    public partial class ConsultaPagos : FormularioBase
    {
        Dominio.Caja.Entidades.Pago pago = new Dominio.Caja.Entidades.Pago();

        private readonly Dominio.Caja.UnidadDeTrabajo.IUnidadDeTrabajoCaja uowConsultaPagos = ObjectFactory.GetInstance<IUnidadDeTrabajoCaja>();

        //variable que me obtiene la fecha del dia de hoy
        private DateTime Hoy = DateTime.Today;


    
        public ConsultaPagos()
        {
            InitializeComponent();

            this.TituloVentana = "Consulta de Pagos";
            this.Titulo = "Consulta de Pagos";
            this.Leyenda = "Consultar Pagos Realizdos";

            

        }

        private void PoblarGrillaPagos()
        {
            var resultado = uowConsultaPagos.PagoRepositorio.ObtenerTodo().Select(x => new DTO.DTOConsultaPago
            {

                Id = x.Id.ToString(),
                Socio = x.Socio,
                Membresia = x.MembresiaNombre,
                Monto = x.Monto.ToString(),
                FechaPago = x.FechaPago.ToString(),
                FechaVencimiento = x.FechaVencimiento.ToString()



            }).ToList();

            this.dgvConsultaPago.DataSource = resultado;

        }

        private void ConsultaPagos_Load(object sender, EventArgs e)
        {
            PoblarGrillaPagos();
            //MarcarVencimiento();
            CalcularVencimiento();
            this.dgvConsultaPago.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvConsultaPago_RowPrePaint);
            
           
           
        }
         

        private void MarcarVencimiento()
        {
            var listaPago = uowConsultaPagos.PagoRepositorio.ObtenerTodo().ToList();

            foreach (var item in listaPago)
            {
                if (item.FechaVencimiento != DateTime.Today)
                {
                    
                }
                else
                {
                    this.dgvConsultaPago.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
                }

            }

        

        }

        private void BuscarPago()
        {
            var resultado = uowConsultaPagos.PagoRepositorio.ObtenerPorFiltro(x => x.Socio.Contains(txtBusquedaConsultaPago.Text)).ToList();
            this.dgvConsultaPago.DataSource = resultado.Select(x => new DTO.DTOConsultaPago
            {
                Id = x.Id.ToString(),
                Socio = x.Socio,
                Membresia = x.MembresiaNombre,
                Monto = x.Monto.ToString(),
                FechaPago = x.FechaPago.ToString(),
                FechaVencimiento = x.FechaVencimiento.ToString()


            }).ToList();

        }

        private void btnBuscarConsultaPago_Click(object sender, EventArgs e)
        {
            BuscarPago();
        }

        public void CalcularVencimiento()
        {
            foreach (DataGridViewRow vencimiento in dgvConsultaPago.Rows)
            {
                //obtengo el valor de la fecha de vencimiento 
                var Fechavencimiento = vencimiento.Cells["FechaVencimiento"].Value;

                //y lo comparo con la fecha del dia
                if (Convert.ToDateTime(Fechavencimiento) <= DateTime.Today)
                {
                    vencimiento.DefaultCellStyle.BackColor = Color.Red;
                    

                }
                else
                {

                    vencimiento.DefaultCellStyle.BackColor = Color.Green;

                }

            }
        }

        private void dgvConsultaPago_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var listaPago = uowConsultaPagos.PagoRepositorio.ObtenerTodo().ToList();

            foreach (var item in listaPago)
            {
                if (item.FechaVencimiento != DateTime.Today)
                {
                    

                }
                else
                {
                    this.dgvConsultaPago.AlternatingRowsDefaultCellStyle.BackColor = Color.Green;
                }

            }
        }

        private void dgvConsultaPago_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtBusquedaConsultaPago_TextChanged(object sender, EventArgs e)
        {

        }

       
        }

      

       
    }

