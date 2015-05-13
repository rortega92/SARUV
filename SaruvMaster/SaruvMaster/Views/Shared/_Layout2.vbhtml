<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Creative - Bootstrap 3 Responsive Admin Template">
    <meta name="author" content="GeeksLabs">
    <meta name="keyword" content="Creative, Dashboard, Admin, Template, Theme, Bootstrap, Responsive, Retina, Minimal">
    <link rel="shortcut icon" href="favicon.png">

    <title>SARUV</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

    <!-- Bootstrap CSS -->
    @Styles.Render("~/Content/layout/css/bootstrap.min.css")
    <!-- bootstrap theme -->
    @Styles.Render("~/Content/layout/css/bootstrap-theme.css")
    <!--external css-->
    <!-- font icon -->
    @Styles.Render("~/Content/layout/css/elegant-icons-style.css")
    @Styles.Render("~/Content/layout/css/font-awesome.min.css")
    <!-- Custom styles -->
    @Styles.Render("~/Content/layout/css/style.css")
    @Styles.Render("~/Content/layout/css/style-responsive.css")

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 -->
    <!--[if lt IE 9]>
      @Scripts.Render("js/html5shiv.js")
      @Scripts.Render("js/respond.min.js")
      @Scripts.Render("js/lte-ie7.js")|
    <![endif]-->

    <link href="~/Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <script href="~/Scripts/app.js"></script>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/jqueryui")
   
</head>

<body>
    <!-- container section start -->
    <section id="container" class="">
        <header class="header dark-bg">@Html.Partial("Header")</header>
            @Html.Partial("LeftContent")
        <section id="main-content">
            <section class="wrapper">@RenderBody()</section>

        </section>
    </section>
    <!-- javascripts -->
    ~/Content/layout/css/
    @Scripts.Render("~/Content/layout/js/jquery.js")
    @Scripts.Render("~/Content/layout/js/bootstrap.min.js")
    <!-- nice scroll -->
    @Scripts.Render("~/Content/layout/js/jquery.scrollTo.min.js")
    @Scripts.Render("~/Content/layout/js/jquery.nicescroll.js")
    <!--custome script for all page-->
    @Scripts.Render("~/Content/layout/js/scripts.js")

    @RenderSection("scripts", required:=False)

</body>
</html>
