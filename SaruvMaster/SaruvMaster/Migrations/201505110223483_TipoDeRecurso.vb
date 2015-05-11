Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class TipoDeRecurso
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.TipoDeRecurso",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(nullable := False, maxLength := 255),
                        .CodigoRecurso = c.String(nullable := False),
                        .FechaInicio = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateStoredProcedure(
                "dbo.TipoDeRecurso_Insert",
                Function(p) New With
                    {
                        .Nombre = p.String(maxLength:=255),
                        .CodigoRecurso = p.String(),
                        .FechaInicio = p.DateTime()
                    },
                body:=
                    "INSERT [dbo].[TipoDeRecurso]([Nombre], [CodigoRecurso], [FechaInicio])" & vbCrLf & _
                    "VALUES (@Nombre, @CodigoRecurso, @FechaInicio)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @Id int" & vbCrLf & _
                    "SELECT @Id = [Id]" & vbCrLf & _
                    "FROM [dbo].[TipoDeRecurso]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[Id]" & vbCrLf & _
                    "FROM [dbo].[TipoDeRecurso] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            )

            CreateStoredProcedure(
                "dbo.TipoDeRecurso_Update",
                Function(p) New With
                    {
                        .Id = p.Int(),
                        .Nombre = p.String(maxLength:=255),
                        .CodigoRecurso = p.String(),
                        .FechaInicio = p.DateTime()
                    },
                body:=
                    "UPDATE [dbo].[TipoDeRecurso]" & vbCrLf & _
                    "SET [Nombre] = @Nombre, [CodigoRecurso] = @CodigoRecurso, [FechaInicio] = @FechaInicio" & vbCrLf & _
                    "WHERE ([Id] = @Id)"
            )

            CreateStoredProcedure(
                "dbo.TipoDeRecurso_Delete",
                Function(p) New With
                    {
                        .Id = p.Int()
                    },
                body:=
                    "DELETE [dbo].[TipoDeRecurso]" & vbCrLf & _
                    "WHERE ([Id] = @Id)"
            )

        End Sub

        Public Overrides Sub Down()
            DropStoredProcedure("dbo.TipoDeRecurso_Delete")
            DropStoredProcedure("dbo.TipoDeRecurso_Update")
            DropStoredProcedure("dbo.TipoDeRecurso_Insert")
            DropTable("dbo.TipoDeRecurso")
        End Sub
    End Class
End Namespace
