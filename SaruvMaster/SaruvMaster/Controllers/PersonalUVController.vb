Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports System.Data.SqlClient
Imports Microsoft.AspNet.Identity
Imports System.Globalization
Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin
Imports Microsoft.AspNet.Identity.EntityFramework


Namespace SaruvMaster
    <LogFilterEstandar>
    Public Class PersonalUVController
        Inherits Controller


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
        ' GET: /RecursoPorUsuario/

        Function Index() As ActionResult
            If User.Identity.IsAuthenticated And User.IsInRole("Estándar") Then
                Dim usuario = UserManager.Users.Where(Function(u) u.UserName = User.Identity.Name).First()
                Dim recursoPorUsuario = db.RecursoPorUsuario.Where(Function(ru) ru.UsuarioID = usuario.Id)
                Dim departamento = db.Departamento.Where(Function(dep) dep.ID = usuario.DepartamentoID).First()
                ViewBag.departamento = departamento.Nombre
                ViewBag.pageTitle = "Departamento de " + departamento.Nombre
                If (usuario.isJefe = 1) Then
                    ViewBag.isJefe = True
                    'Retornar la lista de los recursos de todos los usuarios de su departamento
                    Dim idsUsuariosDeptoActual = UserManager.Users.Where(Function(us) us.DepartamentoID = departamento.ID).ToList()
                    Dim recursoPorUsuarioList As New List(Of RecursoPorUsuario)
                    For i As Integer = 0 To idsUsuariosDeptoActual.ToArray().Length - 1
                        Dim currentUsuarioId = idsUsuariosDeptoActual.ToList().ElementAt(i).Id
                        Dim recursoPorUsuarioDeptoActual = db.RecursoPorUsuario.Where(Function(ru) ru.UsuarioID = currentUsuarioId).ToList()
                        If (recursoPorUsuarioDeptoActual.ToArray().Length = 0) Then
                        Else
                            For j As Integer = 0 To recursoPorUsuarioDeptoActual.ToArray().Length - 1
                                recursoPorUsuarioList.Add(recursoPorUsuarioDeptoActual.ElementAt(j))
                            Next
                        End If
                    Next
                    Return View(recursoPorUsuarioList)
                End If
                ViewBag.isJefe = False
                Return View(recursoPorUsuario.ToList())
            End If
            Return RedirectToAction("Index", "Home")
        End Function

        Function getUsuariosByNombreDepartamento(ByVal nombreDepartamento As String) As ActionResult
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim con As New Connection
            Dim idDepartamento = con.Departamento.Where(Function(d) d.Nombre = nombreDepartamento).First().ID
            Dim listaUsuarios = UserManager.Users.Where(Function(u) u.DepartamentoID = idDepartamento And Not (u.isJefe = 1)).ToList()
            Dim returnUsuarios As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To listaUsuarios.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", listaUsuarios.ElementAt(i).Id)
                row.Add("Nombre", listaUsuarios.ElementAt(i).Nombre)
                returnUsuarios.Add(row)
            Next
            Return Json(returnUsuarios, JsonRequestBehavior.AllowGet)
        End Function
        Function getRecursosByUsuario(ByVal idUsuario As String) As ActionResult
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim con As New Connection
            Dim idsRecursos = con.RecursoPorUsuario.Where(Function(ru) ru.UsuarioID = idUsuario).Select(Function(ru) ru.RecursoID)
            Dim estadosRecursos = con.RecursoPorUsuario.Where(Function(ru) ru.UsuarioID = idUsuario).Select(Function(ru) ru.Estado)
            Dim recursos = con.Recurso
            Dim listaRecursos = New List(Of Recurso)
            Dim listaEstadosRecurso = New List(Of String)
            For i As Integer = 0 To idsRecursos.ToArray().Length - 1
                Dim it = i
                Dim current = idsRecursos.ToArray().ElementAt(it)
                Dim currentEstado = estadosRecursos.ToArray().ElementAt(it)
                listaRecursos.Add(recursos.Where(Function(r) r.Id = current).ToList().First())
                listaEstadosRecurso.Add(currentEstado)
            Next
            Dim returnRecursos As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To listaRecursos.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", listaRecursos.ElementAt(i).Id)
                row.Add("Nombre", listaRecursos.ElementAt(i).Nombre)
                row.Add("Estado", listaEstadosRecurso.ElementAt(i))
                row.Add("Prioridad", listaRecursos.ElementAt(i).Prioridad)
                returnRecursos.Add(row)
            Next
            Return Json(returnRecursos, JsonRequestBehavior.AllowGet)
        End Function
        Function getIdJefeByNombreDepartamento(ByVal nombreDepartamento As String) As ActionResult
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim con As New Connection
            Dim idDepartamento = con.Departamento.Where(Function(d) d.Nombre = nombreDepartamento).First().ID
            Dim listaUsuarios = UserManager.Users.Where(Function(u) u.DepartamentoID = idDepartamento And u.isJefe = 1).ToList()
            Dim returnUsuarios As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To listaUsuarios.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", listaUsuarios.ElementAt(i).Id)
                row.Add("Nombre", listaUsuarios.ElementAt(i).Nombre)
                returnUsuarios.Add(row)
            Next
            Return Json(returnUsuarios, JsonRequestBehavior.AllowGet)
        End Function

        Function getRecursoPorUsuario(ByVal idUsuario As String, ByVal idRecurso As String) As ActionResult
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim con As New Connection
            Dim idsRecursoPorUsuario = con.RecursoPorUsuario.ToList.Where(Function(ru) ru.RecursoID = idRecurso And ru.UsuarioID = idUsuario)
            Dim returnUsuarios As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To idsRecursoPorUsuario.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", idsRecursoPorUsuario.ElementAt(i).ID)
                row.Add("Estado", idsRecursoPorUsuario.ElementAt(i).Estado)
                returnUsuarios.Add(row)
            Next
            Return Json(returnUsuarios, JsonRequestBehavior.AllowGet)
        End Function
        Function updateEstadoRecursoPorUsuario(ByVal idRecursoPorUsuario As Integer, ByVal estado As String) As ActionResult
            Dim con As New Connection

            Dim cone = New SqlConnection(con.Database.Connection.ConnectionString)
            Dim cmd = New SqlCommand()
            cone.Open()

            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.CommandText = "RecursoPorUsuario_UpdateEstado"
            Dim parm = New SqlParameter()
            parm.ParameterName = "@ID"
            parm.Value = idRecursoPorUsuario
            cmd.Parameters.Add(parm)
            Dim parm1 = New SqlParameter()
            parm1.ParameterName = "@Estado"
            parm1.Value = estado
            cmd.Parameters.Add(parm1)
            Dim rxu = con.RecursoPorUsuario.Where(Function(ru) ru.ID = idRecursoPorUsuario).ToList().First()
            Dim parm2 = New SqlParameter()
            parm2.ParameterName = "@RecursoID"
            parm2.Value = rxu.RecursoID
            cmd.Parameters.Add(parm2)
            Dim parm3 = New SqlParameter()
            parm3.ParameterName = "@UsuarioID"
            parm3.Value = rxu.UsuarioID
            cmd.Parameters.Add(parm3)
            cmd.Connection = cone
            Dim res = cmd.ExecuteNonQuery()
            cone.Close()
            Dim row As New Dictionary(Of String, String)
            row.Add("updated", res.Equals(1))
            Return Json(row, JsonRequestBehavior.AllowGet)
        End Function

        Function getUsuarioById(ByVal idUsuario As String) As ActionResult
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim con As New Connection
            Dim usuario = UserManager.Users.Where(Function(u) u.Id = idUsuario).First()
            Dim returnUsuarios As New List(Of Dictionary(Of String, String))
            Dim row As New Dictionary(Of String, String)
            row.Add("ID", usuario.Id)
            row.Add("Nombre", usuario.Nombre)
            returnUsuarios.Add(row)
            Return Json(returnUsuarios, JsonRequestBehavior.AllowGet)
        End Function

        Function updateUsuarioRecursoPorUsuario(ByVal usuarioID As String, ByVal idRecursoPorUsuario As Integer)
            Dim con As New Connection
            Dim cone = New SqlConnection(con.Database.Connection.ConnectionString)
            Dim cmd = New SqlCommand()
            cone.Open()
            Dim idDeptoActual = UserManager.Users.Where(Function(u) u.Id = usuarioID).ToList().First().DepartamentoID
            Dim nombreDeptoActual = con.Departamento.Where(Function(dept) dept.ID = idDeptoActual).ToList().First().Nombre
            Dim nombreSigDepto As String = ""
            If (nombreDeptoActual.Equals("Diseño")) Then
                nombreSigDepto = "Corrección"
            ElseIf (nombreDeptoActual.Equals("Corrección")) Then
                nombreSigDepto = "Grabación"
            ElseIf (nombreDeptoActual.Equals("Grabación")) Then
                nombreSigDepto = "Entrega"
            End If
            Dim idSigDepto = con.Departamento.Where(Function(d) d.Nombre = nombreSigDepto).ToList().First().ID
            Dim idUsuarioSigDepto = UserManager.Users.Where(Function(u) u.DepartamentoID = idSigDepto).ToList().First().Id
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.CommandText = "RecursoPorUsuario_UpdateEstado"
            Dim parm = New SqlParameter()
            parm.ParameterName = "@ID"
            parm.Value = idRecursoPorUsuario
            cmd.Parameters.Add(parm)
            Dim rxu = con.RecursoPorUsuario.Where(Function(ru) ru.ID = idRecursoPorUsuario).ToList().First()
            Dim parm1 = New SqlParameter()
            parm1.ParameterName = "@Estado"
            parm1.Value = rxu.Estado
            cmd.Parameters.Add(parm1)
            Dim parm2 = New SqlParameter()
            parm2.ParameterName = "@RecursoID"
            parm2.Value = rxu.RecursoID
            cmd.Parameters.Add(parm2)
            Dim parm3 = New SqlParameter()
            parm3.ParameterName = "@UsuarioID"
            parm3.Value = idUsuarioSigDepto
            cmd.Parameters.Add(parm3)
            cmd.Connection = cone
            Dim res = cmd.ExecuteNonQuery()
            cone.Close()
            Dim row As New Dictionary(Of String, String)
            row.Add("updated", res.Equals(1))
            Return Json(row, JsonRequestBehavior.AllowGet)
        End Function
        Function updateUsuarioRecursoPorUsuarioAsignar(ByVal usuarioID As String, ByVal idRecursoPorUsuario As Integer, ByVal idRecurso As Integer)
            Dim con As New Connection
            Dim cone = New SqlConnection(con.Database.Connection.ConnectionString)
            Dim cmd = New SqlCommand()
            cone.Open()
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.CommandText = "RecursoPorUsuario_UpdateEstado"
            Dim parm = New SqlParameter()
            parm.ParameterName = "@ID"
            parm.Value = idRecursoPorUsuario
            cmd.Parameters.Add(parm)
            Dim rxu = con.RecursoPorUsuario.Where(Function(ru) ru.ID = idRecursoPorUsuario).ToList().First()
            Dim parm1 = New SqlParameter()
            parm1.ParameterName = "@Estado"
            parm1.Value = rxu.Estado
            cmd.Parameters.Add(parm1)
            Dim parm2 = New SqlParameter()
            parm2.ParameterName = "@RecursoID"
            parm2.Value = idRecurso
            cmd.Parameters.Add(parm2)
            Dim parm3 = New SqlParameter()
            parm3.ParameterName = "@UsuarioID"
            parm3.Value = usuarioID
            cmd.Parameters.Add(parm3)
            cmd.Connection = cone
            Dim res = cmd.ExecuteNonQuery()
            cone.Close()
            Dim row As New Dictionary(Of String, String)
            row.Add("updated", res.Equals(1))
            Return Json(row, JsonRequestBehavior.AllowGet)
        End Function
        Function getUsuariosDelSigDepto(ByVal usuarioID As String)
            Dim con As New Connection
            Dim idDeptoActual = UserManager.Users.Where(Function(u) u.Id = usuarioID).ToList().First().DepartamentoID
            Dim nombreDeptoActual = con.Departamento.Where(Function(dept) dept.ID = idDeptoActual).ToList().First().Nombre
            Dim nombreSigDepto As String = ""
            If (nombreDeptoActual.Equals("Diseño")) Then
                nombreSigDepto = "Corrección"
            ElseIf (nombreDeptoActual.Equals("Corrección")) Then
                nombreSigDepto = "Grabación"
            ElseIf (nombreDeptoActual.Equals("Grabación")) Then
                nombreSigDepto = "Entrega"
            ElseIf (nombreDeptoActual.Equals("Entrega")) Then
                Return False
            End If
            Dim idAntDepto = con.Departamento.Where(Function(d) d.Nombre = nombreSigDepto).ToList().First().ID
            Dim idSigDepto = con.Departamento.Where(Function(d) d.Nombre = nombreSigDepto).ToList().First().ID
            Dim idUsuariosSigDepto = UserManager.Users.Where(Function(u) u.DepartamentoID = idSigDepto).ToList()
            If (nombreDeptoActual.Equals("Corrección")) Then
                idAntDepto = con.Departamento.Where(Function(d) d.Nombre = "Diseño").ToList().First().ID
                Dim usuariosDeptoAnterior = UserManager.Users.Where(Function(u) u.DepartamentoID = idAntDepto).ToList()
                For i As Integer = 0 To usuariosDeptoAnterior.ToArray().Length - 1
                    idUsuariosSigDepto.Add(usuariosDeptoAnterior.ElementAt(i))
                Next
            End If
            If (nombreDeptoActual.Equals("Grabación")) Then
                idAntDepto = con.Departamento.Where(Function(d) d.Nombre = "Corrección").ToList().First().ID
                Dim usuariosDeptoAnterior = UserManager.Users.Where(Function(u) u.DepartamentoID = idAntDepto).ToList()
                For i As Integer = 0 To usuariosDeptoAnterior.ToArray().Length - 1
                    idUsuariosSigDepto.Add(usuariosDeptoAnterior.ElementAt(i))
                Next
            End If

            Dim returnUsuarios As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To idUsuariosSigDepto.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", idUsuariosSigDepto.ElementAt(i).Id)
                row.Add("Nombre", idUsuariosSigDepto.ElementAt(i).Nombre)
                Dim deptID = idUsuariosSigDepto.ElementAt(i).DepartamentoID
                Dim nombreDepartamento = con.Departamento.Where(Function(dep) dep.ID = deptID).First().Nombre
                row.Add("NombreDepartamento", nombreDepartamento)
                returnUsuarios.Add(row)
            Next
            Return Json(returnUsuarios, JsonRequestBehavior.AllowGet)
        End Function

        Function updateRecursoPorUsuario(ByVal usuarioID As String, ByVal recursoID As Integer)
            Dim con As New Connection
            Dim cone = New SqlConnection(con.Database.Connection.ConnectionString)
            Dim cmd = New SqlCommand()
            cone.Open()
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.CommandText = "RecursoPorUsuario_UpdateEstado"
            Dim rxu = con.RecursoPorUsuario.Where(Function(ru) ru.RecursoID = recursoID).ToList().First()
            Dim parm = New SqlParameter()
            parm.ParameterName = "@ID"
            parm.Value = rxu.ID
            cmd.Parameters.Add(parm)
            Dim parm1 = New SqlParameter()
            parm1.ParameterName = "@Estado"
            parm1.Value = rxu.Estado
            cmd.Parameters.Add(parm1)
            Dim parm2 = New SqlParameter()
            parm2.ParameterName = "@RecursoID"
            parm2.Value = rxu.RecursoID
            cmd.Parameters.Add(parm2)
            Dim parm3 = New SqlParameter()
            parm3.ParameterName = "@UsuarioID"
            parm3.Value = usuarioID
            cmd.Parameters.Add(parm3)
            cmd.Connection = cone
            Dim res = cmd.ExecuteNonQuery()
            cone.Close()
            Dim row As New Dictionary(Of String, String)
            row.Add("updated", res.Equals(1))
            row.Add("oldUser", rxu.UsuarioID)
            row.Add("idRecursoPorUsuario", rxu.ID)
            Return Json(row, JsonRequestBehavior.AllowGet)
        End Function
        Function getCurrentUsuarioId() As ActionResult
            Dim usuarioID = UserManager.Users.Where(Function(u) u.UserName = My.User.Name).First().Id
            Dim returnUsuarios As New List(Of Dictionary(Of String, String))
            Dim row As New Dictionary(Of String, String)
            row.Add("ID", usuarioID)
            returnUsuarios.Add(row)
            Return Json(returnUsuarios, JsonRequestBehavior.AllowGet)
        End Function

        Function getCurrentDepartamento() As ActionResult
            Dim usuario = UserManager.Users.Where(Function(u) u.UserName = My.User.Name).First()
            Dim deptoActual = db.Departamento.Where(Function(dept) dept.ID = usuario.DepartamentoID).First()
            Dim returnDepto As New List(Of Dictionary(Of String, String))
            Dim row As New Dictionary(Of String, String)
            row.Add("ID", deptoActual.ID)
            row.Add("Nombre", deptoActual.Nombre)
            returnDepto.Add(row)
            Return Json(returnDepto, JsonRequestBehavior.AllowGet)
        End Function

        Function updateCicloDeVidaAsignacion(ByVal usuarioID As String, ByVal recursoID As Integer) As ActionResult
            Dim manager = UserManager.Users.Where(Function(e) e.UserName = My.User.Name).First().Id
            Dim row = db.CicloDeVida.Where(Function(e) e.RecursoID = recursoID And e.UsuarioID = manager).First()
            Dim userName = UserManager.Users.Where(Function(e) e.Id = usuarioID).First().Nombre
            Dim userSurname = UserManager.Users.Where(Function(e) e.Id = usuarioID).First().Apellido

            Dim con As New Connection
            Dim cone = New SqlConnection(con.Database.Connection.ConnectionString)
            Dim cmd = New SqlCommand()
            cone.Open()
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.CommandText = "CicloDeVida_InsertNewState"
            Dim parm = New SqlParameter()
            parm.ParameterName = "@RecursoID"
            parm.Value = recursoID
            cmd.Parameters.Add(parm)
            Dim parm1 = New SqlParameter()
            parm1.ParameterName = "@UsuarioID"
            parm1.Value = usuarioID
            cmd.Parameters.Add(parm1)
            Dim parm2 = New SqlParameter()
            parm2.ParameterName = "@Estado"
            parm2.Value = row.Estado
            cmd.Parameters.Add(parm2)
            Dim parm3 = New SqlParameter()
            parm3.ParameterName = "@FechaModificacion"
            parm3.Value = Date.Now
            cmd.Parameters.Add(parm3)
            Dim parm4 = New SqlParameter()
            parm4.ParameterName = "@Observacion"
            parm4.Value = "Se asignó a " + userName + " " + userSurname
            cmd.Parameters.Add(parm4)
            cmd.Connection = cone
            Dim res = cmd.ExecuteNonQuery()
            cone.Close()
            Dim returnJson As New Dictionary(Of String, String)
            returnJson.Add("updated", res.Equals(1))
            Return Json(returnJson, JsonRequestBehavior.AllowGet)
        End Function
        Function updateCicloDeVidaEstado(ByVal recursoID As Integer, ByVal estado As String) As ActionResult
            Dim UsuarioID = UserManager.Users.Where(Function(e) e.UserName = My.User.Name).First().Id
            Dim row = db.CicloDeVida.Where(Function(e) e.RecursoID = recursoID And e.UsuarioID = UsuarioID).First()

            Dim con As New Connection
            Dim cone = New SqlConnection(con.Database.Connection.ConnectionString)
            Dim cmd = New SqlCommand()
            cone.Open()
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.CommandText = "CicloDeVida_InsertNewState"
            Dim parm = New SqlParameter()
            parm.ParameterName = "@RecursoID"
            parm.Value = recursoID
            cmd.Parameters.Add(parm)
            Dim parm1 = New SqlParameter()
            parm1.ParameterName = "@UsuarioID"
            parm1.Value = usuarioID
            cmd.Parameters.Add(parm1)
            Dim parm2 = New SqlParameter()
            parm2.ParameterName = "@Estado"
            parm2.Value = estado
            cmd.Parameters.Add(parm2)
            Dim parm3 = New SqlParameter()
            parm3.ParameterName = "@FechaModificacion"
            parm3.Value = Date.Now
            cmd.Parameters.Add(parm3)
            Dim parm4 = New SqlParameter()
            parm4.ParameterName = "@Observacion"
            parm4.Value = "Cambió al estado " + estado
            cmd.Parameters.Add(parm4)
            cmd.Connection = cone
            Dim res = cmd.ExecuteNonQuery()
            cone.Close()
            Dim returnJson As New Dictionary(Of String, String)
            returnJson.Add("updated", res.Equals(1))
            Return Json(returnJson, JsonRequestBehavior.AllowGet)
        End Function
        Function updateObservacion(ByVal observacion As String, ByVal recursoID As Integer) As ActionResult
            Dim row = db.RecursoObservacion.Where(Function(e) e.ID = recursoID)

            Dim con As New Connection
            Dim cone = New SqlConnection(con.Database.Connection.ConnectionString)
            Dim cmd = New SqlCommand()
            cone.Open()
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            If (row.ToArray().Length = 0) Then
                cmd.CommandText = "RecursoObservacion_Insert"
            Else
                cmd.CommandText = "RecursoObservacion_Update"
            End If
            Dim parm = New SqlParameter()
            parm.ParameterName = "@RecursoID"
            parm.Value = recursoID
            cmd.Parameters.Add(parm)
            Dim parm2 = New SqlParameter()
            parm2.ParameterName = "@Observacion"
            parm2.Value = observacion
            cmd.Parameters.Add(parm2)
            Dim parm3 = New SqlParameter()
            parm3.ParameterName = "@isRead"
            parm3.Value = 0
            cmd.Parameters.Add(parm3)
            cmd.Connection = cone
            Dim res = cmd.ExecuteNonQuery()
            cone.Close()
            Dim returnJson As New Dictionary(Of String, String)
            If (row.ToArray().Length = 0) Then
                returnJson.Add("Inserted", res.Equals(1))
            Else
                returnJson.Add("Updated", res.Equals(1))
            End If
            updateCicloDeVidaObservacion(recursoID, observacion)
            Return Json(returnJson, JsonRequestBehavior.AllowGet)
        End Function
        Function mostrarObservacion(ByVal recursoID As Integer) As ActionResult
            Dim recurso = db.RecursoObservacion.Where(Function(e) e.RecursoID = recursoID And e.isRead = 0)
            If (recurso.ToArray().Length = 0) Then
                Dim returnJson1 As New Dictionary(Of String, String)
                returnJson1.Add("isRead", True)
                Return Json(returnJson1, JsonRequestBehavior.AllowGet)
            End If
            Dim recursoObservacion = recurso.First()
            'Actualizar como ya leído
            Dim con As New Connection
            Dim cone = New SqlConnection(con.Database.Connection.ConnectionString)
            Dim cmd = New SqlCommand()
            cone.Open()
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.CommandText = "RecursoObservacion_Update"
            Dim parm = New SqlParameter()
            parm.ParameterName = "@RecursoID"
            parm.Value = recursoID
            cmd.Parameters.Add(parm)
            Dim parm2 = New SqlParameter()
            parm2.ParameterName = "@Observacion"
            parm2.Value = recursoObservacion.Observacion
            cmd.Parameters.Add(parm2)
            Dim parm3 = New SqlParameter()
            parm3.ParameterName = "@isRead"
            parm3.Value = 1
            cmd.Parameters.Add(parm3)
            cmd.Connection = cone
            Dim res = cmd.ExecuteNonQuery()
            cone.Close()

            Dim returnJson As New Dictionary(Of String, String)
            returnJson.Add("Observacion", recursoObservacion.Observacion)
            Return Json(returnJson, JsonRequestBehavior.AllowGet)
        End Function
        Function updateCicloDeVidaObservacion(ByVal recursoID As Integer, ByVal observacion As String) As ActionResult
            Dim UsuarioID = UserManager.Users.Where(Function(e) e.UserName = My.User.Name).First().Id
            Dim row = db.CicloDeVida.Where(Function(e) e.RecursoID = recursoID And e.UsuarioID = UsuarioID).First()

            Dim con As New Connection
            Dim cone = New SqlConnection(con.Database.Connection.ConnectionString)
            Dim cmd = New SqlCommand()
            cone.Open()
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.CommandText = "CicloDeVida_InsertNewState"
            Dim parm = New SqlParameter()
            parm.ParameterName = "@RecursoID"
            parm.Value = recursoID
            cmd.Parameters.Add(parm)
            Dim parm1 = New SqlParameter()
            parm1.ParameterName = "@UsuarioID"
            parm1.Value = UsuarioID
            cmd.Parameters.Add(parm1)
            Dim parm2 = New SqlParameter()
            parm2.ParameterName = "@Estado"
            parm2.Value = row.Estado
            cmd.Parameters.Add(parm2)
            Dim parm3 = New SqlParameter()
            parm3.ParameterName = "@FechaModificacion"
            parm3.Value = Date.Now
            cmd.Parameters.Add(parm3)
            Dim parm4 = New SqlParameter()
            parm4.ParameterName = "@Observacion"
            parm4.Value = "Se agregó la observación " + observacion
            cmd.Parameters.Add(parm4)
            cmd.Connection = cone
            Dim res = cmd.ExecuteNonQuery()
            cone.Close()
            Dim returnJson As New Dictionary(Of String, String)
            returnJson.Add("updated", res.Equals(1))
            Return Json(returnJson, JsonRequestBehavior.AllowGet)
        End Function
    End Class
End Namespace