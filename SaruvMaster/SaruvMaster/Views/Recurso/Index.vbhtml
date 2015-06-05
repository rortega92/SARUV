@ModelType IEnumerable(Of SaruvMaster.Recurso)
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
            @Html.DisplayNameFor(Function(model) model.Curso.Nombres)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Docente.Nombres)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TipoDeRecurso.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Duracion)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Prioridad)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FechaEntrega)
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
            @Html.DisplayFor(Function(modelItem) item.ClienteCorporativo.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Curso.Nombres)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Docente.Nombres)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Empresa.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ModalidadDeCurso.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TipoDeRecurso.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Duracion)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Prioridad)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FechaEntrega)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FechaCreacion)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FechaModificacion)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
