@ModelType SaruvMaster.Recurso
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h3>Recurso</h3>

<section class="panel">
    <header class="panel-heading">
        Editar
    </header>
    <div class="panel-body">


        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">
                <h4>Recurso</h4>
                <hr />
                @Html.ValidationSummary(True)
                @Html.HiddenFor(Function(model) model.Id)

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Nombre  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Nombre)
                        @Html.ValidationMessageFor(Function(model) model.Nombre)
                    </div>
                </div>

                <div class="form-group">
                    <label for="TipoDeRecursoID" class="control-label col-md-2">Tipo de Recurso  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("TipoDeRecursoID", String.Empty)
                        @Html.ValidationMessageFor(Function(model) model.TipoDeRecursoID)
                    </div>
                </div>

                <div class="form-group">
                    <label for="ModalidadDeCursoID" class="control-label col-md-2">Modalidad  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("ModalidadDeCursoID", String.Empty)
                        @Html.ValidationMessageFor(Function(model) model.ModalidadDeCursoID)
                    </div>
                </div>

                <div class="form-group">
                    <label for="EmpresaID" class="control-label col-md-2">Empresa  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("EmpresaID", String.Empty)
                        @Html.ValidationMessageFor(Function(model) model.EmpresaID)
                    </div>
                </div>

                <div class="form-group">
                    <label for="CursoID" class="control-label col-md-2">Curso  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("CursoID", String.Empty)
                        @Html.ValidationMessageFor(Function(model) model.CursoID)
                    </div>
                </div>

                <div class="form-group">
                    <label for="ClienteCorporativoID" class="control-label col-md-2">Cliente Corporativo  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("ClienteCorporativoID", String.Empty)
                        @Html.ValidationMessageFor(Function(model) model.ClienteCorporativoID)
                    </div>
                </div>

                <div class="form-group">
                    <label for="DocenteID" class="control-label col-md-2">Docente  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("DocenteID", String.Empty)
                        @Html.ValidationMessageFor(Function(model) model.DocenteID)
                    </div>
                </div>

                <div class="form-group">
                    <label for="Duracion" class="control-label col-md-2">Duración  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Duracion)
                        @Html.ValidationMessageFor(Function(model) model.Duracion)
                    </div>
                </div>

                <div class="form-group">
                    <label for="Prioridad" class="control-label col-md-2">Prioridad  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Prioridad)
                        @Html.ValidationMessageFor(Function(model) model.Prioridad)
                    </div>
                </div>

                <div class="form-group">
                    <label for="FechaEntrega" class="control-label col-md-2">Fecha de Entrega  @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.FechaEntrega)
                        @Html.ValidationMessageFor(Function(model) model.FechaEntrega)
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Guardar" class="btn btn-default" />
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
