@ModelType IEnumerable(Of SaruvMaster.Usuario)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h2>Index</h2>

<p>
    <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Usuario/Create">Crear Nuevo</a>
    <a style="color: #007AFF" class="btn btn-default btn-sm" href="javascript:void(0)" id="filterButton"> Filtrar</a>
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Departamento.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.RolPorDepartamento.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Apellido)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.correo)
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
            @Html.DisplayFor(Function(modelItem) item.Departamento.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.RolPorDepartamento.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Apellido)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.correo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FechaCreacion)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FechaModificacion)
        </td>
        <td>
            <button class="btn btn-default btn-sm"> @Html.ActionLink("Editar", "Edit", New With {.id = item.ID})</button>
            <button class="btn btn-default btn-sm"> @Html.ActionLink("Detalles ", "Details", New With {.id = item.ID}) </button>
            <button class="btn btn-default btn-sm"> @Html.ActionLink("Detalles", "Delete", New With {.id = item.ID})</button>
        </td>
    </tr>
Next

</table>
