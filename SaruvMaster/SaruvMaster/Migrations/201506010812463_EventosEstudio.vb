Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class EventosEstudio
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.EventosEstudio",
                Function(c) New With
                    {
                        .ID = c.Int(nullable:=False, identity:=True),
                        .Evento = c.String(maxLength:=255),
                        .DocenteID = c.Int(),
                        .ClienteCorporativoID = c.Int(),
                        .FechaReserva = c.DateTime(nullable:=False),
                        .HoraInicio = c.DateTime(nullable:=False),
                        .HoraFinal = c.DateTime(nullable:=False),
                        .IsDeleted = c.Int(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.ClienteCorporativo", Function(t) t.ClienteCorporativoID) _
                .ForeignKey("dbo.Docente", Function(t) t.DocenteID) _
                .Index(Function(t) t.DocenteID) _
                .Index(Function(t) t.ClienteCorporativoID)

        End Sub

        Public Overrides Sub Down()
            DropForeignKey("dbo.EventosEstudio", "DocenteID", "dbo.Docente")
            DropForeignKey("dbo.EventosEstudio", "ClienteCorporativoID", "dbo.ClienteCorporativo")
            DropIndex("dbo.EventosEstudio", New String() {"ClienteCorporativoID"})
            DropIndex("dbo.EventosEstudio", New String() {"DocenteID"})
            DropTable("dbo.EventosEstudio")
        End Sub
    End Class
End Namespace
