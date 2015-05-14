Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace SaruvMaster
    Public Class PersonalUVController
        Inherits Controller


        Private db As New Connection

        ' GET: /Recurso/
        Function Index() As ActionResult
            Dim recursoes = db.Recursoes.Include(Function(r) r.ClienteCorporativo).Include(Function(r) r.Curso).Include(Function(r) r.Docente).Include(Function(r) r.Empresa).Include(Function(r) r.ModalidadDeCurso).Include(Function(r) r.TipoDeRecurso)
            Return View(recursoes.ToList())
        End Function
    End Class
End Namespace