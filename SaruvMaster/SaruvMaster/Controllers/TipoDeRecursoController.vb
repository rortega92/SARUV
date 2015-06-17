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
    <LogFilter>
    Public Class TipoDeRecursoController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: TipoDeRecurso
        Function Index() As ActionResult
            Return View(db.TipoDeRecurso.ToList())
        End Function

        ' GET: TipoDeRecurso/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tipoDeRecurso As TipoDeRecurso = db.TipoDeRecurso.Find(id)
            If IsNothing(tipoDeRecurso) Then
                Return HttpNotFound()
            End If
            Return View(tipoDeRecurso)
        End Function

        ' GET: TipoDeRecurso/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: TipoDeRecurso/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Nombre,CodigoRecurso,FechaCreacion,FechaModificacion")> ByVal tipoDeRecurso As TipoDeRecurso) As ActionResult
            If ModelState.IsValid Then
                db.TipoDeRecurso.Add(tipoDeRecurso)
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            Return View(tipoDeRecurso)
        End Function

        ' GET: TipoDeRecurso/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tipoDeRecurso As TipoDeRecurso = db.TipoDeRecurso.Find(id)
            If IsNothing(tipoDeRecurso) Then
                Return HttpNotFound()
            End If
            Return View(tipoDeRecurso)
        End Function

        ' POST: TipoDeRecurso/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Nombre,CodigoRecurso,FechaCreacion,FechaModificacion")> ByVal tipoDeRecurso As TipoDeRecurso) As ActionResult
            If ModelState.IsValid Then
                db.Entry(tipoDeRecurso).State = EntityState.Modified
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            Return View(tipoDeRecurso)
        End Function

        ' GET: TipoDeRecurso/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tipoDeRecurso As TipoDeRecurso = db.TipoDeRecurso.Find(id)
            If IsNothing(tipoDeRecurso) Then
                Return HttpNotFound()
            End If
            Return View(tipoDeRecurso)
        End Function

        ' POST: TipoDeRecurso/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim tipoDeRecurso As TipoDeRecurso = db.TipoDeRecurso.Find(id)
            db.TipoDeRecurso.Remove(tipoDeRecurso)
            db.Savechanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
