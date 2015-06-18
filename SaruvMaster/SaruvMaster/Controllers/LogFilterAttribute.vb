Public Class LogFilterAttribute
    Inherits ActionFilterAttribute

    Public Overrides Sub OnActionExecuting(ByVal filterContext As  _
    ActionExecutingContext)
        Dim user = CType(filterContext.Controller, System.Web.Mvc.Controller).User
        If user.IsInRole("Admin").Equals(False) Then
            filterContext.RequestContext.HttpContext.Response.StatusCode = 401
        End If
    End Sub
End Class
