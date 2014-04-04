namespace Andriy.Mvc4Application1.App_Start
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryfixval").Include(
                        "~/Scripts/jquery.fix-validate.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-*"));

            bundles.Add(new ScriptBundle("~/bundles/product-edit-categories-select").Include(
                        "~/Scripts/productEdit.categoriesSelect.js"));

            bundles.Add(new ScriptBundle("~/bundles/image-popup").Include(
                        "~/Scripts/image-popup.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/css2").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site2.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            // For To-Do Area (withoput hyphen)
            bundles.Add(new ScriptBundle("~/bundles/todo/ajaxlogin").Include(
                "~/Areas/ToDoArea/Scripts/app/ajaxlogin.js"));

            bundles.Add(new ScriptBundle("~/bundles/todo").Include(
                "~/Areas/ToDoArea/Scripts/app/todo.bindings.js",
                "~/Areas/ToDoArea/Scripts/app/todo.datacontext.js",
                "~/Areas/ToDoArea/Scripts/app/todo.model.js",
                "~/Areas/ToDoArea/Scripts/app/todo.viewmodel.js"));

            bundles.Add(new StyleBundle("~/Areas/ToDoArea/Content/css").Include(
                "~/Areas/ToDoArea/Content/Site.css",
                "~/Areas/ToDoArea/Content/TodoList.css"));
        }
    }
}