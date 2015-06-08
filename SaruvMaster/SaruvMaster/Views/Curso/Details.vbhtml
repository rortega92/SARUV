@ModelType SaruvMaster.Curso
@Code
    ViewData("Title") = "Details"
End Code

<div>
    <h3>Curso</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
        </header>
        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.AreaDeConocimiento.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.EncargadoDeValidacion.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.EncargadoDeValidacion.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.ModalidadDeCurso.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nombres)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombres)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.FechaInicio)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.FechaInicio)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.FechaFinal)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.FechaFinal)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Periodo)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Periodo)
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
    <a class="btn btn-default btn-sm" href="/Curso/Index">Regresar a la lista</a>
</p>