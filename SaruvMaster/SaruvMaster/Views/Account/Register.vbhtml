@ModelType RegisterViewModel
@Code
    ViewBag.Title = "Register"
End Code

<h2>@ViewBag.Title.</h2>

@Using Html.BeginForm("Register", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})

    @Html.AntiForgeryToken()

    @<text>
    <h4>Create a new account.</h4>
    <hr />
    @Html.ValidationSummary("", New With {.class = "text-danger"})
<div class="form-group">
    @Html.LabelFor(Function(model) model.Nombre, htmlAttributes:=New With {.class = "control-label col-md-2"})
    <div class="col-md-10">
        @Html.EditorFor(Function(model) model.Nombre, New With {.htmlAttributes = New With {.class = "form-control"}})
        @Html.ValidationMessageFor(Function(model) model.Nombre, "", New With {.class = "text-danger"})
    </div>
</div>

<div class="form-group">
    @Html.LabelFor(Function(model) model.Apellido, htmlAttributes:=New With {.class = "control-label col-md-2"})
    <div class="col-md-10">
        @Html.EditorFor(Function(model) model.Apellido, New With {.htmlAttributes = New With {.class = "form-control"}})
        @Html.ValidationMessageFor(Function(model) model.Apellido, "", New With {.class = "text-danger"})
    </div>
</div>

<div class="form-group">
    <label for="Administrador" class="control-label col-md-2">Tipo de Usuario @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
    <div class="col-md-10">
        <select class="form-control" id="isAdmin" name="isAdmin">
            <option value="Administrador">Administrador</option>
            <option value="Estándar">Estándar</option>
        </select>
    </div>
</div>

<div class="form-group hidden">
    <label for="isJefe" class="control-label col-md-2">Cargo en Departamento @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
    <div class="col-md-10">
        <select class="form-control" id="isJefe" name="isJefe">
            <option value="Jefe">Jefe</option>
            <option value="Regular">Regular</option>
        </select>
    </div>
</div>

<div class="form-group hidden">
    @Html.LabelFor(Function(model) model.DepartamentoID, "DepartamentoID", htmlAttributes:=New With {.class = "control-label col-md-2"})
    <div class="col-md-10">
        @Html.DropDownList("DepartamentoID", Nothing, htmlAttributes:=New With {.class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.DepartamentoID, "", New With {.class = "text-danger"})
    </div>
</div>

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
            <input type="submit" class="btn btn-default" value="Register" id="Submit" />
        </div>
    </div>
    </text>
End Using

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/Scripts/register.js")
End Section
