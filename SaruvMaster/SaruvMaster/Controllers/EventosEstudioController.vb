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
    Public Class EventosEstudioController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: EventosEstudio
        Function Index() As ActionResult
            Dim eventosEstudio = db.EventosEstudio.Include(Function(e) e.ClienteCorporativo).Include(Function(e) e.Docente)
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre")
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres")
            Return View()
        End Function

        ' GET: EventosEstudio/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim eventosEstudio As EventosEstudio = db.EventosEstudio.Find(id)
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
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Evento,DocenteID,ClienteCorporativoID,FechaReserva,HoraInicio,HoraFinal,IsDeleted")> ByVal eventosEstudio As EventosEstudio) As ActionResult
            eventosEstudio.HoraInicio = eventosEstudio.FechaReserva.AddHours(eventosEstudio.HoraInicio.Hour)
            eventosEstudio.HoraFinal = eventosEstudio.FechaReserva.AddHours(eventosEstudio.HoraFinal.Hour)
            eventosEstudio.StartString = eventosEstudio.HoraInicio.ToString("s")
            eventosEstudio.EndString = eventosEstudio.HoraFinal.ToString("s")
            If ModelState.IsValid Then
                db.EventosEstudio.Add(eventosEstudio)
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre", eventosEstudio.ClienteCorporativoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", eventosEstudio.DocenteID)
            Return View(eventosEstudio)
        End Function

        ' GET: EventosEstudio/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim eventosEstudio As EventosEstudio = db.EventosEstudio.Find(id)
            If IsNothing(eventosEstudio) Then
                Return HttpNotFound()
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre", eventosEstudio.ClienteCorporativoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", eventosEstudio.DocenteID)
            Return View(eventosEstudio)
        End Function

        ' POST: EventosEstudio/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Evento,DocenteID,ClienteCorporativoID,FechaReserva,HoraInicio,HoraFinal,IsDeleted")> ByVal eventosEstudio As EventosEstudio) As ActionResult
            eventosEstudio.HoraInicio = eventosEstudio.FechaReserva.AddHours(eventosEstudio.HoraInicio.Hour)
            eventosEstudio.HoraFinal = eventosEstudio.FechaReserva.AddHours(eventosEstudio.HoraFinal.Hour)
            eventosEstudio.StartString = eventosEstudio.HoraInicio.ToString("s")
            eventosEstudio.EndString = eventosEstudio.HoraFinal.ToString("s")
            If ModelState.IsValid Then
                db.Entry(eventosEstudio).State = EntityState.Modified
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre", eventosEstudio.ClienteCorporativoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", eventosEstudio.DocenteID)
            Return View(eventosEstudio)
        End Function

        ' GET: EventosEstudio/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim eventosEstudio As EventosEstudio = db.EventosEstudio.Find(id)
            If IsNothing(eventosEstudio) Then
                Return HttpNotFound()
            End If
            db.EventosEstudio.Remove(eventosEstudio)
            db.Savechanges()
            Return RedirectToAction("Index")
        End Function

        ' POST: EventosEstudio/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim eventosEstudio As EventosEstudio = db.EventosEstudio.Find(id)
            db.EventosEstudio.Remove(eventosEstudio)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Function GetEvents(start As Double, [end] As Double) As ActionResult
            Dim fromDate = ConvertFromUnixTimestamp(start)
            Dim toDate = ConvertFromUnixTimestamp([end])


            ''
            Dim items = db.EventosEstudio.[Select](Function(a) New With { _
                .title = a.Evento, _
                .start = a.StartString, _
                .end = a.EndString, _
                .allDay = False, _
                .docente = a.Docente.Nombres, _
                .id = a.ID, _
                .isDeleted = a.IsDeleted, _
                .cliente = a.ClienteCorporativo.Nombre _
            })

            

            Dim eventList = items.ToList()

            Dim rows = eventList.ToArray()

            Return Json(rows, JsonRequestBehavior.AllowGet)
        End Function

        Private Shared Function timeAddition(fecha As DateTime, inicio As DateTime) As DateTime
            Dim correctTime = fecha.AddHours(inicio.Hour)
            Return correctTime
        End Function

        Private Function GetEvents() As List(Of EventosEstudio)
            Dim eventList As New List(Of EventosEstudio)()


            Dim eventos = From m In db.EventosEstudio
                                       Select m





            Return eventos.ToList
        End Function

        Private Shared Function ConvertFromUnixTimestamp(timestamp As Double) As DateTime
            Dim origin = New DateTime(1970, 1, 1, 0, 0, 0, 0)
            Return origin.AddSeconds(timestamp)
        End Function

    End Class
End Namespace
