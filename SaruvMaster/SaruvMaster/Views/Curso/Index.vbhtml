@ModelType IEnumerable(Of SaruvMaster.Curso)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
<!DOCTYPE html>

<div class="row">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Curso</h3>
        </header>
        <div class="breadcrumb">
            @Html.ActionLink("Crear Nuevo", "Create")
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
                                @Html.DisplayNameFor(Function(model) model.Nombres)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso)
                            </th>
                            <th>                                
                                @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.EncargadoDeValidacion)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Periodo)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.FechaInicio)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.FechaFinal)
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
                                    @Html.DisplayFor(Function(modelItem) item.ModalidadDeCurso.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.AreaDeConocimiento.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.EncargadoDeValidacion.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Periodo)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaInicio)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.FechaFinal)
                                </td>

                                <td>
                                    @Html.ActionLink("Editar", "Edit", New With {.id = item.ID}) |
                                    @Html.ActionLink("Detalles", "Details", New With {.id = item.ID}) |
                                    @Html.ActionLink("Eliminar", "Delete", New With {.id = item.ID})
                                </td>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </section>
    </div>
</div>
