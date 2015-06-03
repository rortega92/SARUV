Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Friend NotInheritable Class Configuration 
        Inherits DbMigrationsConfiguration(Of Connection)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As Connection)
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

            Dim rolesPorDepartamento = New List(Of RolPorDepartamento)() From {
                   New RolPorDepartamento() With {
                       .Nombre = "Jefe Diseño",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0,
                       .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Diseno").ID
                   },
                   New RolPorDepartamento() With {
                       .Nombre = "Auxiliar Diseño",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0,
                       .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Diseno").ID
                   },
                   New RolPorDepartamento() With {
                       .Nombre = "Auxiliar Corrección",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0,
                       .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Correccion").ID
                   },
                   New RolPorDepartamento() With {
                       .Nombre = "Auxiliar Grabación",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0,
                       .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Grabacion").ID
                   },
                   New RolPorDepartamento() With {
                       .Nombre = "Auxiliar Entrega",
                       .FechaCreacion = DateTime.Parse("2010-09-01"),
                       .FechaModificacion = DateTime.Parse("2010-10-01"),
                       .IsDeleted = 0,
                       .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Entrega").ID
                   }
               }
            For Each rolDept In rolesPorDepartamento
                context.RolPorDepartamento.AddOrUpdate(Function(p) p.Nombre, rolDept)
            Next
            context.Savechanges()

            Dim usuarios = New List(Of ApplicationUser)() From {
                  New ApplicationUser() With {
                      .Nombre = "",
                      .Apellido = "",
                      .Email = "",
                      .PasswordHash = "Hola123!",
                      .DepartamentoID = departamentos.Single(Function(e) e.Nombre = "Diseño").ID,
                      .RolPorDepartamentoID = rolesPorDepartamento.Single(Function(rd) rd.Nombre = "Jefe Diseño").ID
                  }
              }
        End Sub

    End Class

End Namespace
