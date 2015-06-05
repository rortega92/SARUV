Imports System.ComponentModel.DataAnnotations
Public Class EncargadoDeValidacion

    Public Property ID As Integer

    <Display(Name:="Encargado de Validación"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, ErrorMessage:="Este campo solo permite un máximo de 255 caracteres")>
    <RegularExpression("([A-ZÀÈÌÒÙÁÉÍÓÚÝÂÊÎÔÛÃÑÕÄËÏÖÜŸÇßØÅÆ][a-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+\s?)*", ErrorMessage:="Solo se aceptan letras y espacios")>
    Public Property Nombre As String

    <Display(Name:="Facultad")>
    Public Property FacultadID As Integer

    <Display(Name:="Teléfono"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(15, MinimumLength:=11, ErrorMessage:="Solo se aceptan los formatos: (504)-2233-4455, 504-2233-4455, 504-22334455, 50422334455")>
    <RegularExpression("^(\d{3}|\(\s*\d{3}\s*\))\s*-?\s*\d{4}\s*-?\s*\d{4}$", ErrorMessage:="Solo se aceptan los formatos: (504)-2233-4455, 504-2233-4455, 504-22334455, 50422334455")>
    Public Property Telefono As String

    <Display(Name:="Extensión:(Si aplica)")>
    <RegularExpression("^\d+$", ErrorMessage:="Solo se aceptan números")>
    <StringLength(6, MinimumLength:=3, ErrorMessage:="Se permite un mínimo de 3 números y un máximo de 6")>
    Public Property Extensión As String

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <Display(Name:="Correo Electrónico")>
    <EmailAddress(ErrorMessage:="Debe ser un formato de correo correcto. Ejemplo: testn@test.com")>
    Public Property correoElectronico As String

    <Display(Name:="Facultad")>
    Public Overridable Property Facultad As Facultad

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date = Date.Now

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date = Date.Now

    Public Property IsDeleted As Integer = 0

End Class
