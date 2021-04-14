using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace KareAjans.WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/AdminCss").Include(
                "~/Content/font-awesome.min.css",
                "~/Content/AdminTemplate/css/dataTables.bootstrap4.min.css",
                "~/Content/AdminTemplate/css/adminlte.min.css",
                "~/Content/AdminTemplate/css/blue.css",
                "~/Content/AdminTemplate/css/datepicker3.css",
                "~/Content/AdminTemplate/css/daterangepicker-bs3.css"
             ));
            bundles.Add(new ScriptBundle("~/Scripts/AdminScript").Include(
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/js/moment.min.js",
                "~/Scripts/js/daterangepicker.js",
                "~/Scripts/js/bootstrap-datepicker.js",
                "~/Scripts/js/bootstrap-datepicker.tr.js",
                "~/Scripts/js/jquery.slimscroll.min.js",
                "~/Scripts/js/fastclick.js",
                "~/Scripts/js/adminlte.js",
                //"~/Scripts/js/dashboard.js",
                "~/Scripts/js/demo.js"


             ));
        }
    }
}