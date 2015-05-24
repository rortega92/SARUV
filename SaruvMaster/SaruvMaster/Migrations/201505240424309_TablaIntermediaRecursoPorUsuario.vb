Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class TablaIntermediaRecursoPorUsuario
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.RecursoPorUsuario",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .RecursoID = c.Int(nullable := False),
                        .UsuarioID = c.Int(nullable := False),
                        .Estado = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Recurso", Function(t) t.RecursoID, cascadeDelete := True) _
                .ForeignKey("dbo.Usuario", Function(t) t.UsuarioID, cascadeDelete := True) _
                .Index(Function(t) t.RecursoID) _
                .Index(Function(t) t.UsuarioID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.RecursoPorUsuario", "UsuarioID", "dbo.Usuario")
            DropForeignKey("dbo.RecursoPorUsuario", "RecursoID", "dbo.Recurso")
            DropIndex("dbo.RecursoPorUsuario", New String() { "UsuarioID" })
            DropIndex("dbo.RecursoPorUsuario", New String() { "RecursoID" })
            DropTable("dbo.RecursoPorUsuario")
        End Sub
    End Class
End Namespace
