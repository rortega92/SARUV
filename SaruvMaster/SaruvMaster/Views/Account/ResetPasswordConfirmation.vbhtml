@Code
    ViewBag.Title = "Confirmación de restablecimiento de contraseña"
End Code

<hgroup class="title">
    <h3>Restablecer contraseña</h3>
</hgroup>

<section class="panel">
    <header class="panel-heading"> @ViewBag.Title.
    </header>
    <div class="panel-body">
        <div class="form-horizontal">
            <div>
                <p>
                    Se restableció la contraseña. @Html.ActionLink("Haga clic aquí para iniciar sesión", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {Key .id = "loginLink"})
                </p>
            </div>
        </div>
    </div>
</section>
