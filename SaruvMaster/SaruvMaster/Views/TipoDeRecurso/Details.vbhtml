@ModelType SaruvMaster.TipoDeRecurso
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Tipo de Recurso</h3>
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
                    @Html.DisplayNameFor(Function(model) model.CodigoRecurso)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.CodigoRecurso)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.FechaDeCreacion)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.FechaDeCreacion)
                </dd>

            </dl>
        </div>
    </section>
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Resgresar a la lista", "Index")
</p>
