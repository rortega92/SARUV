Imports System.ComponentModel.DataAnnotations
Public Class ModalidadDeCurso
    Public Property ID As Integer

    <Display(Name:="Nombre"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un mínimo de 5 letras y un máximo de 255 letras")>
    <RegularExpression("^([a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+ ?)+?$", ErrorMessage:="Solo se aceptan letras y espacios")>
    Public Property Nombre As String

    <Display(Name:="Duración de Semanas"), Required(ErrorMessage:="Este campo es obligatorio")>
    <Range(5, 10, ErrorMessage:="La duración solo puede ser entre 5 y 10 semanas")>
    Public Property Duracion As Integer

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date

End Class
