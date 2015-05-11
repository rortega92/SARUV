@ModelType Recurso

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Details</title>
</head>
<body>
    <div>
        <h4>Recurso</h4>
        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.ClienteCorporativo.Nombres)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.ClienteCorporativo.Nombres)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Curso.Nombres)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Curso.Nombres)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Docente.Nombres)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Docente.Nombres)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Empresa.Nombre)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso.Nombre)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.ModalidadDeCurso.Nombre)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.TipoDeRecurso.Nombre)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.TipoDeRecurso.Nombre)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Nombre)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Nombre)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Duracion)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Duracion)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Prioridad)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Prioridad)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.FechaEntrega)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.FechaEntrega)
            </dd>
    
        </dl>
    </div>
    <p>
        @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
        @Html.ActionLink("Back to List", "Index")
    </p>
</body>
</html>
