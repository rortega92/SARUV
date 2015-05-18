@ModelType SaruvMaster.ModalidadDeCurso
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<!DOCTYPE html>

<div>
    <h3>Modalidad de Curso</h3>
    <section class="panel">
        <header class="panel-heading">
            ¿Desea eliminar la Modalidad?
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
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-actions no-color">
                    <input type="submit" value="Eliminar" class="btn btn-default" />
                </div>
            End Using
        </div>
    </section>
    <div>
        <a style="color: #007AFF" class="btn btn-default btn-sm" href="/ModalidadDeCurso/Index">Regresar a la lista</a>
    </div>
</div>
