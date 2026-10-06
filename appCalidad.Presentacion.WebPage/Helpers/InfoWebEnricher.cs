using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serilog.Core;
using Serilog.Events;
using UAParser;

// El namespace dependerá del nombre de tu proyecto y carpeta
namespace appCalidad.Presentacion.WebPage.Helpers
{
    public class InfoWebEnricher : ILogEventEnricher
    {
        private static readonly Parser uaParser = Parser.GetDefault();
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {

            var context = HttpContext.Current;
            if (context == null) { return;}

            try
            {
                var request = context.Request;
                if (request == null) { return;}

                string usuario = "Anonimo";
                var user = context.User;
                if (user !=null && user.Identity !=null && user.Identity.IsAuthenticated)
                {
                    usuario = user.Identity.Name;
                }
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserName",usuario));
                // 2. Navegador, Versión, SO y Dispositivo en UN SOLO VALOR
                string rawUserAgent = request.UserAgent;
                string browserInfo = "Desconocido";

                if (!string.IsNullOrEmpty(rawUserAgent))
                {
                    ClientInfo clientInfo = uaParser.Parse(rawUserAgent);
                    string nombre = clientInfo.UA.Family;
                    string version = $"{clientInfo.UA.Major}.{clientInfo.UA.Minor}";
                    string so = $"{clientInfo.OS.Family} {clientInfo.OS.Major}".Trim();
                    string dispositivo = clientInfo.Device.Family;
                    // Concatenamos todo en un solo string amigable. 
                    // Ej: "Chrome 152.0 (Windows 10 - Other)"
                    browserInfo = $"{nombre} {version} ({so} - {dispositivo})";

                }
                // Inyectamos la propiedad unificada
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("BrowserInfo", browserInfo));


            }
            catch (Exception)
            {

            }

        }
    }
}