@ModelType SaruvMaster.ModalidadDeCurso
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<!DOCTYPE html>

<div>
    <h3>Modalidad de Curso</h3>
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
                    @Html.DisplayNameFor(Function(model) model.Duracion)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Duracion)
                </dd>
            </dl>
        </div>
    </section>
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Resgresar a la lista", "Index")
</p>
