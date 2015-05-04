Imports System.ComponentModel.DataAnnotations
Public Class Docente
    Public Property ID As Integer
    <Required>
    <StringLength(255, MinimumLength:=7, ErrorMessage:="Solo se puede un minimo de 7 letras y un maximo de 255 letras")>
    Public Property Nombres As String

    <Required>
    <StringLength(255, MinimumLength:=10, ErrorMessage:="Solo se puede un minimo de 10 letras y un maximo de 255 letras")>
    Public Property Apellidos As String

    <Required, RegularExpression("^[\d]+$", ErrorMessage:="Solo se aceptan números")>
    <StringLength(5, MinimumLength:=5, ErrorMessage:="Exactamente 5 números")>
    Public Property NumeroTalentoHumano As String

    <Required>
    <Display(Name:="Correo Electrónico")>
    <EmailAddress(ErrorMessage:="Asegurate de tener un formato correcto de correo")>
    Public Property correoElectronico As String

    <Display(Name:="Teléfono"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
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
End Class
