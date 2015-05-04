@ModelType IEnumerable(Of Curso)

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <p>
        @Html.ActionLink("Create New", "Create")
    </p>
    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento.Nombre)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.EncargadoDeValidacion.Nombre)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso.Nombre)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Nombres)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.FechaInicio)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.FechaFinal)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Periodo)
            </th>
            <th></th>
        </tr>
    
    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.AreaDeConocimiento.Nombre)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.EncargadoDeValidacion.Nombre)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.ModalidadDeCurso.Nombre)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Nombres)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.FechaInicio)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.FechaFinal)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Periodo)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
                @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
            </td>
        </tr>
    Next
    
    </table>
</body>
</html>
