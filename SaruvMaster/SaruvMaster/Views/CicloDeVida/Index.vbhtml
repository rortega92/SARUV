﻿@ModelType IEnumerable(Of SaruvMaster.CicloDeVida)
@Code
    ViewData("Title") = "Index"

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
            <h3>Historial de Recursos</h3>
        </header>
        <div class="breadcrumb">
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
                        <li><a href="#Usuario">Usuario</a></li>
                        
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
                    <th>
                        @Html.DisplayNameFor(Function(model) model.Recurso.Nombre)
                    </th>
                    <th>
                        @Html.DisplayNameFor(Function(model) model.Usuario)
                    </th>
                    <th>
                        @Html.DisplayNameFor(Function(model) model.Estado)
                    </th>
                    <th>
                        @Html.DisplayNameFor(Function(model) model.FechaModificacion)
                    </th>
                    <th>
                        @Html.DisplayNameFor(Function(model) model.Observacion)
                    </th>

                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Recurso.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Usuario.Nombre)
                                    @Html.DisplayFor(Function(modelItem) item.Usuario.Apellido)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Estado)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaModificacion) - @item.FechaModificacion.TimeOfDay
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Observacion)
                                </td>

                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </section>
    </div>
</div>