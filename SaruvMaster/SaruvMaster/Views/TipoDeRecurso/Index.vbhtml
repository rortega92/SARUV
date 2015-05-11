@ModelType IEnumerable(Of SaruvMaster.TipoDeRecurso)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CodigoRecurso)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FechaDeCreacion)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CodigoRecurso)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FechaDeCreacion)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
