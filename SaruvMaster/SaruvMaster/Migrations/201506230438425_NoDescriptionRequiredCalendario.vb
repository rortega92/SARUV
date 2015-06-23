Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class NoDescriptionRequiredCalendario
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.EventosCalendario", "Description", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.EventosCalendario", "Description", Function(c) c.String(nullable := False))
        End Sub
    End Class
End Namespace
