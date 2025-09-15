using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using appCalidad.Infraestructura.Datos;
namespace appCalidad.Presentacion.WebPage.Controllers
{
    [Authorize]
    public class ReportesController : Controller
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
        string nombre = "";

        private Export _export;
        public ReportesController()
        {
            _export = new Export();
        }

        // GET: Reportes
        public ActionResult Examen()
        {
            return View();
        }

        public ActionResult Examen2()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExamenExcel(string idFormulario)
        {
            DataTable casosList = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Control.[SP_ADMINISTRAR_FORMULARIOS]", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.Add("@CAMPO_1", SqlDbType.VarChar,1000).Value = idFormulario;
                sqlDa.SelectCommand.Parameters.Add("@TIPO", SqlDbType.Int).Value = 30;
                sqlDa.Fill(casosList);
                _export.ToExcel(Response, casosList);
            }
            return View();
        }


        public ActionResult ComunicadoConfirmadoExcel(string idComunicado)
        {
            DataTable casosList = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Seguridad.[SP_ADMINISTRAR_COMUNICADOS]", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.Add("@CONTENIDO", SqlDbType.VarChar, 1000).Value = idComunicado;
                sqlDa.SelectCommand.Parameters.Add("@TIPO", SqlDbType.Int).Value = 10;
                sqlDa.Fill(casosList);
                _export.ToExcel(Response, casosList);
            }
            return View();
        }
        public ActionResult ComunicadoEncuestaExcel(string idComunicado)
        {
            DataTable casosList = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Seguridad.[SP_ADMINISTRAR_COMUNICADOS]", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.Add("@CONTENIDO", SqlDbType.VarChar, 1000).Value = idComunicado;
                sqlDa.SelectCommand.Parameters.Add("@TIPO", SqlDbType.Int).Value = 16;
                sqlDa.Fill(casosList);
                _export.ToExcel(Response, casosList);
            }
            return View();
        }

        
        public ActionResult ClaroExcel(string ini, string fin, string tipo)
        {
            DataTable casosList = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Claro.[SP_REPORTE]", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.Add("@INI", SqlDbType.VarChar, 10).Value = ini;
                sqlDa.SelectCommand.Parameters.Add("@FIN", SqlDbType.VarChar, 10).Value = fin;
                sqlDa.SelectCommand.Parameters.Add("@TIPO", SqlDbType.Int).Value = tipo;
                sqlDa.Fill(casosList);
                _export.ToExcel(Response, casosList);
            }
            return View();
        }
        public ActionResult ReporteExcel(string ini, string fin, string id, string nombre)
        {
            DataTable casosList = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Control.SP_ADMINISTRAR_FORMULARIOS_II", sqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                sqlDa.SelectCommand.Parameters.Add("@CAMPO_1", SqlDbType.VarChar, 10).Value = ini;
                sqlDa.SelectCommand.Parameters.Add("@CAMPO_2", SqlDbType.VarChar, 10).Value = fin;
                sqlDa.SelectCommand.Parameters.Add("@TIPO", SqlDbType.Int).Value = 40;
                sqlDa.Fill(casosList);
                _export.ToExcel(Response, casosList, nombre);
            }
            return View();
        }
        public void Excel()
        {
            
            _export.ToExcel(Response, Session["DATA"]);
        }

    }
}