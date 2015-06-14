Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UserFile
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ArchivoUsuario",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .NombreArchivo = c.String(),
                        .TipoArchivo = c.Int(nullable := False),
                        .RecursoID = c.Int(nullable := False),
                        .FechaCreacion = c.DateTime(nullable := False),
                        .FechaModificacion = c.DateTime(nullable := False),
                        .IsDeleted = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Recurso", Function(t) t.RecursoID) _
                .Index(Function(t) t.RecursoID)
            
            CreateStoredProcedure(
                "dbo.ArchivoUsuario_Insert",
                Function(p) New With
                    {
                        .NombreArchivo = p.String(),
                        .TipoArchivo = p.Int(),
                        .RecursoID = p.Int(),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "INSERT [dbo].[ArchivoUsuario]([NombreArchivo], [TipoArchivo], [RecursoID], [FechaCreacion], [FechaModificacion], [IsDeleted])" & vbCrLf & _
                    "VALUES (@NombreArchivo, @TipoArchivo, @RecursoID, @FechaCreacion, @FechaModificacion, 0)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @ID int" & vbCrLf & _
                    "SELECT @ID = [ID]" & vbCrLf & _
                    "FROM [dbo].[ArchivoUsuario]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[ID]" & vbCrLf & _
                    "FROM [dbo].[ArchivoUsuario] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            )
            
            CreateStoredProcedure(
                "dbo.ArchivoUsuario_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .NombreArchivo = p.String(),
                        .TipoArchivo = p.Int(),
                        .RecursoID = p.Int(),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "UPDATE [dbo].[ArchivoUsuario]" & vbCrLf & _
                    "SET [NombreArchivo] = @NombreArchivo, [TipoArchivo] = @TipoArchivo, [RecursoID] = @RecursoID, [FechaCreacion] = @FechaCreacion, [FechaModificacion] = @FechaModificacion" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.ArchivoUsuario_Delete",
                Function(p) New With
                    {
                        .ID = p.Int()
                    },
                body :=
                    "DELETE [dbo].[ArchivoUsuario]" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
        End Sub
        
        Public Overrides Sub Down()
            DropStoredProcedure("dbo.ArchivoUsuario_Delete")
            DropStoredProcedure("dbo.ArchivoUsuario_Update")
            DropStoredProcedure("dbo.ArchivoUsuario_Insert")
            DropForeignKey("dbo.ArchivoUsuario", "RecursoID", "dbo.Recurso")
            DropIndex("dbo.ArchivoUsuario", New String() { "RecursoID" })
            DropTable("dbo.ArchivoUsuario")
        End Sub
    End Class
End Namespace
