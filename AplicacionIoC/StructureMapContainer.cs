using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Caja.UnidadDeTrabajo;
using Dominio.Producto.UnidadDeTrabajo;
using DominioBase.Repositorios;
using DominioComun.UnidadDeTrabajo;
using DominioSeguridad.UnidadDeTrabajo;
using Infraestructura.Producto.UnidadDeTrabajo;
using InfraestructuraBase.Repositorios;
using InfraestructuraComun.Contexto;
using InfraestructuraComun.UnidadDeTrabajo;
using InfraestructuraSeguridad.Contexto;
using InfraestructuraSeguridad.UnidadDeTrabajo;
using ServicioSeguridad.ServicioFormulario;
using ServicioSeguridad.ServicioFormularioPerfil;
using ServicioSeguridad.ServicioSeguridad;
using ServicioSeguridad.ServicioUsuario;
using ServicioSeguridad.ServicioUsuarioPerfil;
using ServicioSeguridad.UnidadDeTrabajo;
using StructureMap;
using Dominio.Producto.Entidades;
using Infraestructura.Producto.Contexto;
using DominioSpinning.UnidadDeTrabajo;
using InfraestructuraSpnning.Contexto;
using InfraestructuraSpnning.UnidadDeTrabajo;
using Infraestructura.Caja.UnidadDeTrabajo;

namespace AplicacionIoC
{
    public class StructureMapContainer
    {
        /// <summary>
        /// Configure
        /// </summary>
        public void Configure()
        {
            ObjectFactory.Configure(x =>
            {
                x.Scan(scan =>
                {
                    // Automatically maps interface IXyz to class Xyz
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.ConnectImplementationsToTypesClosing(typeof (IRepositorio<>));
                    scan.Assembly(GetType().Assembly);
                });

                x.For(typeof (IRepositorio<>)).Use(typeof (Repositorio<>));
                x.ForSingletonOf<DbContext>().HybridHttpOrThreadLocalScoped();

                // Seguridad
                x.For<IContextoSeguridad>().Use<ContextoSeguridad>();
                x.For<ISeguridadUnidadDeTrabajo>().Use<SeguridadUnidadDeTrabajo>();
                x.For<IServicioSeguridadUnidadDeTrabajo>().Use<ServicioSeguridadUnidadDeTrabajo>();
                x.For<ISeguridadServicio>().Use<SeguridadServicio>();
                x.For<IUsuarioServicio>().Use<UsuarioServicio>();
                x.For<IFormularioServicio>().Use<FormularioServicio>();
                x.For<IUsuarioPerfilServicio>().Use<UsuarioPerfilServicio>();
                x.For<IFormularioPerfilServicio>().Use<FormularioPerfilServicio>();

                //comun
                x.For<IContextoComun>().Use<ContextoComun>();
                x.For<IUnidadDeTrabajoComun>().Use<UnidadDeTrabajoComun>();

                //caja
                x.For<Infraestructura.Caja.Contexto.IConextoCaja>().Use<Infraestructura.Caja.Contexto.ContextoCaja>();
                x.For<IUnidadDeTrabajoCaja>().Use<UnidadDeTrabajoCaja>();

                //Producto
                x.For<IContextoProducto>().Use<ContextoProducto>();
                x.For<IUnidadDeTabajoProducto>().Use<UnidadDeTrabajoProducto>();

                //Spinning
                x.For<IContextoSpinning>().Use<ContextoSpinning>();
                x.For<IUnidadDeTrabajoSpinning>().Use<UnidadDeTrabajoSpnning>();

                //Ejemplo de como declarar las propiedades en StructureMap
                //x.SetAllProperties(p => p.OfType<Repository<Expedientes>>());
            });
        }
    }
}
