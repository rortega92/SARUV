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
    Public Class EventosCalendariosController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: EventosCalendarios
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: EventosCalendarios/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim eventosCalendario As EventosCalendario = db.EventosCalendarios.Find(id)
            If IsNothing(eventosCalendario) Then
                Return HttpNotFound()
            End If
            Return View(eventosCalendario)
        End Function

        ' GET: EventosCalendarios/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: EventosCalendarios/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Evento,Description,StartString,EndString,FechaReserva,HoraInicio,HoraFinal,IsDeleted")> ByVal eventosCalendario As EventosCalendario) As ActionResult
            eventosCalendario.HoraInicio = eventosCalendario.FechaReserva.AddHours(eventosCalendario.HoraInicio.Hour)
            eventosCalendario.HoraFinal = eventosCalendario.FechaReserva.AddHours(eventosCalendario.HoraFinal.Hour)
            eventosCalendario.StartString = eventosCalendario.HoraInicio.ToString("s")
            eventosCalendario.EndString = eventosCalendario.HoraFinal.ToString("s")

            If ModelState.IsValid Then
                db.EventosCalendarios.Add(eventosCalendario)
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            Return View(eventosCalendario)
        End Function

        ' GET: EventosCalendarios/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim eventosCalendario As EventosCalendario = db.EventosCalendarios.Find(id)
            If IsNothing(eventosCalendario) Then
                Return HttpNotFound()
            End If
            Return View(eventosCalendario)
        End Function

        ' POST: EventosCalendarios/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Evento,StartString,EndString,FechaReserva,HoraInicio,HoraFinal,IsDeleted")> ByVal eventosCalendario As EventosCalendario) As ActionResult
            eventosCalendario.HoraInicio = eventosCalendario.FechaReserva.AddHours(eventosCalendario.HoraInicio.Hour)
            eventosCalendario.HoraFinal = eventosCalendario.FechaReserva.AddHours(eventosCalendario.HoraFinal.Hour)
            eventosCalendario.StartString = eventosCalendario.HoraInicio.ToString("s")
            eventosCalendario.EndString = eventosCalendario.HoraFinal.ToString("s")
            If ModelState.IsValid Then

                db.Entry(eventosCalendario).State = EntityState.Modified
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            Return View(eventosCalendario)
        End Function

        ' GET: EventosCalendarios/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim eventosCalendario As EventosCalendario = db.EventosCalendarios.Find(id)
            If IsNothing(eventosCalendario) Then
                Return HttpNotFound()
            End If
            db.EventosCalendarios.Remove(eventosCalendario)
            db.Savechanges()
            Return RedirectToAction("Index")
        End Function

        ' POST: EventosCalendarios/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim eventosCalendario As EventosCalendario = db.EventosCalendarios.Find(id)
            db.EventosCalendarios.Remove(eventosCalendario)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Private Shared Function ConvertFromUnixTimestamp(timestamp As Double) As DateTime
            Dim origin = New DateTime(1970, 1, 1, 0, 0, 0, 0)
            Return origin.AddSeconds(timestamp)
        End Function

        Public Function GetEvents(start As Double, [end] As Double) As ActionResult
            Dim fromDate = ConvertFromUnixTimestamp(start)
            Dim toDate = ConvertFromUnixTimestamp([end])


            ''
            Dim items = db.EventosCalendarios.[Select](Function(a) New With { _
                .title = a.Evento, _
                .start = a.StartString, _
                .end = a.EndString, _
                .allDay = False, _
                .description = a.Description, _
                .id = a.ID, _
                .isDeleted = a.IsDeleted _
            })



            Dim eventList = items.ToList()

            Dim rows = eventList.ToArray()

            Return Json(rows, JsonRequestBehavior.AllowGet)
        End Function


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
