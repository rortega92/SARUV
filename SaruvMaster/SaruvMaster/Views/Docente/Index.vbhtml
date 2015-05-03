@ModelType IEnumerable(Of SaruvMaster.Docente)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div class="row">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Docente</h3>
        </header>
        <div class="breadcrumb">
            @Html.ActionLink("Crear Nueva", "Create")
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
                                @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Facultad.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Nombres)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Apellidos)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.NumeroTalentoHumano)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.correoElectronico)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.telefono)
                            </th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>

                        @For Each item In Model
                            @<tr>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.AreaDeConocimiento.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Facultad.Nombre)
                                </td>
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
                                    @Html.ActionLink("Edit", "Edit", New With {.id = item.ID}) |
                                    @Html.ActionLink("Details", "Details", New With {.id = item.ID}) |
                                    @Html.ActionLink("Delete", "Delete", New With {.id = item.ID})
                                </td>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </section>
    </div>
</div>

