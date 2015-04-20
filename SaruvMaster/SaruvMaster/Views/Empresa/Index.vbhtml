@ModelType IEnumerable(Of SaruvMaster.EmpresaModels)
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
            @Html.DisplayNameFor(Function(model) model.Direccion)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Telefono)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Ciudad)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Departamento)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Direccion)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Telefono)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Ciudad)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Departamento)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
