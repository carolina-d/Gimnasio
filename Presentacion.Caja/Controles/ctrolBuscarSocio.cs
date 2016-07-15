using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.Comun;
using DominioComun.UnidadDeTrabajo;
using PresentacionComun;

namespace Presentacion.Caja.Controles
{
    public partial class ctrolBuscarSocio : UserControl
    {

        private readonly IUnidadDeTrabajoComun _socioUow;
        private long? socioId;

        public long SocioId
        {
            get { return socioId.HasValue ? socioId.Value : - 0; }
        }


        public ctrolBuscarSocio(IUnidadDeTrabajoComun socioComun)
        {
            InitializeComponent();
            _socioUow = socioComun;
        }

        private void btnBuscarSocio_Click(object sender, EventArgs e)
        {
            //id distinto de 1 porque ese es consumidor final
            var resultado = _socioUow.DatoSocioRepositorio.ObtenerPorFiltro(x =>
                (x.Direccion.Contains(this.txtDomicilio.Text)
                 || x.Telefono.Contains(this.txtTelefono.Text)
                 || x.Apellido.Contains(this.txtApyNom.Text)));

            // Pregunta si la consulta obtuvo datos
            if (resultado != null && resultado.Count() > 0)
            {

                BuscarSocio buscarSocio = new BuscarSocio(resultado.ToList());
                
                // abre el formulario
                buscarSocio.ShowDialog();

                // si el cliente seleccionado e distinto de NUll
                if (buscarSocio.Socio != null)
                {
                    // asigna los datos a los text
                    AsignarDatosSocio(buscarSocio.Socio);
                }
            }
            else
            {
                //  En el caso de obtener 1 solo registro asigna los datos
                AsignarDatosSocio(resultado.Select(x => new SocioDTO()
                {
                    Id = x.Id,
                    ApyNombre = x.Apellido + " " + x.Nombre,
                    Telefono = x.Telefono,
                    Domicilio = x.Direccion
                }).First());
            }
        }


         private void AsignarDatosSocio(SocioDTO socio)
        {
            // asignacion de datos
            this.txtTelefono.Text = socio.Telefono;
             this.txtApyNom.Text = socio.ApyNombre;
             this.txtDomicilio.Text = socio.Domicilio;
             this.socioId = socio.Id;

        }

         private void btnBuscarSocio_Click_1(object sender, EventArgs e)
         {
             //id distinto de 1 porque ese es consumidor final
             var resultado = _socioUow.DatoSocioRepositorio.ObtenerPorFiltro(x =>
                 (x.Direccion.Contains(this.txtDomicilio.Text)
                  || x.Telefono.Contains(this.txtTelefono.Text)
                  || x.Apellido.Contains(this.txtApyNom.Text)));

             // Pregunta si la consulta obtuvo datos
             if (resultado != null && resultado.Count() > 0)
             {

                 BuscarSocio buscarSocio = new BuscarSocio(resultado.ToList());

                 // abre el formulario
                 buscarSocio.ShowDialog();

                 // si el cliente seleccionado e distinto de NUll
                 if (buscarSocio.Socio != null)
                 {
                     // asigna los datos a los text
                     AsignarDatosSocio(buscarSocio.Socio);
                 }
             }
             else
             {
                 //  En el caso de obtener 1 solo registro asigna los datos
                 AsignarDatosSocio(resultado.Select(x => new SocioDTO()
                 {
                     Id = x.Id,
                     ApyNombre = x.Apellido + " " + x.Nombre,
                     Telefono = x.Telefono,
                     Domicilio = x.Direccion
                 }).First());
             }
         }

    }
}
