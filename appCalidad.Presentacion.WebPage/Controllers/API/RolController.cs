using appCalidad.Infraestructura.Datos.Repository;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appCalidad.Presentacion.WebPage.Controllers.API
{
    [Authorize]
    public class RolController : ApiController
    {
        private DRolHandlers Rol;
        public RolController()
        {
            Rol = new DRolHandlers();
        }
        // ###########   ROLES   ###########
        [Route("api/Rol/ListarRolesxPrograma")]
        [HttpPost]
        public List<RolResponses> ListarRolesxPrograma(RolRequest rol)
        {
            return Rol.ListarRolesxPrograma(rol);
        }

        [Route("api/Rol/MantenimientoRol")]
        [HttpPost]
        public RolResponses MantenimientoRol(RolRequest rol)
        {
            return Rol.MantenimientoRol(rol);
        }

        [Route("api/Rol/EliminarRol")]
        [HttpPost]
        public RolResponses EliminarRol(RolRequest rol)
        {
            return Rol.EliminarRol(rol);
        }

        // ###########   MODULOS   ###########
        [Route("api/Rol/ListarModulos")]
        [HttpPost]
        public List<RolResponses> ListarModulos(RolRequest rol)
        {
            return Rol.ListarModulos(rol);
        }

        [Route("api/Rol/MantenimientoModulo")]
        [HttpPost]
        public RolResponses MantenimientoModulo(RolRequest rol)
        {
            return Rol.MantenimientoModulo(rol);
        }

        [Route("api/Rol/EliminarModulo")]
        [HttpPost]
        public RolResponses EliminarModulo(RolRequest rol)
        {
            return Rol.EliminarModulo(rol);
        }

        // ###########   MODULOSxROL   ###########
        
    
        [Route("api/Rol/AgregarModulosxRol")]
        [HttpPost]
        public RolResponses AgregarModulosxRol(RolRequest rol)
        {
            return Rol.AgregarModulosxRol(rol);
        }

        [Route("api/Rol/EliminarModulosxRol")]
        [HttpPost]
        public RolResponses EliminarModulosxRol(RolRequest rol)
        {
            return Rol.EliminarModulosxRol(rol);
        }

    }
}
