using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;

namespace appCalidad.Infraestructura.Datos
{
    public class Export
    {
        public void ToExcel(HttpResponseBase Response, object clientsList, string nombre = "")
        {
            var grid = new System.Web.UI.WebControls.GridView();
            var fecha = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            grid.DataSource = clientsList;
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + nombre + "_.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

    }
}