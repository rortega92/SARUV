Imports System.ComponentModel.DataAnnotations
Public Class Docente
    Public Property ID As Integer
    <Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, ErrorMessage:="Este campo solo permite un máximo de 255 caracteres")>
    <RegularExpression("([A-ZÀÈÌÒÙÁÉÍÓÚÝÂÊÎÔÛÃÑÕÄËÏÖÜŸÇßØÅÆ][a-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+\s?)*", ErrorMessage:="Solo se aceptan letras y un espacio")>
    Public Property Nombres As String

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, ErrorMessage:="Este campo solo permite un máximo de 255 caracteres")>
    <RegularExpression("([A-ZÀÈÌÒÙÁÉÍÓÚÝÂÊÎÔÛÃÑÕÄËÏÖÜŸÇßØÅÆ][a-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ]+\s?)*", ErrorMessage:="Solo se aceptan letras y un espacio")>
    Public Property Apellidos As String

    <Required(ErrorMessage:="Este campo es obligatorio"), RegularExpression("^[\d]+$", ErrorMessage:="Solo se aceptan números")>
    <StringLength(5, MinimumLength:=5, ErrorMessage:="Este campo acepta un código de 5 dígitos")>
    Public Property NumeroTalentoHumano As String

    <Required(ErrorMessage:="Este campo es obligatorio")> <Display(Name:="Correo Electrónico")>
    <EmailAddress(ErrorMessage:="Debe ser un formato de correo correcto. Ejemplo: testn@test.com")>
    Public Property correoElectronico As String

    <Display(Name:="Teléfono"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(15, MinimumLength:=11, ErrorMessage:="Solo se aceptan los formatos: (504)-2233-4455, 504-2233-4455, 504-22334455, 50422334455")>
    <RegularExpression("^(\d{3}|\(\s*\d{3}\s*\))\s*-?\s*\d{4}\s*-?\s*\d{4}$", ErrorMessage:="Solo se aceptan los formatos: (504)-2233-4455, 504-2233-4455, 504-22334455, 50422334455")>
    Public Property telefono As String

    <Display(Name:="Área de conocimiento")>
    Public Property AreaDeConocimientoID As Integer

    <Display(Name:="Facultad")>
    Public Property FacultadID As Integer

    <Display(Name:="Área de conocimiento")>
    Public Overridable Property AreaDeConocimiento As AreaDeConocimiento

    <Display(Name:="Facultad")>
    Public Overridable Property Facultad As Facultad

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date

    Public Property IsDeleted As Integer = 0
End Class
