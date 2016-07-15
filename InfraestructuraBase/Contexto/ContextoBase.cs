using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionConexion;


namespace InfraestructuraBase.Contexto
{
    public class ContextoBase : DbContext, IContextoBase
    {
        public ContextoBase()
            : base(Conexion.CadenaConexion)
        {
            /* Desactiva la Carga diferida de manera predetermnada*/
            base.Configuration.LazyLoadingEnabled = false;

            /* Desactiva el Auto Detectar los cambios en la BD. Es se hace ya que se esta
               trabajando con DataBase First mezclado con CodFirst*/
            base.Configuration.AutoDetectChangesEnabled = true;
        }

        public int ExecuteSqlCommand(string sqlCommand, params object[] param)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, param);
        }

        protected override void OnModelCreating(DbModelBuilder constructor)
        {
            constructor.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
