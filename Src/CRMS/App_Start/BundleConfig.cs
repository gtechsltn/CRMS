﻿using System.Web.Optimization;

namespace CRMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/jquery.validate*",
                    "~/Content/js/adminlte.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"
                    ));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.js"
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/css/adminlte.css",
                    "~/Content/site.css"
                    ));
        }
    }
}