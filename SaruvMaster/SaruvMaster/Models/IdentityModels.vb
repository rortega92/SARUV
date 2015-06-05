Imports System.ComponentModel.DataAnnotations
Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin

' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
Public Class ApplicationUser
    Inherits IdentityUser
    Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of ApplicationUser)) As Task(Of ClaimsIdentity)
        ' Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        Dim userIdentity = Await manager.CreateIdentityAsync(Me, DefaultAuthenticationTypes.ApplicationCookie)
        ' Add custom user claims here
        Return userIdentity
    End Function

    Public Property Nombre As String
    Public Property Apellido As String

    Public Property DepartamentoID As Nullable(Of Integer)
    Public Overridable Property Departamento As Departamento

    Public Property FechaCreacion As Date
    Public Property FechaModificacion As Date
    Public Property IsDeleted As Integer = 0
    Public Property isJefe As Integer
End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New("Context", throwIfV1Schema:=False)
    End Sub

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function

    Public Property ApplicationUsers As System.Data.Entity.DbSet(Of ApplicationUser)
    Public Property Departamentoes As System.Data.Entity.DbSet(Of Departamento)
    Public Property EncargadoDeValidacions As System.Data.Entity.DbSet(Of EncargadoDeValidacion)
    Public Property Facultads As System.Data.Entity.DbSet(Of Facultad)
End Class
