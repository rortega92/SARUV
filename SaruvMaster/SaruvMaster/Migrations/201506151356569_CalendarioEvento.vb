Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class CalendarioEvento
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.EventosCalendario",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Evento = c.String(maxLength := 255),
                        .Description = c.String(),
                        .StartString = c.String(),
                        .EndString = c.String(),
                        .FechaReserva = c.DateTime(nullable := False),
                        .HoraInicio = c.DateTime(nullable := False),
                        .HoraFinal = c.DateTime(nullable := False),
                        .IsDeleted = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.EventosCalendario")
        End Sub
    End Class
End Namespace
