@ModelType VerifyCodeViewModel
@Code
    ViewBag.Title = "Verificar"
End Code

<h3>@ViewBag.Title.</h3>
<section class="panel">
    <header class="panel-heading">Introducir código de verificación</header>
    <div class="panel-body">
        <div class="form-horizontal">
            <hr />
            @Using Html.BeginForm("VerifyCode", "Account", New With {.ReturnUrl = Model.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                @Html.AntiForgeryToken()
                @Html.Hidden("provider", Model.Provider)
                @Html.Hidden("rememberMe", Model.RememberMe)
                @<text>
                   
                    <hr />
                    @Html.ValidationSummary("", New With {.class = "text-danger"})
                    <div class="form-group">
                        @Html.LabelFor(Function(m) m.Code, New With {.class = "col-md-2 control-label"})
                        <div class="col-md-10">
                            @Html.TextBoxFor(Function(m) m.Code, New With {.class = "form-control"})
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                @Html.CheckBoxFor(Function(m) m.RememberBrowser)
                                @Html.LabelFor(Function(m) m.RememberBrowser)
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <input type="submit" class="btn btn-default" value="Enviar" />
                        </div>
                    </div>
                </text>
            End Using

            @Section Scripts
                @Scripts.Render("~/bundles/jqueryval")
            End Section
        </div>
    </div>
</section>