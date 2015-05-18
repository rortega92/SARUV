﻿@ModelType IEnumerable(Of SaruvMaster.EncargadoDeValidacion)
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
        });
    });

</script>

<div class="row">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Encargado de Validación</h3>
        </header>
        <div class="breadcrumb">
            <a style="color: #007AFF" class="btn btn-default btn-sm" href="/EncargadoDeValidacion/Create">Crear Nuevo</a>
            <a style="color: #007AFF" class="btn btn-default btn-sm" href="javascript:void(0)" id="botonBuscar"> Buscar</a>
        </div>
    </div>
</div>
<div id="Buscar" class="row" style="margin-bottom:10px">
    <div class="col-xs-4 col-xs-offset-2" style="margin-top:10px">
        @Using Html.BeginForm("Index", "EncargadoDeValidacion", FormMethod.Get)
            @<div class="input-group">
                <div class="input-group-btn" id="search-panel">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                        <span id="search_concept">Filtrar Por</span> <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu">
                        <li><a href="#Facultad">Facultad</a></li>
                        <li><a href="#Nombre">Nombre</a></li>                    
                        <li><a href="#Telefono">Teléfono </a></li>
                        <li><a href="#email">Correo Electrónico </a></li>                        
                    </ul>
                </div>
                 
                @Html.TextBox("SearchString", Nothing, htmlAttributes:=New With {.class = "form-control"})
                <span class="input-group-btn">
                    <button class="btn btn-default" type="button"><span class="glyphicon glyphicon-search"></span></button>
                </span>
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
                                @Html.DisplayNameFor(Function(model) model.Facultad.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Telefono)
                            </th>
                            <th>
                                Extensión
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.correoElectronico)
                            </th>
                            <th>
                                Acciones
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            @<tr>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Facultad.Nombre)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Nombre)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Telefono)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Extensión)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.correoElectronico)
                                 </td>
                                 <td>
                                     <button class="btn btn-default btn-sm"> @Html.ActionLink("Editar", "Edit", New With {.id = item.ID})</button>
                                     <button class="btn btn-default btn-sm"> @Html.ActionLink("Detalles ", "Details", New With {.id = item.ID}) </button>
                                     <button class="btn btn-default btn-sm"> @Html.ActionLink("Detalles", "Delete", New With {.id = item.ID})</button>
                                 </td>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </section>
    </div>
</div>
