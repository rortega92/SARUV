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
        Function Index(ByVal searchString As String, ByVal searchConceptInput As String) As ActionResult
            Dim cliente = From m In db.ClienteCorporativo
                          Select m

            If Not String.IsNullOrEmpty(searchString) Then

                Select Case searchConceptInput
                    Case "Nombre"
                        cliente = cliente.Where(Function(m) m.Nombres.ToUpper().Contains(searchString.ToUpper()))
                    Case "Apellido"
                        cliente = cliente.Where(Function(m) m.Apellidos.ToUpper().Contains(searchString.ToUpper()))
                    Case "Número de Identidad"
                        cliente = cliente.Where(Function(m) m.NumeroIdentidad.ToUpper().Contains(searchString.ToUpper()))
                    Case "Correo Electrónico"
                        cliente = cliente.Where(Function(m) m.CorreoElectronico.ToUpper().Contains(searchString.ToUpper()))
                    Case "Teléfono"
                        cliente = cliente.Where(Function(m) m.Telefono.ToUpper().Contains(searchString.ToUpper()))
                    Case "Empresa"
                        cliente = cliente.Where(Function(m) m.Empresa.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case Else
                        cliente = cliente.Where(Function(m) m.Nombres.ToUpper().Contains(searchString.ToUpper()))
                End Select
            End If

            Return View(cliente)
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
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombres,Apellidos,NumeroIdentidad,CorreoElectronico,Telefono,EmpresaID")> ByVal clienteCorporativo As ClienteCorporativo) As ActionResult
            If ModelState.IsValid Then
                db.ClienteCorporativo.Add(clienteCorporativo)
                db.SaveChanges()
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
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombres,Apellidos,NumeroIdentidad,CorreoElectronico,Telefono,EmpresaID")> ByVal clienteCorporativo As ClienteCorporativo) As ActionResult
            If ModelState.IsValid Then
                db.Entry(clienteCorporativo).State = EntityState.Modified
                db.SaveChanges()
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
