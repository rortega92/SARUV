Imports System.ComponentModel.DataAnnotations

Public Class EventosCalendario
    Public Property ID As Integer

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, ErrorMessage:="Este campo solo permite un máximo de 255 caracteres")>
    Public Property Evento As String

    <Required(ErrorMessage:="Este campo es obligatorio")>
    Public Property Description As String

    Public Property StartString As String
    Public Property EndString As String

    <DataType(DataType.Date)>
        Public Property FechaReserva As Date

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <DataType(DataType.Time)>
    Public Property HoraInicio As Date

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <DataType(DataType.Time)>
    Public Property HoraFinal As Date

    Public Property IsDeleted As Integer = 0

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date = Date.Now

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date = Date.Now
End Class
