@ModelType Curso

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Edit</title>
</head>
<body>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        
        @<div class="form-horizontal">
            <h4>Curso</h4>
            <hr />
            @Html.ValidationSummary(true)
            @Html.HiddenFor(Function(model) model.ID)
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Nombres, New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Nombres)
                    @Html.ValidationMessageFor(Function(model) model.Nombres)
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.AreaDeConocimientoID, "AreaDeConocimientoID", New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.DropDownList("AreaDeConocimientoID", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.AreaDeConocimientoID)
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.ModalidadDeCursoID, "ModalidadDeCursoID", New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.DropDownList("ModalidadDeCursoID", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.ModalidadDeCursoID)
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.EncargadoDeValidacionID, "EncargadoDeValidacionID", New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.DropDownList("EncargadoDeValidacionID", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.EncargadoDeValidacionID)
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.FechaInicio, New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.FechaInicio)
                    @Html.ValidationMessageFor(Function(model) model.FechaInicio)
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.FechaFinal, New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.FechaFinal)
                    @Html.ValidationMessageFor(Function(model) model.FechaFinal)
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Periodo, New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Periodo)
                    @Html.ValidationMessageFor(Function(model) model.Periodo)
                </div>
            </div>
    
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Save" class="btn btn-default" />
                </div>
            </div>
        </div>
    End Using
    
    <div>
        @Html.ActionLink("Back to List", "Index")
    </div>
</body>
</html>
