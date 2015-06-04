Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of Connection)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As Connection)
            Dim hasher As New PasswordHasher()
            Dim departamentos = New List(Of Departamento)() From {
                   New Departamento() With {
                       .Nombre = "Diseño",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0
                   },
                   New Departamento() With {
                       .Nombre = "Corrección",
                       .FechaCreacion = DateTime.Parse("2011-09-01"),
                       .FechaModificacion = DateTime.Parse("2012-10-01"),
                       .IsDeleted = 0
                   },
                   New Departamento() With {
                       .Nombre = "Grabación",
                       .FechaCreacion = DateTime.Parse("2003-09-01"),
                       .FechaModificacion = DateTime.Parse("2012-10-01"),
                       .IsDeleted = 0
                   },
                   New Departamento() With {
                       .Nombre = "Entrega",
                       .FechaCreacion = DateTime.Parse("2002-09-01"),
                       .FechaModificacion = DateTime.Parse("2012-10-01"),
                       .IsDeleted = 0
                   }
               }
            For Each dept In departamentos
                context.Departamento.AddOrUpdate(Function(p) p.Nombre, dept)
            Next
            context.Savechanges()

            Dim roleStore = New RoleStore(Of IdentityRole)(context)
            Dim roleManager = New RoleManager(Of IdentityRole)(roleStore)
            Dim role As New IdentityRole() With {
                .Name = "Admin"
            }
            Dim role2 As New IdentityRole() With {
                .Name = "Estándar"
            }
            roleManager.Create(role)
            roleManager.Create(role2)


            Dim userStore = New UserStore(Of ApplicationUser)(context)
            Dim userManager = New UserManager(Of ApplicationUser)(userStore)
            Dim user As New ApplicationUser() With {
                .Nombre = "Silvia",
                .Apellido = "Colindres",
                .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Diseño").ID,
                .Email = "scolindres@gmail.com",
                .UserName = "scolindres@gmail.com",
                .PasswordHash = hasher.HashPassword("Hola123!"),
                .FechaCreacion = DateTime.Now,
                .FechaModificacion = DateTime.Now,
                .isJefe = 0
            }
            user.Roles.Add(New IdentityUserRole() With {
                .RoleId = role.Id,
                .UserId = user.Id
            })
            'userManager.Create(user)

        End Sub

    End Class

End Namespace
