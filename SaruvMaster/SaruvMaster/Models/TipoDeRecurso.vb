Imports System.ComponentModel.DataAnnotations
Public Class TipoDeRecurso
    Public Property Id As Integer

    <StringLength(255, ErrorMessage:="Este campo permite un máximo de 255 caracteres")>
    <Display(Name:="Nombre de Recurso")>
    <Required(ErrorMessage:="Este campo es obligatorio")>
    <RegularExpression("^([A-Z][a-zA-Z]+ ?)+?$", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    Public Property Nombre As String

    <Required(ErrorMessage:="Este campo es obligatorio.")>
    <Display(name:="Código de Recurso")>
    Public Property CodigoRecurso As String

    <Required(ErrorMessage:="Este campo es obligatorio.")>
    <DataType(DataType.Date)>
    <Display(Name:="Fecha de creación")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property FechaDeCreacion As Date

    Public Property IsDeleted As Integer = 0

End Class
