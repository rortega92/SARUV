Imports System.ComponentModel.DataAnnotations
Imports SaruvMaster.Departamento
Public Class Departamento
    Public Property ID As Integer
    <RegularExpression("^([a-zA-Z\d]+ ?)+?$", ErrorMessage:="Solo se aceptan letras, números y un espacio entre palabras")>
    <Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 caracteres y un máximo de 255")>
    Public Property Nombre As String

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As DateTime

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As DateTime
    Public Property IsDeleted As Integer = 0

End Class
