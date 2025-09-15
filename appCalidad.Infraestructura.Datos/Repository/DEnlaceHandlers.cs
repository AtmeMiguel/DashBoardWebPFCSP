using appCalidad.Infraestructura.Datos.Connection;
using appCalidad.Service.Implementacion.Handlers;
using appCalidad.Service.Implementacion.Request;
using appCalidad.Service.Implementacion.Responses;
using appCalidad.Service.Implementacion.Responses.CLARO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appCalidad.Infraestructura.Datos.Repository
{
    public class DEnlaceHandlers : IEnlaceHandler
    {
        private readonly IDbConnection DbConnection;
        Conexiones con = new Conexiones();
        public DEnlaceHandlers()
        {
            DbConnection = con.ConstruirConexion();
        }

        public TResponses AdministrarEnlace(EnlaceRequest enlace)
        {
            var Consulta = DbConnection.Query<TResponses>("Seguridad.SP_ADMINISTRAR_ENLACES", new
            {
                ID = enlace.ID,
                TITULO = enlace.TITULO,
                CONTENIDO = enlace.CONTENIDO,
                ENLACE = enlace.ENLACE,
                MODO = enlace.MODO,

                ID_GRUPO = enlace.ID_GRUPO,
                ID_SEDE = enlace.ID_SEDE,
                ID_USUARIO = enlace.ID_USUARIO,
                TIPO = enlace.TIPO,
            }, commandType: CommandType.StoredProcedure).First();
            return Consulta;
        }

        public List<TResponses> ClienteCAE(TRequest cliente)
        {
            var Consulta = DbConnection.Query<TResponses>("Seguridad.SP_ADMINISTRAR_ENLACES", new
            {
                CONTENIDO = cliente.CONTENIDO,
                ID_USUARIO = cliente.ID_USUARIO,
                ID_SEDE = cliente.ID_SEDE,
                TIPO = cliente.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<GrillaEdificiosResponses> ListarEdificiosLiberados(TRequest edificios)
        {
            var Consulta = DbConnection.Query<GrillaEdificiosResponses>("Seguridad.SP_ADMINISTRAR_ENLACES", new
            {
                ID = edificios.ID,
                CONTENIDO = edificios.CONTENIDO,
                ID_USUARIO = edificios.ID_USUARIO,
                ID_SEDE = edificios.ID_SEDE,
                TIPO = edificios.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<EnlaceResponses> ListarEnlaces(TRequest enlace)
        {
            var Consulta = DbConnection.Query<EnlaceResponses>("Seguridad.SP_ADMINISTRAR_ENLACES", new
            {
                ID = enlace.ID,

                ID_USUARIO = enlace.ID_USUARIO,
                ID_SEDE = enlace.ID_SEDE,
                TIPO = enlace.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<GrillaCanalesResponses> ListarGrillaCanalesClaro(TRequest comunicado)
        {
            var Consulta = DbConnection.Query<GrillaCanalesResponses>("Seguridad.SP_ADMINISTRAR_ENLACES", new
            {
                ID = comunicado.ID,
                ID_USUARIO = comunicado.ID_USUARIO,
                ID_SEDE = comunicado.ID_SEDE,
                TIPO = comunicado.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<GrillaNodosResponses> ListarNodosLiberados(TRequest customer)
        {
            var Consulta = DbConnection.Query<GrillaNodosResponses>("Seguridad.SP_ADMINISTRAR_ENLACES", new
            {
                ID = customer.ID,
                CONTENIDO = customer.CONTENIDO,
                ID_USUARIO = customer.ID_USUARIO,
                ID_SEDE = customer.ID_SEDE,
                TIPO = customer.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }

        public List<TreeResponses> ListarTree(TRequest comunicado)
        {
            var Consulta = DbConnection.Query<TreeResponses>("Seguridad.SP_ADMINISTRAR_ENLACES", new
            {
                ID = comunicado.ID,

                ID_USUARIO = comunicado.ID_USUARIO,
                ID_SEDE = comunicado.ID_SEDE,
                TIPO = comunicado.TIPO,
            }, commandType: CommandType.StoredProcedure).ToList();
            return Consulta;
        }


    }
}
