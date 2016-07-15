using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionBase
{
    public static class Mensaje
    {
        public static class Tipo
        {
            public const string Informacion = "Información";
            public const string Pregunta = "Pregunta";
            public const string Error = "Error";
            public const string Advertencia = "Advertencia";
            public const string Stop = "Error Grave";
        }


        public static DialogResult Mostrar(string mensaje, string tipoMensaje)
        {
            var resultado = new DialogResult();

            switch (tipoMensaje)
            {
                case Tipo.Informacion:
                    resultado = MessageBox.Show(mensaje, Tipo.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Tipo.Error:
                    resultado = MessageBox.Show(mensaje, Tipo.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Tipo.Pregunta:
                    resultado = MessageBox.Show(mensaje, Tipo.Pregunta, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
                case Tipo.Advertencia:
                    resultado = MessageBox.Show(mensaje, Tipo.Advertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Tipo.Stop:
                    resultado = MessageBox.Show(mensaje, Tipo.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
            }

            return resultado;
        }

        public static DialogResult Mostrar(Exception ex, string tipoMensaje)
        {
            var resultado = new DialogResult();

            switch (tipoMensaje)
            {
                case Tipo.Informacion:
                    resultado = MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, Tipo.Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Tipo.Error:
                    resultado = MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, Tipo.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Tipo.Pregunta:
                    resultado = MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, Tipo.Pregunta, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
                case Tipo.Advertencia:
                    resultado = MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, Tipo.Advertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Tipo.Stop:
                    resultado = MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, Tipo.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
            }

            return resultado;
        }
    }
}
