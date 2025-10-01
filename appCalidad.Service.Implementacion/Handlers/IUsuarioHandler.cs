using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Service.Implementacion.Handlers
{
    public interface IUsuarioHandler
    {
        AutorizacionPFResponse GenerarEnlacePagPF(AutorizacionPFRequest user);

        AccessResponses VerificarUsuarioPagosPF(AccessRequest user);
       
        AccessResponses VerificarUsuario (AccessRequest user);
        //test Verificar(AccessRequest usuario);
        List<RolResponses> ListarRolesxUsuario(AccessRequest usuario);
        List<RolResponses> ListarModulosxRol(AccessRequest usuario);
        List<ComunicadoResponses> ListarComunicadosxUsuario(AccessRequest usuario);

        List<UsuarioResponses> ListarUsuarios(TRequest usuario);
        List<UsuarioResponses> ListarUsuariosxGrupo(TRequest grupo);
        List<UsuarioResponses> ListarUsuariosxCarga_T(TRequest grupo);

        TResponses MantenimientoUsuario(UsuarioRequest usuario);
        TResponses EliminarUsuario(UsuarioRequest usuario);

        TResponses AgregarRolesxUsuario(TRequest rol);
        TResponses EliminarRolesxUsuario(TRequest rol);

        TResponses MantenimientoAsistencia(TRequest asistencia);
        List<TResponses> ListaAsistencia(TRequest asistencia);

        UsuarioResponses VerUsuario(TRequest usuario);
        //AccessResponses AdministrarUsuario(AccessRequest usuario);
        //List<AccessResponses> Listar(AccessRequest usuario);
    }
}
