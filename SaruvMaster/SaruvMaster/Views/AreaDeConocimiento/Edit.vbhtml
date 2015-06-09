@ModelType SaruvMaster.AreaDeConocimiento
@Code
    ViewData("Title") = "Editar"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h3>Area de conocimiento</h3>
<section class="panel">
    <header class="panel-heading">
        Editar
    </header>
    <div class="panel-body">
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">
                <hr />
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                @Html.HiddenFor(Function(model) model.ID)
                @Html.HiddenFor(Function(model) model.FechaCreacion)
                @Html.HiddenFor(Function(model) model.FechaModificacion)

                <div class="form-group">
                    @Html.LabelFor(Function(model) model.Nombre, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    <div class="col-md-10">
                        @Html.EditorFor(Function(model) model.Nombre, New With {.htmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(model) model.Nombre, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Guardar" class="btn btn-default" />
                    </div>
                </div>
            </div>
        End Using
    </div>
</section>
<div>
    <a style="color: #007AFF" class="btn btn-default btn-sm" href="/AreaDeConocimiento/Index">Regresar a la lista</a>
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
