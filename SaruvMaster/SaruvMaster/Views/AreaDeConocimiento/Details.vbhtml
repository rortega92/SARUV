@ModelType SaruvMaster.AreasDeConocimientoModels
@Code
    ViewData("Title") = "Detalles"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Area de conocimiento</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
        </header>
        <div class="panel-body">
            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.AreaDeConocimiento)
                </dd>

            </dl>
        </div>
    </section>
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Regresar a la lista", "Index")
</p>
