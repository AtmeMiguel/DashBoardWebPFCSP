using appCalidad.Infraestructura.Datos.Repository;
//using appCalidad.Presentacion.WebPage.Controllers.JWT;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using System.Web.Security;

namespace appCalidad.Presentacion.WebPage.Controllers.API
{
    [Authorize]
    //[RoutePrefix("api/Usuarios")]
    //[Route("api/Usuarios")]
    public class UsuarioController : ApiController
    {
        private DUsuarioHandlers Usuarios;
        public UsuarioController()
        {
            Usuarios = new DUsuarioHandlers();
        }


        /// <summary>
        /// autenticar usuario pagos plan familiar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [AllowAnonymous]
        //[Route("Verificar")]
        [Route("api/Usuarios/VerificarUsuarioPagPF")]
        [HttpPost]
        public AccessResponses VerificarUsuariosPagosPF(AccessRequest usuario)
        {
            AccessResponses Nuevo = new AccessResponses();
            Nuevo = Usuarios.VerificarUsuarioPagosPF(usuario);
            return Nuevo;
            //bool isCredencialValid = true;
            //if (isCredencialValid)
            //{
            //    AccessResponses Nuevo = Usuarios.VerificarUsuarioPagosPF(usuario);
            //    if (Nuevo.RESULTADO == "CORRECTO")
            //    {

            //        var identity = Thread.CurrentPrincipal.Identity;
            //        FormsAuthentication.SetAuthCookie(usuario.USUARIO, false);
            //        return Nuevo;
            //    }
            //    else
            //    {
            //        FormsAuthentication.SignOut();
            //        return null;
            //    }

            //}
            //else
            //{
            //    return Usuarios.VerificarUsuario(usuario);

            //}
        }

        /// <summary>
        /// Metodo encargado de realizar la autenticación
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [AllowAnonymous]
        //[Route("Verificar")]
        [Route("api/Usuarios/Verificar")]
        [HttpPost]
        public AccessResponses Verificar(AccessRequest usuario)
        {
            bool isCredencialValid = true;
            if (isCredencialValid)
            {
                AccessResponses Nuevo = Usuarios.VerificarUsuario(usuario);
                if (Nuevo.RESULTADO == "CORRECTO")
                {
                    //var token = TokenGenerator.GenerateTokenJwt(usuario.USUARIO);
                    //Nuevo.ACCESS_TOKEN = token;

                    var identity = Thread.CurrentPrincipal.Identity;                 
                    FormsAuthentication.SetAuthCookie(usuario.USUARIO, false);
                    return Nuevo;
                }
                else
                {
                    FormsAuthentication.SignOut();
                    return null;
                }
                //return Usuarios.VerificarUsuario(usuario);
                //return Ok(token);
            }
            else
            {
                return Usuarios.VerificarUsuario(usuario);
                //return Unauthorized();
            }
        }
        [AllowAnonymous]
        //[Route("Salir")]
        [Route("api/Usuarios/Salir")]
        [HttpPost]
        public AccessResponses Salir(AccessRequest usuario)
        {
            FormsAuthentication.SignOut();
            return null;
        }

        //[Authorize]
        //[Route("ListarRolesxUsuario")]
        [Route("api/Usuarios/ListarRolesxUsuario")]
        [HttpPost]
        public List<RolResponses> ListarRolesxUsuario(AccessRequest usuario)
        {
            return Usuarios.ListarRolesxUsuario(usuario);
        }

        //[Authorize]
        [Route("api/Usuarios/ListarModulosxRol")]
        [HttpPost]
        public List<RolResponses> ListarModulosxRol(AccessRequest usuario)
        {
            return Usuarios.ListarModulosxRol(usuario);
        }

        [Route("api/Usuarios/ListarUsuarios")]
        [HttpPost]
        public List<UsuarioResponses> ListarUsuarios(TRequest usuario)
        {
            return Usuarios.ListarUsuarios(usuario);
        }

        [Route("api/Usuarios/EliminarUsuario")]
        [HttpPost]
        public TResponses EliminarUsuario(UsuarioRequest usuario)
        {
            return Usuarios.EliminarUsuario(usuario);
        }

        [Route("api/Usuarios/AgregarRolesxUsuario")]
        [HttpPost]
        public TResponses AgregarRolesxUsuario(TRequest usuario)
        {
            return Usuarios.AgregarRolesxUsuario(usuario);
        }

        [Route("api/Usuarios/EliminarRolesxUsuario")]
        [HttpPost]
        public TResponses EliminarRolesxUsuario(TRequest usuario)
        {
            return Usuarios.EliminarRolesxUsuario(usuario);
        }

        [Route("api/Usuarios/VerUsuario")]
        [HttpPost]
        public UsuarioResponses VerUsuario(TRequest usuario)
        {
            return Usuarios.VerUsuario(usuario);
        }

        [Route("api/Usuarios/ListarUsuariosxGrupo")]
        [HttpPost]
        public List<UsuarioResponses> ListarUsuariosxGrupo(TRequest usuario)
        {
            return Usuarios.ListarUsuariosxGrupo(usuario);
        }

        [Route("api/Usuarios/ListarUsuariosxCarga_T")]
        [HttpPost]
        public List<UsuarioResponses> ListarUsuariosxCarga_T(TRequest usuario)
        {
            return Usuarios.ListarUsuariosxCarga_T(usuario);
        }


        //  PENDIENTE DE MODIFICAR



        [Route("api/Usuarios/ListarComunicadosxUsuario")]
        [HttpPost]
        public List<ComunicadoResponses> ListarComunicadosxUsuario(AccessRequest usuario)
        {
            return Usuarios.ListarComunicadosxUsuario(usuario);
        }

        [Route("api/Usuarios/MantenimientoUsuario")]
        [HttpPost]
        public TResponses MantenimientoUsuario(UsuarioRequest usuario)
        {
            return Usuarios.MantenimientoUsuario(usuario);
        }



        [Route("api/Usuarios/MantenimientoAsistencia")]
        [HttpPost]
        public TResponses MantenimientoAsistencia(TRequest asistencia)
        {
            return Usuarios.MantenimientoAsistencia(asistencia);
        }

        [Route("api/Usuarios/ListaAsistencia")]
        [HttpPost]
        public List<TResponses> ListaAsistencia(TRequest asistencia)
        {
            return Usuarios.ListaAsistencia(asistencia);
        }

    }
}
