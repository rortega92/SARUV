Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Tareas
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Tarea",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .UsuarioID = c.String(maxLength := 128),
                        .Descripcion = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UsuarioID) _
                .Index(Function(t) t.UsuarioID)
            
            CreateStoredProcedure(
                "dbo.Tarea_Insert",
                Function(p) New With
                    {
                        .UsuarioID = p.String(maxLength := 128),
                        .Descripcion = p.String()
                    },
                body :=
                    "INSERT [dbo].[Tarea]([UsuarioID], [Descripcion])" & vbCrLf & _
                    "VALUES (@UsuarioID, @Descripcion)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @ID int" & vbCrLf & _
                    "SELECT @ID = [ID]" & vbCrLf & _
                    "FROM [dbo].[Tarea]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[ID]" & vbCrLf & _
                    "FROM [dbo].[Tarea] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            )
            
            CreateStoredProcedure(
                "dbo.Tarea_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .UsuarioID = p.String(maxLength := 128),
                        .Descripcion = p.String()
                    },
                body :=
                    "UPDATE [dbo].[Tarea]" & vbCrLf & _
                    "SET [UsuarioID] = @UsuarioID, [Descripcion] = @Descripcion" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.Tarea_Delete",
                Function(p) New With
                    {
                        .ID = p.Int()
                    },
                body :=
                    "DELETE [dbo].[Tarea]" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
        End Sub
        
        Public Overrides Sub Down()
            DropStoredProcedure("dbo.Tarea_Delete")
            DropStoredProcedure("dbo.Tarea_Update")
            DropStoredProcedure("dbo.Tarea_Insert")
            DropForeignKey("dbo.Tarea", "UsuarioID", "dbo.AspNetUsers")
            DropIndex("dbo.Tarea", New String() { "UsuarioID" })
            DropTable("dbo.Tarea")
        End Sub
    End Class
End Namespace
