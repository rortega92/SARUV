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
    Public Class ModalidadDeCursoController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: ModalidadDeCurso
        Function Index() As ActionResult
            Return View(db.ModalidadDeCurso.ToList())
        End Function

        ' GET: ModalidadDeCurso/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim modalidadDeCurso As ModalidadDeCurso = db.ModalidadDeCurso.Find(id)
            If IsNothing(modalidadDeCurso) Then
                Return HttpNotFound()
            End If
            Return View(modalidadDeCurso)
        End Function

        ' GET: ModalidadDeCurso/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: ModalidadDeCurso/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombre,Duracion,FechaCreacion,FechaModificacion")> ByVal modalidadDeCurso As ModalidadDeCurso) As ActionResult
            If ModelState.IsValid Then
                db.ModalidadDeCurso.Add(modalidadDeCurso)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(modalidadDeCurso)
        End Function

        ' GET: ModalidadDeCurso/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim modalidadDeCurso As ModalidadDeCurso = db.ModalidadDeCurso.Find(id)
            If IsNothing(modalidadDeCurso) Then
                Return HttpNotFound()
            End If
            Return View(modalidadDeCurso)
        End Function

        ' POST: ModalidadDeCurso/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombre,Duracion,FechaCreacion,FechaModificacion")> ByVal modalidadDeCurso As ModalidadDeCurso) As ActionResult
            If ModelState.IsValid Then
                db.Entry(modalidadDeCurso).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(modalidadDeCurso)
        End Function

        ' GET: ModalidadDeCurso/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim modalidadDeCurso As ModalidadDeCurso = db.ModalidadDeCurso.Find(id)
            If IsNothing(modalidadDeCurso) Then
                Return HttpNotFound()
            End If
            Return View(modalidadDeCurso)
        End Function

        ' POST: ModalidadDeCurso/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim modalidadDeCurso As ModalidadDeCurso = db.ModalidadDeCurso.Find(id)
            db.ModalidadDeCurso.Remove(modalidadDeCurso)
            db.SaveChanges()
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
