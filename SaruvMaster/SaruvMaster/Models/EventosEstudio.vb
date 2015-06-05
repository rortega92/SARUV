Imports System.ComponentModel.DataAnnotations
Public Class EventosEstudio

    Public Property ID As Integer

    Public Property Evento As String

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

End Class
