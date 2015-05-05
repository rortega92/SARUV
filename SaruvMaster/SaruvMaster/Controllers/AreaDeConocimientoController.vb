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
    Public Class AreaDeConocimientoController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: AreaDeConocimiento
        Function Index() As ActionResult
            Return View(db.AreaDeConocimiento.ToList())
        End Function

        ' GET: AreaDeConocimiento/Details/5
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

        ' GET: AreaDeConocimiento/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: AreaDeConocimiento/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombre")> ByVal areaDeConocimiento As AreaDeConocimiento) As ActionResult


            For i = 0 To db.AreaDeConocimiento.ToArray.Length - 1
                If db.AreaDeConocimiento.ToArray(i).Nombre = areaDeConocimiento.Nombre Then
                    ModelState.AddModelError(String.Empty, "El nombre del Área de Conocimiento ya existe ")
                    Return View(areaDeConocimiento)
                    Exit For

                End If
            Next
            areaDeConocimiento.FechaCreacion = DateTime.Now
            areaDeConocimiento.FechaModificacion = areaDeConocimiento.FechaCreacion
            If ModelState.IsValid Then
                db.AreaDeConocimiento.Add(areaDeConocimiento)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(areaDeConocimiento)
        End Function

        ' GET: AreaDeConocimiento/Edit/5
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

        ' POST: AreaDeConocimiento/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombre,FechaCreacion, FechaModificacion")> ByVal areaDeConocimiento As AreaDeConocimiento) As ActionResult
            areaDeConocimiento.FechaModificacion = DateTime.Now
            If ModelState.IsValid Then
                db.Entry(areaDeConocimiento).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(areaDeConocimiento)
        End Function

        ' GET: AreaDeConocimiento/Delete/5
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

        ' POST: AreaDeConocimiento/Delete/5
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
