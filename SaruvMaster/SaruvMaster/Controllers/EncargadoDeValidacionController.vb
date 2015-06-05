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
    Public Class EncargadoDeValidacionController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: EncargadoDeValidacion
        Function Index() As ActionResult
            Dim encargadoDeValidacion = db.encargadoDeValidacion.Include(Function(e) e.Facultad)
            Return View(encargadoDeValidacion.ToList())
        End Function

        ' GET: EncargadoDeValidacion/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim encargadoDeValidacion As EncargadoDeValidacion = db.encargadoDeValidacion.Find(id)
            If IsNothing(encargadoDeValidacion) Then
                Return HttpNotFound()
            End If
            Return View(encargadoDeValidacion)
        End Function

        ' GET: EncargadoDeValidacion/Create
        Function Create() As ActionResult
            ViewBag.FacultadID = New SelectList(db.Facultad, "ID", "Nombre")
            Return View()
        End Function

        ' POST: EncargadoDeValidacion/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombre,FacultadID,Telefono,Extensión,correoElectronico,FechaCreacion,FechaModificacion")> ByVal encargadoDeValidacion As EncargadoDeValidacion) As ActionResult
            If ModelState.IsValid Then
                db.EncargadoDeValidacion.Add(encargadoDeValidacion)
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.FacultadID = New SelectList(db.Facultad, "ID", "Nombre", encargadoDeValidacion.FacultadID)
            Return View(encargadoDeValidacion)
        End Function

        ' GET: EncargadoDeValidacion/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim encargadoDeValidacion As EncargadoDeValidacion = db.EncargadoDeValidacion.Find(id)
            If IsNothing(encargadoDeValidacion) Then
                Return HttpNotFound()
            End If
            ViewBag.FacultadID = New SelectList(db.Facultad, "ID", "Nombre", encargadoDeValidacion.FacultadID)
            Return View(encargadoDeValidacion)
        End Function

        ' POST: EncargadoDeValidacion/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombre,FacultadID,Telefono,Extensión,correoElectronico,FechaCreacion,FechaModificacion")> ByVal encargadoDeValidacion As EncargadoDeValidacion) As ActionResult
            If ModelState.IsValid Then
                db.Entry(encargadoDeValidacion).State = EntityState.Modified
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.FacultadID = New SelectList(db.Facultad, "ID", "Nombre", encargadoDeValidacion.FacultadID)
            Return View(encargadoDeValidacion)
        End Function

        ' GET: EncargadoDeValidacion/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim encargadoDeValidacion As EncargadoDeValidacion = db.encargadoDeValidacion.Find(id)
            If IsNothing(encargadoDeValidacion) Then
                Return HttpNotFound()
            End If
            Return View(encargadoDeValidacion)
        End Function

        ' POST: EncargadoDeValidacion/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim encargadoDeValidacion As EncargadoDeValidacion = db.encargadoDeValidacion.Find(id)
            db.encargadoDeValidacion.Remove(encargadoDeValidacion)
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
