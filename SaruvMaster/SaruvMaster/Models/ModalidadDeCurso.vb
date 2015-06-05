Imports System.ComponentModel.DataAnnotations
Public Class ModalidadDeCurso
    Public Property ID As Integer

    <Display(Name:="Modalidad de Curso"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, ErrorMessage:="Este campo solo permite un máximo de 255 caracteres")>
    <RegularExpression("[A-Z]([A-Za-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+\s?)*", ErrorMessage:="Solo se aceptan letras y espacios")>
    Public Property Nombre As String

    <Display(Name:="Duración de Semanas"), Required(ErrorMessage:="Este campo es obligatorio")>
    <Range(1, 10, ErrorMessage:="La duración solo puede ser entre 5 y 10 semanas")>
    Public Property Duracion As Integer

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date = Date.Now

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date = Date.Now

    Public Property IsDeleted As Integer = 0

End Class
