@ModelType SaruvMaster.EventosCalendario
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
