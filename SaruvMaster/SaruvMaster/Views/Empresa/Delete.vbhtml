@ModelType SaruvMaster.Empresa
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<script>
    $(function () {
        $("#botonEliminar").click(function () {
            $("#dialog").dialog();
        })
    });
</script>

<div>
    <h3>Empresa</h3>
    <section class="panel">
        <header class="panel-heading">
            ¿Desea eliminar el registro?
        </header>
        <div class="panel-body">
            <div id="dialog" title="Advertencia">
                <p>Para borrar la Empresa primero debe borrar los Clientes Corporativos de esta empresa </p>
            </div>
            <dl class="dl-horizontal">
                
                <dt>
                    @Html.DisplayNameFor(Function(model) model.Nombre)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Nombre)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Direccion)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Direccion)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Telefono)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Telefono)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Ciudad)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Ciudad)
                </dd>

                <dt>
                    @Html.DisplayNameFor(Function(model) model.Departamento)
                </dt>

                <dd>
                    @Html.DisplayFor(Function(model) model.Departamento)
                </dd>

            </dl>
            @Using (Html.BeginForm())
                @Html.AntiForgeryToken()

                @<div class="form-group">
                     <input type="submit" value="Eliminar" class="btn btn-default" id="botonEliminar" />
                     <input type="submit" value="Deshabilitar" class="btn btn-default" />
                </div>
            End Using
        </div>
    </section>
    <div>
        <a style="color: #007AFF" class="btn btn-default btn-sm" href="/Empresa/Index">Regresar a la lista</a>
    </div>
</div>