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
            @Html.ActionLink("Crear Nuevo", "Create")
        </div>
    </div>
</div>

<div class="row">
    <div class="col-md-12">
        <section class="panel">
            <div navbar-collapse navbar-ex1-collapse>
                <div class="col-xs-6 col-sm-4 col-md-3 col-lg-3" style="margin-top:10px">
                    @Using Html.BeginForm("Index", "Docente", FormMethod.Get)
                        @<div class="input-group">
                            @Html.TextBox("SearchString", Nothing, htmlAttributes:=New With {.class = "form-control", .placeholder = "Buscar por Nombre"})
                            <span class="input-group-btn">
                                <button type="submit" value="Filter" class="btn btn-default"><span class="glyphicon glyphicon-search"></span></button>
                            </span>
                        </div>
                    End Using
                </div>
            </div>
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
