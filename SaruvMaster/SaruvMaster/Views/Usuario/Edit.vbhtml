﻿@ModelType SaruvMaster.Usuario
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
<script>
    $(document).ready(function () {
        $("#DepartamentoID").change(function () {
            $.ajax({
                type: "GET",
                url: "/Usuario/getRolesByNombreDepartamento",
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


<h3>Usuario</h3>
<section class="panel">
    <header class="panel-heading">
        Editar
    </header>
    <div class="panel-body">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()



            @<div class="form-horizontal">
                <hr />
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                @Html.HiddenFor(Function(model) model.ID)
                @Html.HiddenFor(Function(model) model.FechaCreacion)
                @Html.HiddenFor(Function(model) model.FechaModificacion)
                @Html.HiddenFor(Function(model) model.IsDeleted)

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
                        @Html.EditorFor(Function(model) model.correo, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.correo, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Departamento @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("DepartamentoID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.DepartamentoID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Rol por Departamento @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("RolPorDepartamentoID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.RolPorDepartamentoID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Editar" class="btn btn-default" />
                    </div>
                </div>
            </div>
        End Using
    </div>
</section>

<div>
    <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Usuario/Index">Regresar a la lista</a>
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
