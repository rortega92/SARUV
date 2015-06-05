@ModelType ForgotPasswordViewModel
@Code
    ViewBag.Title = "¿Olvidó la contraseña?"
End Code

<h3>@ViewBag.Title</h3>
<section class="panel">
    <header class="panel-heading">Especifique su correo electrónico.</header>
    <div class="panel-body">
        <div class="form-horizontal">
            <hr />
            @Using Html.BeginForm("ForgotPassword", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                @Html.AntiForgeryToken()
                @<text>                   
                    @Html.ValidationSummary("", New With {.class = "text-danger"})
                    <div class="form-group">
                        <label for="Nombre" class="control-label col-md-2">Correo Electrónico @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                        <div class="col-md-10">
                            @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <input type="submit" class="btn btn-default" value="Vínculo de correo electrónico" />
                        </div>
                    </div>
                </text>
            End Using

            @section Scripts
                @Scripts.Render("~/bundles/jqueryval")
            End Section
        </div>
    </div>
</section>
