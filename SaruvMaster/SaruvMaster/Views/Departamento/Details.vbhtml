@ModelType SaruvMaster.Departamento
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Departamento</h3>
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
    <button class="btn btn-default btn-sm"> @Html.ActionLink("Regresar a la lista", "Index") </button>
</p>