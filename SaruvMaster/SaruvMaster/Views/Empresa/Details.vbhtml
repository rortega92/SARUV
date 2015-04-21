@ModelType SaruvMaster.EmpresaModels
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Empresa</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
        </header>
        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Direccion)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Direccion)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Telefono)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Telefono)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Ciudad)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Ciudad)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Departamento)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Departamento)
                </dd>

            </dl>
        </div>
    </section>
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Regresar a la lista", "Index")
</p>
