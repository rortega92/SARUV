Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Initial
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Departamento",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(nullable := False, maxLength := 255),
                        .FechaCreacion = c.DateTime(nullable := False),
                        .FechaModificacion = c.DateTime(nullable := False),
                        .IsDeleted = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.AspNetRoles",
                Function(c) New With
                    {
                        .Id = c.String(nullable := False, maxLength := 128),
                        .Name = c.String(nullable := False, maxLength := 256)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .Index(Function(t) t.Name, unique := True, name := "RoleNameIndex")
            
            CreateTable(
                "dbo.AspNetUserRoles",
                Function(c) New With
                    {
                        .UserId = c.String(nullable := False, maxLength := 128),
                        .RoleId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) New With { t.UserId, t.RoleId }) _
                .ForeignKey("dbo.AspNetRoles", Function(t) t.RoleId) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserId) _
                .Index(Function(t) t.UserId) _
                .Index(Function(t) t.RoleId)
            
            CreateTable(
                "dbo.AspNetUsers",
                Function(c) New With
                    {
                        .Id = c.String(nullable:=False, maxLength:=128),
                        .Email = c.String(maxLength:=256),
                        .EmailConfirmed = c.Boolean(nullable:=False),
                        .PasswordHash = c.String(),
                        .SecurityStamp = c.String(),
                        .PhoneNumber = c.String(),
                        .PhoneNumberConfirmed = c.Boolean(nullable:=False),
                        .TwoFactorEnabled = c.Boolean(nullable:=False),
                        .LockoutEndDateUtc = c.DateTime(),
                        .LockoutEnabled = c.Boolean(nullable:=False),
                        .AccessFailedCount = c.Int(nullable:=False),
                        .UserName = c.String(nullable:=False, maxLength:=256),
                        .Nombre = c.String(),
                        .Apellido = c.String(),
                        .DepartamentoID = c.Int(),
                        .FechaCreacion = c.DateTime(),
                        .FechaModificacion = c.DateTime(),
                        .IsDeleted = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Departamento", Function(t) t.DepartamentoID) _
                .Index(Function(t) t.UserName, unique:=True, name:="UserNameIndex") _
                .Index(Function(t) t.DepartamentoID)
            
            CreateTable(
                "dbo.AspNetUserClaims",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .UserId = c.String(nullable := False, maxLength := 128),
                        .ClaimType = c.String(),
                        .ClaimValue = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserId) _
                .Index(Function(t) t.UserId)
            
            CreateTable(
                "dbo.AspNetUserLogins",
                Function(c) New With
                    {
                        .LoginProvider = c.String(nullable := False, maxLength := 128),
                        .ProviderKey = c.String(nullable := False, maxLength := 128),
                        .UserId = c.String(nullable := False, maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) New With { t.LoginProvider, t.ProviderKey, t.UserId }) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserId) _
                .Index(Function(t) t.UserId)
            
            CreateStoredProcedure(
                "dbo.Departamento_Insert",
                Function(p) New With
                    {
                        .Nombre = p.String(maxLength := 255),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "INSERT [dbo].[Departamento]([Nombre], [FechaCreacion], [FechaModificacion], [IsDeleted])" & vbCrLf & _
                    "VALUES (@Nombre, @FechaCreacion, @FechaModificacion, 0)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @ID int" & vbCrLf & _
                    "SELECT @ID = [ID]" & vbCrLf & _
                    "FROM [dbo].[Departamento]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[ID]" & vbCrLf & _
                    "FROM [dbo].[Departamento] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            )
            
            CreateStoredProcedure(
                "dbo.Departamento_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombre = p.String(maxLength := 255),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "UPDATE [dbo].[Departamento]" & vbCrLf & _
                    "SET [Nombre] = @Nombre, [FechaCreacion] = @FechaCreacion, [FechaModificacion] = @FechaModificacion" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.Departamento_Delete",
                Function(p) New With
                    {
                        .ID = p.Int()
                    },
                body :=
                    "DELETE [dbo].[Departamento]" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
        End Sub
        
        Public Overrides Sub Down()
            DropStoredProcedure("dbo.Departamento_Delete")
            DropStoredProcedure("dbo.Departamento_Update")
            DropStoredProcedure("dbo.Departamento_Insert")
            DropForeignKey("dbo.AspNetUsers", "DepartamentoID", "dbo.Departamento")
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers")
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles")
            DropIndex("dbo.AspNetUserLogins", New String() { "UserId" })
            DropIndex("dbo.AspNetUserClaims", New String() { "UserId" })
            DropIndex("dbo.AspNetUsers", New String() { "DepartamentoID" })
            DropIndex("dbo.AspNetUsers", "UserNameIndex")
            DropIndex("dbo.AspNetUserRoles", New String() { "RoleId" })
            DropIndex("dbo.AspNetUserRoles", New String() { "UserId" })
            DropIndex("dbo.AspNetRoles", "RoleNameIndex")
            DropTable("dbo.AspNetUserLogins")
            DropTable("dbo.AspNetUserClaims")
            DropTable("dbo.AspNetUsers")
            DropTable("dbo.AspNetUserRoles")
            DropTable("dbo.AspNetRoles")
            DropTable("dbo.Departamento")
        End Sub
    End Class
End Namespace
