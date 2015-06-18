Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class CicloDeVida
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.CicloDeVida",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .RecursoID = c.Int(nullable := False),
                        .UsuarioID = c.String(maxLength := 128),
                        .Estado = c.String(),
                        .FechaModificacion = c.DateTime(nullable := False),
                        .Observacion = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Recurso", Function(t) t.RecursoID) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UsuarioID) _
                .Index(Function(t) t.RecursoID) _
                .Index(Function(t) t.UsuarioID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.CicloDeVida", "UsuarioID", "dbo.AspNetUsers")
            DropForeignKey("dbo.CicloDeVida", "RecursoID", "dbo.Recurso")
            DropIndex("dbo.CicloDeVida", New String() { "UsuarioID" })
            DropIndex("dbo.CicloDeVida", New String() { "RecursoID" })
            DropTable("dbo.CicloDeVida")
        End Sub
    End Class
End Namespace
