Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports SaruvMaster

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As New Connection

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Public Function GetEvents(start As Double, [end] As Double) As ActionResult
        Dim fromDate = ConvertFromUnixTimestamp(start)
        Dim toDate = ConvertFromUnixTimestamp([end])

        'Get the events
        'You may get from the repository also
        Dim eventList = GetEvents()

        Dim rows = eventList.ToArray()
        Return Json(rows, JsonRequestBehavior.AllowGet)
    End Function

    Private Function GetEvents() As List(Of Events)
        Dim eventList As New List(Of Events)()

        Dim eventos = From m In db.Events
                                   Select m





        Return eventos.ToList
    End Function

    Private Shared Function ConvertFromUnixTimestamp(timestamp As Double) As DateTime
        Dim origin = New DateTime(1970, 1, 1, 0, 0, 0, 0)
        Return origin.AddSeconds(timestamp)
    End Function

End Class
