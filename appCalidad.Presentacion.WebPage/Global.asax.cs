using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


using Serilog;

using appCalidad;
using appCalidad.Presentacion.WebPage.Helpers;

namespace appCalidad.Presentacion.WebPage
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {



            string rutaSeriLog = ConfigurationManager.AppSettings["rutaSerilog"].ToString();


            // =========================================================
            // CONFIGURACIÓN DE SERILOG
            // =========================================================

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()    //debug 
                // === EL FILTRO: Ignora todos los logs automáticos de tráfico web ===
                .Filter.ByExcluding(log => log.MessageTemplate.Text.StartsWith("HTTP ") && log.MessageTemplate.Text.Contains("responded"))
                .Enrich.WithHttpRequestUrl()
                .Enrich.WithHttpRequestClientHostIP()
                .Enrich.With(new InfoWebEnricher())    // <-- NUESTRA CLASE: Saca el Usuario y el Navegador
                .WriteTo.File(rutaSeriLog,
                    rollingInterval: RollingInterval.Day,
                     outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [User: {UserName}] {Message:lj}{Exception}| [Browser: {BrowserInfo}]{NewLine}")
                // [IP: {HttpRequestClientHostIP}]  [URL: {HttpRequestUrl}]    
                //outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [URL: {RequestUrl}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            Log.Information(" | APP | La aplicación WebPagosPF se ha iniciado correctamente.");

            // ==========================================================
            // CONFIGURACIONES ORIGINALES
            // ==========================================================

            BundleTable.EnableOptimizations = true;
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // MÉTODO PARA CERRAR SERILOG AL DETENER LA APP
        protected void Application_End()
        {
            Log.Information("La aplicación WebPagosPF se está deteniendo.");
            Log.CloseAndFlush(); // Libera el archivo .txt para que no quede bloqueado en el servidor
        }
    }
}


/*
 Si quieres que tu propia aplicación te avise cuando su memoria está siendo destruida y por qué, puedes agregar este código en tu archivo `Global.asax` o `Global.asax.cs`:

```csharp
protected void Application_End(object sender, EventArgs e)
{
    HttpRuntime runtime = (HttpRuntime)typeof(System.Web.HttpRuntime).InvokeMember("_theRuntime",
        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.GetField,
        null, null, null);

    if (runtime != null)
    {
        string shutDownMessage = (string)runtime.GetType().InvokeMember("_shutDownMessage",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetField,
            null, runtime, null);

        string shutDownStack = (string)runtime.GetType().InvokeMember("_shutDownStack",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetField,
            null, runtime, null);

        // Usa Serilog para guardar esto ANTES de que muera la app
        Log.Warning("La aplicación se reinició. Motivo: {Motivo}. Detalle: {Detalle}", shutDownMessage, shutDownStack);
    }
}
```
*Este código
 
 */


/*
 
using Serilog.Formatting.Compact;

// ... dentro de tu Application_Start:

Log.Logger = new LoggerConfiguration()
    // 1. CAMBIO A INFORMATION: Ignorará los .Debug()
    .MinimumLevel.Information() 
    
    // (Opcional pero recomendado) Silenciar logs internos molestos del sistema
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning) 

    .Enrich.WithHttpRequestUrl()
    .Enrich.WithHttpRequestClientHostIP()
    
    // ========================================================
    // SALIDA 1: ARCHIVO TXT CON LÍMITES
    // ========================================================
    .WriteTo.File(@"C:\logSistemas\WebPagos\log-.txt",
        rollingInterval: RollingInterval.Day,
        
        // REGLAS DE PRODUCCIÓN:
        fileSizeLimitBytes: 10485760, // Límite de 10 MB por archivo
        rollOnFileSizeLimit: true,    // Si pasa de 10MB, crea otro archivo en el mismo día
        retainedFileCountLimit: 30,   // Solo conserva los últimos 30 días
        
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [URL: {HttpRequestUrl}] {Message:lj}{NewLine}{Exception}")
    
    // ========================================================
    // SALIDA 2: ARCHIVO JSON CON LÍMITES
    // ========================================================
    .WriteTo.File(
        formatter: new RenderedCompactJsonFormatter(),
        path: @"C:\logSistemas\WebPagos\log-.json",
        rollingInterval: RollingInterval.Day,
        
        // REGLAS DE PRODUCCIÓN (Deben repetirse aquí también):
        fileSizeLimitBytes: 10485760,
        rollOnFileSizeLimit: true,
        retainedFileCountLimit: 30)
        
    .CreateLogger();
 
 */

/*
 
Las variables de Session: Guardas datos extras en la memoria RAM del servidor para poder mostrar el nombre del usuario en la barra de navegación superior de tu página web.

FormsAuthentication.SetAuthCookie(...): ¡Aquí es donde nace "jperez" para Serilog! Esta línea crea una galleta (cookie) encriptada en el navegador del usuario. A partir de este momento, en cualquier otra petición que haga el usuario, ASP.NET leerá esa cookie y llenará automáticamente la variable HttpContext.Current.User.Identity.Name con el nombre de usuario. Gracias a esta línea, el Enriquecedor de Serilog del que hablamos antes puede saber quién está navegando. 


El nuevo outputTemplate:
Insertamos dos nuevas "cajas" (placeholders) en el formato de tu texto:

[IP: {HttpRequestClientHostIP}]: Extrae la IP que ya estabas recolectando.

[User: {UserName}]: Extrae el nombre de usuario del paso anterior.

 */
