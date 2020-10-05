using System.Web.Optimization;

namespace ManagementStore
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/CSS").Include(
                "~/plugins/fontawesome-free/css/all.min.css",
                "~/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                "~/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                "~/plugins/jqvmap/jqvmap.min.css",
                "~/dist/css/adminlte.min.css",
                "~/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                "~/plugins/daterangepicker/daterangepicker.css",
                "~/plugins/summernote/summernote-bs4.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/JQUERY_NEW").Include(
                "~/plugins/jquery/jquery.min.js",
                "~/plugins/jquery-ui/jquery-ui.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/JS").Include(
                "~/plugins/bootstrap/js/bootstrap.bundle.min.js",
                "~/plugins/chart.js/Chart.min.js",
                "~/plugins/sparklines/sparkline.js",
                "~/plugins/jqvmap/jquery.vmap.min.js",
                "~/plugins/jqvmap/maps/jquery.vmap.usa.js",
                "~/plugins/jquery-knob/jquery.knob.min.js",
                "~/plugins/moment/moment.min.js",
                "~/plugins/daterangepicker/daterangepicker.js",
                "~/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                "~/plugins/summernote/summernote-bs4.min.js",
                "~/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                "~/dist/js/adminlte.js",
                "~/dist/js/pages/dashboard.js",
                "~/dist/js/demo.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/data-table").Include(
                "~/plugins/datatables/jquery.dataTables.min.js",
                "~/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
                "~/plugins/datatables-responsive/js/dataTables.responsive.min.js",
                "~/plugins/datatables-responsive/js/responsive.bootstrap4.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                "~/plugins/fullcalendar/main.min.js",
                "~/plugins/moment/moment.min.js",
                "~/plugins/fullcalendar-daygrid/main.min.js",
                "~/plugins/fullcalendar-timegrid/main.min.js",
                "~/plugins/fullcalendar-interaction/main.min.js",
                "~/plugins/fullcalendar-bootstrap/main.min.js"
               ));
        }
    }
}
