@ModelType ResetPasswordViewModel
@Code
    ViewBag.Title = "Restablecer contraseña"
End Code

<h3>@ViewBag.Title.</h3>
<section class="panel">
    <header class="panel-heading"> Restablezca la contraseña.  
    </header>
    <div class="panel-body">
        <div class="form-horizontal">
            <hr />
            @Using Html.BeginForm("ResetPassword", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})

                @Html.AntiForgeryToken()

                @<text>
                    
                    <hr />
                    @Html.ValidationSummary("", New With {.class = "text-danger"})
                    @Html.HiddenFor(Function(m) m.Code)
                    <div class="form-group">
                        @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 control-label"})
                        <div class="col-md-10">
                            @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
                        </div>
                    </div>
                    <div class="form-group">
                        @Html.LabelFor(Function(m) m.Password, New With {.class = "col-md-2 control-label"})
                        <div class="col-md-10">
                            @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                        </div>
                    </div>
                    <div class="form-group">
                        @Html.LabelFor(Function(m) m.ConfirmPassword, New With {.class = "col-md-2 control-label"})
                        <div class="col-md-10">
                            @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <input type="submit" class="btn btn-default" value="Restablecer" />
                        </div>
                    </div>
                </text>
            End Using
        </div>
    </div>
</section>

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
