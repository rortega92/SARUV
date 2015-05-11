@ModelType IEnumerable(Of SaruvMaster.ClienteCorporativo)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div class="row">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Cliente Corporativo</h3>
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
                    @Using Html.BeginForm("Index", "ClienteCorporativo", FormMethod.Get)
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
                                @Html.DisplayNameFor(Function(model) model.Nombres)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Apellidos)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.NumeroIdentidad)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.CorreoElectronico)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Telefono)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
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
                                     @Html.DisplayFor(Function(modelItem) item.Nombres)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Apellidos)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.NumeroIdentidad)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.CorreoElectronico)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Telefono)
                                 </td>
                                 <td>
                                     @Html.DisplayFor(Function(modelItem) item.Empresa.Nombre)
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


