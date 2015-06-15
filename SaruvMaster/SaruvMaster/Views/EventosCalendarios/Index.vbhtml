@ModelType SaruvMaster.EventosCalendario
@Code
    ViewData("Title") = "Calendario"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
@Styles.Render("~/Content/css")
@Styles.Render("~/Content/fullcalendarcss")
@Scripts.Render("~/bundles/fullcalendarjs")
@Scripts.Render("~/bundles/jquery")
@Scripts.Render("~/bundles/fullcalendarjs")


<script type="text/javascript">
    $(function () {
        $('#addToggle').click(function (e) {
            $('#eventAdd').modal();
        });
    });

    $(document).ready(function () {

        $('#calendar').fullCalendar({
            theme: false,
            header: {
                left: '',
                center: 'prev title next',
                right: 'month agendaWeek agendaDay'
            },
            eventRender: function (event, element) {

                if (event.isDeleted != 0) return false;
            },
            eventClick: function (event, jsEvent, view) {
                $('#modalTitle').html(event.title);
                if (event.description != null) {
                    $('#modalDescription').html("<label class='control-label col-md-2'>Descripción: </label> " + event.description);
                }
                
                $('#modalHoraInicio').html("<label class='control-label col-md-2'>Inicio: </label> " + event.start);
                $('#modalHoraFinal').html("<label class='control-label col-md-2'>Fin: </label> " + event.end);
                var hreflink1 = $('#modalDelete');
                hreflink1.attr('href', "/EventosCalendarios/Delete/" + event.id);
                var hreflink2 = $('#modalEdit');
                hreflink2.attr('href', "/EventosCalendarios/Edit/" + event.id);
                $('#fullCalModal').modal();
            },
            //defaultView: 'agendaDay',
            editable: false,
            events: "/eventoscalendarios/getevents/"

        });

    });


</script>

<!DOCTYPE html>
<div class="panel-body">
    <div id="fullCalModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span> <span class="sr-only">close</span></button>
                    <h4 id="modalTitle" class="modal-title"></h4>
                </div>
                <div id="modalBody" class="modal-body">
                    <div id="modalDescription" class="form-group"></div>
           
                    <div id="modalHoraInicio" class="form-group"></div>
                    <div id="modalHoraFinal" class="form-group"></div>

                    <div class="form-group">
                        <div class="modal-footer">
                            <a class="btn btn-default btn-sm" id="modalEdit" href="/EventosCalendario/Edit/"><span class="glyphicon glyphicon-trash"></span> Editar</a>
                            <a class="btn btn-default btn-sm" id="modalDelete" href="/EventosCalendario/Delete/"><span class="glyphicon glyphicon-trash"></span> Eliminar</a>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        </div>
                    </div>
                </div>
            </div>



        </div>
    </div>
</div>

<div id="eventAdd" class="modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span> <span class="sr-only">Cerrar</span></button>
                <h4 id="modalTitle" class="modal-title">Add</h4>
            </div>
            <div id="modalBody" class="modal-body">

                @Using (Html.BeginForm("Create", "EventosCalendarios"))
                    @Html.AntiForgeryToken()
                    @<div class="form-horizontal">
                        <hr />
                        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                        <div class="form-group">
                            <label for="Nombre" class="control-label col-md-2">Evento @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                            <div class="col-md-10">
                                @Html.EditorFor(Function(model) model.Evento, New With {.htmlAttributes = New With {.class = "form-control"}})
                                @Html.ValidationMessageFor(Function(model) model.Evento, "", New With {.class = "text-danger"})
                            </div>
                        </div>
                        
                        

                        <div class="form-group">
                            <label for="FechaReserva" class="control-label col-md-2">Fecha de Reserva @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                            <div class="col-md-10">
                                @Html.JQueryUI().DatepickerFor(Function(model) model.FechaReserva, New With {.htmlAttributes = New With {.class = "form-control", .id = "inicio"}}).MinDate(DateTime.Today)
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
                            <div class="modal-footer">
                                <input type="submit" class="btn btn-primary" id="saveBtn" value="Crear" />

                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>

                            </div>
                        </div>


                    </div>



                End Using

            </div>

        </div>
    </div>
</div>


<header class="panel-heading">
    Calendario
</header>
<div class="breadcrumb">
    <a style="color: #007AFF" class="btn btn-default btn-sm" id="addToggle"><span class="glyphicon glyphicon-plus"></span> Crear Evento</a>
</div>
<div id="calendar"></div>

<script>
    $(document).ready(function () {
        $("#clienteForm").hide();
        $("input[name=options]").change(function () {
            if ($(this).val() == "docenteToggle") {
                $("#docenteToggle").attr("checked", "checked")
                $("#clienteToggle").removeAttr('checked');
                $("label[for=ClienteCorporativoID], #ClienteCorporativoID").parent().hide();
                $("label[for=DocenteID], #DocenteID").parent().show();
            } else
                if ($(this).val() == "clienteToggle") {
                    $("#clienteToggle").attr("checked", "checked")
                    $("#docenteToggle").removeAttr('checked');
                    $("label[for=ClienteCorporativoID], #ClienteCorporativoID").parent().show();
                    $("label[for=DocenteID], #DocenteID").parent().hide();
                }
        });
    });

    $("#saveBtn").click(function () {

        if ($('#docenteToggle').is(':checked')) {
            $("#ClienteCorporativoID").empty();
        }
        if ($('#clienteToggle').is(':checked')) {
            $("#DocenteID").empty();
        }

    });


</script>