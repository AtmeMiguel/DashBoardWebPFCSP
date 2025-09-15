using System.Web;
using System.Web.Optimization;

namespace appCalidad.Presentacion.WebPage
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundlesLogin/js").Include(

                        "~/Scripts/Galerias/Vue.js",
                        "~/Scripts/Galerias/axios.js",
                        "~/Scripts/Galerias/bootstrap-vue.js",
                        "~/Scripts/Galerias/bootstrap-vue-icons.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        
                        "~/Scripts/Galerias/Vue.js",
                        "~/Scripts/Galerias/axios.js",
                        "~/Scripts/Galerias/bootstrap-vue.js",
                        "~/Scripts/Galerias/bootstrap-vue-icons.js", 
                        "~/Scripts/Galerias/moment.js",

                        "~/Scripts/Galerias/xlsx.full.min.js", //sheetjs para exportar a excel

                        //
                        "~/Scripts/Galerias/vue-chartkick.js",
                        "~/Scripts/Galerias/v-img.min.js",
                        "~/Scripts/Galerias/Chart.min.js",
                        "~/Scripts/Galerias/qrious.min.js",          // Qr
                                                                     //"~/Scripts/Galerias/vue-quill.js",
                                                                     //"~/Scripts/Galerias/mc-wysiwyg.js",
                                                                     //"~/Scripts/Galerias/vueditor.min.js",
                        "~/Scripts/Galerias/clipboard.js",
                         "~/Scripts/Galerias/chartjs-plugin-datalabels-1.js"

                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Galerias/Bootstrap.css",
                      "~/Content/Galerias/bootstrap-vue.css",
                      "~/Content/Galerias/bootstrap-vue-icons.css",
                      "~/icons/bootstrap-icons.css",
                      "~/Content/Galerias/vue-quill.css",
                      "~/Content/Galerias/util.css"));
        }
    }
}
