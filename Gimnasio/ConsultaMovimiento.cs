using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio.Caja.UnidadDeTrabajo;
using StructureMap;

namespace Gimnasio
{
    public partial class ConsultaMovimiento : PresentacionPlantilla.FormularioBase
    {


        Dominio.Caja.Entidades.Movimiento movimiento = new Dominio.Caja.Entidades.Movimiento();

        private readonly Dominio.Caja.UnidadDeTrabajo.IUnidadDeTrabajoCaja uowConsultaPagos = ObjectFactory.GetInstance<IUnidadDeTrabajoCaja>();

        public ConsultaMovimiento()
        {
            InitializeComponent();
        }

        public void PoblarGrillaMovimiento()
        {
            //Aca necesito mostrar el total (ingreso menos egreso)

            var resultado = uowConsultaPagos.MovimientoRepositorio.ObtenerTodo().Select(x => new DTO.DTOMovimiento
            {
                Fecha = x.Fecha.ToShortDateString(),
                Ingreso = x.Ingreso,
                Egreso = x.Egreso
                //Total = x.Total.ToString()

            }).ToList();
            this.dataGridView1.DataSource = resultado.ToList();
            this.CalcularTotal(resultado);
        }

        private void ConsultaMovimiento_Load(object sender, EventArgs e)
        {
            PoblarGrillaMovimiento();
            FormatearGrilla();
        }



        private void BuscarPorFecha()
        {
            //obviamente debe haber una forma mas facil, pero bue
            var fechita = this.dateTimePicker1.Value;
            var resultado = uowConsultaPagos.MovimientoRepositorio
                //.ObtenerPorFiltro(x => x.Fecha.Equals(this.dateTimePicker1.Value))
                .ObtenerPorFiltro(x => x.Fecha.Day == fechita.Day
                    && x.Fecha.Month == fechita.Month
                    && x.Fecha.Year == fechita.Year
                    )
                .Select(x => new DTO.DTOMovimiento
                {

                    Fecha = x.Fecha.ToString(),
                    Ingreso = x.Ingreso,
                    Egreso = x.Egreso
                    //Total = x.Total.ToString()

                }).ToList();

            this.dataGridView1.DataSource = resultado.ToList();

            CalcularTotal(resultado);
        }

        private void CalcularTotal(List<DTO.DTOMovimiento> resultado)
        {
            this.nudTotal.Maximum = decimal.MaxValue;
            if (resultado.Any())
            {
                this.nudTotal.Value = resultado.Sum(x => x.Ingreso) - resultado.Sum(x => x.Egreso);
            }
            else
            {
                this.nudTotal.Value = 0;
            }
        }

        private void FormatearGrilla()
        {

            this.dataGridView1.Columns["Fecha"].Visible = true;
            this.dataGridView1.Columns["Fecha"].HeaderText = "Fecha";
            this.dataGridView1.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView1.Columns["Ingreso"].Visible = true;
            this.dataGridView1.Columns["Ingreso"].HeaderText = "Ingreso";
            this.dataGridView1.Columns["Ingreso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns["Ingreso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView1.Columns["Egreso"].Visible = true;
            this.dataGridView1.Columns["Egreso"].HeaderText = "Egreso";
            this.dataGridView1.Columns["Egreso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns["Egreso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            PoblarGrillaMovimiento();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            BuscarPorFecha();
        }

        private void ConsultaMovimiento_Load_1(object sender, EventArgs e)
        {
            PoblarGrillaMovimiento();
            FormatearGrilla();
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            BuscarPorFecha();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PoblarGrillaMovimiento();

        }
    }
}
