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
    Public Class EmpresaController
        Inherits System.Web.Mvc.Controller

        Private db As New EmpresaDbContext

        ' GET: Empresa
        Function Index() As ActionResult
            Return View(db.empresas.ToList())
        End Function

        ' GET: Empresa/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresaModels As EmpresaModels = db.empresas.Find(id)
            If IsNothing(empresaModels) Then
                Return HttpNotFound()
            End If
            Return View(empresaModels)
        End Function

        ' GET: Empresa/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Empresa/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombre,Direccion,Telefono,Ciudad,Departamento")> ByVal empresaModels As EmpresaModels) As ActionResult
            If ModelState.IsValid Then
                db.empresas.Add(empresaModels)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(empresaModels)
        End Function

        ' GET: Empresa/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresaModels As EmpresaModels = db.empresas.Find(id)
            If IsNothing(empresaModels) Then
                Return HttpNotFound()
            End If
            Return View(empresaModels)
        End Function

        ' POST: Empresa/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombre,Direccion,Telefono,Ciudad,Departamento")> ByVal empresaModels As EmpresaModels) As ActionResult
            If ModelState.IsValid Then
                db.Entry(empresaModels).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(empresaModels)
        End Function

        ' GET: Empresa/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim empresaModels As EmpresaModels = db.empresas.Find(id)
            If IsNothing(empresaModels) Then
                Return HttpNotFound()
            End If
            Return View(empresaModels)
        End Function

        ' POST: Empresa/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim empresaModels As EmpresaModels = db.empresas.Find(id)
            db.empresas.Remove(empresaModels)
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
