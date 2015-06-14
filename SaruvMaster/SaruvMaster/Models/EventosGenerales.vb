Imports System.ComponentModel.DataAnnotations
Public Class EventosGenerales

    Public Property ID As Integer

    <StringLength(255, ErrorMessage:="Este campo solo permite un máximo de 255 caracteres")>
    Public Property Evento As String

    Public Property StartString As String
    Public Property EndString As String

    <DataType(DataType.Date)>
    Public Property FechaReserva As Date

    <DataType(DataType.Time)>
    Public Property HoraInicio As Date

    <DataType(DataType.Time)>
    Public Property HoraFinal As Date

End Class
