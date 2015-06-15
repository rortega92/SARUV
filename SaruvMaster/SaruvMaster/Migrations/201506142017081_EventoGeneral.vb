Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Partial Public Class EventoGeneral
        Inherits DbMigration

        Public Overrides Sub Up()
            CreateTable(
                "dbo.EventosGenerales",
                Function(c) New With
                    {
                        .ID = c.Int(nullable:=False, identity:=True),
                        .Evento = c.String(maxLength:=255),
                        .StartString = c.String(),
                        .EndString = c.String(),
                        .FechaReserva = c.DateTime(nullable:=False),
                        .HoraInicio = c.DateTime(nullable:=False),
                        .HoraFinal = c.DateTime(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) t.ID)

        End Sub

        Public Overrides Sub Down()
            DropTable("dbo.EventosGenerales")
        End Sub
    End Class
End Namespace
