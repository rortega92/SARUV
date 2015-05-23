@ModelType IEnumerable(Of SaruvMaster.Docente)
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
            <h3>Docente</h3>
        </header>
        <div class="breadcrumb">
            <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Docente/Create">Crear Nuevo</a>
            <a style="color: #007AFF" class="btn btn-default btn-sm" href="javascript:void(0)" id="botonBuscar">Filtrar</a>
        </div>
    </div>
</div>

<div id="Buscar" class="row" style="margin-bottom:10px">
    <div class="col-xs-4 col-xs-offset-2" style="margin-top:10px">
        @Using Html.BeginForm("Index", "Docente", FormMethod.Get)
           
            @<div class="input-group">
                <div class="input-group-btn" id="search-panel">                
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                        <span id="search_concept">Filtrar Por</span> <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu">
                        <li><a href="#Nombre">Nombre</a></li>
                        <li><a href="#Apellido">Apellido</a></li>
                        <li><a href="#NumID">Número de Identidad</a></li>
                        <li><a href="#Correo">Correo Electrónico </a></li>
                        <li><a href="#Telefono">Teléfono </a></li>
                        <li><a href="#Facultad">Facultad </a></li>
                        <li><a href="#Área de Conocimineto">Área de Conocimineto </a></li>
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
                                @Html.DisplayNameFor(Function(model) model.Nombres)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Apellidos)
                            </th>
                            <th>
                                Número de Talento Humano
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.correoElectronico)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.telefono)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Facultad.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento.Nombre)
                            </th>

                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>

                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Nombres)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Apellidos)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.NumeroTalentoHumano)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.correoElectronico)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.telefono)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Facultad.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.AreaDeConocimiento.Nombre)
                                </td>

                                <td>
                                    <button class="btn btn-default btn-sm"> @Html.ActionLink("Editar", "Edit", New With {.id = item.ID})</button>
                                    <button class="btn btn-default btn-sm"> @Html.ActionLink("Detalles ", "Details", New With {.id = item.ID}) </button>
                                    <button class="btn btn-default btn-sm"> @Html.ActionLink("Eliminar", "Delete", New With {.id = item.ID})</button>
                                </td>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </section>
    </div>
</div>
