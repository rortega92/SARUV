Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace SaruvMaster
    Public Class ModalidadDeCursoController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: /ModalidadDeCurso/
        Function Index() As ActionResult
            Return View(db.ModalidadDeCurso.ToList())
        End Function

        ' GET: /ModalidadDeCurso/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim modalidaddecurso As ModalidadDeCurso = db.ModalidadDeCurso.Find(id)
            If IsNothing(modalidaddecurso) Then
                Return HttpNotFound()
            End If
            Return View(modalidaddecurso)
        End Function

        ' GET: /ModalidadDeCurso/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: /ModalidadDeCurso/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include := "ID,Nombre,Duracion")> ByVal modalidaddecurso As ModalidadDeCurso) As ActionResult
            For i = 0 To db.ModalidadDeCurso.ToArray.Length - 1
                If db.ModalidadDeCurso.ToArray(i).Nombre = modalidaddecurso.Nombre Then
                    ModelState.AddModelError(String.Empty, "El nombre de la Facultad ya existe ")
                    Return View(modalidaddecurso)
                    Exit For

                End If
            Next
            modalidaddecurso.FechaCreacion = DateTime.Now
            modalidaddecurso.FechaModificacion = modalidaddecurso.FechaCreacion
            If ModelState.IsValid Then
                db.ModalidadDeCurso.Add(modalidaddecurso)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(modalidaddecurso)
        End Function

        ' GET: /ModalidadDeCurso/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim modalidaddecurso As ModalidadDeCurso = db.ModalidadDeCurso.Find(id)
            If IsNothing(modalidaddecurso) Then
                Return HttpNotFound()
            End If
            Return View(modalidaddecurso)
        End Function

        ' POST: /ModalidadDeCurso/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include := "ID,Nombre,Duracion")> ByVal modalidaddecurso As ModalidadDeCurso) As ActionResult
            If ModelState.IsValid Then
                db.Entry(modalidaddecurso).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(modalidaddecurso)
        End Function

        ' GET: /ModalidadDeCurso/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim modalidaddecurso As ModalidadDeCurso = db.ModalidadDeCurso.Find(id)
            If IsNothing(modalidaddecurso) Then
                Return HttpNotFound()
            End If
            Return View(modalidaddecurso)
        End Function

        ' POST: /ModalidadDeCurso/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim modalidaddecurso As ModalidadDeCurso = db.ModalidadDeCurso.Find(id)
            db.ModalidadDeCurso.Remove(modalidaddecurso)
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
