@ModelType IEnumerable(Of SaruvMaster.CicloDeVida)
@Code
    ViewData("Title") = "Index"

End Code
<div class="row indexHeader">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Ciclo de Vida</h3>
        </header>
        <div class="breadcrumb">

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