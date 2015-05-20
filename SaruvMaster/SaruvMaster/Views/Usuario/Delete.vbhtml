@ModelType SaruvMaster.Usuario
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <div id="dialog" title="Advertencia">
        <p>Para borrar la Empresa primero debe borrar los Clientes Corporativos de esta empresa </p>
    </div>
    <h3>Usuario</h3>
    <section class="panel">
        <header class="panel-heading">
            Desea eliminar el Usuario?
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
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-group">
                    <input type="submit" value="Eliminar" class="btn btn-default" id="botonEliminar" />
                    <input type="submit" value="Deshabilitar" class="btn btn-default hidden" />
                </div>
            End Using
        </div>
    </section>
    <div>
        <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Usuario/Index">Regresar a la lista</a>
    </div>
</div>