@ModelType IEnumerable(Of SaruvMaster.RolPorDepartamento)
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
            @Html.DisplayNameFor(Function(model) model.Departamento.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nombre)
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
            @Html.DisplayFor(Function(modelItem) item.Nombre)
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
        </td>
    </tr>
Next

</table>
