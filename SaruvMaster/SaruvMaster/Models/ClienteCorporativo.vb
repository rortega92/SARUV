Imports System.ComponentModel.DataAnnotations
Public Class ClienteCorporativo
    Public Property ID As Integer

    <Required(ErrorMessage:="Este campo es obligatorio"), RegularExpression("^([a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+ ?)+?$", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    <StringLength(255, MinimumLength:=7, ErrorMessage:="Solo se puede un mínimo de 7 letras y un máximo de 255 letras")>
    Public Property Nombres As String

    <Required(ErrorMessage:="Este campo es obligatorio"), RegularExpression("^([a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+ ?)+?$", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    <StringLength(255, MinimumLength:=10, ErrorMessage:="Solo se puede un mínimo de 10 letras y un máximo de 255 letras")>
    Public Property Apellidos As String

    <Required(ErrorMessage:="Este campo es obligatorio"), RegularExpression("^[\d]{4}-[\d]{4}-[\d]{5}$", ErrorMessage:="Solo se acepta el formato: 1234-1950-12345")>
    <Display(Name:="Número de Identidad")>
    <StringLength(15, MinimumLength:=15, ErrorMessage:="Debe de existir exactamente 15 caracteres incluyendo '-' ")>
    Public Property NumeroIdentidad As String

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <Display(Name:="Correo Electrónico")>
    <EmailAddress(ErrorMessage:="Asegurate de tener un formao correcto de correo")>
    Public Property CorreoElectronico As String

    <Display(Name:="Teléfono"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
    <RegularExpression("^(\d{3}|\(\s*\d{3}\s*\))\s*-?\s*\d{4}\s*-?\s*\d{4}$", ErrorMessage:="Solo se aceptan los formatos: (504)-2233-4455, 504-2233-4455, 504-22334455, 50422334455")>
    Public Property Telefono As String

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <Display(Name:="Empresa")>
    Public Property EmpresaID As Integer

    Public Overridable Property Empresa As Empresa

End Class
