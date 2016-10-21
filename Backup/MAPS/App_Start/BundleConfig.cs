using System.Web.Optimization;

namespace MAPS
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquerytip").Include("~/Scripts/jquery.tooltipster.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
              "~/Scripts/WebForms/WebForms.js",
              "~/Scripts/WebForms/WebUIValidation.js",
              "~/Scripts/WebForms/MenuStandards.js",
              "~/Scripts/WebForms/Focus.js",
              "~/Scripts/WebForms/GridView.js",
              "~/Scripts/WebForms/DetailsView.js",
              "~/Scripts/WebForms/TreeView.js",
              "~/Scripts/WebForms/WebParts.js"));

            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                "~/Scripts/latlon.js",
                "~/Scripts/geo.js",
                "~/Scripts/main.js", "~/Scripts/ptpl.min.js",
                "~/Scripts/infobox.js"));


            bundles.Add(new ScriptBundle("~/bundles/gritter").Include(
               "~/Scripts/jquery.gritter.min.js"));


            bundles.Add(new StyleBundle("~/css/css").Include("~/Content/ami-sheet.css",
                "~/Content/button.css",
                "~/Content/form.css", "~/Content/jquery.gritter.css", "~/Content/jshmsheet.css",
                "~/Content/main.css", "~/Content/sliderNav.css", "~/Content/style.css", "~/Content/stylesheets1.css",
                "~/Content/tooltipster.css", "~/Content/font.css"));

            bundles.Add(new StyleBundle("~/css/admin").Include("~/Content/ami-sheet.css",
                                                                "~/Content/button.css",
                                                                "~/Content/form.css", "~/Content/jquery.gritter.css",
                                                                "~/Content/main.css", "~/Content/sliderNav.css",
                                                                "~/Content/tooltipster.css"));


            bundles.Add(new StyleBundle("~/css/login").Include("~/Content/jquery.gritter.css",
                "~/Content/tooltipster.css", "~/Content/login.css"));

            bundles.Add(new StyleBundle("~/css/ui").Include("~/Content/themes/base/minified/jquery-ui.min.css", "~/Content/themes/base/minified/jquery.ui.datepicker.min.css"));

        }
    }
}
