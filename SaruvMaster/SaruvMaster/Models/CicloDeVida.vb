Imports System.ComponentModel.DataAnnotations


Public Class CicloDeVida

    Public Property ID As Integer

    Public Property RecursoID As Integer
    Public Property UsuarioID As String
    Public Property Estado As String

    Public Overridable Property Recurso As Recurso
    Public Overridable Property Usuario As ApplicationUser

    <DataType(DataType.Date)>
    Public Property FechaModificacion As Date

    Public Property Observacion As String



End Class
