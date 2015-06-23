@Imports Microsoft.AspNet.Identity
@If Request.IsAuthenticated Then
    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-right"})
        @Html.AntiForgeryToken()
        @<div class="top-nav notification-row">
            <ul class="nav pull-right top-menu">
                <li class="dropdown">
                    <a data-toggle="dropdown" class="dropdown-toggle" href="#"> <span class="username"> ¡Hola @User.Identity.GetUserName()! </span><b class="caret"></b> </a>
                    <ul class="dropdown-menu extended logout">
                        <div class="log-arrow-up"></div>
                        <li class="eborder-top"><a  href="/Manage/ChangePassword"> <i class="icon_key_alt"></i> Cambiar Contraseña</a></li>
                        <li ><a href="javascript:document.getElementById('logoutForm').submit()"><i class="fa fa-sign-out"></i>Cerrar Sesión</a></li>

                    </ul>
                </li>
            </ul>
        </div>
    End Using
Else
    @<ul class="nav navbar-nav navbar-right">
        @*<li>@Html.ActionLink("Registrarse", "Register", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "registerLink"})</li>*@
        <li>@Html.ActionLink("Iniciar Sesión", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink"})</li>
    </ul>
End If

