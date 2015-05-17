Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class FieldsRecurso
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Recurso", "ClienteCorporativoID", "dbo.ClienteCorporativo")
            DropForeignKey("dbo.Recurso", "CursoID", "dbo.Curso")
            DropForeignKey("dbo.Recurso", "DocenteID", "dbo.Docente")
            DropForeignKey("dbo.Recurso", "EmpresaID", "dbo.Empresa")
            DropIndex("dbo.Recurso", New String() { "EmpresaID" })
            DropIndex("dbo.Recurso", New String() { "CursoID" })
            DropIndex("dbo.Recurso", New String() { "ClienteCorporativoID" })
            DropIndex("dbo.Recurso", New String() { "DocenteID" })
            AlterColumn("dbo.Recurso", "EmpresaID", Function(c) c.Int())
            AlterColumn("dbo.Recurso", "CursoID", Function(c) c.Int())
            AlterColumn("dbo.Recurso", "ClienteCorporativoID", Function(c) c.Int())
            AlterColumn("dbo.Recurso", "DocenteID", Function(c) c.Int())
            CreateIndex("dbo.Recurso", "EmpresaID")
            CreateIndex("dbo.Recurso", "CursoID")
            CreateIndex("dbo.Recurso", "ClienteCorporativoID")
            CreateIndex("dbo.Recurso", "DocenteID")
            AddForeignKey("dbo.Recurso", "ClienteCorporativoID", "dbo.ClienteCorporativo", "ID")
            AddForeignKey("dbo.Recurso", "CursoID", "dbo.Curso", "ID")
            AddForeignKey("dbo.Recurso", "DocenteID", "dbo.Docente", "ID")
            AddForeignKey("dbo.Recurso", "EmpresaID", "dbo.Empresa", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Recurso", "EmpresaID", "dbo.Empresa")
            DropForeignKey("dbo.Recurso", "DocenteID", "dbo.Docente")
            DropForeignKey("dbo.Recurso", "CursoID", "dbo.Curso")
            DropForeignKey("dbo.Recurso", "ClienteCorporativoID", "dbo.ClienteCorporativo")
            DropIndex("dbo.Recurso", New String() { "DocenteID" })
            DropIndex("dbo.Recurso", New String() { "ClienteCorporativoID" })
            DropIndex("dbo.Recurso", New String() { "CursoID" })
            DropIndex("dbo.Recurso", New String() { "EmpresaID" })
            AlterColumn("dbo.Recurso", "DocenteID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Recurso", "ClienteCorporativoID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Recurso", "CursoID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Recurso", "EmpresaID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.Recurso", "DocenteID")
            CreateIndex("dbo.Recurso", "ClienteCorporativoID")
            CreateIndex("dbo.Recurso", "CursoID")
            CreateIndex("dbo.Recurso", "EmpresaID")
            AddForeignKey("dbo.Recurso", "EmpresaID", "dbo.Empresa", "ID", cascadeDelete := True)
            AddForeignKey("dbo.Recurso", "DocenteID", "dbo.Docente", "ID", cascadeDelete := True)
            AddForeignKey("dbo.Recurso", "CursoID", "dbo.Curso", "ID", cascadeDelete := True)
            AddForeignKey("dbo.Recurso", "ClienteCorporativoID", "dbo.ClienteCorporativo", "ID", cascadeDelete := True)
        End Sub
    End Class
End Namespace
