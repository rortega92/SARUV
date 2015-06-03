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
    Public Class RolPorDepartamentoController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: RolPorDepartamento
        Function Index() As ActionResult
            Dim rolPorDepartamento = db.RolPorDepartamento.Include(Function(r) r.Departamento)
            Return View(rolPorDepartamento.ToList())
        End Function

        ' GET: RolPorDepartamento/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim rolPorDepartamento As RolPorDepartamento = db.RolPorDepartamento.Find(id)
            If IsNothing(rolPorDepartamento) Then
                Return HttpNotFound()
            End If
            Return View(rolPorDepartamento)
        End Function

        ' GET: RolPorDepartamento/Create
        Function Create() As ActionResult
            ViewBag.DepartamentoID = New SelectList(db.Departamento, "ID", "Nombre")
            Return View()
        End Function

        ' POST: RolPorDepartamento/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombre,DepartamentoID,FechaCreacion,FechaModificacion")> ByVal rolPorDepartamento As RolPorDepartamento) As ActionResult
            If ModelState.IsValid Then
                db.RolPorDepartamento.Add(rolPorDepartamento)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.DepartamentoID = New SelectList(db.Departamento, "ID", "Nombre", rolPorDepartamento.DepartamentoID)
            Return View(rolPorDepartamento)
        End Function

        ' GET: RolPorDepartamento/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim rolPorDepartamento As RolPorDepartamento = db.RolPorDepartamento.Find(id)
            If IsNothing(rolPorDepartamento) Then
                Return HttpNotFound()
            End If
            ViewBag.DepartamentoID = New SelectList(db.Departamento, "ID", "Nombre", rolPorDepartamento.DepartamentoID)
            Return View(rolPorDepartamento)
        End Function

        ' POST: RolPorDepartamento/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombre,DepartamentoID,FechaCreacion,FechaModificacion")> ByVal rolPorDepartamento As RolPorDepartamento) As ActionResult
            If ModelState.IsValid Then
                db.Entry(rolPorDepartamento).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.DepartamentoID = New SelectList(db.Departamento, "ID", "Nombre", rolPorDepartamento.DepartamentoID)
            Return View(rolPorDepartamento)
        End Function

        ' GET: RolPorDepartamento/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim rolPorDepartamento As RolPorDepartamento = db.RolPorDepartamento.Find(id)
            If IsNothing(rolPorDepartamento) Then
                Return HttpNotFound()
            End If
            Return View(rolPorDepartamento)
        End Function

        ' POST: RolPorDepartamento/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim rolPorDepartamento As RolPorDepartamento = db.RolPorDepartamento.Find(id)
            db.RolPorDepartamento.Remove(rolPorDepartamento)
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
