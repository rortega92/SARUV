﻿@ModelType SaruvMaster.Curso
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Curso</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AreaDeConocimiento.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.EncargadoDeValidacion.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EncargadoDeValidacion.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ModalidadDeCurso.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombres)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombres)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FechaInicio)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FechaInicio)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FechaFinal)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FechaFinal)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Periodo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Periodo)
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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
