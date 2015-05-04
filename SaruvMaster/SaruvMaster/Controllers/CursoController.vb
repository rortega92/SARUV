Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace SaruvMaster
    Public Class CursoController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: /Curso/
        Function Index() As ActionResult
            Dim curso = db.Curso.Include(Function(c) c.AreaDeConocimiento).Include(Function(c) c.EncargadoDeValidacion).Include(Function(c) c.ModalidadDeCurso)
            Return View(curso.ToList())
        End Function

        ' GET: /Curso/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim curso As Curso = db.Curso.Find(id)
            If IsNothing(curso) Then
                Return HttpNotFound()
            End If
            Return View(curso)
        End Function

        ' GET: /Curso/Create
        Function Create() As ActionResult
            ViewBag.AreaDeConocimientoID = New SelectList(db.AreaDeConocimiento, "ID", "Nombre")
            ViewBag.EncargadoDeValidacionID = New SelectList(db.EncargadoDeValidacion, "ID", "Nombre")
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre")
            Return View()
        End Function

        ' POST: /Curso/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include := "ID,Nombres,AreaDeConocimientoID,ModalidadDeCursoID,EncargadoDeValidacionID,FechaInicio,FechaFinal,Periodo")> ByVal curso As Curso) As ActionResult
            If ModelState.IsValid Then
                db.Curso.Add(curso)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If 
            ViewBag.AreaDeConocimientoID = New SelectList(db.AreaDeConocimiento, "ID", "Nombre", curso.AreaDeConocimientoID)
            ViewBag.EncargadoDeValidacionID = New SelectList(db.EncargadoDeValidacion, "ID", "Nombre", curso.EncargadoDeValidacionID)
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre", curso.ModalidadDeCursoID)
            Return View(curso)
        End Function

        ' GET: /Curso/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim curso As Curso = db.Curso.Find(id)
            If IsNothing(curso) Then
                Return HttpNotFound()
            End If
            ViewBag.AreaDeConocimientoID = New SelectList(db.AreaDeConocimiento, "ID", "Nombre", curso.AreaDeConocimientoID)
            ViewBag.EncargadoDeValidacionID = New SelectList(db.EncargadoDeValidacion, "ID", "Nombre", curso.EncargadoDeValidacionID)
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre", curso.ModalidadDeCursoID)
            Return View(curso)
        End Function

        ' POST: /Curso/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include := "ID,Nombres,AreaDeConocimientoID,ModalidadDeCursoID,EncargadoDeValidacionID,FechaInicio,FechaFinal,Periodo")> ByVal curso As Curso) As ActionResult
            If ModelState.IsValid Then
                db.Entry(curso).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AreaDeConocimientoID = New SelectList(db.AreaDeConocimiento, "ID", "Nombre", curso.AreaDeConocimientoID)
            ViewBag.EncargadoDeValidacionID = New SelectList(db.EncargadoDeValidacion, "ID", "Nombre", curso.EncargadoDeValidacionID)
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre", curso.ModalidadDeCursoID)
            Return View(curso)
        End Function

        ' GET: /Curso/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim curso As Curso = db.Curso.Find(id)
            If IsNothing(curso) Then
                Return HttpNotFound()
            End If
            Return View(curso)
        End Function

        ' POST: /Curso/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim curso As Curso = db.Curso.Find(id)
            db.Curso.Remove(curso)
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
