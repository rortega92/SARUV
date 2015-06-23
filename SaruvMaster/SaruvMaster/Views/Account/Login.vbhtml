@ModelType LoginViewModel
@Code
    ViewBag.Title = "Iniciar sesión"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h3>@ViewBag.Title</h3>
<section class="panel">
    <header class="panel-heading">
        Use una cuenta local para iniciar sesión.
    </header>
    <div class="panel-body">
        <div class="form-horizontal">
            <section id="loginForm">
                <hr />
                @Using Html.BeginForm("Login", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                    @Html.AntiForgeryToken()
                    @<text>

                        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                        <div class="form-group">
                            <label for="Nombre" class="control-label col-md-2">Correo Electrónico @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                            <div class="col-md-10">
                                @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="Nombre" class="control-label col-md-2">Contraseña @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                            <div class="col-md-10">
                                @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <div class="checkbox">
                                    @Html.CheckBoxFor(Function(m) m.RememberMe)
                                    @Html.LabelFor(Function(m) m.RememberMe)
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <input type="submit" value="Iniciar Sesión" class="btn btn-default" />
                            </div>
                        </div>

                        @* Habilite esta opción después de habilitar la confirmación de la cuenta para la función de restablecimiento de contraseña
                        <p>
                            @Html.ActionLink("¿Ha olvidado su contraseña?", "ForgotPassword")
                        </p>*@
                    </text>
                End Using
            </section>
        </div>
    </div>
</section>
<p>
    <a class="btn btn-default btn-sm" href="/Account/Register">Registrarse</a>

</p>
<div class="col-md-4">
    <section id="socialLoginForm">
        @Html.Partial("_ExternalLoginsListPartial", New ExternalLoginListViewModel With {.ReturnUrl = ViewBag.ReturnUrl})
    </section>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
