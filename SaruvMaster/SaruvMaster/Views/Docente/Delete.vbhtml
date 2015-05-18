@ModelType SaruvMaster.Docente
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Docente</h3>
    <section class="panel">
        <header class="panel-heading">
            ¿Desea eliminar el Docente?
        </header>

        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.AreaDeConocimiento.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Facultad.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Facultad.Nombre)
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
                    @Html.DisplayNameFor(Function(model) model.NumeroTalentoHumano)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.NumeroTalentoHumano)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.correoElectronico)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.correoElectronico)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.telefono)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.telefono)
                </dd>

            </dl>
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-actions no-color">
                    <input type="submit" value="Eliminar" class="btn btn-default" /> 
                </div>
            End Using
        </div>
    </section>
    <div>
        <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Docente/Index">Regresar a la lista</a>
    </div>
</div>
