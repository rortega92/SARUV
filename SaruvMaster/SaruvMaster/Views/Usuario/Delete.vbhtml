@ModelType SaruvMaster.Usuario
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Usuario</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Departamento.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Departamento.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RolPorDepartamento.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RolPorDepartamento.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Apellido)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Apellido)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.correo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.correo)
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
             <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Usuario/Index">Regresar a la lista</a>
        </div>
    End Using
</div>
