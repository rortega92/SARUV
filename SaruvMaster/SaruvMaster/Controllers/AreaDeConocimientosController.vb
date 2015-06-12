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
    Public Class AreaDeConocimientosController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: AreaDeConocimientos
        Function Index() As ActionResult
            Return View(db.AreaDeConocimiento.ToList())
        End Function

        ' GET: AreaDeConocimientos/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim areaDeConocimiento As AreaDeConocimiento = db.AreaDeConocimiento.Find(id)
            If IsNothing(areaDeConocimiento) Then
                Return HttpNotFound()
            End If
            Return View(areaDeConocimiento)
        End Function

        ' GET: AreaDeConocimientos/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: AreaDeConocimientos/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombre,FechaCreacion,FechaModificacion")> ByVal areaDeConocimiento As AreaDeConocimiento) As ActionResult
            If ModelState.IsValid Then
                db.AreaDeConocimiento.Add(areaDeConocimiento)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(areaDeConocimiento)
        End Function

        ' GET: AreaDeConocimientos/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim areaDeConocimiento As AreaDeConocimiento = db.AreaDeConocimiento.Find(id)
            If IsNothing(areaDeConocimiento) Then
                Return HttpNotFound()
            End If
            Return View(areaDeConocimiento)
        End Function

        ' POST: AreaDeConocimientos/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombre,FechaCreacion,FechaModificacion")> ByVal areaDeConocimiento As AreaDeConocimiento) As ActionResult
            If ModelState.IsValid Then
                db.Entry(areaDeConocimiento).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(areaDeConocimiento)
        End Function

        ' GET: AreaDeConocimientos/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim areaDeConocimiento As AreaDeConocimiento = db.AreaDeConocimiento.Find(id)
            If IsNothing(areaDeConocimiento) Then
                Return HttpNotFound()
            End If
            Return View(areaDeConocimiento)
        End Function

        ' POST: AreaDeConocimientos/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim areaDeConocimiento As AreaDeConocimiento = db.AreaDeConocimiento.Find(id)
            db.AreaDeConocimiento.Remove(areaDeConocimiento)
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
