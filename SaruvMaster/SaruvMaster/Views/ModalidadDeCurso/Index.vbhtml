@ModelType IEnumerable(Of SaruvMaster.ModalidadDeCurso)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code


<!DOCTYPE html>
<script>
    $(function () {
        $("#boton").click(function () {
            $("#Buscar").show("blind");
            $("#boton").hide();

        })
        $("#cancelar").click(function () {
            $("#Buscar").hide("blind");
            $("#boton").show();

        })
        $("#Buscar").hide();
    });
   
</script>

<div class="row">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Modalidad de Curso</h3>
        </header>
        <div class="breadcrumb">
            @Html.ActionLink("Crear Nueva", "Create") |
            <a  href ="javascript:void(0)" id="boton"> Buscar</a>
        </div>
        @Using Html.BeginForm("Index", "ModalidadDeCurso", FormMethod.Get)

        End Using
    </div>
</div>

<div id="Buscar" class="row" display:"none" style="margin-bottom:10px">
    <div class="col-xs-3 col-xs-offset-2" style="margin-top:10px">
        @Using Html.BeginForm("Index", "ModalidadDeCurso", FormMethod.Get)
            @<div class="input-group">
                @Html.TextBox("SearchString", Nothing, htmlAttributes:=New With {.class = "form-control", .placeholder = "Buscar por Nombre"})
                <span class="input-group-btn">
                    <button type="submit" value="Filter" class="btn btn-default"><span class="glyphicon glyphicon-search"></span></button>
                </span>                
            </div>
        End Using
        <a href="javascript:void(0)" id="cancelar">Cancelar</a>
    </div>
</div>

<div class="row">
    <div class="col-md-12">
        <section class="panel">
            <div class="panel-body">
                <table class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Duracion)
                            </th>
                            <th>Acciones</th>
                        </tr>
                    </thead>

                    <tbody>

                        @For Each item In Model
                            @<tr>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Nombre)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(modelItem) item.Duracion)
                                </td>
                                <td>
                                    @Html.ActionLink("Editar", "Edit", New With {.id = item.ID}) |
                                    @Html.ActionLink("Detalles", "Details", New With {.id = item.ID}) |
                                    @Html.ActionLink("Eliminar", "Delete", New With {.id = item.ID})
                                </td>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </section>
    </div>
</div>
