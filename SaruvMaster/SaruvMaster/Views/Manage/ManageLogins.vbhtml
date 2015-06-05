@ModelType ManageLoginsViewModel
@Imports Microsoft.Owin.Security
@Imports Microsoft.AspNet.Identity
@Code
    ViewBag.Title = "Administrar los inicios de sesión externos"
End Code

<h3>@ViewBag.Title.</h3>
<section class="panel">
    <header class="panel-heading">
        Inicios de sesión registrados
    </header>
    <div class="panel-body">
        <div class="form-horizontal">

            <p class="text-success">@ViewBag.StatusMessage</p>
            @Code
                Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
                If loginProviders.Count = 0 Then
                @<div>
                    <p>
                        No hay servicios de autenticación externos configurados. Consulte <a href="http://go.microsoft.com/fwlink/?LinkId=313242">este artículo</a>
                        para obtener más información acerca de la configuración de esta aplicación ASP.NET para admitir el inicio de sesión mediante servicios externos.
                    </p>
                </div>
                Else
                    If Model.CurrentLogins.Count > 0 Then

                @<table class="table">
                    <tbody>
                        @For Each account As UserLoginInfo In Model.CurrentLogins
                            @<tr>
                                <td>@account.LoginProvider</td>
                                <td>
                                    @If ViewBag.ShowRemoveButton Then
                                        @Using Html.BeginForm("RemoveLogin", "Manage")
                                            @Html.AntiForgeryToken()
                                            @<div>
                                                @Html.Hidden("loginProvider", account.LoginProvider)
                                                @Html.Hidden("providerKey", account.ProviderKey)
                                                <input type="submit" class="btn btn-default" value="Quitar" title="Quitar este inicio de sesión @account.LoginProvider de su cuenta" />
                                            </div>
                                        End Using
                                    Else
                                        @: &nbsp;
                                End If
                                </td>
                            </tr>
                                Next
                    </tbody>
                </table>
                    End If
                    If Model.OtherLogins.Count > 0 Then
                @<text>
                    <h4>Agregue otro servicio para iniciar sesión.</h4>
                    <hr />
                </text>
                @Using Html.BeginForm("LinkLogin", "Manage")
                    @Html.AntiForgeryToken()
                    @<div id="socialLoginList">
                        <p>
                            @For Each p As AuthenticationDescription In Model.OtherLogins
                                @<button type="submit" class="btn btn-default" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="Iniciar sesión con la cuenta @p.Caption">@p.AuthenticationType</button>
                            Next
                        </p>
                    </div>
                        End Using
                    End If
                End If
            End Code
        </div>
    </div>
</section>
