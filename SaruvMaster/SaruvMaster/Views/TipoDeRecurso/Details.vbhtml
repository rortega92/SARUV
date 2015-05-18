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
    <button class="btn btn-default btn-sm"> @Html.ActionLink("Editar", "Edit", New With {.id = Model.Id}) </button>
    <a style="color: #007AFF" class="btn btn-default btn-sm" href="/TipoDeRecurso/Index">Regresar a la lista</a>
</p>
