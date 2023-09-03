using System.Web.Optimization;

namespace CRMS
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/jquery.validate*",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/bootstrap.bundle.js",
                    "~/Content/js/adminlte.js",
                    "~/Scripts/jquery.dataTables.js",
                    "~/Scripts/dataTables.bootstrap4.js",
                    "~/Scripts/markitup/jquery.markitup.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                    
                    "~/Scripts/modernizr-*"
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/css/adminlte.css",
                    "~/Content/dataTables.bootstrap4.css",
                    "~/Content/site.css"
                    ));
        }
    }
}