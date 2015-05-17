Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace SaruvMaster
    Public Class RecursoController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: /Recurso/
        Function Index() As ActionResult
            Dim recursoes = db.Recursoes.Include(Function(r) r.ClienteCorporativo).Include(Function(r) r.Curso).Include(Function(r) r.Docente).Include(Function(r) r.Empresa).Include(Function(r) r.ModalidadDeCurso).Include(Function(r) r.TipoDeRecurso)
            Return View(recursoes.ToList())
        End Function

        ' GET: /Recurso/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim recurso As Recurso = db.Recursoes.Find(id)
            If IsNothing(recurso) Then
                Return HttpNotFound()
            End If
            Return View(recurso)
        End Function

        ' GET: /Recurso/Create
        Function Create() As ActionResult
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombres")
            ViewBag.CursoID = New SelectList(db.Curso, "ID", "Nombres")
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres")
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre")
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre")
            ViewBag.TipoDeRecursoID = New SelectList(db.TipoDeRecurso, "Id", "Nombre")
            Dim prioridad(3) As String
            prioridad(0) = "baja"
            prioridad(1) = "Media"
            prioridad(2) = "Alta"
            ViewBag.prioridad = New SelectList(Prioridad)
            Return View()
        End Function

        ' POST: /Recurso/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Nombre,TipoDeRecursoID,ModalidadDeCursoID,EmpresaID,CursoID,ClienteCorporativoID,DocenteID,Duracion,Prioridad,FechaEntrega")> ByVal recurso As Recurso) As ActionResult
            If ModelState.IsValid Then
                db.Recursoes.Add(recurso)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombres", recurso.ClienteCorporativoID)
            ViewBag.CursoID = New SelectList(db.Curso, "ID", "Nombres", recurso.CursoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", recurso.DocenteID)
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre", recurso.EmpresaID)
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre", recurso.ModalidadDeCursoID)
            ViewBag.TipoDeRecursoID = New SelectList(db.TipoDeRecurso, "Id", "Nombre", recurso.TipoDeRecursoID)

            Return View(recurso)
        End Function

        ' GET: /Recurso/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim recurso As Recurso = db.Recursoes.Find(id)
            If IsNothing(recurso) Then
                Return HttpNotFound()
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombres", recurso.ClienteCorporativoID)
            ViewBag.CursoID = New SelectList(db.Curso, "ID", "Nombres", recurso.CursoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", recurso.DocenteID)
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre", recurso.EmpresaID)
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre", recurso.ModalidadDeCursoID)
            Dim prioridad(3) As String
            prioridad(0) = "baja"
            prioridad(1) = "Media"
            prioridad(2) = "Alta"
            ViewBag.prioridad = New SelectList(prioridad)
            ViewBag.TipoDeRecursoID = New SelectList(db.TipoDeRecurso, "Id", "Nombre", recurso.TipoDeRecursoID)
            Return View(recurso)
        End Function

        ' POST: /Recurso/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include := "Id,Nombre,TipoDeRecursoID,ModalidadDeCursoID,EmpresaID,CursoID,ClienteCorporativoID,DocenteID,Duracion,Prioridad,FechaEntrega")> ByVal recurso As Recurso) As ActionResult
            If ModelState.IsValid Then
                db.Entry(recurso).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombres", recurso.ClienteCorporativoID)
            ViewBag.CursoID = New SelectList(db.Curso, "ID", "Nombres", recurso.CursoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", recurso.DocenteID)
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre", recurso.EmpresaID)
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre", recurso.ModalidadDeCursoID)
            ViewBag.TipoDeRecursoID = New SelectList(db.TipoDeRecurso, "Id", "Nombre", recurso.TipoDeRecursoID)
            Return View(recurso)
        End Function

        ' GET: /Recurso/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim recurso As Recurso = db.Recursoes.Find(id)
            If IsNothing(recurso) Then
                Return HttpNotFound()
            End If
            Return View(recurso)
        End Function

        ' POST: /Recurso/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim recurso As Recurso = db.Recursoes.Find(id)
            db.Recursoes.Remove(recurso)
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
