@ModelType IEnumerable(Of SaruvMaster.Recurso)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<!DOCTYPE html>

<script>

    $(function () {
        $("#botonBuscar").click(function () {
            $("#Buscar").show("blind");
            $("#botonBuscar").hide();

        })
        $("#cancelar").click(function () {
            $("#Buscar").hide("blind");
            $("#botonBuscar").show();

        })
        $("#Buscar").hide();
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

<div class="row">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Recurso</h3>
        </header>
        <div class="breadcrumb">
            <a class="btn btn-default btn-sm" href="/Recurso/Create"><span class="glyphicon glyphicon-plus"></span> Crear Nuevo</a>
            <a class="btn btn-default btn-sm" href="javascript:void(0)" id="botonBuscar"><span class="glyphicon glyphicon-filter"></span> Filtrar</a>
        </div>
    </div>
</div>
<div id="Buscar" class="row" style="margin-bottom:10px">
    <div class="col-xs-4 col-xs-offset-2" style="margin-top:10px">
        @Using Html.BeginForm()
            @<div class="input-group">
                <div class="input-group-btn" id="search-panel">
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
                @Html.TextBox("SearchString", Nothing, htmlAttributes:=New With {.class = "form-control"})
            </div>
        End Using
        <a href="javascript:void(0)" id="cancelar">Cancelar</a>
    </div>
</div>

<div class="row">
    <div class="col-md-12">
        <section class="panel">
            <div style="overflow-x:auto" class="panel-body">
                <table style="white-space:nowrap" class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Duracion)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Prioridad)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.TipoDeRecurso.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.FechaEntrega)
                            </th>
                            <th>
                                Modalidad
                            </th>  
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.ClienteCorporativo.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Curso.Nombres)
                            </th>
                            <th>
                                Docente
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
                                     @Html.DisplayFor(Function(modelItem) item.Nombre)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Duracion)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Prioridad)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.TipoDeRecurso.Nombre)
                                 </td>                                 
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.FechaEntrega)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.ModalidadDeCurso.Nombre)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Empresa.Nombre)
                                 </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.ClienteCorporativo.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Curso.Nombres)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Docente.Nombres)
                                    @Html.DisplayFor(Function(modelItem) item.Docente.Apellidos)
                                </td>                                
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaCreacion)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaModificacion)
                                </td>
                                <td>
                                    <a class="btn btn-default btn-sm" href="@Url.Action("Edit", New With {.id = item.ID})"><span class="glyphicon glyphicon-pencil"></span> Editar</a>
                                    <a class="btn btn-default btn-sm" href="@Url.Action("Details", New With {.id = item.ID})"><span class="glyphicon glyphicon-list-alt"></span> Detalles</a>
                                    <a class="btn btn-default btn-sm" href="@Url.Action("Delete", New With {.id = item.ID})"><span class="glyphicon glyphicon-trash"></span> Eliminar</a>

                                </td>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </section>
    </div>
</div>