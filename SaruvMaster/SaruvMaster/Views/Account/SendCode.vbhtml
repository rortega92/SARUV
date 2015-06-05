@ModelType SendCodeViewModel
@Code
    ViewBag.Title = "Enviar"
End Code

<h3>@ViewBag.Title.</h3>
<section class="panel">
    <header class="panel-heading">Enviar código de verificación 
    </header>
    <div class="panel-body">
        <div class="form-horizontal">

            @Using Html.BeginForm("SendCode", "Account", New With {.ReturnUrl = Model.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                @Html.AntiForgeryToken()
                @Html.Hidden("rememberMe", Model.RememberMe)
                @<text>
                    Enviar código de verificación
                    <hr />
                    <div class="row">
                        <div class="col-md-8">
                            Seleccione el proveedor de autenticación en dos fases:
                            @Html.DropDownListFor(Function(model) model.SelectedProvider, Model.Providers)
                            <input type="submit" value="Enviar" class="btn btn-default" />
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
