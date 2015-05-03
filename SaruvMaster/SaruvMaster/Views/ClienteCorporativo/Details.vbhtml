﻿@ModelType SaruvMaster.ClienteCorporativo
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code


<div>
    <h3>ClienteCorporativo</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
        </header>
        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Empresa.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nombres)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombres)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Apellidos)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Apellidos)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.NumeroIdentidad)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.NumeroIdentidad)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.CorreoElectronico)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.CorreoElectronico)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Telefono)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Telefono)
                </dd>

            </dl>
        </div>
    </section>
</div>
        <p>
            @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
            @Html.ActionLink("Back to List", "Index")
        </p>
