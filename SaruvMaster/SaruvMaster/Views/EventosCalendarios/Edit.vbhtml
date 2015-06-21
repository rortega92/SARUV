@ModelType SaruvMaster.EventosCalendario
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h3>Eventos</h3>

<section class="panel">
    <header class="panel-heading">
        Editar
    </header>
    <div class="panel-body">
        @Using (Html.BeginForm("Edit", "EventosCalendarios"))
            @Html.AntiForgeryToken()
            @<div class="form-horizontal">
                <hr />
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                <div class="form-group">
                    <label for="Evento" class="control-label col-md-2">Evento @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Evento, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Evento, "", New With {.class = "text-danger"})
                    </div>
                </div>
                


                <div class="form-group">
                    <label for="FechaReserva" class="control-label col-md-2">Fecha de Reserva @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        @Html.JQueryUI().DatepickerFor(Function(model) model.FechaReserva, New With {.htmlAttributes = New With {.class = "form-control", .id = "fechaEntraga"}}).MinDate(DateTime.Today)
                        @Html.ValidationMessageFor(Function(model) model.FechaReserva, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    <label for="HoraInicio" class="control-label col-md-2">Hora Inicio @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        <select name="HoraInicio" class="form-control valid" id="HoraInicio">
                            <option value="10:00">10:00</option>
                            <option value="10:30">10:30</option>
                            <option value="11:00">11:00</option>
                            <option value="11:30">11:30</option>
                            <option value="12:00">12:00</option>
                            <option value="12:30">12:30</option>
                            <option value="13:00">13:00</option>
                            <option value="13:30">13:30</option>
                            <option value="14:00">14:00</option>
                            <option value="14:30">14:30</option>
                            <option value="15:00">15:00</option>
                            <option value="15:30">15:30</option>
                            <option value="16:00">16:00</option>
                            <option value="16:30">16:30</option>
                            <option value="17:00">17:00</option>
                            <option value="17:30">17:30</option>
                        </select>
                        @Html.ValidationMessageFor(Function(model) model.HoraInicio, "", New With {.class = "text-danger"})
                    </div>
                </div>
                <div class="form-group">
                    <label for="HoraFinal" class="control-label col-md-2">Hora Final @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    <div class="col-md-10">
                        <select name="HoraFinal" class="form-control valid" id="HoraFinal">
                            <option value="10:00">10:00</option>
                            <option value="10:30">10:30</option>
                            <option value="11:00">11:00</option>
                            <option value="11:30">11:30</option>
                            <option value="12:00">12:00</option>
                            <option value="12:30">12:30</option>
                            <option value="13:00">13:00</option>
                            <option value="13:30">13:30</option>
                            <option value="14:00">14:00</option>
                            <option value="14:30">14:30</option>
                            <option value="15:00">15:00</option>
                            <option value="15:30">15:30</option>
                            <option value="16:00">16:00</option>
                            <option value="16:30">16:30</option>
                            <option value="17:00">17:00</option>
                            <option value="17:30">17:30</option>
                        </select>
                        @Html.ValidationMessageFor(Function(model) model.HoraFinal, "", New With {.class = "text-danger"})
                    </div>
                </div>
                 <div class="form-group">
                     <label for="Description" class="control-label col-md-2">Descripción @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                     <div class="col-md-10">
                         <textarea typeof="text" id="Description" name="Description" class="form-control"></textarea>

                     </div>
                 </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" id="saveBtn" class="btn btn-default" value="Editar" />
                    </div>
                </div>


            </div>



        End Using

    </div>
</section>
<div>
    <a class="btn btn-default btn-sm" href="/EventosCalendarios/Index">Regresar al Calendario</a>
</div>
<script>

    $("#saveBtn").click(function (event) {
        if ($("#HoraInicio").val() >= $("#HoraFinal").val()) {

            event.stopPropagation();
        }



    });
</script>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section