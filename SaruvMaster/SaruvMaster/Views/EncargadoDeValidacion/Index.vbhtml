@ModelType IEnumerable(Of SaruvMaster.EncargadoDeValidacion)
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
            @Html.DisplayNameFor(Function(model) model.Facultad.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Telefono)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Extensión)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.correoElectronico)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Facultad.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Telefono)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Extensión)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.correoElectronico)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
