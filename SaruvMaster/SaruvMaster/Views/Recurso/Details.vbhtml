﻿@ModelType SaruvMaster.Recurso
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code


<div>
    <h3>Recurso</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
        </header>
        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.ClienteCorporativo.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.ClienteCorporativo.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Curso.Nombres)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Curso.Nombres)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Docente.Nombres)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Docente.Nombres)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Empresa.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.ModalidadDeCurso.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.TipoDeRecurso.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.TipoDeRecurso.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Duracion)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Duracion)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Prioridad)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Prioridad)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.FechaEntrega)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.FechaEntrega)
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
    </section>
</div>
<p>
    <a class="btn btn-default btn-sm" href="@Url.Action("Edit", New With {.id = Model.ID})"><span class="glyphicon glyphicon-pencil"></span> Editar</a>
    <a class="btn btn-default btn-sm" href="/Recurso/Index">Regresar a la lista</a>
</p>