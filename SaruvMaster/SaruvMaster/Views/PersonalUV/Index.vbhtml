@ModelType IEnumerable(Of SaruvMaster.Recurso)
@Code
    ViewData("Title") = "View"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
<section class="panel">
    <header class="panel-heading">
        Recursos
    </header>
    <div class="panel-body">
        @For Each item In Model
            If (item.Prioridad.Equals("Alta")) Then
                @<div class="alert alert-danger">
                     <ul class="navbar-right">
                         <li>
                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Cambiar estado</a>
                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Enviar al siguiente departamento</a>
                         </li>
                     </ul>
                    @Html.DisplayFor(Function(modelItem) item.Nombre)
                </div>            
            Else If (item.Prioridad = "Media") Then
                @<div class="alert alert-warning">
                     <ul class="navbar-right">
                         <li>
                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Cambiar estado</a>
                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Enviar al siguiente departamento</a>
                         </li>
                     </ul>
                    @Html.DisplayFor(Function(modelItem) item.Nombre)
                </div>
            Else
                @<div class="alert alert-success">
                     <ul class="navbar-right">
                         <li>
                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Cambiar estado</a>
                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Enviar al siguiente departamento</a>
                         </li>
                     </ul>
                    @Html.DisplayFor(Function(modelItem) item.Nombre)
                </div>
            End If

        Next
    </div>
</section>