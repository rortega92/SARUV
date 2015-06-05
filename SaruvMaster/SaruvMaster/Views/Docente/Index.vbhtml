@ModelType IEnumerable(Of SaruvMaster.Docente)
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
            @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Facultad.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nombres)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Apellidos)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NumeroTalentoHumano)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.correoElectronico)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.telefono)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FechaCreacion)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FechaModificacion)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AreaDeConocimiento.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Facultad.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nombres)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Apellidos)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NumeroTalentoHumano)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.correoElectronico)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.telefono)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FechaCreacion)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FechaModificacion)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
