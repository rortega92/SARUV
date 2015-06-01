Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin

' Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
Public Class ApplicationUser
    Inherits IdentityUser
    Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of ApplicationUser)) As Task(Of ClaimsIdentity)
        ' Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
        Dim userIdentity = Await manager.CreateIdentityAsync(Me, DefaultAuthenticationTypes.ApplicationCookie)
        ' Agregar reclamaciones de usuario personalizado aquí
        Return userIdentity
    End Function
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property FechaCreacion As Date
    Public Property FechaModificacion As Date
    Public Property DepartamentoID As Nullable(Of Integer)
    Public Overridable Property Departamento As Departamento
    Public Property RolPorDepartamentoID As Nullable(Of Integer)
    Public Overridable Property RolPorDepartamento As RolPorDepartamento
    Public Property IsDeleted As Integer = 0

End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New("Context", throwIfV1Schema:=False)
    End Sub

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function
End Class
