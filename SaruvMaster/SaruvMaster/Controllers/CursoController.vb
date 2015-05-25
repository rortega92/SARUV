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
        Function Index(ByVal searchString As String, ByVal searchConceptInput As String) As ActionResult
            Dim curso = From m In db.Curso
                                   Select m

            If Not String.IsNullOrEmpty(searchString) Then

                Select Case searchConceptInput
                    Case "Nombre"
                        curso = curso.Where(Function(m) m.Nombres.ToUpper().Contains(searchString.ToUpper()))
                    Case "Modalidad de Curso"
                        curso = curso.Where(Function(m) m.ModalidadDeCurso.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Área de Conocimiento"
                        curso = curso.Where(Function(m) m.AreaDeConocimiento.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Encargado de Validación"
                        curso = curso.Where(Function(m) m.EncargadoDeValidacion.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Período"
                        curso = curso.Where(Function(m) m.Periodo.ToString.Equals(searchString.ToUpper))
                    Case Else
                        curso = curso.Where(Function(m) m.Nombres.ToUpper().Contains(searchString.ToUpper()))
                End Select
            End If

            Return View(Curso)
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
            For i = 0 To db.Curso.ToArray.Length - 1
                If db.Curso.ToArray(i).Nombres = curso.Nombres Then
                    ModelState.AddModelError(String.Empty, "El nombre del Curso ya existe ")
                    Return View(curso)
                    Exit For

                End If
            Next
            curso.FechaCreacion = DateTime.Now
            curso.FechaModificacion = curso.FechaCreacion
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
        Function Edit(<Bind(Include:="ID,Nombres,AreaDeConocimientoID,ModalidadDeCursoID,EncargadoDeValidacionID,FechaInicio,FechaFinal,Periodo,FechaCreacion,FechaModificacion")> ByVal curso As Curso) As ActionResult
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
