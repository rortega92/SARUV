﻿@ModelType IEnumerable(Of SaruvMaster.EncargadoDeValidacion)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div class="row">
    <div class="col-md-12">
        <header class="panel-heading">
            <h3>Encargado de Validación</h3>
        </header>
        <div class="breadcrumb">
            @Html.ActionLink("Crear Nueva", "Create")
        </div>
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
                                @Html.DisplayNameFor(Function(model) model.Facultad.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Nombre)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Telefono)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.Extensión)
                            </th>
                            <th>
                                @Html.DisplayNameFor(Function(model) model.correoElectronico)
                            </th>
                            <th>
                                Acciones
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            @<tr>
                                 <th>
                                     @Html.DisplayNameFor(Function(model) model.Facultad.Nombre)
                                 </th>
                                 <th>
                                     @Html.DisplayNameFor(Function(model) model.Nombre)
                                 </th>
                                 <th>
                                     @Html.DisplayNameFor(Function(model) model.Telefono)
                                 </th>
                                 <th>
                                     @Html.DisplayNameFor(Function(model) model.Extensión)
                                 </th>
                                 <th>
                                     @Html.DisplayNameFor(Function(model) model.correoElectronico)
                                 </th>
                            </tr>
                        Next
                    </tbody>
                </table>
            </div>
        </section>
    </div>
</div>
