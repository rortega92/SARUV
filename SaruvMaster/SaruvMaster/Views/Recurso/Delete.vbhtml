@ModelType Recurso

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Delete</title>
</head>
<body>
    <h3>Are you sure you want to delete this?</h3>
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
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
    
            @<div class="form-actions no-color">
                <input type="submit" value="Delete" class="btn btn-default" /> |
                @Html.ActionLink("Back to List", "Index")
            </div>
        End Using
    </div>
</body>
</html>
