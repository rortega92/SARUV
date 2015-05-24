Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc

Namespace SaruvMaster
    Public Class PersonalUVController
        Inherits Controller


        Private db As New Connection

        ' GET: /Recurso/
        Function Index() As ActionResult
            Dim recursoes = db.Recursoes.Include(Function(r) r.ClienteCorporativo).Include(Function(r) r.Curso).Include(Function(r) r.Docente).Include(Function(r) r.Empresa).Include(Function(r) r.ModalidadDeCurso).Include(Function(r) r.TipoDeRecurso)
            Return View(recursoes.ToList())
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
            Dim listaRecursos = con.Recursoes.ToList()
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
    End Class
End Namespace