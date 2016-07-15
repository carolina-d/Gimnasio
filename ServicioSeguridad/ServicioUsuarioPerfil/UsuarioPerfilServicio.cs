using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DominioSeguridad.UnidadDeTrabajo;
using ServicioSeguridad.DTOs;

namespace ServicioSeguridad.ServicioUsuarioPerfil
{
    public class UsuarioPerfilServicio : IUsuarioPerfilServicio
    {
        private readonly ISeguridadUnidadDeTrabajo _uowSeguridad;

        public UsuarioPerfilServicio(ISeguridadUnidadDeTrabajo uowSeguridad)
        {
            this._uowSeguridad = uowSeguridad;
        }

        public void VincularUsuarioPerfil(List<long> listaIdUsuario, long perfilId)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    var perfil = _uowSeguridad.PerfilRepositorio.ObtenerPorId(perfilId, "Usuarios");

                    foreach (var id in listaIdUsuario)
                    {
                        var usuario = _uowSeguridad.UsuarioRepositorio.ObtenerPorId(id);

                        perfil.Usuarios.Add(usuario);
                    }

                    _uowSeguridad.Commit();

                    tran.Complete();
                }
                catch (Exception)
                {
                    tran.Dispose();
                    throw new Exception("Ocurrió un error al vincular un Usuario a al Perfil");
                }
            }
        }

        public void DesvincularUsuarioPerfil(List<long> listaIdUsuario, long perfilId)
        {
             using (var tran = new TransactionScope())
            {
                try
                {
                    var perfil = _uowSeguridad.PerfilRepositorio.ObtenerPorId(perfilId, "Usuarios");

                    foreach (var id in listaIdUsuario)
                    {
                        var usuario = _uowSeguridad.UsuarioRepositorio.ObtenerPorId(id);

                        perfil.Usuarios.Remove(usuario);
                    }

                    _uowSeguridad.Commit();

                    tran.Complete();
                }
                catch (Exception)
                {
                    tran.Dispose();

                    throw new Exception("Ocurrió un error al Desvincular un Usuario a al Perfil");
                }
            }
        }
        
        public IEnumerable<UsuarioDTO> MostrarUsuariosNoAsignados(long perfilId, string cadena)
        {
            var perfil = _uowSeguridad.PerfilRepositorio.ObtenerPorId(perfilId, "Usuarios, Usuarios.Empleado");

            if (perfil != null)
            {
                var usuarios = _uowSeguridad.UsuarioRepositorio.ObtenerTodo("Empleado")
                    .Except(perfil.Usuarios).Where(x => x.Nombre.Contains(cadena));

                return usuarios.Select(x => new UsuarioDTO()
                {
                    Id = x.Id,
                    EmpleadoId = x.EmpleadoId,
                    ApyNom = x.Empleado.ApyNom,
                    Usuario = x.Nombre,
                    EstaBloqueado = x.EstaBloqueado ? "SI" : "NO"
                }).ToList();
            }
            else
            {
                return _uowSeguridad.UsuarioRepositorio.ObtenerPorFiltro(x => x.Id.Equals(-1), "Empleado")
                    .Select(x => new UsuarioDTO()
                    {
                        Id = x.Id,
                        EmpleadoId = x.EmpleadoId,
                        ApyNom = x.Empleado.ApyNom,
                        Usuario = x.Nombre,
                        EstaBloqueado = x.EstaBloqueado ? "SI" : "NO"
                    }).ToList();
            }
        }

        public IEnumerable<UsuarioDTO> MostrarUsuariosAsignados(long perfilId, string cadena)
        {
            var perfil = _uowSeguridad.PerfilRepositorio.ObtenerPorId(perfilId, "Usuarios, Usuarios.Empleado");

            if (perfil != null)
            {
                var resultado = perfil.Usuarios.Where(x => x.Nombre.Contains(cadena));

                return resultado.Select(x => new UsuarioDTO()
                {
                    Id = x.Id,
                    EmpleadoId = x.EmpleadoId,
                    ApyNom = x.Empleado.ApyNom,
                    Usuario = x.Nombre,
                    EstaBloqueado = x.EstaBloqueado ? "SI" : "NO"
                }).ToList();
            }
            else
            {
                return _uowSeguridad.UsuarioRepositorio
                    .ObtenerPorFiltro(x => x.Id.Equals(-1), "Empleado").Select(x => new UsuarioDTO()
                    {
                        Id = x.Id,
                        EmpleadoId = x.EmpleadoId,
                        ApyNom = x.Empleado.ApyNom,
                        Usuario = x.Nombre,
                        EstaBloqueado =
                            x.EstaBloqueado ? "SI" : "NO"
                    }).ToList();
            }
        }
    }
}

