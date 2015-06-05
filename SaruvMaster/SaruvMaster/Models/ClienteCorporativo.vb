Imports System.ComponentModel.DataAnnotations
Public Class ClienteCorporativo
    Public Property ID As Integer

    <Display(Name:="Cliente Corporativo")>
    <Required(ErrorMessage:="Este campo es obligatorio"), RegularExpression("([A-ZÀÈÌÒÙÁÉÍÓÚÝÂÊÎÔÛÃÑÕÄËÏÖÜŸÇßØÅÆ][a-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+\s?)*", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    <StringLength(255, ErrorMessage:="Este campo permite un máximo de 255 caracteres")>
    Public Property Nombre As String

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, ErrorMessage:="Este campo permite un máximo de 255 caracteres")>
    <RegularExpression("([A-ZÀÈÌÒÙÁÉÍÓÚÝÂÊÎÔÛÃÑÕÄËÏÖÜŸÇßØÅÆ][a-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+\s?)*", ErrorMessage:="Solo se aceptan letras y un espacio")>
    Public Property Apellidos As String

    <Required(ErrorMessage:="Este campo es obligatorio"), RegularExpression("^[\d]{4}-[\d]{4}-[\d]{5}$", ErrorMessage:="Solo se acepta el formato: 1234-1950-12345")>
    <Display(Name:="Número de Identidad")>
    <StringLength(15, MinimumLength:=15, ErrorMessage:="Debe de existir exactamente 15 caracteres incluyendo '-' ")>
    Public Property NumeroIdentidad As String

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <Display(Name:="Correo Electrónico")>
    <EmailAddress(ErrorMessage:="Debe ser un formato de correo correcto. Ejemplo: testn@test.com")>
    Public Property CorreoElectronico As String

    <Display(Name:="Teléfono"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(15, MinimumLength:=11, ErrorMessage:="Este campo debe tener un mínimo de 11 números, representando código de país y número.")>
    <RegularExpression("^(\d{3}|\(\s*\d{3}\s*\))\s*-?\s*\d{4}\s*-?\s*\d{4}$", ErrorMessage:="Solo se aceptan los formatos: (504)-2233-4455, 504-2233-4455, 504-22334455, 50422334455")>
    Public Property Telefono As String

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <Display(Name:="Empresa")>
    Public Property EmpresaID As Integer

    Public Overridable Property Empresa As Empresa

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date = Date.Now

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date = Date.Now

    Public Property IsDeleted As Integer = 0

End Class
