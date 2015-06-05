Imports System.ComponentModel.DataAnnotations
Public Class TipoDeRecurso
    Public Property Id As Integer

    <StringLength(255, ErrorMessage:="Este campo permite un máximo de 255 caracteres")>
    <Display(Name:="Tipo de Recurso")>
    <Required(ErrorMessage:="Este campo es obligatorio")>
    <RegularExpression("[A-Z]([A-Za-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+\s?)*", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    Public Property Nombre As String

    <Required(ErrorMessage:="Este campo es obligatorio.")>
    <Display(name:="Código de Recurso")>
    Public Property CodigoRecurso As String

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date = Date.Now

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date = Date.Now

    Public Property IsDeleted As Integer = 0

End Class
