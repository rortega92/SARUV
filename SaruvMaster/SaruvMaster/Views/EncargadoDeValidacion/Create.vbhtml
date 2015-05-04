@ModelType SaruvMaster.EncargadoDeValidacion
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h3>Encargado de Validación</h3>
<section class="panel">
    <header class="panel-heading">
        Crear
    </header>
    <div class="panel-body">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">
                <hr />
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Nombre @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Nombre, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Nombre, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="FacultadID" class="control-label col-md-2">Facultad @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("FacultadID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.FacultadID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Telefono" class="control-label col-md-2">Teléfono @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Telefono, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Telefono, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Extensión" class="control-label col-md-2">Extensión (Si aplica)</label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Extensión, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Extensión, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="correoElectronico" class="control-label col-md-2">Correo Electrónico @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.correoElectronico, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.correoElectronico, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Crear" class="btn btn-default" />
                    </div>
                </div>
            </div>
        End Using
    </div>
</section>

<div>
    @Html.ActionLink("Regresar a la Lista", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
