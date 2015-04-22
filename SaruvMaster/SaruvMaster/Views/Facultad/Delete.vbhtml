@ModelType SaruvMaster.Facultad
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Facultad</h3>
    <section class="panel">
        <header class="panel-heading">
            Desea eliminar el registro?
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
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-group">
                    <input type="submit" value="Eliminar" class="btn btn-default" />
                </div>
            End Using
        </div>
    </section>
    <div>
        @Html.ActionLink("Regresar a la lista", "Index")
    </div>
</div>