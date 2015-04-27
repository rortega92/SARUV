@ModelType IEnumerable(Of SaruvMaster.ClienteCorporativo)
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
            @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nombres)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Apellidos)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NumeroIdentidad)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CorreoElectronico)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Telefono)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Empresa.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nombres)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Apellidos)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NumeroIdentidad)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CorreoElectronico)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Telefono)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
