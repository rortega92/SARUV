﻿Imports System.ComponentModel.DataAnnotations
Public Class EncargadoDeValidacion

    Public Property ID As Integer

    <Display(Name:="Encargado de Validación"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
    <RegularExpression("^(([A-Z][a-zàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+) ?)+$", ErrorMessage:="Solo se aceptan letras y espacios")>
    Public Property Nombre As String

    <Display(Name:="Facultad")>
    Public Property FacultadID As Integer

    <Display(Name:="Teléfono"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
    <RegularExpression("^(\d{3}|\(\s*\d{3}\s*\))\s*-?\s*\d{4}\s*-?\s*\d{4}$", ErrorMessage:="Solo se aceptan los formatos: (504)-2233-4455, 504-2233-4455, 504-22334455, 50422334455")>
    Public Property Telefono As String

    <Display(Name:="Extensión:(Si aplica)")>
    <RegularExpression("^\d+$", ErrorMessage:="Solo se aceptan números")>
    <StringLength(4, MinimumLength:=4, ErrorMessage:="Solo se puede un total de 4 números")>
    Public Property Extensión As String

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <Display(Name:="Correo Electrónico")>
    <EmailAddress(ErrorMessage:="Asegurate de tener un formao correcto de correo")>
    Public Property correoElectronico As String

    <Display(Name:="Facultad")>
    Public Overridable Property Facultad As Facultad

End Class
