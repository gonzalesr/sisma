﻿using System.Web;
using System.Web.Optimization;

namespace SismaV02
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.2.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // plugins | jquery-ui
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/jquery-ui/js").Include(
                                         "~/AdminLTE/plugins/jquery-ui/js/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/AdminLTE").Include(
                        "~/Content/AdminLTE/js/app.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/DataTable").Include(
                        "~/Content/AdminLTE/plugins/datatables/jquery.dataTables.min.js",
                        "~/Content/AdminLTE/plugins/datatables/dataTables.bootstrap.min.js",
                        "~/Content/AdminLTE/plugins/slimScroll/jquery.slimscroll.min.js",
                        "~/Content/AdminLTE/plugins/fastclick/fastclick.js",
                        "~/Content/AdminLTE/js/demo.js",
                        "~/Scripts/DataTableCustom.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/AdminLTE/css/font-awesome.min.css",
                      "~/Content/AdminLTE/css/ionicons.min.css",
                      "~/Content/AdminLTE/css/AdminLTE.css",
                      "~/Content/AdminLTE/css/skins/skin-blue.min.css"
                      //"~/Content/site.css"
                      ));
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/iCheck/square/blue").Include(
                     "~/Content/AdminLTE/plugins/iCheck/square/blue.css"));

            // plugins | icheck
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/iCheck").Include(
                                         "~/Content/AdminLTE/plugins/iCheck/icheck.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Account/Login").Include(
               "~/Scripts/Account/Login.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Account/Register").Include(
                "~/Scripts/Account/Register.js"));

        }
    }
}
