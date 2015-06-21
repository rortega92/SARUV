@ModelType IEnumerable(Of SaruvMaster.Tarea)
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
            @Html.DisplayNameFor(Function(model) model.UsuarioID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Descripcion)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Fecha)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Usuario.Nombre)
            @Html.DisplayFor(Function(modelItem) item.Usuario.Apellido)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Descripcion)
        </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.Fecha)
         </td>
    </tr>
Next

</table>
