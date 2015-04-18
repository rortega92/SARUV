Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations



Public Class AreasDeConocimientoModels

    Public Property ID As Integer
    <Display(Name:="Área de conocimiento"), Required>
    <StringLength(255, MinimumLength:=5, ErrorMessage:="Solo se puede un minimo de 5 letras y un maximo de 255 letras")>
    <RegularExpression("^[a-zA-Z0-9_ ]*$", ErrorMessage:="Solo se aceptan letras numeros y espacios")>
    Public Property AreaDeConocimiento As String

End Class

Public Class AreaConocimientoDbContext
    Inherits DbContext

    Public Property areas As DbSet(Of AreasDeConocimientoModels)

End Class
