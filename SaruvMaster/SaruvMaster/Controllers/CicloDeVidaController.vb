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
        Function Index(ByVal id As Integer?) As ActionResult
            If Not (id Is Nothing) Then
                Dim cicloDeVidaRecurso = db.CicloDeVida.Where(Function(e) e.RecursoID = id)
                Return View(cicloDeVidaRecurso.ToList())
            End If
            Dim cicloDeVida = db.CicloDeVida.Include(Function(c) c.Recurso).Include(Function(c) c.Usuario)
            Return View(cicloDeVida.ToList())
        End Function
    End Class
End Namespace
