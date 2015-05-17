@ModelType SaruvMaster.TipoDeRecurso
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Tipo de Recurso</h3>
    <section class="panel">
        <header class="panel-heading">
            ¿Desea eliminar el tipo?
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
                    @Html.DisplayNameFor(Function(model) model.CodigoRecurso)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.CodigoRecurso)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.FechaDeCreacion)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.FechaDeCreacion)
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
        @Html.ActionLink("Regresar a la lista", "Index")
    </div>
</div>
