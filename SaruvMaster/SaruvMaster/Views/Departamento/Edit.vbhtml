﻿@ModelType SaruvMaster.Departamento
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h3>Departamento</h3>
<section class="panel">
    <header class="panel-heading">
        Editar
    </header>
    <div class="panel-body">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
            @<div class="form-horizontal">
                <h4>Departamento</h4>
                <hr />
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                @Html.HiddenFor(Function(model) model.ID)
                @Html.HiddenFor(Function(model) model.FechaCreacion)
                @Html.HiddenFor(Function(model) model.FechaModificacion)

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Departamento @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Nombre, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Nombre, "", New With {.class = "text-danger"})
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
    <button class="btn btn-default btn-sm"> @Html.ActionLink("Regresar a la lista", "Index") </button>
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
