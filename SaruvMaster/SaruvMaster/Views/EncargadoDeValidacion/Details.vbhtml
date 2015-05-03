@ModelType SaruvMaster.EncargadoDeValidacion
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h2>Detalles</h2>

<div>
    <h3>Encargado de Validación</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
        </header>
        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Facultad.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Facultad.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Telefono)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Telefono)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Extensión)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Extensión)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.correoElectronico)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.correoElectronico)
                </dd>

            </dl>
        </div>
    </section>
</div>

<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Regresar a la Lista", "Index")
</p>
