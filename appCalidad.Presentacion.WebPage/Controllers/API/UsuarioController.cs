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
using System.Web;
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
        [Route("api/Usuarios/GenerarEnlacePagPF")]
        [HttpPost]
        public AutorizacionPFResponse GenerarEnlacePagPF(AutorizacionPFRequest usuario)
        {
            AutorizacionPFResponse Nuevo = new AutorizacionPFResponse();
           
            Nuevo = Usuarios.GenerarEnlacePagPF(usuario);
            return Nuevo;
        }



        /// <summary>
        /// autenticar usuario pagos plan familiar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [AllowAnonymous]
        //[Route("Verificar")]
        [Route("api/Usuarios/InsertarUsuarioPagosPF")]
        [HttpPost]
        public AccessResponses InsertarUsuarioPagosPF(AccessRequest usuario)
        {
            AccessResponses Nuevo = new AccessResponses();
            Nuevo = Usuarios.insertarUsuarioPagosPF(usuario);
            return Nuevo;
        }

        /// <summary>
        /// autenticar usuario pagos plan familiar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [AllowAnonymous]
        //[Route("Verificar")]
        [Route("api/Usuarios/VerificarAfiliadoPagoPF")]
        [HttpPost]
        public AccessResponses VerificarAfiliadoPagoPF(AccessRequest usuario)
        {
            AccessResponses Nuevo = new AccessResponses();
            Nuevo = Usuarios.VerificarAfiliadoPagoPF(usuario);
            return Nuevo;
        }


        /// <summary>
        /// autenticar usuario pagos plan familiar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [AllowAnonymous]
        //[Route("Verificar")]
        [Route("api/Usuarios/VerificarUsuarioPagoPF")]
        [HttpPost]
        public AccessResponses VerificarUsuarioPagosPF(AccessRequest usuario)
        {

            AccessResponses Nuevo = new AccessResponses();
            Nuevo = Usuarios.VerificarUsuarioPagosPF(usuario);
            return Nuevo;
        }


        /// <summary>
        /// autenticar usuario pagos plan familiar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [AllowAnonymous]
        //[Route("Verificar")]
        [Route("api/Usuarios/ValidarEnlaceDeIngreso")]
        [HttpPost]
        public AccessResponses ValidarEnlaceDeIngreso(AccessRequest usuario)
        {
            
            AccessResponses Nuevo = new AccessResponses();
            Nuevo = Usuarios.ValidarEnlaceDeIngreso(usuario);
            return Nuevo;
        }
        

        /// <summary>
        /// autenticar usuario pagos plan familiar
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        [AllowAnonymous]
        //[Route("Verificar")]
        [Route("api/Usuarios/VerificarCorreoPagoPF")]
        [HttpPost]
        public AccessResponses VerificarCorreoPagosPF(AccessRequest usuario)
        {
            AccessResponses Nuevo = new AccessResponses();
            Nuevo = Usuarios.VerificarCorreoPagosPF(usuario);
            return Nuevo;
        }


        /// <summary>
        /// autenticar usuario pagos plan familiar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [AllowAnonymous]
        //[Route("Verificar")]
        [Route("api/Usuarios/VerificarCodigoPagoPF")]
        [HttpPost]
        public AutorizacionPFResponse VerificarCodigoPagoPF(AutorizacionPFRequest usuario)
        {
            AutorizacionPFResponse Nuevo = new AutorizacionPFResponse();

            Nuevo = Usuarios.VerificarCodigoPagoPF(usuario);
            return Nuevo;
        }

        /// <summary>
        /// Obtener data de usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        //[Route("Verificar")]
        [Route("api/Usuarios/ActualizaUsuPagoPF")]
        [HttpPost]
        public AccessResponses ActualizaUsuPagoPF(AccessRequest usuario)
        {
            AccessResponses Nuevo = new AccessResponses();
            Nuevo = Usuarios.ActualizaUsuPagoPF(usuario);
            return Nuevo;
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

    }
}
