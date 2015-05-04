@ModelType ModalidadDeCurso

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Create</title>
</head>
<body>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/jqueryval")
    @Using (Html.BeginForm()) 
        @Html.AntiForgeryToken()
        
        @<div class="form-horizontal">
            <h4>ModalidadDeCurso</h4>
            <hr />
            @Html.ValidationSummary(true)
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Nombre, New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Nombre)
                    @Html.ValidationMessageFor(Function(model) model.Nombre)
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Duracion, New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Duracion)
                    @Html.ValidationMessageFor(Function(model) model.Duracion)
                </div>
            </div>
    
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Create" class="btn btn-default" />
                </div>
            </div>
        </div>
    End Using
    
    <div>
        @Html.ActionLink("Back to List", "Index")
    </div>
</body>
</html>
