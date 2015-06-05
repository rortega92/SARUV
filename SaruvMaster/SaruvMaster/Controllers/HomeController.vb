Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        If My.User.IsAuthenticated Then
            If My.User.IsInRole("Admin") Then
                ViewBag.pageTitle = "Administración"
                Return View()
            Else
                Return RedirectToAction("Index", "PersonalUV")
            End If
        End If
        ViewBag.pageTitle = ""
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
