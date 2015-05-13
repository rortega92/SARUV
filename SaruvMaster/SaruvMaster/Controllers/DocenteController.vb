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
    Public Class DocenteController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: Docente
        Function Index(ByVal filtro As String, ByVal searchString As String) As ActionResult
            Dim array(2) As String
            array(0) = "Area de conocimiento"
            array(1) = "Facultad"
            ViewBag.filtro = New SelectList(array)
            Dim docente = db.Docente.Include(Function(d) d.AreaDeConocimiento).Include(Function(d) d.Facultad)
            Return View(docente.ToList())
        End Function

        ' GET: Docente/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim docente As Docente = db.Docente.Find(id)
            If IsNothing(docente) Then
                Return HttpNotFound()
            End If
            Return View(docente)
        End Function

        ' GET: Docente/Create
        Function Create() As ActionResult
            ViewBag.AreaDeConocimientoID = New SelectList(db.AreaDeConocimiento, "ID", "Nombre")
            ViewBag.FacultadID = New SelectList(db.Facultad, "ID", "Nombre")
            Return View()
        End Function

        ' POST: Docente/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombres,Apellidos,NumeroTalentoHumano,correoElectronico,telefono,AreaDeConocimientoID,FacultadID")> ByVal docente As Docente) As ActionResult
            For i = 0 To db.Docente.ToArray.Length - 1
                If db.Docente.ToArray(i).NumeroTalentoHumano = docente.NumeroTalentoHumano Then
                    ModelState.AddModelError(String.Empty, "El número de talento ya existe ")
                    ViewBag.AreaDeConocimientoID = New SelectList(db.AreaDeConocimiento, "ID", "Nombre", docente.AreaDeConocimientoID)
                    ViewBag.FacultadID = New SelectList(db.Facultad, "ID", "Nombre", docente.FacultadID)
                    Return View(docente)
                    Exit For

                End If
            Next
            
            If ModelState.IsValid Then
                db.Docente.Add(docente)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AreaDeConocimientoID = New SelectList(db.AreaDeConocimiento, "ID", "Nombre", docente.AreaDeConocimientoID)
            ViewBag.FacultadID = New SelectList(db.Facultad, "ID", "Nombre", docente.FacultadID)
            Return View(docente)
        End Function

        ' GET: Docente/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim docente As Docente = db.Docente.Find(id)
            If IsNothing(docente) Then
                Return HttpNotFound()
            End If
            ViewBag.AreaDeConocimientoID = New SelectList(db.AreaDeConocimiento, "ID", "Nombre", docente.AreaDeConocimientoID)
            ViewBag.FacultadID = New SelectList(db.Facultad, "ID", "Nombre", docente.FacultadID)
            Return View(docente)
        End Function

        ' POST: Docente/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombres,Apellidos,NumeroTalentoHumano,correoElectronico,telefono,AreaDeConocimientoID,FacultadID")> ByVal docente As Docente) As ActionResult
            If ModelState.IsValid Then
                db.Entry(docente).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AreaDeConocimientoID = New SelectList(db.AreaDeConocimiento, "ID", "Nombre", docente.AreaDeConocimientoID)
            ViewBag.FacultadID = New SelectList(db.Facultad, "ID", "Nombre", docente.FacultadID)
            Return View(docente)
        End Function

        ' GET: Docente/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim docente As Docente = db.Docente.Find(id)
            If IsNothing(docente) Then
                Return HttpNotFound()
            End If
            Return View(docente)
        End Function

        ' POST: Docente/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim docente As Docente = db.Docente.Find(id)
            db.Docente.Remove(docente)
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
