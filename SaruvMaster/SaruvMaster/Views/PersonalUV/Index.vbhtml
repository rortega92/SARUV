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
                                                            <option value="No Empezado">No Empezado</option>
                                                            <option value="En Progreso">En Progreso</option>
                                                            <option value="Terminado">Terminado</option>
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

                                    <button data-dismiss="modal" class="btn btn-success" type="button" onclick="validarEnviarSiguienteDepto(@item.RecursoID)">Enviar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    

                    @<div class="modal fade" id="modalFuente_@Html.DisplayFor(Function(modelitem) item.Recurso.Id)" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">Especificación del recurso: "@Html.DisplayFor(Function(modelItem) item.Recurso.Nombre)"</h4>
                                </div>
                                <div class="modal-body" style="height:100%">
                                    <table>
                                        <tbody>
                                        @If ViewBag.departamento.Equals("Corrección") Or (ViewBag.departamento.Equals("Diseño") And ViewBag.isJefe) Then
                                            @<tr>                    
                                                    @Using (Html.BeginForm("Upload", "FTP", New With {.recursoId = item.RecursoID, .tipo = 0}, FormMethod.Post, New With {Key .enctype = "multipart/form-data", .id = item.RecursoID, .class = "frmUpFuente"}))
                                                    @<td>
                                                         <input type="file" name="file2" class="col-md-12" />
                                                    </td>
                                                    @<td>
                                                         <input type="submit" name="Submit" id="Submit" value="Subir" class="btn btn-default col-md-12" />  
                                                    </td>
                                                    End Using
                                            </tr>
                                        End If
                                        @If ViewBag.departamento.Equals("Corrección") Or (ViewBag.departamento.Equals("Diseño")) Then
                                            @<tr>
                                                <td>
                                                    <div class="col-md-12">
                                                        <select class="form-control" id="selectArchivosFuente_@item.RecursoID" name="ArchivosFuenteDescargar"></select>
                                                    </div>
                                                </td>
                                                <td>
                                                    @Using (Html.BeginForm("download", "FTP", New With {.archivoId = 1}, FormMethod.Post, New With {.id = item.RecursoID, .class = "frmDesFuente"}))
                                                        @<input type="submit" name="Submit" id="Submit" value="Descargar" class="btn btn-default col-md-12" onclick="descargarFuente(@item.RecursoID)"/>
                                                    End Using
                                                </td>
                                            @If ViewBag.departamento.Equals("Corrección") Or (ViewBag.departamento.Equals("Diseño") And ViewBag.isJefe) Then
                                                @<td>
                                                    @Using (Html.BeginForm("delete", "FTP", New With {.archivoId = 1}, FormMethod.Post, New With {.id = item.RecursoID, .class = "frmDelFuente"}))
                                                        @<input type="submit" name="Submit" id="Submit" value="Eliminar" class="btn btn-default col-md-12" onclick="eliminarFuente(@item.RecursoID)" />
                                                    End Using
                                                </td>
                                            End If

                                            </tr>
                                        End If
                                        
                                        </tbody>
                                    </table>
                                </div>
                                <div class="modal-footer">
                                    <button data-dismiss="modal" class="btn btn-default" type="button">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    @<div class="modal fade" id="modalRecurso_@Html.DisplayFor(Function(modelitem) item.Recurso.Id)" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">Recurso: "@Html.DisplayFor(Function(modelItem) item.Recurso.Nombre)"</h4>
                                </div>
                                <div class="modal-body" style="height:100%">
                                    <table>
                                        <tbody>
                                            @If ViewBag.departamento.Equals("Corrección") or ViewBag.departamento.Equals("Diseño")
                                            @<tr>
                                                @Using (Html.BeginForm("Upload", "FTP", New With {.recursoId = item.RecursoID, .tipo = 1}, FormMethod.Post, New With {Key .enctype = "multipart/form-data", .id = item.RecursoID, .class = "frmUpRecurso"}))
                                                    @<td>
                                                         <input type="file" name="file2" class="col-md-12" />
                                                    </td>
                                                    @<td>
                                                        <input type="submit" name="Submit" id="Submit" value="Subir" class="btn btn-default col-md-12" />
                                                    </td>
                                                End Using
                                            </tr>
                                            End If
                                            <tr>
                                                <td>
                                                    <div class="col-md-12">
                                                        <select class="form-control" id="selectArchivosRecurso_@item.RecursoID" name="ArchivosRecursoDescargar"></select>
                                                    </div>
                                                </td>
                                                <td>
                                                    @Using (Html.BeginForm("download", "FTP", New With {.archivoId = 1}, FormMethod.Post, New With {.id = item.RecursoID, .class = "frmDesRecurso"}))
                                                        @<input type="submit" name="Submit" id="Submit" value="Descargar" class="btn btn-default col-md-12" onclick="descargarRecurso(@item.RecursoID)" />
                                                    End Using
                                                </td>

                                                @If ViewBag.departamento.Equals("Corrección") Or ViewBag.departamento.Equals("Diseño") Then
                                                @<td>
                                                    @Using (Html.BeginForm("delete", "FTP", New With {.archivoId = 1}, FormMethod.Post, New With {.id = item.RecursoID, .class = "frmDelRecurso"}))
                                                        @<input type="submit" name="Submit" id="Submit" value="Eliminar" class="btn btn-default col-md-12" onclick="eliminarRecurso(@item.RecursoID)" />
                                                    End Using
                                                </td>
                                                End If                  
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="modal-footer">
                                    <button data-dismiss="modal" class="btn btn-default" type="button">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    @<a id="linkEscribaObservacion_@item.RecursoID" class="btn btn-default btn-sm" data-toggle="modal" href="#escribaObservacion_@item.RecursoID" style="display:none"></a>
                    @<div class="modal fade" id="escribaObservacion_@item.RecursoID" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title">Ingrese una observación</h4>
                                </div>
                                <form>
                                    <div class="modal-body" style="height:100%">
                                        <textarea id="txtObservacion_@item.RecursoID" style="width:100%" required class="form-control"></textarea>
                                    </div>
                                    <div class="modal-footer">
                                        <button value="Submit" data-dismiss="modal" data-target="#escribaObservacion" class="btn btn-default" type="button" onclick="enviarSiguienteDepto(@item.RecursoID)">Aceptar</button>
                                    </div>
                                </form>
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

