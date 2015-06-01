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
    Public Class DepartamentoController

        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: Departamento
        Function Index() As ActionResult
            Return View(db.Departamento.ToList())
        End Function

        ' GET: Departamento/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim departamento As Departamento = db.Departamento.Find(id)
            If IsNothing(departamento) Then
                Return HttpNotFound()
            End If
            Return View(departamento)
        End Function

        ' GET: Departamento/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Departamento/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombre")> ByVal departamento As Departamento) As ActionResult
            For i = 0 To db.Departamento.ToArray.Length - 1
                If db.Departamento.ToArray(i).Nombre = departamento.Nombre Then
                    ModelState.AddModelError(String.Empty, "El nombre del Departamento ya existe ")
                    Return View(departamento)
                    Exit For

                End If
            Next
            departamento.FechaCreacion = DateTime.Now
            departamento.FechaModificacion = departamento.FechaCreacion
            If ModelState.IsValid Then
                db.Departamento.Add(departamento)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(departamento)
        End Function

        ' GET: Departamento/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim departamento As Departamento = db.Departamento.Find(id)
            If IsNothing(departamento) Then
                Return HttpNotFound()
            End If
            Return View(departamento)
        End Function

        ' POST: Departamento/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombre,FechaCreacion,FechaModificacion")> ByVal departamento As Departamento) As ActionResult
            If ModelState.IsValid Then
                departamento.FechaModificacion = DateTime.Now
                db.Entry(departamento).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(departamento)
        End Function

        ' GET: Departamento/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim departamento As Departamento = db.Departamento.Find(id)
            If IsNothing(departamento) Then
                Return HttpNotFound()
            End If
            Return View(departamento)
        End Function

        ' POST: Departamento/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim departamento As Departamento = db.Departamento.Find(id)
            db.Departamento.Remove(departamento)
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
