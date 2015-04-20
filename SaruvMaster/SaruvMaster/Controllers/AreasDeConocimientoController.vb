Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports SaruvMaster
Imports System.Data.SqlClient


Namespace Controllers
    Public Class AreasDeConocimientoController
        Inherits System.Web.Mvc.Controller

        Private db As New AreaConocimientoDbContext

        ' GET: AreasDeConocimiento
        Function Index() As ActionResult
            Return View(db.areas.ToList())
        End Function

        ' GET: AreasDeConocimiento/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim areasDeConocimientoModels As AreasDeConocimientoModels = db.areas.Find(id)
            If IsNothing(areasDeConocimientoModels) Then
                Return HttpNotFound()
            End If
            Return View(areasDeConocimientoModels)
        End Function

        ' GET: AreasDeConocimiento/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: AreasDeConocimiento/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,AreaDeConocimiento")> ByVal areasDeConocimientoModels As AreasDeConocimientoModels) As ActionResult
            If ModelState.IsValid Then
                db.areas.Add(areasDeConocimientoModels)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(areasDeConocimientoModels)
        End Function

        ' GET: AreasDeConocimiento/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim areasDeConocimientoModels As AreasDeConocimientoModels = db.areas.Find(id)
            If IsNothing(areasDeConocimientoModels) Then
                Return HttpNotFound()
            End If
            Return View(areasDeConocimientoModels)
        End Function

        ' POST: AreasDeConocimiento/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,AreaDeConocimiento")> ByVal areasDeConocimientoModels As AreasDeConocimientoModels) As ActionResult
            If ModelState.IsValid Then
                db.Entry(areasDeConocimientoModels).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(areasDeConocimientoModels)
        End Function

        ' GET: AreasDeConocimiento/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim areasDeConocimientoModels As AreasDeConocimientoModels = db.areas.Find(id)
            If IsNothing(areasDeConocimientoModels) Then
                Return HttpNotFound()
            End If
            Return View(areasDeConocimientoModels)
        End Function

        ' POST: AreasDeConocimiento/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim areasDeConocimientoModels As AreasDeConocimientoModels = db.areas.Find(id)
            db.areas.Remove(areasDeConocimientoModels)
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
