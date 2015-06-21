Imports System.ComponentModel.DataAnnotations



Public Class Tarea
    Public Property ID As Integer
    <Display(Name:="Usuario")>
    Public Property UsuarioID As String
    <Display(Name:="Descripción"), Required(ErrorMessage:="Este campo es obligatorio")>
    Public Property Descripcion As String
    <DataType(DataType.Date)>
    Public Fecha As Date = Date.Now
    <Display(Name:="Usuario")>
    Public Overridable Property Usuario As ApplicationUser

End Class
