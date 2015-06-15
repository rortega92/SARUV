Imports System.ComponentModel.DataAnnotations

Public Class ArchivoUsuario
    Public Property ID As Integer
    Public Property NombreArchivo As String
    Public Property TipoArchivo As Integer
    Public Property RecursoID As Integer

    Public Overridable Property Recurso As Recurso
    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date = Date.Now

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date = Date.Now

    Public Property IsDeleted As Integer = 0
End Class
