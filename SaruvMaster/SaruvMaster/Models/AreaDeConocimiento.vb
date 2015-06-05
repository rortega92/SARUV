Imports System.ComponentModel.DataAnnotations


Public Class AreaDeConocimiento

    Public Property ID As Integer
    <Display(Name:="Área de conocimiento"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, ErrorMessage:="Este campo permite un máximo de 255 caracteres")>
    <RegularExpression("[A-Z]([A-Za-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+\s?)*", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    Public Property Nombre As String

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date = Date.Now

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date = Date.Now

    Public Property IsDeleted As Integer = 0

End Class
