Imports System.Data.Entity

Namespace Models
    Public Class Facultad
        Public Property ID As Integer
        Public Property Nombre As String

    End Class

    Public Class FacultadDbContext
        Inherits DbContext

        Public Property Facultad As DbSet(Of Facultad)
    End Class

End Namespace