@ModelType IEnumerable(Of SaruvMaster.CicloDeVida)
@Code
    ViewData("Title") = "Index"

End Code
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
            <h3>Ciclo de Vida</h3>
        </header>
        <div class="breadcrumb">

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
                        <li><a href="#Fecha Entrega">Fecha</a></li>
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
                    <th>
                        @Html.DisplayNameFor(Function(model) model.Recurso.Nombre)
                    </th>
                    <th>
                        @Html.DisplayNameFor(Function(model) model.Usuario.Email)
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
                                    @Html.DisplayFor(Function(modelItem) item.Usuario.Email)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Estado)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaModificacion)
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