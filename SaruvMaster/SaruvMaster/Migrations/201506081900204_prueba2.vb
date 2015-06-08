Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class prueba2
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.EventosEstudio", "StartString", Function(c) c.String())
            AddColumn("dbo.EventosEstudio", "EndString", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.EventosEstudio", "EndString")
            DropColumn("dbo.EventosEstudio", "StartString")
        End Sub
    End Class
End Namespace
