@ModelType IEnumerable(Of SaruvMaster.EncargadoDeValidacion)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div class="row">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Encargado de Validación</h3>
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
