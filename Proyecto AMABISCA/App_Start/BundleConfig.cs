﻿using System.Web;
using System.Web.Optimization;

namespace Proyecto_AMABISCA
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(

                    "~/Content/vendor/jquery/jquery.min.js",
                    "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    

                     "~/Content/vendor/bootstrap/css/bootstrap.min.css",

                     "~/Content/css/shop-homepage.css",
                     "~/Content/InicioSesion.css",
                     "~/Content/Registrar.css",
                     "~/Content/Contacto.css"));
        }
    }
}
