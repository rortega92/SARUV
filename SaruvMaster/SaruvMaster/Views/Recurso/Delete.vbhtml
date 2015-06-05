@ModelType SaruvMaster.Recurso
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Recurso</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.ClienteCorporativo.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ClienteCorporativo.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Curso.Nombres)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Curso.Nombres)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Docente.Nombres)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Docente.Nombres)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Empresa.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ModalidadDeCurso.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TipoDeRecurso.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TipoDeRecurso.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Duracion)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Duracion)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Prioridad)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Prioridad)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FechaEntrega)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FechaEntrega)
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
