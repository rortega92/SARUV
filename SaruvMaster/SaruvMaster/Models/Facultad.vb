Imports System.ComponentModel.DataAnnotations

Public Class Facultad
    Public Property ID As Integer
    <Required(ErrorMessage:="Este campo es obligatorio")>
    <RegularExpression("^([A-Z][a-zA-Z]+ ?)+?$", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
    <Display(Name:="Facultad")>
    Public Property Nombre As String

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date

    Public Property IsDeleted As Integer = 0

End Class

