@ModelType IEnumerable(Of SaruvMaster.AreaDeConocimiento)
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
</script>


<div class="row indexHeader">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Areas de conocimiento</h3>
        </header>
        <div class="breadcrumb">
            <a  class="btn btn-default btn-sm" href="/AreaDeConocimiento/Create"><span class="glyphicon glyphicon-plus"></span> Crear Nueva</a>            
            <a  class="btn btn-default btn-sm" href="javascript:void(0)" id="filterButton"><span class="glyphicon glyphicon-filter"></span> Filtrar</a>
        </div>
    </div>
    <div class="col-md-12" id="Buscar">
        <div class="filterBox col-md-12">
            @Using Html.BeginForm("Index", "AreaDeConocimiento", FormMethod.Get)
            @<div class="col-md-2">
              <input name="searchString" class="form-control" type="search" Placeholder="Buscar"/>
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
                                Acciones
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            @<tr>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Nombre)
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