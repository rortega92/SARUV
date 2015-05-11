@ModelType SaruvMaster.TipoDeRecurso
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>TipoDeRecurso</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CodigoRecurso)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CodigoRecurso)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FechaInicio)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FechaInicio)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
