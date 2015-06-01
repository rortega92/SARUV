@ModelType RegisterViewModel
@Code
    ViewBag.Title = "Registrarse"
End Code
<script>
    $(document).ready(function () {
        $("#DepartamentoID").change(function () {
            $.ajax({
                type: "GET",
                url: "getRolesByNombreDepartamento",
                data: {"nombreDepartamento":$("#DepartamentoID option:selected").html()},
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $("#RolPorDepartamentoID").empty()
                    $.each(msg, function () {
                        $("#RolPorDepartamentoID").append($("<option></option>").val(this['ID']).html(this['Nombre']));
                    });
                },
                error: function() {
                    alert("An error has occurred during processing your request.");
                }
            });
        }).change()


    });
</script>   
<h2>@ViewBag.Title.</h2>

<section class="panel">
    <header class="panel-heading">
        Crear
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
                        <input type="submit" value="Create" class="btn btn-default" />
                    </div>
                </div>
            </div>
        End Using
    </div>
</section>

<div>
    <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Usuario/Index">Regresar a la lista</a>

</div>

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
