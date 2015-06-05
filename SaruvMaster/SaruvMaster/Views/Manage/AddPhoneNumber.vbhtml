@ModelType AddPhoneNumberViewModel
@Code
    ViewBag.Title = "Número de teléfono"
End Code

<h3>@ViewBag.Title.</h3>
<section class="panel">
    <header class="panel-heading">
        Agregar un número de teléfono
    </header>
    <div class="panel-body">
        <div class="form-horizontal">

            @Using Html.BeginForm("AddPhoneNumber", "Manage", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                @Html.AntiForgeryToken()
                @<text>

                    <hr />
                    @Html.ValidationSummary("", New With {.class = "text-danger"})
                    <div class="form-group">
                        <label for="Nombre" class="control-label col-md-2">Número de teléfono @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                        <div class="col-md-10">
                            @Html.TextBoxFor(Function(m) m.Number, New With {.class = "form-control"})
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <input type="submit" class="btn btn-default" value="Enviar" />
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
