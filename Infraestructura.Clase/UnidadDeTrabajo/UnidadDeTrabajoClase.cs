using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Clase.Entidades;
using Dominio.Clase.UnidadDeTrabajo;
using DominioBase.Repositorios;
using Infraestructura.Clase.Contexto;
using InfraestructuraBase.Repositorios;

namespace Infraestructura.Clase.UnidadDeTrabajo
{
    public class UnidadDeTrabajoClase : IUnidadDeTrabajoClase
    {

        private readonly ContextoClase _contexto;

        public UnidadDeTrabajoClase(ContextoClase contexto)
        {
            _contexto = contexto;
        }



        public void Commit()
        {
            _contexto.SaveChanges();

        }

        public void Disposed()
        {
            _contexto.Dispose();
        }
    }
}
