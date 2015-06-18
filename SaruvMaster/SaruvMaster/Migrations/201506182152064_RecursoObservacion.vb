Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class RecursoObservacion
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.RecursoObservacion",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .RecursoID = c.Int(nullable := False),
                        .Observacion = c.String(),
                        .isRead = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Recurso", Function(t) t.RecursoID) _
                .Index(Function(t) t.RecursoID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.RecursoObservacion", "RecursoID", "dbo.Recurso")
            DropIndex("dbo.RecursoObservacion", New String() { "RecursoID" })
            DropTable("dbo.RecursoObservacion")
        End Sub
    End Class
End Namespace
