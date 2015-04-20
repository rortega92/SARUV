@ModelType SaruvMaster.AreasDeConocimientoModels
@Code
    ViewData("Title") = "Borrar"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h3>Eliminar</h3>
<div>
    <h4>Area de conocimiento</h4>
    <p>Desea eliminar el registro?</p>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.AreaDeConocimiento)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AreaDeConocimiento)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-group">
             <input type="submit" value="Eliminar" class="btn btn-default" />
         </div>        
    End Using
    <div>
        @Html.ActionLink("Regresar a la lista", "Index")
    </div>
</div>
