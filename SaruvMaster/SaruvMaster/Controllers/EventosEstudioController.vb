Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports SaruvMaster

Namespace Controllers
    Public Class EventosEstudioController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: EventosEstudio
        Async Function Index() As Task(Of ActionResult)
            Dim eventosEstudio = db.EventosEstudio.Include(Function(e) e.ClienteCorporativo).Include(Function(e) e.Docente)
            Return View(Await eventosEstudio.ToListAsync())
        End Function

        ' GET: EventosEstudio/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim eventosEstudio As EventosEstudio = Await db.EventosEstudio.FindAsync(id)
            If IsNothing(eventosEstudio) Then
                Return HttpNotFound()
            End If
            Return View(eventosEstudio)
        End Function

        ' GET: EventosEstudio/Create
        Function Create() As ActionResult
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre")
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres")
            Return View()
        End Function

        ' POST: EventosEstudio/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="ID,Evento,DocenteID,ClienteCorporativoID,FechaReserva,HoraInicio,HoraFinal,IsDeleted")> ByVal eventosEstudio As EventosEstudio) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.EventosEstudio.Add(eventosEstudio)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre", eventosEstudio.ClienteCorporativoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", eventosEstudio.DocenteID)
            Return View(eventosEstudio)
        End Function

        ' GET: EventosEstudio/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim eventosEstudio As EventosEstudio = Await db.EventosEstudio.FindAsync(id)
            If IsNothing(eventosEstudio) Then
                Return HttpNotFound()
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre", eventosEstudio.ClienteCorporativoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", eventosEstudio.DocenteID)
            Return View(eventosEstudio)
        End Function

        ' POST: EventosEstudio/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="ID,Evento,DocenteID,ClienteCorporativoID,FechaReserva,HoraInicio,HoraFinal,IsDeleted")> ByVal eventosEstudio As EventosEstudio) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(eventosEstudio).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre", eventosEstudio.ClienteCorporativoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", eventosEstudio.DocenteID)
            Return View(eventosEstudio)
        End Function

        ' GET: EventosEstudio/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim eventosEstudio As EventosEstudio = Await db.EventosEstudio.FindAsync(id)
            If IsNothing(eventosEstudio) Then
                Return HttpNotFound()
            End If
            Return View(eventosEstudio)
        End Function

        ' POST: EventosEstudio/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim eventosEstudio As EventosEstudio = Await db.EventosEstudio.FindAsync(id)
            db.EventosEstudio.Remove(eventosEstudio)
            Await db.SaveChangesAsync()
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
