Imports System.ComponentModel.DataAnnotations
Public Class TipoDeRecurso
    Public Property Id As Integer

    <StringLength(255, MinimumLength:=6, ErrorMessage:="Solo se puede un máximmo de 255 letras y un mínimo de 6 letras.")>
    <Display(Name:="Nombre de Recurso")>
    <Required(ErrorMessage:="Este campo es obligatorio")>
    <RegularExpression("^([a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+ ?)+?$", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    Public Property Nombre As String

    <Required(ErrorMessage:="Este campo es obligatorio.")>
    <Display(name:="Código de Recurso")>
    Public Property CodigoRecurso As String

    <Required(ErrorMessage:="Este campo es obligatorio.")>
    <DataType(DataType.Date)>
    <Display(Name:="Fecha de creación")>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property FechaDeCreacion As Date



End Class
