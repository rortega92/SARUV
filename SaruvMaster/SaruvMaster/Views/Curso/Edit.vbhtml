@ModelType SaruvMaster.Curso
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
<!DOCTYPE html>

<script>
    function Test() {

        var startDate = document.getElementById("inicio").value;
        var endDate = document.getElementById("final").value;
        //Difference in milliseconds
        var timeDiff = Date.parse(endDate) - Date.parse(startDate);
        if (Date.parse(endDate) > Date.parse(startDate)) {
            document.getElementById("finalError").innerHTML = " ";
            return true;
        }
        else {
            if (document.getElementById("cursoNombre").value != "") {
                document.getElementById("finalError").innerHTML = "La Fecha final tiene que ser después de la fecha Inícial";
                document.getElementById("final").focus();
                return false;
            }
        }
    }
</script>


<h3>Curso</h3>
<section class="panel">
    <header class="panel-heading">
        Editar
    </header>
    <div class="panel-body">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">
                <hr />
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                @Html.HiddenFor(Function(model) model.ID)
                @Html.HiddenFor(Function(model) model.FechaCreacion)
                @Html.HiddenFor(Function(model) model.FechaModificacion)

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Nombre @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Nombres, New With {.htmlAttributes = New With {.class = "form-control", .id = "cursoNombre"}})
                        @Html.ValidationMessageFor(Function(model) model.Nombres, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Área de Conocimiento @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("AreaDeConocimientoID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.AreaDeConocimientoID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Modalidad de Curso @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("ModalidadDeCursoID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.ModalidadDeCursoID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Encargado de Validación @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("EncargadoDeValidacionID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.EncargadoDeValidacionID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Fecha Inicio @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.FechaInicio, New With {.htmlAttributes = New With {.class = "form-control", .id = "inicio"}})
                        @Html.ValidationMessageFor(Function(model) model.FechaInicio, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.FechaFinal, New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.FechaFinal, New With {.htmlAttributes = New With {.class = "form-control", .id = "final", .oninput = "Test()"}})
                        @Html.ValidationMessageFor(Function(model) model.FechaFinal, "", New With {.class = "text-danger"})
                        <span style="color:#b94a48 " id="finalError"></span>
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Periodo, New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        <select class="form-control" id="Periodo" name="Periodo">
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                        </select>
                        @Html.ValidationMessageFor(Function(model) model.Periodo, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Editar" class="btn btn-default" onclick="return Test()" />
                    </div>
                </div>
            </div>
        End Using        
    </div>
</section>
<div>
    @Html.ActionLink("Regresar a la lista", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
