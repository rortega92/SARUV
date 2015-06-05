@Code
    ViewBag.Title = "Error de inicio de sesión"
End Code

<h3>¡Error!</h3>
<section class="panel">
    <header class="panel-heading">@ViewBag.Title.       
    </header>
    <div class="panel-body">
        <div class="form-horizontal">
            <hr />
            <hgroup>                
                <h3 class="text-danger">El inicio de sesión con el servicio no se ha llevado a cabo correctamente.</h3>
            </hgroup>
        </div>
    </div>
</section>