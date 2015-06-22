Imports System.ComponentModel.DataAnnotations
Public Class EventosEstudio

    Public Property ID As Integer

    <StringLength(255, ErrorMessage:="Este campo solo permite un máximo de 255 caracteres")>
    Public Property Evento As String

    Public Property StartString As String
    Public Property EndString As String

    Public Property DocenteID As Nullable(Of Integer)

    Public Overridable Property Docente As Docente

    Public Property ClienteCorporativoID As Nullable(Of Integer)

    Public Overridable Property ClienteCorporativo As ClienteCorporativo

    <DataType(DataType.Date)>
    Public Property FechaReserva As Date

    <DataType(DataType.Time)>
    Public Property HoraInicio As Date

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
