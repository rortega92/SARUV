Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports SaruvMaster

Namespace Controllers
    Public Class CicloDeVidaController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: CicloDeVida
        Function Index(ByVal id As Integer?, ByVal searchConceptInput As String, ByVal searchString As String) As ActionResult
            If Not (id Is Nothing) Then
                Dim cicloDeVidaRecurso = db.CicloDeVida.Where(Function(e) e.RecursoID = id)
                Return View(cicloDeVidaRecurso.ToList())
            End If
            Dim cicloDeVida = db.CicloDeVida.Include(Function(c) c.Recurso).Include(Function(c) c.Usuario)

            If Not String.IsNullOrEmpty(searchString) Then

                Select Case searchConceptInput
                    Case "Nombre"
                        cicloDeVida = cicloDeVida.Where(Function(m) m.Recurso.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Usuario"
                        cicloDeVida = cicloDeVida.Where(Function(m) m.Usuario.Nombre.ToUpper().Contains(searchString.ToUpper()))
       
                    Case Else
                        cicloDeVida = cicloDeVida.Where(Function(m) m.Recurso.Nombre.ToUpper().Contains(searchString.ToUpper()))
                End Select
            End If

            Return View(cicloDeVida.ToList())
        End Function
    End Class
End Namespace
