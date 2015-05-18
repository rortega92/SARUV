@ModelType SaruvMaster.Usuario
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Usuario</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
        </header>
        <div class="panel-body">
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
        </div>
    </section>
</div>
<p>
    <button class="btn btn-default btn-sm"> @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID}) </button>
    <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Usuario/Index">Regresar a la lista</a>
</p>
