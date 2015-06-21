Imports System.ComponentModel.DataAnnotations



Public Class Tarea
    Public Property ID As Integer
    Public Property UsuarioID As Integer
    Public Property Descripcion As String
    <DataType(DataType.Date)>
    Public Fecha As Date = Date.Now
    Public Overridable Property Usuario As ApplicationUser

End Class
