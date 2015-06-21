@ModelType SaruvMaster.AreaDeConocimiento
@Code
    ViewData("Title") = "Detalles"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<div>
    <h3>Area de conocimiento</h3>
    <section class="panel">
        <header class="panel-heading">
            Detalles
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
        </div>
    </section>
</div>
<p>
    
    <a class="btn btn-default btn-sm" href="@Url.Action("Edit", New With {.id = Model.ID})"><span class="glyphicon glyphicon-pencil"></span> Editar</a>
    <a class="btn btn-default btn-sm" href="/AreaDeConocimiento/Index">Regresar a la lista</a>
  
</p>
