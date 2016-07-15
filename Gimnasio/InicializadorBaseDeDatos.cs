using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DominioComun.Entidades;

namespace Gimnasio
{
   public class InicializadorBaseDeDatos
    {
       public void Inicializar()
       {
           using (var contexto = new ContextoGlobal())
           {
               Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextoGlobal>());
               contexto.Database.Initialize(true);

           }

           InicializarMembresia();
           InicializadorPromcion();
           InicializadorAreaGimnasio();
           InicializarTipoRutina();
          // InicializarProductors();
           InicializarSocio();
          // InicializadorClase();

           //InicializarRutina();
       }

       public static void InicializadorClase()
       {
           var contexto = new InfraestructuraComun.Contexto.ContextoComun();
           var clase = new DominioComun.Entidades.Clase();
           var unidad = new InfraestructuraComun.UnidadDeTrabajo.UnidadDeTrabajoComun(contexto);

           var resultados = contexto.TIPOCLASE;

           if (resultados.Count() > 0)

               return;

           clase.Id = 1;
           clase.Codigo = "100";
           clase.Nombre = "Aerobic";
           clase.Precio = 150;

           unidad.TipoClaseRepositorio.Insertar(clase);
           unidad.Commit();

           new Clase();

           clase.Id = 2;
           clase.Codigo = "101";
           clase.Nombre = "Tae Bo";
           clase.Precio = 150;

           unidad.TipoClaseRepositorio.Insertar(clase);
           unidad.Commit();

           new Clase();

           clase.Id = 2;
           clase.Codigo = "102";
           clase.Nombre = "Spinning";
           clase.Precio = 200;

           unidad.TipoClaseRepositorio.Insertar(clase);
           unidad.Commit();


       }

       public static void InicializadorPromcion()
       {
           var contexto = new InfraestructuraComun.Contexto.ContextoComun();
           var promocion = new DominioComun.Entidades.Promocion();
           var unidad = new InfraestructuraComun.UnidadDeTrabajo.UnidadDeTrabajoComun(contexto);

           var resultado = contexto.PROMOCION;
           if (resultado.Count() > 0)
               return;
           promocion.Id = 1;
           promocion.Codigo = "1234";
           promocion.Descripcion = "Promocion UNO";

           unidad.PromocionRepositorio.Insertar(promocion);
           unidad.Commit();

           promocion = new Promocion();
           promocion.Id = 2;
           promocion.Codigo = "123";
           promocion.Descripcion = "Promocion DOS";
           unidad.PromocionRepositorio.Insertar(promocion);
           unidad.Commit();

       }

       public static void InicializadorAreaGimnasio()
       {
           var contexto = new InfraestructuraComun.Contexto.ContextoComun();
           var areaGimnasio = new DominioComun.Entidades.AreaGimnasio();
           var unidad = new InfraestructuraComun.UnidadDeTrabajo.UnidadDeTrabajoComun(contexto);

           var resultado = contexto.AREAGIMNASIO;
           if (resultado.Count() > 0)
               return;
           areaGimnasio.Id = 1;
           areaGimnasio.Codigo = 1234;
           areaGimnasio.Descripcion = "Salon Maquinas";
           unidad.AreaGimnasioRepositorio.Insertar(areaGimnasio);
           unidad.Commit();

           areaGimnasio = new AreaGimnasio();
           areaGimnasio.Id = 2;
           areaGimnasio.Codigo = 12342;
           areaGimnasio.Descripcion = "Salon Spinning";
           unidad.AreaGimnasioRepositorio.Insertar(areaGimnasio);
           unidad.Commit();




       }


