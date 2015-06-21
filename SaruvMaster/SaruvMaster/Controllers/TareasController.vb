Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports SaruvMaster
Imports System.Data.SqlClient
Imports Microsoft.AspNet.Identity
Imports System.Globalization
Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin
Imports Microsoft.AspNet.Identity.EntityFramework

Namespace Controllers
    Public Class TareasController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection
        Private _userManager As ApplicationUserManager
        Public Property UserManager() As ApplicationUserManager
            Get
                Return If(_userManager, HttpContext.GetOwinContext().GetUserManager(Of ApplicationUserManager)())
            End Get
            Private Set(value As ApplicationUserManager)
                _userManager = value
            End Set
        End Property
        ' GET: Tareas
        <LogFilter>
        Function Index(ByVal idUsuario As String) As ActionResult
            If Not (idUsuario Is Nothing) Then
                Dim tareas = db.Tarea.Where(Function(e) e.UsuarioID = idUsuario)
                Return View(tareas.ToList())
            End If
            Return View(db.Tarea.ToList())
        End Function
        ' GET: Tareas/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Tareas/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Descripcion")> ByVal tarea As Tarea) As ActionResult
            If ModelState.IsValid Then
                Dim usuarioId = UserManager.Users.Where(Function(e) e.UserName = My.User.Name).First().Id
                tarea.UsuarioID = usuarioId
                db.Tarea.Add(tarea)
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            Return View(tarea)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
