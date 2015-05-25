Imports System.Web.Mvc

Namespace Controllers
    Public Class HeaderController
        Inherits Controller
        Private db As New Connection
        ' GET: Head
        Function Index() As ActionResult
            Return View()
        End Function

        Function getUsuarios() As ActionResult
            Dim con As New Connection
            Dim listaUsuarios = db.Usuario.ToList()
            Dim returnUsuarios As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To listaUsuarios.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", listaUsuarios.ElementAt(i).ID)
                row.Add("Nombre", listaUsuarios.ElementAt(i).Nombre)
                row.Add("Apellido", listaUsuarios.ElementAt(i).Apellido)
                row.Add("correo", listaUsuarios.ElementAt(i).correo)
                row.Add("DepartamentoID", listaUsuarios.ElementAt(i).DepartamentoID)
                row.Add("RolPorDepartamentoID", listaUsuarios.ElementAt(i).RolPorDepartamentoID)
                row.Add("FechaCreacion", listaUsuarios.ElementAt(i).FechaCreacion)
                row.Add("FechaModificacion", listaUsuarios.ElementAt(i).FechaModificacion)
                returnUsuarios.Add(row)
            Next
            Return Json(returnUsuarios, JsonRequestBehavior.AllowGet)
        End Function
    End Class
End Namespace