@ModelType SaruvMaster.ClienteCorporativo
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Cliente Corporativo</h3>
    <section class="panel">
        <header class="panel-heading">
            Desea eliminar el registro?
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
                    @Html.DisplayNameFor(Function(model) model.Nombres)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombres)
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

            </dl>
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-group">
                    <input type="submit" value="Eliminar" class="btn btn-default" />
                </div>
            End Using
        </div>
    </section>
    <div>
        <a style="color: #007AFF" class="btn btn-default btn-sm" href="/ClienteCorporativo/Index">Regresar a la lista</a>
    </div>
</div>

