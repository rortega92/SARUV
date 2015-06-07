@ModelType RegisterViewModel
@Code
    ViewBag.Title = "Registrarse"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code 


<h3>@ViewBag.Title</h3>
<section class="panel">
    <header class="panel-heading">
        Registrar Usuario
    </header>
    <div class="panel-body">
        @Using (Html.BeginForm("Register", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"}))
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">
                <hr />
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Nombre @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Nombre, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Nombre, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Apellido @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>

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
                    <label for="Nombre" class="control-label col-md-2">Correo Electronico @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>

                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
                    </div>
                </div>

                 <div class="form-group">
                     <label for="Nombre" class="control-label col-md-2">Contraseña @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                   
                     <div class="col-md-10">
                         @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                     </div>
                 </div>

                 <div class="form-group">
                     <label for="Nombre" class="control-label col-md-2">Confirmar Contraseña @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                     <div class="col-md-10">
                       
                         @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
                     </div>
                 </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Registrar" class="btn btn-default" />
                    </div>
                </div>
            </div>
        End Using
    </div>
</section>


@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/Scripts/register.js")
End Section
