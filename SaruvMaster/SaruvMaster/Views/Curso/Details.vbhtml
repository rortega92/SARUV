@ModelType SaruvMaster.Curso

@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<!DOCTYPE html>

<div>
    <h3>Curso</h3>
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
                    @Html.DisplayFor(Function(model) model.AreaDeConocimiento.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.EncargadoDeValidacion)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.EncargadoDeValidacion.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.ModalidadDeCurso.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nombres)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombres)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.FechaInicio)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.FechaInicio)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.FechaFinal)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.FechaFinal)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Periodo)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Periodo)
                </dd>

            </dl>
        </div>
    </section>
</div>
<p>
    @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Resgresar a la lista", "Index")
</p>