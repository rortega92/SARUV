Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Events
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Events",
                Function(c) New With
                    {
                        .id = c.Int(nullable := False, identity := True),
                        .title = c.String(),
                        .fecha = c.String(),
                        .start = c.String(),
                        ._end = c.String(name := "end"),
                        .url = c.String(),
                        .allDay = c.Boolean(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Events")
        End Sub
    End Class
End Namespace
