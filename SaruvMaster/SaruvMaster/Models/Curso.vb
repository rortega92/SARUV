Imports System.ComponentModel.DataAnnotations
Public Class Curso

    Public Property ID As Integer

    <Required(ErrorMessage:="Este campo es obligatorio"), RegularExpression("^([a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð]+ ?)+?$", ErrorMessage:="Solo se aceptan letras y un espacio entre palabras")>
    <Display(Name:="Nombre")>
    <StringLength(255, MinimumLength:=3, ErrorMessage:="Solo se puede un minimo de 3 letras y un maximo de 255 letras")>
    Public Property Nombres As String

    <Display(Name:="Área de conocimiento")>
    Public Property AreaDeConocimientoID As Integer

    <Display(Name:="Área de conocimiento")>
    Public Overridable Property AreaDeConocimiento As AreaDeConocimiento

    <Display(Name:="Modalidad de Curso")>
    Public Property ModalidadDeCursoID As Integer

    <Display(Name:="Modalidad de Curso")>
    Public Overridable Property ModalidadDeCurso As ModalidadDeCurso

    <Display(Name:="Encargado de Validación")>
    Public Property EncargadoDeValidacionID As Integer

    <Display(Name:="Encargado de Validación")>
    Public Overridable Property EncargadoDeValidacion As EncargadoDeValidacion

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <Display(Name:="Fecha Inicio")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property FechaInicio As Date

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <Display(Name:="Fecha Final")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property FechaFinal As Date

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <Display(Name:="Período")>
    <Range(1, 5, ErrorMessage:="El período no puede ser menor a 1 o mayor a 5")>
    Public Property Periodo As Integer

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date


End Class
