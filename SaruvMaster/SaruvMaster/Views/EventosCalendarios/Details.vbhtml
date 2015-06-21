@ModelType SaruvMaster.EventosCalendario
@Code
    ViewData("Title") = "Details"
End Code

<div>
    <h3>Eventos Calendarios</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
        </header>
        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Evento)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Evento)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.StartString)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.StartString)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.EndString)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.EndString)
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
    <a class="btn btn-default btn-sm" href="/EventosCalendario/Index">Regresar a la lista</a>
</p>
