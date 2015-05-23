@ModelType IEnumerable(Of SaruvMaster.TipoDeRecurso)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
<script>
    $(function () {
        $("#filterButton").click(function () {
            $("#Buscar").toggle();
        })
    });
</script>


<div class="row indexHeader">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Tipo de Recurso</h3>
        </header>
        <div class="breadcrumb">
            <a style="color: #007AFF" class="btn btn-default btn-sm" href="/TipoDeRecurso/Create">Crear Nuevo</a>
            <a style="color: #007AFF" class="btn btn-default btn-sm" href="javascript:void(0)" id="filterButton"> Filtrar</a>
        </div>
    </div>
    <div class="col-md-12" id="Buscar">
        <div class="filterBox col-md-12">
            @Using Html.BeginForm("Index", "AreaDeConocimiento", FormMethod.Get)
            @<div class="col-md-2">
              <input class="form-control" type="search" Placeholder="Buscar"/>
              <span class="glyphicon glyphicon-search"></span>
            </div>       
            End Using                     
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
                                @Html.DisplayNameFor(Function(model) model.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.CodigoRecurso)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.FechaDeCreacion)
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
                                    @Html.DisplayFor(Function(modelItem) item.CodigoRecurso)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaDeCreacion)
                                </td>
                                <td>
                                    <button class="btn btn-default btn-sm"> @Html.ActionLink("Editar", "Edit", New With {.id = item.Id})</button>
                                    <button class="btn btn-default btn-sm"> @Html.ActionLink("Detalles ", "Details", New With {.id = item.Id}) </button>
                                    <button class="btn btn-default btn-sm"> @Html.ActionLink("Eliminar", "Delete", New With {.id = item.Id})</button>
                                </td>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </section>
    </div>
</div>
