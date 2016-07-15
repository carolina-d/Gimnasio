using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConexion
{
    public static class Conexion
    {
        private static string _servidor = Configuracion.Default.Servidor;
        private static string _baseDatos = Configuracion.Default.BaseDatos;

        public static string NombreServidor
        {
            set { _servidor = value; }
        }

        public static string NombreBaseDatos
        {
            set { _baseDatos = value; }
        }

        public static string CadenaConexion
        {
            //get { return @"Data Source=" + _servidor + ";Initial Catalog=" + _baseDatos + ";User Id=cad;Password=cad;"; }
            get { return @"Data Source=" + _servidor + ";Initial Catalog=" + _baseDatos + ";Integrated Security=true"; }
        }
    }
}
