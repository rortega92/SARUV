@ModelType Curso

@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<!DOCTYPE html>

<div>
    <h3>Curso</h3>
    <section class="panel">
        <header class="panel-heading">
            ¿Desea eliminar el Curso?
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
        <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Curso/Index">Regresar a la lista</a>
    </div>
</div>