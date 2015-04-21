Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations



Public Class EmpresaModels

    Public Property ID As Integer

    <Display(Name:="Nombre"), Required>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un minimo de 5 letras y un maximo de 255 letras")>
    <RegularExpression("^[a-zA-Z ]*$", ErrorMessage:="Solo se aceptan letras y espacios")>
    Public Property Nombre As String

    <Display(Name:="Dirección"), Required>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un minimo de 5 letras y un maximo de 255 letras")>
    <RegularExpression("^[a-zA-Z ]*$", ErrorMessage:="Solo se aceptan letras y espacios")>
    Public Property Direccion As String

    <Display(Name:="Teléfono"), Required>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un minimo de 5 letras y un maximo de 255 letras")>
    <RegularExpression("^(\d{3}|\(\s*\d{3}\s*\))\s*-?\s*\d{4}\s*-?\s*\d{4}$", ErrorMessage:="Solo se aceptan los formatos: (504)-2233-4455, 504-2233-4455, 504-22334455, 50422334455")>
    Public Property Telefono As String

    <Display(Name:="Ciudad"), Required>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un minimo de 5 letras y un maximo de 255 letras")>
    <RegularExpression("^[a-zA-Z ]*$", ErrorMessage:="Solo se aceptan letras  y espacios")>
    Public Property Ciudad As String

    <Display(Name:="Departamento"), Required>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un minimo de 5 letras y un maximo de 255 letras")>
    <RegularExpression("^[a-zA-Z ]*$", ErrorMessage:="Solo se aceptan letras y espacios")>
    Public Property Departamento As String

End Class

Public Class EmpresaDbContext
    Inherits DbContext

    Public Property empresas As DbSet(Of EmpresaModels)

End Class
