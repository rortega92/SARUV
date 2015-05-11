@ModelType Recurso

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
    @Using (Html.BeginForm()) 
        @Html.AntiForgeryToken()
        
        @<div class="form-horizontal">
            <h4>Recurso</h4>
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
                @Html.LabelFor(Function(model) model.TipoDeRecursoID, "TipoDeRecursoID", New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.DropDownList("TipoDeRecursoID", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.TipoDeRecursoID)
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
                @Html.LabelFor(Function(model) model.EmpresaID, "EmpresaID", New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.DropDownList("EmpresaID", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.EmpresaID)
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.CursoID, "CursoID", New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.DropDownList("CursoID", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.CursoID)
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.ClienteCorporativoID, "ClienteCorporativoID", New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.DropDownList("ClienteCorporativoID", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.ClienteCorporativoID)
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.DocenteID, "DocenteID", New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.DropDownList("DocenteID", String.Empty)
                    @Html.ValidationMessageFor(Function(model) model.DocenteID)
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
                @Html.LabelFor(Function(model) model.Prioridad, New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Prioridad)
                    @Html.ValidationMessageFor(Function(model) model.Prioridad)
                </div>
            </div>
    
            <div class="form-group">
                @Html.LabelFor(Function(model) model.FechaEntrega, New With { .class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.FechaEntrega)
                    @Html.ValidationMessageFor(Function(model) model.FechaEntrega)
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
