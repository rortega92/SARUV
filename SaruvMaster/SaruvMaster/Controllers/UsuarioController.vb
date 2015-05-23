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
    Public Class UsuarioController
        Inherits System.Web.Mvc.Controller

        Private db As New Connection

        ' GET: Usuario
        Function Index() As ActionResult
            Dim usuario = db.Usuario.Include(Function(u) u.Departamento).Include(Function(u) u.RolPorDepartamento)
            Return View(usuario.ToList())
        End Function

        ' GET: Usuario/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As Usuario = db.Usuario.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            Return View(usuario)
        End Function

        ' GET: Usuario/Create
        Function Create() As ActionResult
            ViewBag.DepartamentoID = New SelectList(db.Departamento, "ID", "Nombre")
            ViewBag.RolPorDepartamentoID = New SelectList(db.RolPorDepartamento, "ID", "Nombre")
            Return View()
        End Function

        ' POST: Usuario/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Nombre,Apellido,correo,DepartamentoID,RolPorDepartamentoID")> ByVal usuario As Usuario) As ActionResult
            For i = 0 To db.Usuario.ToArray.Length - 1
                If db.Usuario.ToArray(i).Nombre = usuario.Nombre Then
                    ModelState.AddModelError(String.Empty, "El nombre de el usuario ya existe ")
                    ViewBag.DepartamentoID = New SelectList(db.Departamento, "ID", "Nombre", usuario.DepartamentoID)
                    ViewBag.RolPorDepartamentoID = New SelectList(db.RolPorDepartamento, "ID", "Nombre", usuario.RolPorDepartamentoID)
                    Return View(usuario)
                    Exit For

                End If
            Next
            usuario.FechaCreacion = DateTime.Now
            usuario.FechaModificacion = usuario.FechaCreacion
            If ModelState.IsValid Then
                db.Usuario.Add(usuario)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.DepartamentoID = New SelectList(db.Departamento, "ID", "Nombre", usuario.DepartamentoID)
            ViewBag.RolPorDepartamentoID = New SelectList(db.RolPorDepartamento, "ID", "Nombre", usuario.RolPorDepartamentoID)
            Return View(usuario)
        End Function

        ' GET: Usuario/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As Usuario = db.Usuario.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            ViewBag.DepartamentoID = New SelectList(db.Departamento, "ID", "Nombre", usuario.DepartamentoID)
            ViewBag.RolPorDepartamentoID = New SelectList(db.RolPorDepartamento, "ID", "Nombre", usuario.RolPorDepartamentoID)
            Return View(usuario)
        End Function

        ' POST: Usuario/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Nombre,Apellido,correo,DepartamentoID,RolPorDepartamentoID,FechaCreacion,FechaModificacion")> ByVal usuario As Usuario) As ActionResult
            usuario.FechaModificacion = DateTime.Now
            If ModelState.IsValid Then
                db.Entry(usuario).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.DepartamentoID = New SelectList(db.Departamento, "ID", "Nombre", usuario.DepartamentoID)
            ViewBag.RolPorDepartamentoID = New SelectList(db.RolPorDepartamento, "ID", "Nombre", usuario.RolPorDepartamentoID)
            Return View(usuario)
        End Function

        ' GET: Usuario/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As Usuario = db.Usuario.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            Return View(usuario)
        End Function

        ' POST: Usuario/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim usuario As Usuario = db.Usuario.Find(id)
            db.Usuario.Remove(usuario)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Function getRolesByNombreDepartamento(ByVal nombreDepartamento As String) As ActionResult
            Dim con As New Connection
            Dim idDepartamento = con.Departamento.Where(Function(e) e.Nombre = nombreDepartamento).First().ID
            Dim listaRoles = con.RolPorDepartamento.ToList.Where(Function(r) r.DepartamentoID = idDepartamento)
            Dim returnRoles As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To listaRoles.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", listaRoles.ElementAt(i).ID)
                row.Add("Nombre", listaRoles.ElementAt(i).Nombre)
                returnRoles.Add(row)
            Next
            Return Json(returnRoles, JsonRequestBehavior.AllowGet)
        End Function
    End Class
End Namespace
