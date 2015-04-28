Imports System.ComponentModel.DataAnnotations


Public Class AreaDeConocimiento

    Public Property ID As Integer
    <Display(Name:="Área de conocimiento"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un minimo de 5 letras y un maximo de 255 letras")>
    <RegularExpression("^([a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+ ?)+?$", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    Public Property Nombre As String

End Class
