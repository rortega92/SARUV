@ModelType SaruvMaster.RolPorDepartamento
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<!DOCTYPE html>

<div>
<<<<<<< HEAD
    <h4>RolPorDepartamento</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Departamento.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Departamento.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombre)
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
             <a style="color: #007AFF" class="btn btn-default btn-sm" href="/RolPorDepartamento/Index">Regresar a la lista</a>
=======
    <h3>Rol por Departamento</h3>
    <section class="panel">
        <header class="panel-heading">
            ¿Desea eliminar este rol?
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
                    @Html.DisplayNameFor(Function(model) model.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombre)
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
                    <input type="submit" value="Eliminar" class="btn btn-default" />
                     <input type="submit" value="Deshabilitar" class="btn btn-default" />
                </div>
            End Using
>>>>>>> ad4a948f2736ace83dd3c49591d50b5c085268f6
        </div>
    </section>
    <div>
        @Html.ActionLink("Regresar a la lista", "Index")
    </div>
</div>
