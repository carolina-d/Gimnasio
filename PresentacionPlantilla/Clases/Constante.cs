using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentacionPlantilla;

namespace PresentacionBase
{
    public static class Constante
    {


        public static class Seguridad
        {
            public const string UsuarioAdmin = "ADMIN";
            public const string PasswordAdmin = "P$assword";
        }

        public static class TipoMensaje
        {
            public const string Error = "Error";
            public const string Advertencia = "Advertencia";
            public const string Informacion = "Información";
            public const string Pregunta = "Pregunta";
            public const string Stop = "Error Grave";
        }

        public static class Mensaje
        {
            public const string DatoObligatorio = "Campo Obligatorio";
            public const string NoHayDatosCargados = "No Hay Datos Cargados";
        }

        public static class TipoOperacion
        {
            public const string Nuevo = "Nuevo";
            public const string Modificar = "Modificar";
            public const string Eliminar = "Eliminar";
            public const string Imprimir = "Imprimir";
        }

        public static class ColorControl
        {
            public static Color ColorTitulo = Color.SteelBlue;
            public static Color ColorTituloBusqueda = Color.SteelBlue;
            public static Color ColorConFoco = Color.Beige;
            public static Color ColorSinFoco = Color.White;
        }

    

        public static class Validacion
        {
            public static void DatoExistente(TextBox txt, ErrorProvider error, string mensajeMostrar)
            {
               error.Icon = Recursos.info;
               error.SetError(txt, mensajeMostrar);

                
            }

            public static void DatoExistenteCmb(ComboBox cmb, ErrorProvider error, string mensajeMostrar)
            {
                error.Icon = Recursos.info;           
                error.SetError(cmb, mensajeMostrar);
               // error.UpdateBinding();

                error.Clear();
                
            }

            public static void DatoExistenteNum(NumericUpDown num, ErrorProvider error, string mensajeMostrar)
            {
                error.Icon = Recursos.info;
                error.SetError(num, mensajeMostrar);
                error.UpdateBinding();
                
                error.Clear();
            }


        }

        public static class DiasDeLaSemana
        {

            public const string Lunes = "Lunes";
            public const int CodigoLunes = 1;

            public const string Martes = "Martes";
            public const int CodigoMartes = 2;

            public const string Miercoles = "Miercoles";
            public const int CodigoMiercoles = 3;

            public const string Jueves = "Jueves";
            public const int CodigoJueves = 4;

            public const string Viernes = "Viernes";
            public const int CodigoViernes = 5;

            public const string Sabado = "Sabado";
            public const int CodigoSabado = 6;

            public const string Domingo = "Domingo";
            public const int CodigoDomingo = 7;

            public static List<string> ListaDias = new List<string>
            {
                Lunes,
                Martes,
                Miercoles,
                Jueves,
                Viernes,
                Sabado,
                Domingo
            };

            public static Dictionary<int, string> TipoDias = new Dictionary<int, string>()
            {
                {CodigoLunes, Lunes},
                {CodigoMartes, Martes},
                {CodigoMiercoles, Miercoles},
                {CodigoJueves, Jueves},
                {CodigoViernes, Viernes},
                {CodigoSabado, Sabado},
                {CodigoDomingo, Domingo}
            };
        }
    }

}
    



