@ModelType IndexViewModel
@Code
    ViewBag.Title = "Gestionar"
End Code

<h3>@ViewBag.Title</h3>
<section class="panel">
    <header class="panel-heading">
        Cambiar la configuración de la cuenta
    </header>
    <div class="panel-body">
        <div class="form-horizontal">

            <p class="text-success">@ViewBag.StatusMessage</p>
         

                <dl class="dl-horizontal">
                    <dt>Contraseña:</dt>
                    <dd>
                        [
                        @If Model.HasPassword Then
                            @Html.ActionLink("Cambiar la contraseña", "ChangePassword")
                        Else
                            @Html.ActionLink("Crear", "SetPassword")
                        End If
                        ]
                    </dd>                    
                </dl>            
        </div>
    </div>
</section>