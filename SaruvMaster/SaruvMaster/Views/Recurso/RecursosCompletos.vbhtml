@ModelType IEnumerable(Of SaruvMaster.Recurso)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<!DOCTYPE html>
<script>
    $(function () {
        $("#filterButton").click(function () {
            $("#Buscar").toggle();
        })
    });

    $(document).ready(function (e) {
        $('#search-panel .dropdown-menu').find('a').click(function (e) {
            e.preventDefault();
            var parametro = $(this).attr("href").replace("#", "");
            var concepto = $(this).text();
            $('#search-panel span#search_concept').text(concepto);
            $('.input-group #search_param').val(parametro);
            $("#searchConceptInput").val(concepto);
        });
    });
</script>

<div class="row indexHeader">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Recursos Completados</h3>
        </header>
        <div class="breadcrumb">
            <a class="btn btn-default btn-sm" href="javascript:void(0)" id="filterButton"><span class="glyphicon glyphicon-filter"></span> Filtrar</a>
        </div>
    </div>
    <div class="col-md-12" id="Buscar">
        <div class="filterBox col-md-12">
            <div class="col-md-8">
                <div class="col-md-1" id="search-panel">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                        <span id="search_concept">Filtrar Por</span> <span class="caret"></span>
                    </button>
                    <input type="hidden" value="Nombre" id="searchConceptInput" name="searchConceptInput" />
                    <ul class="dropdown-menu" role="menu">
                        <li><a href="#Nombre">Nombre</a></li>
                        <li><a href="#Tipo">Tipo de Recurso</a></li>
                        <li><a href="#Modalidad">Modalidad</a></li>
                        <li><a href="#Empresa">Empresa</a></li>
                        <li><a href="#Curso">Curso</a></li>
                        <li><a href="#Cliente Corp.">Cliente Corporativo</a></li>
                        <li><a href="#Docente">Docente</a></li>
                        <li><a href="#Correo">Correo Electrónico</a></li>
                        <li><a href="#Duración">Duración</a></li>
                        <li><a href="#Prioridad">Prioridad</a></li>
                        <li><a href="#Fecha Entrega">Fecha Entrega</a></li>
                    </ul>
                </div>
                <div class="col-md-3">
                    <input class="form-control" type="search" placeholder="Buscar" />
                    <span class="glyphicon glyphicon-search"></span>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <section class="panel">
            <div class="panel-body">
                <table class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.ClienteCorporativo.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Curso.Nombres)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Docente.Nombres)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.TipoDeRecurso.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Duracion)
                            </th>
                            
                            <th>
                                @Html.DisplayNameFor(Function(model) model.FechaCreacion)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.FechaModificacion)
                            </th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.ClienteCorporativo.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Curso.Nombres)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Docente.Nombres)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Empresa.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.ModalidadDeCurso.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.TipoDeRecurso.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Duracion)
                                </td>
                                
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaCreacion)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaModificacion)
                                </td>
                                <td>
                                    <a class="btn btn-default btn-sm" href="@Url.Action("", New With {.id = item.Id})"><span class="glyphicon glyphicon-time"></span> Historial</a>
                                </td>
                                 <td>
                                     <div class="col-md-12">
                                         <select class="form-control" id="selectArchivosFuente_@item.Id" name="ArchivosFuenteDescargar"></select>
                                     </div>
                                 </td>
                                 <td>
                                     @Using (Html.BeginForm("download", "FTP", New With {.archivoId = 1}, FormMethod.Post, New With {.id = item.Id, .class = "frmDesFuente"}))
                                         @<input type="submit" name="Submit" id="Submit" value="Descargar" class="btn btn-default col-md-12" onclick="descargarFuente(@item.Id)" />
                                     End Using
                                 </td>

                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </section>
    </div>
</div>