@ModelType SaruvMaster.Docente
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Docente</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
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
        </div>
    </section>
</div>
<p>
    <button class="btn btn-default btn-sm"> @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID}) </button>   
    <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Docente/Index">Regresar a la lista</a>
</p>
