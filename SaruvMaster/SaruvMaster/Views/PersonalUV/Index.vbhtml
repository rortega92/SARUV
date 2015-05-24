@ModelType IEnumerable(Of SaruvMaster.Recurso)
@Code
    ViewData("Title") = "View"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
<!--Inicio Si es Jefe-->
@Scripts.Render("~/Scripts/PersonalUV.js")
<!--Fin Si es Jefe-->
<div class="row">
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                Recursos
            </header>
            <div class="panel-body">
                @For Each item In Model
                    If (item.Prioridad.Equals("Alta")) Then
                        @<div class="alert alert-danger">
                             <table class="table" style="margin: 0px">
                                 <tr>
                                     <td style="border:0px">
                                         @Html.DisplayFor(Function(modelItem) item.Nombre)
                                     </td>
                                     <td class="navbar-right" style="border:0px">
                                         <div class="btn-group-vertical">
                                             <a id="CambiarEstado" class="btn btn-default btn-sm" href="javascript:;">Cambiar estado</a>
                                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Enviar al siguiente departamento</a>
                                         </div>
                                     </td>
                                 </tr>
                             </table>                          
                        </div>
                    ElseIf (item.Prioridad = "Media") Then
                        @<div class="alert alert-warning">
                             <table class="table" style="margin: 0px">
                                 <tr>
                                     <td style="border:0px">
                                         @Html.DisplayFor(Function(modelItem) item.Nombre)
                                     </td>
                                     <td class="navbar-right" style="border:0px">
                                         <div class="btn-group-vertical">
                                             <a id="CambiarEstado" class="btn btn-default btn-sm" href="javascript:;">Cambiar estado</a>
                                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Enviar al siguiente departamento</a>
                                         </div>
                                     </td>
                                 </tr>
                             </table>
                        </div>
                    Else
                        @<div class="alert alert-success">
                             <table class="table" style="margin: 0px">
                                 <tr>
                                     <td style="border:0px">
                                         @Html.DisplayFor(Function(modelItem) item.Nombre)
                                     </td>
                                     <td class="navbar-right" style="border:0px">
                                         <div class="btn-group-vertical">
                                             <a id="CambiarEstado" class="btn btn-default btn-sm" href="javascript:;">Cambiar estado</a>
                                             <a id="add-regular" class="btn btn-default btn-sm" href="javascript:;">Enviar al siguiente departamento</a>
                                         </div>
                                     </td>
                                 </tr>
                             </table>
                        </div>
                    End If
                Next
            </div>
        </section>
    </div>
    <div class="col-lg-12">
        <section class="panel">
            <header class="panel-heading">
                Personal
            </header>
            <div class="panel-body">
                <section class="panel">
                    <header class="panel-heading tab-bg-primary ">
                        <ul id="NavTabs" class="nav nav-tabs">
                        </ul>
                    </header>
                    <div class="panel-body">
                        <div id="TabContent" class="tab-content">
                        </div>
                    </div>
                </section>
            </div>
        </section>
    </div>
</div>

