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
    
    <button class="btn btn-default btn-sm"> @Html.ActionLink("Editar", "Edit", New With {.id = Model.ID}) </button> 
    <a style="color: #007AFF" class="btn btn-default btn-sm" href="/AreaDeConocimiento/Index">Regresar a la lista</a>
  
</p>
