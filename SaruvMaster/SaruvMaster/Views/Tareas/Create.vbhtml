﻿@ModelType SaruvMaster.Tarea
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
    
End Code

<h3>Tarea</h3>
<section class="panel">
    <header class="panel-heading">
        Crear
    </header>
    <div class="panel-body">

        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">

                <hr />
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})


                <div class="form-group">
                    <label for="Nombre" class="control-label col-md-2">Descripción @Html.Label("*", htmlAttributes:=New With {.class = "text-danger"}) </label>
                    
                    <div class="col-md-10">
                     
                        @Html.TextAreaFor(Function(model) model.Descripcion, New With {.class = "form-control"})
                        @Html.ValidationMessageFor(Function(model) model.Descripcion, "", New With {.class = "text-danger"})
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Crear" class="btn btn-default" />
                    </div>
                </div>
            </div>
        End Using
    </div>
</section>

<div>
    <a class="btn btn-default btn-sm" href="/Tarea/Index">Regresar a la lista</a>
</div>
