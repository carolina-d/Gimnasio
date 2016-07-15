using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AplicacionSeguridad.Clases;
using DominioBase.Clases;
using DominioSeguridad.Entidades;
using DominioSeguridad.UnidadDeTrabajo;
using StructureMap;
using Encriptar = DominioBase.Clases.Encriptar;

namespace ServicioSeguridad.ServicioUsuario
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly ISeguridadUnidadDeTrabajo seguridadUoW;

        public UsuarioServicio(ISeguridadUnidadDeTrabajo _seguridadUoW)
        {
            this.seguridadUoW = _seguridadUoW;
        }

        public bool CrearUsuario(List<long> _listaIds)
        {
            var seCreoAlgunUsuario = false;
            var ocurrioUnError = false;

            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (var Id in _listaIds)
                    {
                        var empleado = seguridadUoW.EmpleadoRepositorio.ObtenerPorId(Id);

                        if (empleado == null)
                        {
                            ocurrioUnError = true;
                            break;
                        }

                        var usuarioNuevo = ObtenerUsuario(empleado);
                        seguridadUoW.UsuarioRepositorio.Insertar(usuarioNuevo);
                        seguridadUoW.Commit();
                        seCreoAlgunUsuario = true;
                    }

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();
                    throw new Exception("Ocurrio un error al crear los usuarios");
                }
            }

            return !ocurrioUnError && seCreoAlgunUsuario;
        }

        public bool BloquearUsuario(List<long> _listaIds)
        {
            var seBloqueoAlgunUsuario = false;
            var ocurrioUnError = false;

            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (var Id in _listaIds)
                    {
                        var usuario = seguridadUoW.UsuarioRepositorio.ObtenerPorId(Id);

                        if (usuario == null)
                        {
                            ocurrioUnError = true;
                            break;
                        }

                        usuario.EstaBloqueado = !usuario.EstaBloqueado;

                        seguridadUoW.UsuarioRepositorio.Modificar(usuario);
                        seguridadUoW.Commit();
                        seBloqueoAlgunUsuario = true;
                    }

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();
                    throw new Exception("Ocurrio un error al bloquear los usuarios");
                }
            }

            return !ocurrioUnError && seBloqueoAlgunUsuario;
        }

        public bool ReiniciarPassword(List<long> _listaIds)
        {
            var seReseteoAlgunUsuario = false;
            var ocurrioUnError = false;

            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (var Id in _listaIds)
                    {
                        var usuario = seguridadUoW.UsuarioRepositorio.ObtenerPorId(Id);

                        if (usuario == null)
                        {
                            ocurrioUnError = true;
                            break;
                        }

                        usuario.Password = Encriptar.EncriptarCadena(Constante.Seguridad.PasswordPorDefecto);

                        seguridadUoW.UsuarioRepositorio.Modificar(usuario);
                        seguridadUoW.Commit();
                        seReseteoAlgunUsuario = true;
                    }

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();
                    throw new Exception("Ocurrio un error al bloquear los usuarios");
                }
            }

            return !ocurrioUnError && seReseteoAlgunUsuario;
        }

        public bool VerificarSiEstaBloqueado(string usuarioLogin, string password)
        {
            var passwrodEncriptado = Encriptar.EncriptarCadena(password);

            return seguridadUoW.UsuarioRepositorio.ObtenerPorFiltro(x => x.Nombre == usuarioLogin
                                                                         && x.Password == passwrodEncriptado
                                                                         && x.EstaBloqueado).Any();
        }

        #region Metodos Privados

        private Usuario ObtenerUsuario(Empleado empleado)
        {
            var nombre = ObtenerNombreUsuario(empleado.Apellido, empleado.Nombre);

            var usuarioNuevo = ObjectFactory.GetInstance<Usuario>();

            usuarioNuevo.EstaBloqueado = false;
            usuarioNuevo.Nombre = nombre;
            usuarioNuevo.Password = Encriptar.EncriptarCadena(Constante.Seguridad.PasswordPorDefecto);
            usuarioNuevo.EmpleadoId = empleado.Id;

            return usuarioNuevo;
        }

        private string ObtenerNombreUsuario(string apellido, string nombre)
        {
            var contadorLetras = 1;
            var nombreUsuario = (nombre.Trim().Substring(0, contadorLetras) + apellido.Trim()).ToUpper();

            while (seguridadUoW.UsuarioRepositorio.ObtenerPorFiltro(x => x.Nombre.Equals(nombreUsuario)).Any())
            {
                contadorLetras++;
                nombreUsuario = (nombre.Trim().Substring(0, contadorLetras) + apellido.Trim()).ToUpper();
            }

            return nombreUsuario.ToUpper();
        }

        #endregion
    }
}
