@ModelType SaruvMaster.ClienteCorporativo
@Code
    ViewData("Title") = "Delete"
End Code

<div>
    <h3>Cliente Corporativo</h3>
    <section class="panel">
        <header class="panel-heading">
           ¿Desea eliminar el Cliente?
        </header>
        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Empresa.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Apellidos)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Apellidos)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.NumeroIdentidad)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.NumeroIdentidad)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.CorreoElectronico)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.CorreoElectronico)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Telefono)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Telefono)
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
        </div>
    </section>
    <div>
        <a  class="btn btn-default btn-sm" href="/ClienteCorporativo/Index">Regresar a la lista</a>
    </div>
</div>
