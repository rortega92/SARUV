@ModelType SaruvMaster.AreasDeConocimientoModels
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>AreasDeConocimientoModels</h4>
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
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
