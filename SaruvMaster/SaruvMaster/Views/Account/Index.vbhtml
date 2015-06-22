@ModelType IEnumerable(Of SaruvMaster.ApplicationUser)
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
            <h3>Usuarios</h3>
        </header>
        <div class="breadcrumb">
            <a class="btn btn-default btn-sm" href="/Account/Register"><span class="glyphicon glyphicon-plus"></span> Crear Nuevo</a>
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
                        <li><a href="#Apellido">Apellido</a></li>
                        <li><a href="#email">Email</a></li>
                        <li><a href="#Departamento">Departamento</a></li>
                        
                    </ul>
                </div>
                @Html.TextBox("searchString", Nothing, htmlAttributes:=New With {.class = "form-control"})
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
                            @Html.DisplayNameFor(Function(model) model.Apellido)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model.Email)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model.UserName)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model.Departamento)
                        </th>
                        <th>
                            Jefe
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model.FechaCreacion)
                        </th>
                        <th>
                            @Html.DisplayNameFor(Function(model) model.FechaModificacion)
                        </th>
                    </tr>
                        </thead>

                    @For Each item In Model
                        @<tr>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Nombre)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Apellido)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Email)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.UserName)
                            </td>

                            <td>
                                @Code
                                Dim db As New Connection
                                Dim S = db.Departamento.Where(Function(e) e.ID = item.DepartamentoID)
                                If S.ToArray().Length > 0 Then
                                ViewBag.NombreDepartamento = S.First().Nombre
                                Else
                                ViewBag.NombreDepartamento = "N/A"
                                End If
                                End Code
                                @ViewBag.NombreDepartamento
                            </td>
                            <td>
                                @If item.isJefe = 0 Then
                                ViewBag.jefe = "No"
                                Else
                                ViewBag.jefe = "Si"
                                End If
                                @ViewBag.jefe
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.FechaCreacion)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.FechaModificacion)
                            </td>
                        </tr>
                    Next

                </table>
            </div>
        </section>
    </div>
</div>
