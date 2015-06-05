@ModelType IEnumerable(Of SaruvMaster.EventosEstudio)
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
            @Html.DisplayNameFor(Function(model) model.ClienteCorporativo.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Docente.Nombres)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Evento)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FechaReserva)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.HoraInicio)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.HoraFinal)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IsDeleted)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ClienteCorporativo.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Docente.Nombres)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Evento)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FechaReserva)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.HoraInicio)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.HoraFinal)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IsDeleted)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
