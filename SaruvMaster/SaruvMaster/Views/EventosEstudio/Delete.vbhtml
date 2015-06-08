@ModelType SaruvMaster.EventosEstudio
@Code
    ViewData("Title") = "Delete"
End Code

<div>
    <h3>Eventos Estudio</h3>
    <section class="panel">
        <header class="panel-heading">
            ¿Desea eliminar el Evento?
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
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-actions no-color">
                    <input type="submit" value="Eliminar" class="btn btn-default" />
                    <input type="submit" value="Deshabilitar" class="btn btn-default" />
                </div>
            End Using
        </div>
    </section>
    <div>
        <a class="btn btn-default btn-sm" href="/EventosEstudio/Index">Regresar a la lista</a>
    </div>
</div>