       public static void InicializarSocio()
       {
           var contexto = new InfraestructuraComun.Contexto.ContextoComun();
           var socio = new DominioComun.Entidades.DatosSocio();
           var unidad = new InfraestructuraComun.UnidadDeTrabajo.UnidadDeTrabajoComun(contexto);

           var resultados = contexto.DATOSSOCIO;

           if (resultados.Count() > 0)

               return;

           socio.Id = 1;
           socio.Codigo = "100";
           socio.Nombre = "Bob";
           socio.Apellido = "Esponja";
           socio.Direccion = "Fondo de Bikini";
           socio.FechaNacimiento = DateTime.Today;
           socio.Telefono = "4229742";
           socio.Observacion = "Pantalones Cuadrados";
          

           unidad.DatoSocioRepositorio.Insertar(socio);
           unidad.Commit();

           socio = new DatosSocio();

           socio.Id = 2;
           socio.Codigo = "200";
           socio.Nombre = "Patricio";
           socio.Apellido = "Estrella";
           socio.Direccion = "Bajo una Piedra";
           socio.FechaNacimiento = DateTime.Today;
           socio.Telefono = "156101275";

           unidad.DatoSocioRepositorio.Insertar(socio);
           unidad.Commit();

           socio = new DatosSocio();

           socio.Id = 3;
           socio.Codigo = "300";
           socio.Nombre = "Carlos";
           socio.Apellido = "Gomez";
           socio.Direccion = "Balcarse 686";
           socio.FechaNacimiento = DateTime.Today;
           socio.Telefono = "156101275";

           unidad.DatoSocioRepositorio.Insertar(socio);
           unidad.Commit();


       }
       public static void InicializarMembresia()
       {
           var contexto = new InfraestructuraComun.Contexto.ContextoComun();
           var membresia = new DominioComun.Entidades.Membresia();
           var unidad = new InfraestructuraComun.UnidadDeTrabajo.UnidadDeTrabajoComun(contexto);

           var resultados = contexto.MEMBRESIA;

           if (resultados.Count() > 0)

               return;

           membresia.Codigo = "1";
           membresia.Descripcion = "Mensual";
           membresia.Nombre = "asdf";

           unidad.MembresiaRepositorio.Insertar(membresia);
           unidad.Commit();

           membresia = new Membresia();

       
       }

       public static void InicializarTipoRutina()
       {
           var contexto = new InfraestructuraComun.Contexto.ContextoComun();
           var TipoRutina = new DominioComun.Entidades.TipoRutina();
           var unidad = new InfraestructuraComun.UnidadDeTrabajo.UnidadDeTrabajoComun(contexto);

           var resultados = contexto.TIPORUTINA;

           if (resultados.Count() > 0)

               return;

           TipoRutina.Codigo = "100";
           TipoRutina.Descripcion = "Básica";
           

           unidad.TipoRutinaRepositorio.Insertar(TipoRutina);
           unidad.Commit();

           //segundo dato cargado
           TipoRutina = new TipoRutina();
           TipoRutina.Codigo = "200";
           TipoRutina.Descripcion = "Intermedia";


           unidad.TipoRutinaRepositorio.Insertar(TipoRutina);
           unidad.Commit();

           //Tercer dato cargado
           TipoRutina = new TipoRutina();
           TipoRutina.Codigo = "300";
           TipoRutina.Descripcion = "Avanzada";


           unidad.TipoRutinaRepositorio.Insertar(TipoRutina);
           unidad.Commit();


       }

     /*  public static void InicializarRutina()
       {
           var contexto = new InfraestructuraComun.Contexto.ContextoComun();
           var Rutina = new DominioComun.Entidades.Rutina();
           var unidad = new InfraestructuraComun.UnidadDeTrabajo.UnidadDeTrabajoComun(contexto);

           var resultados = contexto.RUTINA;

           if (resultados.Count() > 0)

               return;

           Rutina.Nombre = "Musculación";
           Rutina.Descripcion = "Levantamiento de Pesas, Adominales, Pecho Plano";
           Rutina.Dias = "Lunes, Miercoles y Viernes";
           Rutina.Repeticiones = 100;
           Rutina.Series = 5;
           Rutina.TipoRutinaId = 1;
          


           unidad.RutinaRepositorio.Insertar(Rutina);
           unidad.Commit();*/

       public static void InicializarProductors()
       {
           var contexto = new Infraestructura.Producto.Contexto.ContextoProducto();
           var producto = new Dominio.Producto.Entidades.Producto();
           var unidad = new Infraestructura.Producto.UnidadDeTrabajo.UnidadDeTrabajoProducto(contexto);

           var resultados = contexto.PRODUCTO;
          // if (resultados.Count() > 0)
          //
          //     return;

           producto.Codigo = 123;
           producto.Descripcion = "Coca Cola";
           producto.PrecioUnitario = 20;
           producto.Stock = 100;
           unidad.ProductoRepositorio.Insertar(producto);
           unidad.Commit();



       }


       }

    }



