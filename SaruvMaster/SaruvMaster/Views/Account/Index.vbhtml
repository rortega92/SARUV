@ModelType IEnumerable(Of SaruvMaster.ApplicationUser)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Register")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Apellido)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Departamento)
        </th>
        <th>
            Jefe
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FechaCreacion)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FechaModificacion)
        </th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Nombre)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Apellido)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Email)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.UserName)
            </td>

            <td>
                @Code
                Dim db As New Connection
                Dim S = db.Departamento.Where(Function(e) e.ID = item.DepartamentoID)
                If S.ToArray().Length > 0 Then
                ViewBag.NombreDepartamento = S.First().Nombre
                Else
                ViewBag.NombreDepartamento = "N/A"
                End If
                End Code
                @ViewBag.NombreDepartamento
            </td>
            <td>
                @If item.isJefe = 0 Then
                ViewBag.jefe = "No"
                Else
                ViewBag.jefe = "Si"
                End If
                @ViewBag.jefe
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.FechaCreacion)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.FechaModificacion)
            </td>
        </tr>
    Next

</table>
