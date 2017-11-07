using System.Web;
using System.Web.Optimization;

namespace TravelApp.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js",
                      "~/Scripts/js/bootstrap.min.js",
                      "~/Scripts/js/custom.js",
                      "~/Scripts/js/jquery.isotope.min.js",
                      "~/Scripts/js/jquery.prettyPhoto.js",
                      "~/Scripts/js/retina-1.0.0.js",
                      "~/Scripts/js/jquery.hoverdir.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls-0.13.4.js",
                "~/Scripts/angular-sanitize.js",
                "~/Scripts/app/app.module.js",                
                "~/Scripts/app/core/attraction/singleattractionController.js",
                "~/Scripts/app/core/attraction/attractionController.js",
                "~/Scripts/app/core/tripPlan/tripPlanController.js",
                "~/Scripts/app/core/blog/blogController.js",
                "~/Scripts/app/core/blog/singleBlogController.js",
                "~/Scripts/app/favourite/favouriteController.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/style.css",
                      "~/Content/css/font-awsome.min.css",
                      "~/Content/css/hoverex-all.css.css",
                      "~/Content/css/prettyPhoto.css",
                      "~/Content/site.css"));
        }
    }
}
