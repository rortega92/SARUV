@ModelType SaruvMaster.Recurso
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
<script>
    $("#FechaEntrega").addClass('form-control text-box single-line valid');
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
                if ($(this).html() == "Presencial") {
                    $("label[for=EmpresaID], #EmpresaID").hide();
                    $("label[for=ClienteCorporativoID], #ClienteCorporativoID").hide();
                    $("label[for=DocenteID], #DocenteID").show();
                }
                if ($(this).html() == "Corporativo" || $(this).html() == "Corporativa") {
                    $("label[for=EmpresaID], #EmpresaID").show();
                    $("label[for=ClienteCorporativoID], #ClienteCorporativoID").show();
                    $("label[for=DocenteID], #DocenteID").hide();
                }

            });
        }).change();
    });
</script>





<h3>Recurso</h3>

<section class="panel">
    <header class="panel-heading">
        Editar
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
                         @Html.JQueryUI().DatepickerFor(Function(model) model.FechaEntrega, New With {.htmlAttributes = New With {.class = "form-control", .id = "fechaEntrega"}}).MinDate(DateTime.Today)
                         <span style="color:#FF2D55 " id="finalError"></span>
                          @Html.ValidationMessageFor(Function(model) model.FechaEntrega, "", New With {.class = "text-danger"})
                     </div>
                 </div>

                 <div class="form-group">
                     <div class="col-md-offset-2 col-md-10">
                         <input type="submit" value="Editar" class="btn btn-default" id="Submit" />
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
