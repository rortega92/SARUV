Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ModelosEventosConFechaMod
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.EventosCalendario", "FechaCreacion", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.EventosCalendario", "FechaModificacion", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.EventosEstudio", "FechaCreacion", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.EventosEstudio", "FechaModificacion", Function(c) c.DateTime(nullable := False))
            AlterColumn("dbo.EventosCalendario", "Evento", Function(c) c.String(nullable := False, maxLength := 255))
            AlterColumn("dbo.EventosCalendario", "Description", Function(c) c.String(nullable := False))
            AlterColumn("dbo.EventosEstudio", "Evento", Function(c) c.String(nullable := False, maxLength := 255))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.EventosEstudio", "Evento", Function(c) c.String(maxLength := 255))
            AlterColumn("dbo.EventosCalendario", "Description", Function(c) c.String())
            AlterColumn("dbo.EventosCalendario", "Evento", Function(c) c.String(maxLength := 255))
            DropColumn("dbo.EventosEstudio", "FechaModificacion")
            DropColumn("dbo.EventosEstudio", "FechaCreacion")
            DropColumn("dbo.EventosCalendario", "FechaModificacion")
            DropColumn("dbo.EventosCalendario", "FechaCreacion")
        End Sub
    End Class
End Namespace
