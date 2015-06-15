Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class EvetosEstudio
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.EventosCalendario", "Description", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.EventosCalendario", "Description")
        End Sub
    End Class
End Namespace
