@ModelType IEnumerable(Of SaruvMaster.Recurso)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div class="row">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Recurso</h3>
        </header>
        <div class="breadcrumb">
            @Html.ActionLink("Crear Nuevo", "Create")
        </div>
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <section class="panel">
            <div navbar-collapse navbar-ex1-collapse>
                <div class="col-sm-6 col-md-3" style="margin-bottom:10px">
                    @Using Html.BeginForm("Index", "Recurso", FormMethod.Get)
                        @<div class="input-group">
                            @Html.TextBox("SearchString", Nothing, htmlAttributes:=New With {.class = "form-control", .placeholder = "Buscar por Nombre"})
                            <div class="input-group-btn">
                                <button type="submit" value="Filter" class="btn btn-default"><span class="glyphicon glyphicon-search"></span></button>
                            </div>
                        </div>
                    End Using
                </div>
            </div>
            <div class="panel-body">
                <table class="table table-bordered table-striped">
                    <thead>

                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.TipoDeRecurso)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Duracion)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Prioridad)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Curso)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Docente)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Empresa)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.ClienteCorporativo)
                            </th>          
                            <th>
                                @Html.DisplayNameFor(Function(model) model.FechaEntrega)
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
                                     @Html.DisplayFor(Function(modelItem) item.TipoDeRecurso.Nombre)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Duracion)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Prioridad)
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
                                     @Html.DisplayFor(Function(modelItem) item.ClienteCorporativo.Nombres)
                                </td>                             
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaEntrega)
                                </td>
                                <td>
                                    @Html.ActionLink("Editar", "Edit", New With {.id = item.Id}) |
                                    @Html.ActionLink("Detalles", "Details", New With {.id = item.Id}) |
                                    @Html.ActionLink("Eliminar", "Delete", New With {.id = item.Id})
                                </td>
                            </tr>
                        Next
                        </tbody>
                </table>
            </div>
        </section>
    </div>
</div>