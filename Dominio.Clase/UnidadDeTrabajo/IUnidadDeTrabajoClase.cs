using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Clase.Entidades;
using DominioBase.Repositorios;

namespace Dominio.Clase.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajoClase
    {
     

        void Commit();
        void Disposed();


    }
}
