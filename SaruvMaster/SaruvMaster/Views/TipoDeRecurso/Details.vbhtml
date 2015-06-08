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
                        @Html.DisplayNameFor(Function(model) model.FechaCreacion)
                    </dt>

                    <dd>
                        @Html.DisplayFor(Function(model) model.FechaCreacion)
                    </dd>

                    <dt>
                        @Html.DisplayNameFor(Function(model) model.FechaModificacion)
                    </dt>

                    <dd>
                        @Html.DisplayFor(Function(model) model.FechaModificacion)
                    </dd>

                </dl>
        </div>
    </section>
</div>
<p>
    <a class="btn btn-default btn-sm" href="@Url.Action("Edit", New With {.id = Model.ID})"><span class="glyphicon glyphicon-pencil"></span> Editar</a>
    <a class="btn btn-default btn-sm" href="/TipoDeRecurso/Index">Regresar a la lista</a>
</p>


