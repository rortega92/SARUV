﻿Imports System.ComponentModel.DataAnnotations

Public Class Empresa

    Public Property ID As Integer

    <Display(Name:="Empresa"), Required>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
    <RegularExpression("^[a-zA-Z ]*$", ErrorMessage:="Solo se aceptan letras y espacios")>
    Public Property Nombre As String

    <Display(Name:="Dirección"), Required>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
    <RegularExpression("^([a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð\d]+ ?.?)+?$", ErrorMessage:="Solo se aceptan letras, números, punto y un espacio entre palabras")>
    Public Property Direccion As String

    <Display(Name:="Teléfono"), Required>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
    <RegularExpression("^(\d{3}|\(\s*\d{3}\s*\))\s*-?\s*\d{4}\s*-?\s*\d{4}$", ErrorMessage:="Solo se aceptan los formatos: (504)-2233-4455, 504-2233-4455, 504-22334455, 50422334455")>
    Public Property Telefono As String

    <Display(Name:="Ciudad"), Required>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
    <RegularExpression("^[a-zA-Z ]*$", ErrorMessage:="Solo se aceptan letras  y espacios")>
    Public Property Ciudad As String

    <Display(Name:="Departamento"), Required>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
    <RegularExpression("^[a-zA-Z ]*$", ErrorMessage:="Solo se aceptan letras y espacios")>
    Public Property Departamento As String

End Class