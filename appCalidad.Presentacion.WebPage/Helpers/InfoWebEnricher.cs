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
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                // ... (AQUÍ VA TODO EL CÓDIGO DEL PASO ANTERIOR) ...

                string usuario = "Anonimo";
                if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    usuario = HttpContext.Current.User.Identity.Name;
                }
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserName", usuario));

                // 2. Navegador, Versión, SO y Dispositivo en UN SOLO VALOR
                string rawUserAgent = HttpContext.Current.Request.UserAgent;
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




                /*
                string navegador = HttpContext.Current.Request.UserAgent ?? "Desconocido";
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Navegador", navegador));*/
            }
        }
    }
}