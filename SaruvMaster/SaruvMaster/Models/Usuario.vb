Imports System.ComponentModel.DataAnnotations
Imports Microsoft.AspNet.Identity.EntityFramework
Public Class Usuario
    Public Property ID As Integer

    <Required(ErrorMessage:="Este campo es obligatorio.")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255.")>
    <RegularExpression("([A-ZÀÈÌÒÙÁÉÍÓÚÝÂÊÎÔÛÃÑÕÄËÏÖÜŸÇßØÅÆ][a-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+\s?)*", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    Public Property Nombre As String

    <Required(ErrorMessage:="Este campo es obligatorio.")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255.")>
    <RegularExpression("([A-ZÀÈÌÒÙÁÉÍÓÚÝÂÊÎÔÛÃÑÕÄËÏÖÜŸÇßØÅÆ][a-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+\s?)*", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    Public Property Apellido As String

    <Display(Name:="Departamento")>
    <Required(ErrorMessage:="Este campo es obligatorio.")>
    Public Property DepartamentoID As Integer
    Public Overridable Property Departamento As Departamento

    <Display(Name:="Rol por departamento")>
    <Required(ErrorMessage:="Este campo es obligatorio.")>
    Public Property RolPorDepartamentoID As Integer
    Public Overridable Property RolPorDepartamento As RolPorDepartamento

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date
    Public Property IsDeleted As Integer = 0

End Class
