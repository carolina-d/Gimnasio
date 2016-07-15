using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSpinning.Entidades
{
    class Constantes
    {
        public static class TipoMensajeError
        {
            public const string Error = "Error: ";
            public const string Advertencia = "Advertencia: ";
            public const string Informacion = "Información: ";
            public const string Pregunta = "Pregunta: ";
        }

        public static class TipoOperacion
        {
            public const string Nuevo = "Nuevo";
            public const string Modificar = "Modificar";
            public const string Eliminar = "Eliminar";
            public const string Actualizar = "Actualizar";
            public const string Imprimir = "Imprimir";
            public const string Obtener = "Obtener";
        }
    }
}
