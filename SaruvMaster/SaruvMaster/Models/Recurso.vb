Imports System.ComponentModel.DataAnnotations
Public Class Recurso
    Public Property Id As Integer

    <Display(Name:="Tema de Recurso"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, ErrorMessage:="Este campo permite un máximo de 255 caracteres")>
    <RegularExpression("([A-Za-zàèìòùÀÈÌÒÙáéíóúýÁÉÍÓÚÝâêîôûÂÊÎÔÛãñõÃÑÕäëïöüÿÄËÏÖÜŸçÇßØøÅåÆæœ0-9]+\s?)*", ErrorMessage:="Este es un campo alfanumérico que acepta letras, números y espacios")>
    Public Property Nombre As String

    <Display(Name:="Tipo de Recurso")>
    Public Property TipoDeRecursoID As Integer

    <Display(Name:="Tipo de Recurso")>
    Public Overridable Property TipoDeRecurso As TipoDeRecurso

    <Display(Name:="Modalidad De Curso")>
    Public Property ModalidadDeCursoID As Integer

    <Display(Name:="Modalidad De Curso")>
    Public Overridable Property ModalidadDeCurso As ModalidadDeCurso

    <Display(Name:="Empresa")>
    Public Property EmpresaID As Nullable(Of Integer)

    <Display(Name:="Empresa")>
    Public Overridable Property Empresa As Empresa

    <Display(Name:="Curso")>
    Public Property CursoID As Nullable(Of Integer)

    <Display(Name:="Curso")>
    Public Overridable Property Curso As Curso

    <Display(Name:="Cliente Corporativo")>
    Public Property ClienteCorporativoID As Nullable(Of Integer)

    <Display(Name:="Cliente Corporativo")>
    Public Overridable Property ClienteCorporativo As ClienteCorporativo

    <Display(Name:="Docente")>
    Public Property DocenteID As Nullable(Of Integer)

    <Display(Name:="Docente")>
    Public Overridable Property Docente As Docente

    <Display(Name:="Semana"), Required(ErrorMessage:="Este campo es obligatorio")>
    <Range(1, 10, ErrorMessage:="La semana solo puede ser entre 1 y 10")>
    Public Property Duracion As Integer

    <Display(Name:="Prioridad"), Required(ErrorMessage:="Este campo es obligatorio")>
    <StringLength(255, ErrorMessage:="Este campo permite un máximo de 255 caracteres")>
    Public Property Prioridad As String

    <Required(ErrorMessage:="Este campo es obligatorio")>
    <Display(Name:="Fecha Estimada de Entrega")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy-MM-dd}", ApplyFormatInEditMode:=True)>
    Public Property FechaEntrega As Date

    <Display(Name:="Fecha de creación")>
    <DataType(DataType.DateTime)>
    Public Property FechaCreacion As Date

    <Display(Name:="Fecha de modificación")>
    <DataType(DataType.DateTime)>
    Public Property FechaModificacion As Date

    Public Property IsDeleted As Integer = 0

    Public Overridable Property RecursoPorUsuario As ICollection(Of RecursoPorUsuario)

End Class
