@ModelType IEnumerable(Of SaruvMaster.Recurso)
@Code
    ViewData("Title") = "View"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code
<div class="row">
    <div class="col-lg-6">
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
                    ElseIf (item.Prioridad = "Media") Then
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
    </div>
    <!--Si es Jefe
    <div class="col-lg-6">
        <section class="panel">
            <header class="panel-heading">
                Panels
            </header>
            <div class="panel-body">
                <div class="panel panel-primary">
                    <div class="panel-heading">Panel heading</div>
                    <div class="panel-content">Panel content</div>
                </div>
                <div class="panel panel-success">
                    <div class="panel-heading">Panel heading</div>
                    <div class="panel-content">Panel content</div>
                </div>
                <div class="panel panel-warning">
                    <div class="panel-heading">Panel heading</div>
                    <div class="panel-content">Panel content</div>
                </div>
                <div class="panel panel-danger">
                    <div class="panel-heading">Panel heading</div>
                    <div class="panel-content">Panel content</div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">Panel heading</div>
                    <div class="panel-content">Panel content</div>
                </div>
            </div>
        </section>
    </div>
        -->
</div>
<!--Si es Jefe-->
<!--
<script>
    $(function () {
        $(".panel-body").css("width", "50%");
        $(".panel-body").css("float", "left");
    });
</script>
    -->