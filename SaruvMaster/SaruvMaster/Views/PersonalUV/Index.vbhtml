@ModelType IEnumerable(Of SaruvMaster.Recurso)
@Code
    ViewData("Title") = "View"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
<!--Inicio Si es Jefe-->
@Scripts.Render("~/Scripts/PersonalUV.js")
<!--Fin Si es Jefe-->
<div class="row">
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                Recursos
            </header>
            <div class="panel-body">
                @For Each item In Model
                    If (item.Prioridad.Equals("Alta")) Then
                        @<div class="alert alert-danger">
                             <table class="table" style="margin: 0px">
                                 <tr>
                                     <td style="border:0px">
                                         @Html.DisplayFor(Function(modelItem) item.Nombre)
                                     </td>
                                     <td class="navbar-right" style="border:0px">
                                         <div class="btn-group-vertical">
                                             <a id="CambiarEstado" class="btn btn-default btn-sm" data-toggle="modal" href="#modalCambiarEstado_@html.displayfor(function(modelitem) item.Id)">Cambiar estado</a>
                                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Enviar al siguiente departamento</a>
                                         </div>
                                     </td>
                                 </tr>
                             </table>                          
                        </div>
                    ElseIf (item.Prioridad = "Media") Then
                        @<div class="alert alert-warning">
                             <table class="table" style="margin: 0px">
                                 <tr>
                                     <td style="border:0px">
                                         @Html.DisplayFor(Function(modelItem) item.Nombre)
                                     </td>
                                     <td class="navbar-right" style="border:0px">
                                         <div class="btn-group-vertical">
                                             <a id="CambiarEstado" class="btn btn-default btn-sm" data-toggle="modal" href="#modalCambiarEstado_@Html.DisplayFor(Function(modelitem) item.Id)">Cambiar estado</a>
                                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Enviar al siguiente departamento</a>
                                         </div>
                                     </td>
                                 </tr>
                             </table>
                        </div>
                    Else
                        @<div class="alert alert-success">
                             <table class="table" style="margin: 0px">
                                 <tr>
                                     <td style="border:0px">
                                         @Html.DisplayFor(Function(modelItem) item.Nombre)
                                     </td>
                                     <td class="navbar-right" style="border:0px">
                                         <div class="btn-group-vertical">
                                             <a id="CambiarEstado" class="btn btn-default btn-sm" data-toggle="modal" href="#modalCambiarEstado_@Html.DisplayFor(Function(modelitem) item.Id)">Cambiar estado</a>
                                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Enviar al siguiente departamento</a>
                                         </div>
                                     </td>
                                 </tr>
                             </table>
                        </div>
                    End If
                    @<div class="modal fade" id="modalCambiarEstado_@html.displayfor(function(modelitem) item.Id)" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">Cambiar estado @Html.DisplayFor(Function(modelItem) item.Nombre)</h4>
                                </div>
                                <div class="modal-body" style="height:200px">
                                    <label for="Nombre" class="control-label col-md-2">Estado </label>
                                    <div class="col-md-10">
                                        <select class="form-control" id="Periodo" name="Estado">
                                            <option value="1">No Empezado</option>
                                            <option value="2">En Progreso</option>
                                            <option value="3">Terminado</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button data-dismiss="modal" class="btn btn-default" type="button">Cerrar</button>
                                    <button class="btn btn-success" type="button">Guardar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                Next
            </div>
        </section>
    </div>
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                Personal
            </header>
            <div class="panel-body">
                <section class="panel">
                    <header class="panel-heading tab-bg-primary ">
                        <ul id="NavTabs" class="nav nav-tabs">
                        </ul>
                    </header>
                    <div class="panel-body">
                        <div id="TabContent" class="tab-content">
                        </div>
                    </div>
                </section>
            </div>
        </section>
    </div>
</div>

