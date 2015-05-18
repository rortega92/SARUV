@ModelType  SaruvMaster.Recurso

@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
  
<script>
    $(document).ready(function () {

        $("#FechaEntrega").addClass('form-control text-box single-line valid');
       
    })
</script>

<script>
    function getSelectedValue(ElementID) {
        var element = document.getElementById(ElementID);
        var index = element.options[element.selectedIndex];
        alert(index.innerHTML);
    }
    $(document).ready(function () {
        $("#ModalidadDeCursoID").change(function () {
            $("select option:selected").each(function () {
                if ($(this).html() == "Presencial" || $(this).html() == "Virtual" || $(this).html() == "Internacional") {
                    $("label[for=EmpresaID], #EmpresaID").parent().hide();
                    $("label[for=ClienteCorporativoID], #ClienteCorporativoID").parent().hide();
                    $("label[for=DocenteID], #DocenteID").parent().show();
                    $("label[for=CursoID], #CursoID").parent().show();
                }else
                if ($(this).html() == "Corporativo" || $(this).html() == "Corporativa") {
                    $("label[for=EmpresaID], #EmpresaID").parent().show();
                    $("label[for=ClienteCorporativoID], #ClienteCorporativoID").parent().show();
                    $("label[for=DocenteID], #DocenteID").parent().hide();
                    $("label[for=CursoID], #CursoID").parent().hide();
                }
                
            });
        }).change();
        $("#Submit").click(function () {
            $("select option:selected").each(function () {
                if ($(this).html() == "Presencial" || $(this).html() == "Virtual") {
                    $("#EmpresaID").empty();
                    $("#ClienteCorporativoID").empty();
                }
                if ($(this).html() == "Corporativo" || $(this).html() == "Corporativa") {
                    $("#DocenteID").empty();
                    $("#CursoID").empty();
                }
            });
        });
        $("#EmpresaID").change(function () {
            $.ajax({
                type: "GET",
                url: "getClientesByNombreEmpresa",
                data: {"nombreEmpresa":$("#EmpresaID option:selected").html()},
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    console.log(msg[0])
                    $("#ClienteCorporativoID").empty()
                    $.each(msg, function () {                        
                        $("#ClienteCorporativoID").append($("<option></option>").val(this['ID']).html(this['Nombres']));
                    });
                },
                error: function() {
                    alert("An error has occurred during processing your request.");
                }
            });
        }).change()

    });
</script>   



<h3>Recurso</h3>
<section class="panel">
    <header class="panel-heading">
        Crear
    </header>
    <div class="panel-body">

        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">
                <hr />
                @Html.ValidationSummary(True)
                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Nombre @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Nombre, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Nombre, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="TipoDeRecursoID" class="control-label col-md-2">Tipo de Recurso @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("TipoDeRecursoID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.TipoDeRecursoID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="ModalidadDeCursoID" class="control-label col-md-2">Modalidad @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("ModalidadDeCursoID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.ModalidadDeCursoID, "", New With {.class = "text-danger"})
                                            
                    </div>
                </div>

                <div class="form-group">
                    <label for="EmpresaID" class="control-label col-md-2">Empresa @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("EmpresaID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.EmpresaID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="CursoID" class="control-label col-md-2">Curso @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("CursoID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.CursoID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="ClienteCorporativoID" class="control-label col-md-2">Cliente Corporativo @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("ClienteCorporativoID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.ClienteCorporativoID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="DocenteID" class="control-label col-md-2">Docente @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("DocenteID", Nothing, htmlAttributes:=New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.DocenteID, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Duracion" class="control-label col-md-2">Duración @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Duracion, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Duracion, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <label for="Prioridad" class="control-label col-md-2">Prioridad @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.DropDownList("Prioridad", Nothing, htmlAttributes:=New With {.class = "form-control"})                        
                        @Html.ValidationMessageFor(Function(model) model.Prioridad, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.FechaEntrega, New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.JQueryUI().DatepickerFor(Function(model) model.FechaEntrega, New With {.htmlAttributes = New With {.class = "form-control", .id = "fechaEntraga"}}).MinDate(DateTime.Today)
                       
                        @Html.ValidationMessageFor(Function(model) model.FechaEntrega, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Crear" class="btn btn-default" id="Submit" />
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
