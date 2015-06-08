@ModelType SaruvMaster.EventosEstudio
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Encargado de Validación</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
        </header>
        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.ClienteCorporativo.Nombres)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.ClienteCorporativo.Nombres)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Docente.Nombres)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Docente.Nombres)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Evento)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Evento)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.FechaReserva)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.FechaReserva)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.HoraInicio)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.HoraInicio)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.HoraFinal)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.HoraFinal)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.IsDeleted)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.IsDeleted)
                </dd>

            </dl>
        </div>
    </section>
</div>
<p>
    <a class="btn btn-default btn-sm" href="@Url.Action("Edit", New With {.id = Model.ID})"><span class="glyphicon glyphicon-pencil"></span> Editar</a>
    <a class="btn btn-default btn-sm" href="/EventosEstudio/Index">Regresar a la lista</a>
</p>

