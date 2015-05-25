Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports System.Data.SqlClient

Namespace SaruvMaster
    Public Class PersonalUVController
        Inherits Controller


        Private db As New Connection

        ' GET: /RecursoPorUsuario/
        Function Index(ByVal idUsuario As Integer?) As ActionResult
            Dim recursoPorUsuario = db.RecursoPorUsuario.Include(Function(r) r.Recurso).Include(Function(r) r.Usuario)
            Dim idRolPorDepartamento = db.Usuario.Where(Function(u) u.ID = idUsuario).First().RolPorDepartamentoID
            Dim nombreRol = db.RolPorDepartamento.Where(Function(ro) ro.ID = idRolPorDepartamento).First().Nombre
            If (nombreRol.ToLower.StartsWith("jefe")) Then
                ViewBag.isJefe = True
                Return View(recursoPorUsuario.ToList())
            End If
            ViewBag.isJefe = False
            Return View(recursoPorUsuario.Where(Function(ru) ru.UsuarioID = idUsuario).ToList())
        End Function

        Function getUsuariosByNombreDepartamento(ByVal nombreDepartamento As String) As ActionResult
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim con As New Connection
            Dim idDepartamento = con.Departamento.Where(Function(d) d.Nombre = nombreDepartamento).First().ID
            Dim listaUsuarios = con.Usuario.ToList.Where(Function(u) u.DepartamentoID = idDepartamento And Not (u.RolPorDepartamento.Nombre.StartsWith("Jefe")))
            Dim returnUsuarios As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To listaUsuarios.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", listaUsuarios.ElementAt(i).ID)
                row.Add("Nombre", listaUsuarios.ElementAt(i).Nombre)
                returnUsuarios.Add(row)
            Next
            Return Json(returnUsuarios, JsonRequestBehavior.AllowGet)
        End Function
        Function getRecursosByUsuario(ByVal idUsuario As Integer) As ActionResult
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim con As New Connection
            Dim idsRecursos = con.RecursoPorUsuario.Where(Function(ru) ru.UsuarioID = idUsuario).Select(Function(ru) ru.RecursoID)
            Dim recursos = con.Recursoes
            Dim listaRecursos = New List(Of Recurso)
            For i As Integer = 0 To idsRecursos.ToArray().Length - 1
                Dim it = i
                Dim current = idsRecursos.ToArray().ElementAt(it)
                listaRecursos.Add(recursos.Where(Function(r) r.Id = current).ToList().First())
            Next
            Dim returnRecursos As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To listaRecursos.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", listaRecursos.ElementAt(i).Id)
                row.Add("Nombre", listaRecursos.ElementAt(i).Nombre)
                row.Add("Prioridad", listaRecursos.ElementAt(i).Prioridad)
                returnRecursos.Add(row)
            Next
            Return Json(returnRecursos, JsonRequestBehavior.AllowGet)
        End Function
        Function getIdJefeByNombreDepartamento(ByVal nombreDepartamento As String) As ActionResult
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim con As New Connection
            Dim idDepartamento = con.Departamento.Where(Function(d) d.Nombre = nombreDepartamento).First().ID
            Dim listaUsuarios = con.Usuario.ToList.Where(Function(u) u.DepartamentoID = idDepartamento And u.RolPorDepartamento.Nombre.StartsWith("Jefe"))
            Dim returnUsuarios As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To listaUsuarios.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", listaUsuarios.ElementAt(i).ID)
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

        Function getUsuarioById(ByVal idUsuario As Integer) As ActionResult
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim con As New Connection
            Dim usuario = con.Usuario.ToList.Where(Function(u) u.ID = idUsuario).First()
            Dim returnUsuarios As New List(Of Dictionary(Of String, String))
            Dim row As New Dictionary(Of String, String)
            row.Add("ID", usuario.ID)
            row.Add("Nombre", usuario.Nombre)
            returnUsuarios.Add(row)
            Return Json(returnUsuarios, JsonRequestBehavior.AllowGet)
        End Function
    End Class
End Namespace