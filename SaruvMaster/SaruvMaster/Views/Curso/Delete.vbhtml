@ModelType Curso

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
        <h4>Curso</h4>
        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento.Nombre)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.AreaDeConocimiento.Nombre)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.EncargadoDeValidacion.Nombre)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.EncargadoDeValidacion.Nombre)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso.Nombre)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.ModalidadDeCurso.Nombre)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Nombres)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Nombres)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.FechaInicio)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.FechaInicio)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.FechaFinal)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.FechaFinal)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Periodo)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Periodo)
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
