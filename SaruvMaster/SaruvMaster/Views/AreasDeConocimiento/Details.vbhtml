@ModelType SaruvMaster.AreasDeConocimientoModels
@Code
    ViewData("Title") = "Detalles"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h3>Detalles</h3>

<div>
    <h4>Area de conocimiento</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AreaDeConocimiento)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Regresar a la lista", "Index")
</p>
