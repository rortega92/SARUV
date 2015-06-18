@ModelType IEnumerable(Of SaruvMaster.CicloDeVida)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Recurso.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Usuario.Email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Estado)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FechaModificacion)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Observacion)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Recurso.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Usuario.Email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Estado)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FechaModificacion)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Observacion)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
