@ModelType IEnumerable(Of SaruvMaster.Curso)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

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
            <h3>Curso</h3>
        </header>
        <div class="breadcrumb">
            <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Curso/Create"><span class="glyphicon glyphicon-plus"></span> Crear Nuevo</a>
            <a style="color: #007AFF" class="btn btn-default btn-sm" href="javascript:void(0)" id="botonBuscar"><span class="glyphicon glyphicon-filter"></span> Filtrar</a>
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
                        <li><a href="#Modalidad">Modalidad de Curso</a></li>
                        <li><a href="#Área de Conocimiento">Área de Conocimiento</a></li>
                        <li><a href="#Encargado de Validación">Encargado de Validación</a></li>
                        <li><a href="#Período">Período</a></li>
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
            <div class="panel-body">
                <table class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.EncargadoDeValidacion.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Nombres)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.FechaInicio)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.FechaFinal)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Periodo)
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
                                    @Html.DisplayFor(Function(modelItem) item.AreaDeConocimiento.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.EncargadoDeValidacion.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.ModalidadDeCurso.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Nombres)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaInicio)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaFinal)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Periodo)
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
