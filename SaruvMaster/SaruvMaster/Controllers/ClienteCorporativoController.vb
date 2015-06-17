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
    Public Class ClienteCorporativoController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: ClienteCorporativo
        Function Index() As ActionResult
            Dim clienteCorporativo = db.ClienteCorporativo.Include(Function(c) c.Empresa)
            Return View(clienteCorporativo.ToList())
        End Function

        ' GET: ClienteCorporativo/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim clienteCorporativo As ClienteCorporativo = db.ClienteCorporativo.Find(id)
            If IsNothing(clienteCorporativo) Then
                Return HttpNotFound()
            End If
            Return View(clienteCorporativo)
        End Function

        ' GET: ClienteCorporativo/Create
        Function Create() As ActionResult
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre")
            Return View()
        End Function

        ' POST: ClienteCorporativo/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombre,Apellidos,NumeroIdentidad,CorreoElectronico,Telefono,EmpresaID,FechaCreacion,FechaModificacion")> ByVal clienteCorporativo As ClienteCorporativo) As ActionResult
            If ModelState.IsValid Then
                db.ClienteCorporativo.Add(clienteCorporativo)
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre", clienteCorporativo.EmpresaID)
            Return View(clienteCorporativo)
        End Function

        ' GET: ClienteCorporativo/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim clienteCorporativo As ClienteCorporativo = db.ClienteCorporativo.Find(id)
            If IsNothing(clienteCorporativo) Then
                Return HttpNotFound()
            End If
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre", clienteCorporativo.EmpresaID)
            Return View(clienteCorporativo)
        End Function

        ' POST: ClienteCorporativo/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombre,Apellidos,NumeroIdentidad,CorreoElectronico,Telefono,EmpresaID,FechaCreacion,FechaModificacion")> ByVal clienteCorporativo As ClienteCorporativo) As ActionResult
            If ModelState.IsValid Then
                db.Entry(clienteCorporativo).State = EntityState.Modified
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre", clienteCorporativo.EmpresaID)
            Return View(clienteCorporativo)
        End Function

        ' GET: ClienteCorporativo/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim clienteCorporativo As ClienteCorporativo = db.ClienteCorporativo.Find(id)
            If IsNothing(clienteCorporativo) Then
                Return HttpNotFound()
            End If
            Return View(clienteCorporativo)
        End Function

        ' POST: ClienteCorporativo/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim clienteCorporativo As ClienteCorporativo = db.ClienteCorporativo.Find(id)
            db.ClienteCorporativo.Remove(clienteCorporativo)
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
