@ModelType ExternalLoginListViewModel
@Imports Microsoft.Owin.Security
@Code
    Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
End Code

@Using Html.BeginForm("ExternalLogin", "Account", New With {.ReturnUrl = Model.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
    @Html.AntiForgeryToken()
    @<div id="socialLoginList">
       <p>
           @For Each p As AuthenticationDescription In loginProviders
               @<button type="submit" class="btn btn-default" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="Inicie sesión con su cuenta @p.Caption">@p.AuthenticationType</button>
           Next
       </p>
    </div>
End Using