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
    <LogFilter>
    Public Class RecursoController
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
        ' GET: Recurso
        Function Index(ByVal searchString As String, ByVal searchConceptInput As String) As ActionResult
            Dim recurso = db.Recurso.Include(Function(r) r.ClienteCorporativo).Include(Function(r) r.Curso).Include(Function(r) r.Docente).Include(Function(r) r.Empresa).Include(Function(r) r.ModalidadDeCurso).Include(Function(r) r.TipoDeRecurso)

            If Not String.IsNullOrEmpty(searchString) Then

                Select Case searchConceptInput
                    Case "Nombre"
                        recurso = recurso.Where(Function(m) m.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Tipo de Recurso"
                        recurso = recurso.Where(Function(m) m.TipoDeRecurso.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Modalidad"
                        recurso = recurso.Where(Function(m) m.ModalidadDeCurso.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Empresa"
                        recurso = recurso.Where(Function(m) m.Empresa.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Curso"
                        recurso = recurso.Where(Function(m) m.Curso.Nombres.ToUpper().Contains(searchString.ToUpper()))
                    Case "Cliente Corp."
                        recurso = recurso.Where(Function(m) m.ClienteCorporativo.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Docente"
                        recurso = recurso.Where(Function(m) m.Docente.Nombres.ToUpper().Contains(searchString.ToUpper()))
                    Case "Correo Electrónico"
                        recurso = recurso.Where(Function(m) m.Docente.correoElectronico.ToUpper().Contains(searchString.ToUpper()))
                    Case "Duración"
                        recurso = recurso.Where(Function(m) m.Duracion.ToString.ToUpper().Contains(searchString.ToUpper()))
                    Case "Prioridad"
                        recurso = recurso.Where(Function(m) m.Prioridad.ToUpper().Contains(searchString.ToUpper()))
                    Case "Fecha de Entrega"
                        recurso = recurso.Where(Function(m) m.FechaEntrega.ToString.ToUpper().Contains(searchString.ToUpper()))
                    Case Else
                        recurso = recurso.Where(Function(m) m.Nombre.ToUpper().Contains(searchString.ToUpper()))
                End Select
            End If

            Return View(recurso.ToList())
        End Function

        Function RecursosCompletos(ByVal wantsJson As Boolean?, ByVal searchString As String, ByVal searchConceptInput As String) As ActionResult
            Dim recurso = db.Recurso.Include(Function(r) r.ClienteCorporativo).Include(Function(r) r.Curso).Include(Function(r) r.Docente).Include(Function(r) r.Empresa).Include(Function(r) r.ModalidadDeCurso).Include(Function(r) r.TipoDeRecurso)
            Dim departamentoId = db.Departamento.Where(Function(e) e.Nombre = "Entrega").First().ID
            Dim usuariosEntrega = UserManager.Users.Where(Function(u) u.DepartamentoID = departamentoId).ToList()
            Dim recursosPorUsuario = New List(Of RecursoPorUsuario)
            Dim recursos = New List(Of Recurso)
            For i As Integer = 0 To usuariosEntrega.ToArray().Length - 1
                Dim currentUsuarioId = usuariosEntrega.ToArray().ElementAt(i).Id
                Dim recursosPorUsuarioActual = db.RecursoPorUsuario.Where(Function(e) e.UsuarioID = currentUsuarioId And e.Estado = "Terminado")
                If (recursosPorUsuarioActual.ToArray().Length > 0) Then
                    For j As Integer = 0 To recursosPorUsuarioActual.ToArray().Length - 1
                        Dim currentRecursosPorUsuario = recursosPorUsuarioActual.ToArray().ElementAt(j)
                        recursosPorUsuario.Add(currentRecursosPorUsuario)
                    Next
                End If
            Next
            For i As Integer = 0 To recursosPorUsuario.ToArray().Length - 1
                Dim currentRecursoPorUsuarioId = recursosPorUsuario.ToArray().ElementAt(i).RecursoID
                Dim recursoActual = db.Recurso.Where(Function(e) e.Id = currentRecursoPorUsuarioId)
                If recursoActual.ToArray().Length > 0 Then
                    recursos.Add(recursoActual.First())
                End If
            Next
            If Not (wantsJson Is Nothing) Then
                Dim returnRecursos As New List(Of Dictionary(Of String, String))
                For i As Integer = 0 To recursos.ToArray().Length - 1
                    Dim row As New Dictionary(Of String, String)
                    row.Add("ID", recursos.ElementAt(i).Id)
                    returnRecursos.Add(row)
                Next
                Return Json(returnRecursos, JsonRequestBehavior.AllowGet)
            End If

            If Not String.IsNullOrEmpty(searchString) Then

                Select Case searchConceptInput
                    Case "Nombre"
                        recurso = recurso.Where(Function(m) m.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Tipo de Recurso"
                        recurso = recurso.Where(Function(m) m.TipoDeRecurso.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Modalidad"
                        recurso = recurso.Where(Function(m) m.ModalidadDeCurso.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Empresa"
                        recurso = recurso.Where(Function(m) m.Empresa.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Curso"
                        recurso = recurso.Where(Function(m) m.Curso.Nombres.ToUpper().Contains(searchString.ToUpper()))
                    Case "Cliente Corp."
                        recurso = recurso.Where(Function(m) m.ClienteCorporativo.Nombre.ToUpper().Contains(searchString.ToUpper()))
                    Case "Docente"
                        recurso = recurso.Where(Function(m) m.Docente.Nombres.ToUpper().Contains(searchString.ToUpper()))
                    Case "Correo Electrónico"
                        recurso = recurso.Where(Function(m) m.Docente.correoElectronico.ToUpper().Contains(searchString.ToUpper()))
                    Case "Duración"
                        recurso = recurso.Where(Function(m) m.Duracion.ToString.ToUpper().Contains(searchString.ToUpper()))
                    Case "Prioridad"
                        recurso = recurso.Where(Function(m) m.Prioridad.ToUpper().Contains(searchString.ToUpper()))
                    Case "Fecha de Entrega"
                        recurso = recurso.Where(Function(m) m.FechaEntrega.ToString.ToUpper().Contains(searchString.ToUpper()))
                    Case Else
                        recurso = recurso.Where(Function(m) m.Nombre.ToUpper().Contains(searchString.ToUpper()))
                End Select
            End If

            Return View(recursos.ToList())
        End Function

        ' GET: Recurso/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim recurso As Recurso = db.Recurso.Find(id)
            If IsNothing(recurso) Then
                Return HttpNotFound()
            End If
            Return View(recurso)
        End Function

        ' GET: Recurso/Create
        Function Create() As ActionResult
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre")
            ViewBag.CursoID = New SelectList(db.Curso, "ID", "Nombres")
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres")
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre")
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre")
            ViewBag.TipoDeRecursoID = New SelectList(db.TipoDeRecurso, "Id", "Nombre")
            Dim prioridad(2) As String
            prioridad(0) = "Baja"
            prioridad(1) = "Media"
            prioridad(2) = "Alta"
            ViewBag.prioridad = New SelectList(prioridad)
            Return View()
        End Function

        ' POST: Recurso/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Nombre,TipoDeRecursoID,ModalidadDeCursoID,EmpresaID,CursoID,ClienteCorporativoID,DocenteID,Duracion,Prioridad,FechaEntrega,FechaCreacion,FechaModificacion")> ByVal recurso As Recurso) As ActionResult
            If ModelState.IsValid Then
                db.Recurso.Add(recurso)
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre", recurso.ClienteCorporativoID)
            ViewBag.CursoID = New SelectList(db.Curso, "ID", "Nombres", recurso.CursoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", recurso.DocenteID)
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre", recurso.EmpresaID)
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre", recurso.ModalidadDeCursoID)
            ViewBag.TipoDeRecursoID = New SelectList(db.TipoDeRecurso, "Id", "Nombre", recurso.TipoDeRecursoID)
            Return View(recurso)
        End Function

        ' GET: Recurso/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim recurso As Recurso = db.Recurso.Find(id)
            If IsNothing(recurso) Then
                Return HttpNotFound()
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre", recurso.ClienteCorporativoID)
            ViewBag.CursoID = New SelectList(db.Curso, "ID", "Nombres", recurso.CursoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", recurso.DocenteID)
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre", recurso.EmpresaID)
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre", recurso.ModalidadDeCursoID)
            Dim prioridad(2) As String
            prioridad(0) = "Baja"
            prioridad(1) = "Media"
            prioridad(2) = "Alta"
            ViewBag.prioridad = New SelectList(prioridad)
            ViewBag.TipoDeRecursoID = New SelectList(db.TipoDeRecurso, "Id", "Nombre", recurso.TipoDeRecursoID)

            Return View(recurso)
        End Function

        ' POST: Recurso/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Nombre,TipoDeRecursoID,ModalidadDeCursoID,EmpresaID,CursoID,ClienteCorporativoID,DocenteID,Duracion,Prioridad,FechaEntrega,FechaCreacion,FechaModificacion")> ByVal recurso As Recurso) As ActionResult
            If ModelState.IsValid Then
                db.Entry(recurso).State = EntityState.Modified
                db.Savechanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ClienteCorporativoID = New SelectList(db.ClienteCorporativo, "ID", "Nombre", recurso.ClienteCorporativoID)
            ViewBag.CursoID = New SelectList(db.Curso, "ID", "Nombres", recurso.CursoID)
            ViewBag.DocenteID = New SelectList(db.Docente, "ID", "Nombres", recurso.DocenteID)
            ViewBag.EmpresaID = New SelectList(db.Empresa, "ID", "Nombre", recurso.EmpresaID)
            ViewBag.ModalidadDeCursoID = New SelectList(db.ModalidadDeCurso, "ID", "Nombre", recurso.ModalidadDeCursoID)
            ViewBag.TipoDeRecursoID = New SelectList(db.TipoDeRecurso, "Id", "Nombre", recurso.TipoDeRecursoID)
            Return View(recurso)
        End Function

        ' GET: Recurso/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim recurso As Recurso = db.Recurso.Find(id)
            If IsNothing(recurso) Then
                Return HttpNotFound()
            End If
            Return View(recurso)
        End Function

        ' POST: Recurso/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim recurso As Recurso = db.Recurso.Find(id)
            db.Recurso.Remove(recurso)
            db.Savechanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Function getClientesByNombreEmpresa(ByVal nombreEmpresa As String) As ActionResult
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim con As New Connection
            Dim idEmpresa = con.Empresa.Where(Function(e) e.Nombre = nombreEmpresa).First().ID
            Dim listaClientes = con.ClienteCorporativo.ToList.Where(Function(c) c.EmpresaID = idEmpresa)
            Dim returnClientes As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To listaClientes.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", listaClientes.ElementAt(i).ID)
                row.Add("Nombres", listaClientes.ElementAt(i).Nombre)
                returnClientes.Add(row)
            Next
            Return Json(returnClientes, JsonRequestBehavior.AllowGet)
        End Function
    End Class
End Namespace
