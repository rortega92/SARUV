@ModelType SaruvMaster.EventosCalendario
@Code
    ViewData("Title") = "Delete"
End Code

<div>
    <h3>Eventos Calendarios</h3>
    <section class="panel">
        <header class="panel-heading">
            ¿Desea eliminar el Evento?
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
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-actions no-color">
                    <input type="submit" value="Eliminar" class="btn btn-default" /> |
                    <a class="btn btn-default btn-sm" href="/EventosCalendario/Index">Regresar a la lista</a>
                </div>
            End Using
        </div>
    </section>
    <div>
        <a class="btn btn-default btn-sm" href="/EventosCalendario/Index">Regresar a la lista</a>
    </div>
</div>

