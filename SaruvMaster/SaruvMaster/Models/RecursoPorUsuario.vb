Public Class RecursoPorUsuario

    Public Property ID As Integer

    Public Property RecursoID As Integer
    Public Property UsuarioID As String
    Public Property Estado As String

    Public Overridable Property Recurso As Recurso
    Public Overridable Property Usuario As ApplicationUser

End Class
