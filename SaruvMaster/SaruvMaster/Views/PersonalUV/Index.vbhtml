@ModelType IEnumerable(Of SaruvMaster.RecursoPorUsuario)
@Code
    Dim isJefe As Boolean = ViewBag.isJefe
    ViewData("Title") = "View"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
<!--Inicio Si es Jefe-->
@If isJefe = True Then
    @Scripts.Render("~/Scripts/PersonalUVJefe.js")
Else
    @Scripts.Render("~/Scripts/PersonalUV.js")
End If
<!--Fin Si es Jefe-->
<div class="row">
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                Recursos
            </header>
            <div id="recursosPanel" class="panel-body recurso-container">
                @For Each item In Model
                    @<div class="modal fade" id="modalCambiarEstado_@Html.DisplayFor(Function(modelitem) item.Recurso.Id)" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">Cambiar estado de: "@Html.DisplayFor(Function(modelItem) item.Recurso.Nombre)"</h4>
                                </div>
                                <div class="modal-body" style="height:100%">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <label for="TipoDeRecurso" class="control-label col-md-12">@Html.DisplayNameFor(Function(model) model.Recurso.TipoDeRecurso)</label>
                                                </td>
                                                <td>
                                                    <div class="col-md-12">@Html.DisplayFor(Function(modelItem) item.Recurso.TipoDeRecurso.Nombre)</div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label for="Prioridad" class="control-label col-md-12">@Html.DisplayNameFor(Function(model) model.Recurso.Prioridad)</label>
                                                </td>
                                                <td>
                                                    <div class="col-md-12">@Html.DisplayFor(Function(modelItem) item.Recurso.Prioridad)</div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="control-label col-md-12">@Html.DisplayNameFor(Function(model) model.Estado)</label>
                                                </td>
                                                <td>
                                                    <div class="col-md-12">
                                                        <select class="form-control" id="EstadoRecurso" name="Estado">
                                                            <option value="1">No Empezado</option>
                                                            <option value="2">En Progreso</option>
                                                            <option value="3">Terminado</option>
                                                        </select>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="modal-footer">
                                    <button data-dismiss="modal" class="btn btn-default" type="button">Cerrar</button>
                                    <button data-dismiss="modal" class="btn btn-success" type="button" onclick="cambiarEstado( @item.ID )">Guardar</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    @<div class="modal fade" id="modalEnviar_@Html.DisplayFor(Function(modelitem) item.Recurso.Id)" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">Enviar recurso: "@Html.DisplayFor(Function(modelItem) item.Recurso.Nombre)"</h4>
                                </div>
                                <div class="modal-body" style="height:100%">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <label class="control-label col-md-12">Usuarios</label>
                                                </td>
                                                <td>
                                                    <div class="col-md-12">
                                                        <select class="form-control" id="SelectUsuariosDestino" name="Estado"></select>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="modal-footer">
                                    <button data-dismiss="modal" class="btn btn-default" type="button">Cerrar</button>

                                    <button data-dismiss="modal" class="btn btn-success" type="button" onclick="enviarSiguienteDepto( @item.ID )">Enviar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                Next
            <a id="linkAviso" class="btn btn-default btn-sm" data-toggle="modal" href="#aviso" style="display:none"></a>
                <div class="modal fade" id="aviso" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">Aviso</h4>
                            </div>
                            <div class="modal-body" style="height:100%">
                            </div>
                            <div class="modal-footer">
                                <button data-dismiss="modal" data-target="#aviso" class="btn btn-default" type="button">Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    @If isJefe = True Then
        @<!--Si es Jefe-->
        @<div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    Personal
                </header>
                <div class="panel-body">
                    <section class="panel">
                        <header class="panel-heading tab-bg-primary ">
                            <ul id="NavTabs" class="nav nav-tabs"></ul>
                        </header>
                        <div class="panel-body">
                            <div style="height:100%; min-height:200px" id="TabContent" class="tab-content">
                            </div>
                        </div>
                    </section>
                </div>
            </section>
        </div>
    End If
</div>

