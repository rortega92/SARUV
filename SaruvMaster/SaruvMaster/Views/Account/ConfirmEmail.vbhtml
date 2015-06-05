@Code
    ViewBag.Title = "Confirmar correo electrónico"
End Code

<h3>@ViewBag.Title.</h3>
<section class="panel">
    <header class="panel-heading">Confimación de Correo</header>
    <div class=" =" panel-heading">
        <div class="form-horizontal">
            <hr />
            <p>
                Gracias por confirmar su correo electrónico. @Html.ActionLink("Haga clic aquí para iniciar sesión", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {Key .id = "loginLink"})
            </p>
        </div>
    </div>
</section>
