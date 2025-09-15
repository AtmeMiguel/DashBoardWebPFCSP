using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Handlers
{
    public interface IRolHandler
    {
        List<RolResponses> ListarRolesxPrograma(RolRequest rol);
        RolResponses MantenimientoRol(RolRequest rol);
        RolResponses EliminarRol(RolRequest rol);

        List<RolResponses> ListarModulos(RolRequest rol);
        RolResponses MantenimientoModulo(RolRequest rol);
        RolResponses EliminarModulo(RolRequest rol);

        RolResponses AgregarModulosxRol(RolRequest rol);
        RolResponses EliminarModulosxRol(RolRequest rol);
    }
}
