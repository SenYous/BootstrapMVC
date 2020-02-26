using System.Web;
using System.Web.Optimization;

namespace BootstrapMVC
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Content/lib/assets/js/loader.js",
                      "~/Content/lib/assets/js/libs/jquery-3.1.1.min.js",
                      "~/Content/lib/bootstrap/js/popper.min.js",
                      "~/Content/lib/bootstrap/js/bootstrap.min.js",
                      "~/Content/lib/plugins/perfect-scrollbar/perfect-scrollbar.min.js",
                      "~/Content/lib/assets/js/app.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/customJs").Include(
                 "~/Content/lib/assets/js/custom.js",
                 "~/Content/lib/plugins/apex/apexcharts.min.js",
                 "~/Content/lib/assets/js/dashboard/dash_1.js"
                 ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/lib/assets/css/loader.css",
                      "~/Content/lib/bootstrap/css/bootstrap.min.css",
                      "~/Content/lib/assets/css/plugins.css",
                      "~/Content/lib/plugins/apex/apexcharts.css",
                      "~/Content/lib/assets/css/dashboard/dash_1.css"));
        }
    }
}
