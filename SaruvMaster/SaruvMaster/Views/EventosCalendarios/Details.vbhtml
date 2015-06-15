@ModelType SaruvMaster.EventosCalendario
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>EventosCalendario</h4>
    <hr />
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
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
