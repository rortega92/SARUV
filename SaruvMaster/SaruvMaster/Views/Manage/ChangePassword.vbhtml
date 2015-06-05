@ModelType ChangePasswordViewModel
@Code
    ViewBag.Title = "Cambiar contraseña"
End Code

<h3>@ViewBag.Title.</h3>

<section class="panel">
    <header class="panel-heading">
        Formulario para cambiar la contraseña.
    </header>
    <div class="panel-body">
        <div class="form-horizontal">
            @Using Html.BeginForm("ChangePassword", "Manage", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                @Html.AntiForgeryToken()

                @<text>

                    
                    @Html.ValidationSummary("", New With {.class = "text-danger"})
                    <div class="form-group">
                        <label for="Nombre" class="control-label col-md-2">Contraseña actual @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                        <div class="col-md-10">
                            @Html.PasswordFor(Function(m) m.OldPassword, New With {.class = "form-control"})
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="Nombre" class="control-label col-md-2">Nueva contraseña @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                        <div class="col-md-10">
                            @Html.PasswordFor(Function(m) m.NewPassword, New With {.class = "form-control"})
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="Nombre" class="control-label col-md-2">Confirme la contraseña @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                        <div class="col-md-10">
                            @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <input type="submit" value="Cambiar contraseña" class="btn btn-default" />
                        </div>
                    </div>
                </text>
            End Using
        </div>
    </div>
</section>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
