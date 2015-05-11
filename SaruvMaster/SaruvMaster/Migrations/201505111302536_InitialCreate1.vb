Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialCreate1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Recurso",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(nullable := False, maxLength := 255),
                        .TipoDeRecursoID = c.Int(nullable := False),
                        .ModalidadDeCursoID = c.Int(nullable := False),
                        .EmpresaID = c.Int(nullable := False),
                        .CursoID = c.Int(nullable := False),
                        .ClienteCorporativoID = c.Int(nullable := False),
                        .DocenteID = c.Int(nullable := False),
                        .Duracion = c.Int(nullable := False),
                        .Prioridad = c.String(nullable := False, maxLength := 255),
                        .FechaEntrega = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.ClienteCorporativo", Function(t) t.ClienteCorporativoID, cascadeDelete := True) _
                .ForeignKey("dbo.Curso", Function(t) t.CursoID, cascadeDelete := True) _
                .ForeignKey("dbo.Docente", Function(t) t.DocenteID, cascadeDelete := True) _
                .ForeignKey("dbo.Empresa", Function(t) t.EmpresaID, cascadeDelete := True) _
                .ForeignKey("dbo.ModalidadDeCurso", Function(t) t.ModalidadDeCursoID, cascadeDelete := True) _
                .ForeignKey("dbo.TipoDeRecurso", Function(t) t.TipoDeRecursoID, cascadeDelete := True) _
                .Index(Function(t) t.TipoDeRecursoID) _
                .Index(Function(t) t.ModalidadDeCursoID) _
                .Index(Function(t) t.EmpresaID) _
                .Index(Function(t) t.CursoID) _
                .Index(Function(t) t.ClienteCorporativoID) _
                .Index(Function(t) t.DocenteID)
            
            AddColumn("dbo.TipoDeRecurso", "FechaDeCreacion", Function(c) c.DateTime(nullable := False))
            AlterColumn("dbo.Empresa", "Telefono", Function(c) c.String(nullable := False, maxLength := 11))
            AlterColumn("dbo.EncargadoDeValidacion", "Telefono", Function(c) c.String(nullable := False, maxLength := 11))
            AlterColumn("dbo.EncargadoDeValidacion", "Extensión", Function(c) c.String(maxLength := 6))
            AlterColumn("dbo.Docente", "telefono", Function(c) c.String(nullable := False, maxLength := 11))
            DropColumn("dbo.TipoDeRecurso", "FechaInicio")
            CreateStoredProcedure(
                "dbo.Recurso_Insert",
                Function(p) New With
                    {
                        .Nombre = p.String(maxLength := 255),
                        .TipoDeRecursoID = p.Int(),
                        .ModalidadDeCursoID = p.Int(),
                        .EmpresaID = p.Int(),
                        .CursoID = p.Int(),
                        .ClienteCorporativoID = p.Int(),
                        .DocenteID = p.Int(),
                        .Duracion = p.Int(),
                        .Prioridad = p.String(maxLength := 255),
                        .FechaEntrega = p.DateTime()
                    },
                body :=
                    "INSERT [dbo].[Recurso]([Nombre], [TipoDeRecursoID], [ModalidadDeCursoID], [EmpresaID], [CursoID], [ClienteCorporativoID], [DocenteID], [Duracion], [Prioridad], [FechaEntrega])" & vbCrLf & _
                    "VALUES (@Nombre, @TipoDeRecursoID, @ModalidadDeCursoID, @EmpresaID, @CursoID, @ClienteCorporativoID, @DocenteID, @Duracion, @Prioridad, @FechaEntrega)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @Id int" & vbCrLf & _
                    "SELECT @Id = [Id]" & vbCrLf & _
                    "FROM [dbo].[Recurso]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[Id]" & vbCrLf & _
                    "FROM [dbo].[Recurso] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            )
            
            CreateStoredProcedure(
                "dbo.Recurso_Update",
                Function(p) New With
                    {
                        .Id = p.Int(),
                        .Nombre = p.String(maxLength := 255),
                        .TipoDeRecursoID = p.Int(),
                        .ModalidadDeCursoID = p.Int(),
                        .EmpresaID = p.Int(),
                        .CursoID = p.Int(),
                        .ClienteCorporativoID = p.Int(),
                        .DocenteID = p.Int(),
                        .Duracion = p.Int(),
                        .Prioridad = p.String(maxLength := 255),
                        .FechaEntrega = p.DateTime()
                    },
                body :=
                    "UPDATE [dbo].[Recurso]" & vbCrLf & _
                    "SET [Nombre] = @Nombre, [TipoDeRecursoID] = @TipoDeRecursoID, [ModalidadDeCursoID] = @ModalidadDeCursoID, [EmpresaID] = @EmpresaID, [CursoID] = @CursoID, [ClienteCorporativoID] = @ClienteCorporativoID, [DocenteID] = @DocenteID, [Duracion] = @Duracion, [Prioridad] = @Prioridad, [FechaEntrega] = @FechaEntrega" & vbCrLf & _
                    "WHERE ([Id] = @Id)"
            )
            
            CreateStoredProcedure(
                "dbo.Recurso_Delete",
                Function(p) New With
                    {
                        .Id = p.Int()
                    },
                body :=
                    "DELETE [dbo].[Recurso]" & vbCrLf & _
                    "WHERE ([Id] = @Id)"
            )
            
            AlterStoredProcedure(
                "dbo.Empresa_Insert",
                Function(p) New With
                    {
                        .Nombre = p.String(maxLength := 255),
                        .Direccion = p.String(maxLength := 255),
                        .Telefono = p.String(maxLength := 11),
                        .Ciudad = p.String(maxLength := 255),
                        .Departamento = p.String(maxLength := 255)
                    },
                body :=
                    "INSERT [dbo].[Empresa]([Nombre], [Direccion], [Telefono], [Ciudad], [Departamento])" & vbCrLf & _
                    "VALUES (@Nombre, @Direccion, @Telefono, @Ciudad, @Departamento)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @ID int" & vbCrLf & _
                    "SELECT @ID = [ID]" & vbCrLf & _
                    "FROM [dbo].[Empresa]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[ID]" & vbCrLf & _
                    "FROM [dbo].[Empresa] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            )
            
            AlterStoredProcedure(
                "dbo.Empresa_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombre = p.String(maxLength := 255),
                        .Direccion = p.String(maxLength := 255),
                        .Telefono = p.String(maxLength := 11),
                        .Ciudad = p.String(maxLength := 255),
                        .Departamento = p.String(maxLength := 255)
                    },
                body :=
                    "UPDATE [dbo].[Empresa]" & vbCrLf & _
                    "SET [Nombre] = @Nombre, [Direccion] = @Direccion, [Telefono] = @Telefono, [Ciudad] = @Ciudad, [Departamento] = @Departamento" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            AlterStoredProcedure(
                "dbo.EncargadoDeValidacion_Insert",
                Function(p) New With
                    {
                        .Nombre = p.String(maxLength := 255),
                        .FacultadID = p.Int(),
                        .Telefono = p.String(maxLength := 11),
                        .Extensión = p.String(maxLength := 6),
                        .correoElectronico = p.String()
                    },
                body :=
                    "INSERT [dbo].[EncargadoDeValidacion]([Nombre], [FacultadID], [Telefono], [Extensión], [correoElectronico])" & vbCrLf & _
                    "VALUES (@Nombre, @FacultadID, @Telefono, @Extensión, @correoElectronico)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @ID int" & vbCrLf & _
                    "SELECT @ID = [ID]" & vbCrLf & _
                    "FROM [dbo].[EncargadoDeValidacion]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[ID]" & vbCrLf & _
                    "FROM [dbo].[EncargadoDeValidacion] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            )
            
            AlterStoredProcedure(
                "dbo.EncargadoDeValidacion_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombre = p.String(maxLength := 255),
                        .FacultadID = p.Int(),
                        .Telefono = p.String(maxLength := 11),
                        .Extensión = p.String(maxLength := 6),
                        .correoElectronico = p.String()
                    },
                body :=
                    "UPDATE [dbo].[EncargadoDeValidacion]" & vbCrLf & _
                    "SET [Nombre] = @Nombre, [FacultadID] = @FacultadID, [Telefono] = @Telefono, [Extensión] = @Extensión, [correoElectronico] = @correoElectronico" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            AlterStoredProcedure(
                "dbo.Docente_Insert",
                Function(p) New With
                    {
                        .Nombres = p.String(maxLength := 255),
                        .Apellidos = p.String(maxLength := 255),
                        .NumeroTalentoHumano = p.String(maxLength := 5),
                        .correoElectronico = p.String(),
                        .telefono = p.String(maxLength := 11),
                        .AreaDeConocimientoID = p.Int(),
                        .FacultadID = p.Int()
                    },
                body :=
                    "INSERT [dbo].[Docente]([Nombres], [Apellidos], [NumeroTalentoHumano], [correoElectronico], [telefono], [AreaDeConocimientoID], [FacultadID])" & vbCrLf & _
                    "VALUES (@Nombres, @Apellidos, @NumeroTalentoHumano, @correoElectronico, @telefono, @AreaDeConocimientoID, @FacultadID)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @ID int" & vbCrLf & _
                    "SELECT @ID = [ID]" & vbCrLf & _
                    "FROM [dbo].[Docente]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[ID]" & vbCrLf & _
                    "FROM [dbo].[Docente] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            )
            
            AlterStoredProcedure(
                "dbo.Docente_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombres = p.String(maxLength := 255),
                        .Apellidos = p.String(maxLength := 255),
                        .NumeroTalentoHumano = p.String(maxLength := 5),
                        .correoElectronico = p.String(),
                        .telefono = p.String(maxLength := 11),
                        .AreaDeConocimientoID = p.Int(),
                        .FacultadID = p.Int()
                    },
                body :=
                    "UPDATE [dbo].[Docente]" & vbCrLf & _
                    "SET [Nombres] = @Nombres, [Apellidos] = @Apellidos, [NumeroTalentoHumano] = @NumeroTalentoHumano, [correoElectronico] = @correoElectronico, [telefono] = @telefono, [AreaDeConocimientoID] = @AreaDeConocimientoID, [FacultadID] = @FacultadID" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            AlterStoredProcedure(
                "dbo.TipoDeRecurso_Insert",
                Function(p) New With
                    {
                        .Nombre = p.String(maxLength := 255),
                        .CodigoRecurso = p.String(),
                        .FechaDeCreacion = p.DateTime()
                    },
                body :=
                    "INSERT [dbo].[TipoDeRecurso]([Nombre], [CodigoRecurso], [FechaDeCreacion])" & vbCrLf & _
                    "VALUES (@Nombre, @CodigoRecurso, @FechaDeCreacion)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @Id int" & vbCrLf & _
                    "SELECT @Id = [Id]" & vbCrLf & _
                    "FROM [dbo].[TipoDeRecurso]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[Id]" & vbCrLf & _
                    "FROM [dbo].[TipoDeRecurso] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            )
            
            AlterStoredProcedure(
                "dbo.TipoDeRecurso_Update",
                Function(p) New With
                    {
                        .Id = p.Int(),
                        .Nombre = p.String(maxLength := 255),
                        .CodigoRecurso = p.String(),
                        .FechaDeCreacion = p.DateTime()
                    },
                body :=
                    "UPDATE [dbo].[TipoDeRecurso]" & vbCrLf & _
                    "SET [Nombre] = @Nombre, [CodigoRecurso] = @CodigoRecurso, [FechaDeCreacion] = @FechaDeCreacion" & vbCrLf & _
                    "WHERE ([Id] = @Id)"
            )
            
        End Sub
        
        Public Overrides Sub Down()
            DropStoredProcedure("dbo.Recurso_Delete")
            DropStoredProcedure("dbo.Recurso_Update")
            DropStoredProcedure("dbo.Recurso_Insert")
            AddColumn("dbo.TipoDeRecurso", "FechaInicio", Function(c) c.DateTime(nullable := False))
            DropForeignKey("dbo.Recurso", "TipoDeRecursoID", "dbo.TipoDeRecurso")
            DropForeignKey("dbo.Recurso", "ModalidadDeCursoID", "dbo.ModalidadDeCurso")
            DropForeignKey("dbo.Recurso", "EmpresaID", "dbo.Empresa")
            DropForeignKey("dbo.Recurso", "DocenteID", "dbo.Docente")
            DropForeignKey("dbo.Recurso", "CursoID", "dbo.Curso")
            DropForeignKey("dbo.Recurso", "ClienteCorporativoID", "dbo.ClienteCorporativo")
            DropIndex("dbo.Recurso", New String() { "DocenteID" })
            DropIndex("dbo.Recurso", New String() { "ClienteCorporativoID" })
            DropIndex("dbo.Recurso", New String() { "CursoID" })
            DropIndex("dbo.Recurso", New String() { "EmpresaID" })
            DropIndex("dbo.Recurso", New String() { "ModalidadDeCursoID" })
            DropIndex("dbo.Recurso", New String() { "TipoDeRecursoID" })
            AlterColumn("dbo.Docente", "telefono", Function(c) c.String(maxLength := 255))
            AlterColumn("dbo.EncargadoDeValidacion", "Extensión", Function(c) c.String(maxLength := 4))
            AlterColumn("dbo.EncargadoDeValidacion", "Telefono", Function(c) c.String(nullable := False, maxLength := 255))
            AlterColumn("dbo.Empresa", "Telefono", Function(c) c.String(nullable := False, maxLength := 255))
            DropColumn("dbo.TipoDeRecurso", "FechaDeCreacion")
            DropTable("dbo.Recurso")
            Throw New NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.")
        End Sub
    End Class
End Namespace
