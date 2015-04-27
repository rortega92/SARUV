Imports System.ComponentModel.DataAnnotations

Public Class Facultad
    Public Property ID As Integer
    <Required, RegularExpression("^([a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+ ?)+?$", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
    <Display(Name:="Facultad")>
    Public Property Nombre As String

End Class

