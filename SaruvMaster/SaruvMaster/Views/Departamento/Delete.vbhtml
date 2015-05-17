@ModelType SaruvMaster.Departamento
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code


<div>
    <h3>Departamento</h3>
    <section class="panel">
        <header class="panel-heading">
            Desea eliminar el Departmento?
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
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-group">
                    <input type="submit" value="Eliminar" class="btn btn-default" onclick="return ConfirmDelete();" />
                     <input type="submit" value="Deshabilitar" class="btn btn-default" />
                </div>
            End Using
        </div>
    </section>
    <div>
        <button class="btn btn-default btn-sm">Regresar a la lista @Html.ActionLink(Nothing, "Index") </button>
    </div>
</div>