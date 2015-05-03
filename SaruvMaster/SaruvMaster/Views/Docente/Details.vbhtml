@ModelType SaruvMaster.Docente
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h2>Detalles</h2>

<div>
    <h4>Docente</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AreaDeConocimiento.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Facultad.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Facultad.Nombre)
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
            @Html.DisplayNameFor(Function(model) model.NumeroTalentoHumano)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NumeroTalentoHumano)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.correoElectronico)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.correoElectronico)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.telefono)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.telefono)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Resgresar a la lista", "Index")
</p>
