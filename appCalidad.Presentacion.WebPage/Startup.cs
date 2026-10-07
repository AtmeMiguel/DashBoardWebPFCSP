
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;


// ¡ESTA LÍNEA ES CRUCIAL! Le indica al servidor que esta es la clase de inicio OWIN.
// Cambia "TuNombreDeProyecto" por el nombre real de tu proyecto.
[assembly: OwinStartup(typeof(appCalidad.Presentacion.WebPage.Startup))]

namespace appCalidad.Presentacion.WebPage
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            /*
            // Aquí configuramos las reglas de la Cookie (la "pulsera")
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                
                // Reemplazamos la variable por el texto directo
                AuthenticationType = "ApplicationCookie",
                // Si alguien sin sesión intenta entrar a una página protegida, 
                // será redirigido automáticamente a tu pantalla de Login en Vue
                LoginPath = new PathString("/Seguridad/Login"),

                // Tiempo de vida de la sesión (ej. 60 minutos)
                ExpireTimeSpan = System.TimeSpan.FromMinutes(60),

                // Si está en true, cada vez que el usuario hace una petición, 
                // el contador de 60 minutos vuelve a empezar (evita que se cierre mientras trabaja)
                SlidingExpiration = true
            });
            */
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                CookieName = "AppPagPF_Auth", // <-- Aquí defines el nombre exacto de la cookie
                LoginPath = new PathString("/Seguridad/Login"),
                ExpireTimeSpan = System.TimeSpan.FromMinutes(60),
                SlidingExpiration = true
            });






        }
    }
}