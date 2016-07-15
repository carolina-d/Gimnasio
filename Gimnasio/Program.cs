using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicacionIoC;
using Gimnasio.IoC;
using StructureMap;

namespace Gimnasio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InicializadorInyectorDependencia();

            var iniciarBase = new InicializadorBaseDeDatos();
            iniciarBase.Inicializar();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           // var pago = new PantallaPago();
            //pago.ShowDialog();

            ObjectFactory.GetInstance<Principal>().ShowDialog();
        }

        private static void InicializadorInyectorDependencia()
        {
            var ioc = new StructureMapContainer();

            ioc.Configure();

            new StructureMapDependencyResolver(ObjectFactory.Container);
            new StructureMapFilterProvider(ObjectFactory.Container);
        }
    }
}
