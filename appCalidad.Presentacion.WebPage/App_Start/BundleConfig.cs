using System.Web;
using System.Web.Optimization;

namespace appCalidad.Presentacion.WebPage
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundlesLogin/js").Include(
            //            //"~/Scripts/Galerias/Vue.js",
            //            "~/Scripts/Galerias/axios.js"
            //            //"~/Scripts/Galerias/bootstrap-vue.js"
            //            ));

            //bundles.Add(new StyleBundle("~/ContentLogin/css").Include(
            //   //"~/Content/Galerias/bootstrap-vue.css",
            //   "~/Content/Galerias/utilPF.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                               "~/Scripts/Galerias/jquery-3.2.1.min.js",
                                  "~/Scripts/Galerias/bootstrap.min.js",
                        "~/Scripts/Galerias/Vue.min.js",
                        "~/Scripts/Galerias/axios.js",
                        "~/Scripts/Galerias/bootstrap-vue.min.js",
                        "~/Scripts/Galerias/xlsx.full.min.js" //sheetjs para exportar a excel
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/Galerias/Bootstrap.css",
                      "~/Content/Galerias/bootstrap-vue.min.css",
                     
                      "~/Content/Galerias/util.css"));


               
        }


    }
}
