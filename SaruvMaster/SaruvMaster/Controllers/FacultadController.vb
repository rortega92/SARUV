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
    Public Class FacultadController
        Inherits System.Web.Mvc.Controller

        Private db As New FacultadDbContext

        ' GET: Facultad
        Function Index() As ActionResult
            Return View(db.facultades.ToList())
        End Function

        ' GET: Facultad/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim facultadModels As FacultadModels = db.facultades.Find(id)
            If IsNothing(facultadModels) Then
                Return HttpNotFound()
            End If
            Return View(facultadModels)
        End Function

        ' GET: Facultad/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Facultad/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombre")> ByVal facultadModels As FacultadModels) As ActionResult
            If ModelState.IsValid Then
                db.facultades.Add(facultadModels)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(facultadModels)
        End Function

        ' GET: Facultad/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim facultadModels As FacultadModels = db.facultades.Find(id)
            If IsNothing(facultadModels) Then
                Return HttpNotFound()
            End If
            Return View(facultadModels)
        End Function

        ' POST: Facultad/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombre")> ByVal facultadModels As FacultadModels) As ActionResult
            If ModelState.IsValid Then
                db.Entry(facultadModels).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(facultadModels)
        End Function

        ' GET: Facultad/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim facultadModels As FacultadModels = db.facultades.Find(id)
            If IsNothing(facultadModels) Then
                Return HttpNotFound()
            End If
            Return View(facultadModels)
        End Function

        ' POST: Facultad/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim facultadModels As FacultadModels = db.facultades.Find(id)
            db.facultades.Remove(facultadModels)
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
