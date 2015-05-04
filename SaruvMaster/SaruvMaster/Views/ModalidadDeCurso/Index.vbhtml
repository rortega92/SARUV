@ModelType IEnumerable(Of ModalidadDeCurso)

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
                @Html.DisplayNameFor(Function(model) model.Nombre)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Duracion)
            </th>
            <th></th>
        </tr>
    
    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Nombre)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Duracion)
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
