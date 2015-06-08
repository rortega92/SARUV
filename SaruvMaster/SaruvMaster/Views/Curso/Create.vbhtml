@ModelType SaruvMaster.Curso
@Code
    ViewData("Title") = "Create"
End Code

<script>
    $(document).ready(function Test() {
        $("#Submit").on("click", function () {
            var startDate = document.getElementById("FechaInicio").value;
            var endDate = document.getElementById("FechaFinal").value;
            //Diferencia en milissegundos
            var timeDiff = Date.parse(endDate) - Date.parse(startDate);
            if (Date.parse(endDate) > Date.parse(startDate)) {
                document.getElementById("finalError").innerHTML = " ";
                return true;
            }
            else {
                if (document.getElementById("cursoNombre").value != "") {
                    document.getElementById("finalError").innerHTML = "La fecha final debe ser mayor a la fecha inicial";
                    document.getElementById("FechaFinal").focus();
                    return false;
                }
            }
        })
        $("#FechaInicio").addClass('form-control text-box single-line valid');
        $("#FechaFinal").addClass('form-control text-box single-line valid');
    })
</script>
<h3>Curso</h3>

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
                        @Html.EditorFor(Function(model) model.Nombres, New With {.htmlAttributes = New With {.class = "form-control"}})
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

                        @Html.JQueryUI().DatepickerFor(Function(model) model.FechaInicio, New With {.htmlAttributes = New With {.class = "form-control", .id = "inicio"}})
                        @Html.ValidationMessageFor(Function(model) model.FechaInicio, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Fecha Final @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                       @Html.JQueryUI().DatepickerFor(Function(model) model.FechaFinal, New With {.htmlAttributes = New With {.class = "form-control", .id = "final", .oninput = "Test()"}})
                    <span style="color:#FF2D55 " id="finalError"></span>
                        @Html.ValidationMessageFor(Function(model) model.FechaFinal, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Periodo @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        <select class="form-control" id="Periodo" name="Periodo">
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">4</option>
                            <option value="4">5</option>
                        </select>
                        @Html.ValidationMessageFor(Function(model) model.Periodo, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Crear" class="btn btn-default" onclick="return Test()" id="Submit" />
                    </div>
                </div>
            </div>
        End Using
    </div>
</section>


<div>
    <a class="btn btn-default btn-sm" href="/Curso/Index">Regresar a la lista</a>
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
