@ModelType SaruvMaster.Facultad
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Facultad</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
        </header>
        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombre)
                </dd>

            </dl>
        </div>
    </section>
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Regresar a la lista", "Index")
</p>