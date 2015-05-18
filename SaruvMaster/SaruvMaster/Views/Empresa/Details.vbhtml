@ModelType SaruvMaster.Empresa
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h2>Detalles</h2>

<div>
    <h4>Empresa</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Direccion)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Direccion)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Telefono)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Telefono)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Ciudad)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Ciudad)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Departamento)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Departamento)
        </dd>

    </dl>
</div>
<p>
    <button class="btn btn-default btn-sm"> @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID}) </button>   
    <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Empresa/Index">Regresar a la lista</a>
</p>
