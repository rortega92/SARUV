﻿@ModelType SaruvMaster.RolPorDepartamento
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<!DOCTYPE html>

<div>
    <h3>Rol por Departamento</h3>
    <section class="panel">
        <header class="panel-heading">
            ¿Desea eliminar este rol?
        </header>
        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Departamento.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Departamento.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.FechaCreacion)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.FechaCreacion)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.FechaModificacion)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.FechaModificacion)
                </dd>

            </dl>
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-actions no-color">
                    <input type="submit" value="Eliminar" class="btn btn-default" />
                </div>
            End Using
        </div>
    </section>
    <div>
        @Html.ActionLink("Regresar a la lista", "Index")
    </div>
</div>