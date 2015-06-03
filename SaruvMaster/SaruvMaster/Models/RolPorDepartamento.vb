Imports System.ComponentModel.DataAnnotations
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class RolPorDepartamento
    Public Property ID As Integer

    <Display(Name:="Rol")>
    <Required(ErrorMessage:="Este campo es obligatorio.")>
    <RegularExpression("[A-Z]([A-Za-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+\s?)*", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un un mínimo de 5 letras y un máximo de 255.")>
    Public Property Nombre As String

    <Required(ErrorMessage:="Este campo es obligatorio.")>
    Public Property DepartamentoID As Integer
    Public Overridable Property Departamento As Departamento
    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date

    Public Property IsDeleted As Integer = 0

End Class
