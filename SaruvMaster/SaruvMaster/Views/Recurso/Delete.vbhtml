@ModelType SaruvMaster.Recurso
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Recurso</h3>
    <section class="panel">
        <header class="panel-heading">
            Desea eliminar el registro?
        </header>
        <div class="panel-body">

            <dl class="dl-horizontal">
                <dt>
                    @Html.DisplayNameFor(Function(model) model.ClienteCorporativo.Nombres)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.ClienteCorporativo.Nombres)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Curso.Nombres)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Curso.Nombres)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Docente.Nombres)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Docente.Nombres)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Empresa.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.ModalidadDeCurso.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.ModalidadDeCurso.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.TipoDeRecurso.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.TipoDeRecurso.Nombre)
                </dd>

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

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Prioridad)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Prioridad)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.FechaEntrega)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.FechaEntrega)
                </dd>

            </dl>
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-group">
                    <input type="submit" value="Eliminar" class="btn btn-default" />
                     <input type="submit" value="Deshabilitar" class="btn btn-default" />
                </div>
            End Using
        </div>
    </section>
    <div>
        <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Recurso/Index">Regresar a la lista</a>
    </div>
</div>
