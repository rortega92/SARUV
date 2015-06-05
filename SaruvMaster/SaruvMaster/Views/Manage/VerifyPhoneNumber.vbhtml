@ModelType VerifyPhoneNumberViewModel
@Code
    ViewBag.Title = "Verificar número de teléfono"
End Code

<h3>@ViewBag.Title.</h3>
<section class="panel">
    <header class="panel-heading">
        Introduzca el código de verificación
    </header>
    <div class="panel-body">
        <div class="form-horizontal">

            @Using Html.BeginForm("VerifyPhoneNumber", "Manage", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                @Html.AntiForgeryToken()
                @Html.Hidden("phoneNumber", Model.PhoneNumber)
                @<text>

                    <h5>@ViewBag.Status</h5>
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
