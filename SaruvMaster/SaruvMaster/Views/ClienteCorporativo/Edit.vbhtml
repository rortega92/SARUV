@ModelType SaruvMaster.ClienteCorporativo
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h3>Cliente Corporativo</h3>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Editar</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        @Html.HiddenFor(Function(model) model.ID)

        <div class="form-group">
            <label for="Nombres" class="control-label col-md-2">Nombre  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Nombres, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Nombres, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <label for="Apellidos" class="control-label col-md-2">Apellidos  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Apellidos, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Apellidos, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <label for="NumeroIdentidad" class="control-label col-md-2">Número de Identidad  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NumeroIdentidad, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.NumeroIdentidad, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <label for="CorreoElectronico" class="control-label col-md-2">Correo  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.CorreoElectronico, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.CorreoElectronico, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <label for="Telefono" class="control-label col-md-2">Teléfono  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Telefono, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Telefono, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <label for="EmpresaID" class="control-label col-md-2">Empresa  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
            <div class="col-md-10">
                @Html.DropDownList("EmpresaID", Nothing, htmlAttributes:= New With { .class = "form-control" })
                @Html.ValidationMessageFor(Function(model) model.EmpresaID, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Guardar" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
