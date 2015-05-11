@ModelType SaruvMaster.TipoDeRecurso
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>TipoDeRecurso</h4>
    <hr />
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
            @Html.DisplayNameFor(Function(model) model.FechaInicio)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FechaInicio)
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
