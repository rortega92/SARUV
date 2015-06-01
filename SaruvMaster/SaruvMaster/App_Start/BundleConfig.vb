Imports System.Web.Optimization

Public Module BundleConfig
    ' Para obtener más información sobre las uniones, visite http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        ' Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
        ' preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js",
            "~/Scripts/jquery-ui.unobtrusive-{version}.js"))

        bundles.Add(New StyleBundle("~/Content/themes/base/css").Include(
        "~/Content/themes/base/jquery.ui.core.css",
        "~/Content/themes/base/jquery.ui.datepicker.css",
        "~/Content/themes/base/jquery.ui.theme.css"))

        'FullCalendar css file
        bundles.Add(New StyleBundle("~/Content/fullcalendarcss").Include("~/Content/themes/jquery.ui.all.css", "~/Content/fullcalendar.css"))

        'FullCalendar Script file

        bundles.Add(New ScriptBundle("~/bundles/fullcalendarjs").Include("~/Scripts/jquery-ui-1.10.4.min.js", "~/Scripts/fullcalendar.min.js"))

    End Sub
End Module

