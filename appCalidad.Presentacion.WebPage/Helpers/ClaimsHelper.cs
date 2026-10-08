using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Security.Claims;

namespace appCalidad.Presentacion.WebPage.Helpers
{
    public static class ClaimsHelper
    {

        // 1. Propiedad para verificar si el usuario está autenticado
        public static bool EstaAutenticado
        {
            get
            {
                return HttpContext.Current.User != null &&
                       HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }
        /*
        usuLogueado = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
        nomLogueado = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value ?? "";
        apeLogueado = claimsIdentity.FindFirst("Apellidos")?.Value ?? "";
       */
        public static string usuLogueado
        {
            get
            {
                if (!EstaAutenticado) return "";
                var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
                return identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value ??string.Empty;
            }
        }


        public static string nomLogueado
        {
            get
            {
                if (!EstaAutenticado) return "";
                var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
                return identity?.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
            }
        }

        public static string apeLogueado
        {
            get
            {
                if (!EstaAutenticado) return "";
                var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
                return identity?.FindFirst("Apellidos")?.Value ?? string.Empty;
            }
        }



        // Método genérico para obtener un claim personalizado por su tipo
        public static string ObtenerClaimPersonalizado(string tipoClaim)
        {
            if (!EstaAutenticado) return "";
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            return identity?.FindFirst(tipoClaim)?.Value ?? string.Empty;
        }


    }
}