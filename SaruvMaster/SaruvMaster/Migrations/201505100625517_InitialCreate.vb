Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialCreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.AreaDeConocimiento",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(nullable := False, maxLength := 255),
                        .FechaCreacion = c.DateTime(nullable := False),
                        .FechaModificacion = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.ClienteCorporativo",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombres = c.String(nullable := False, maxLength := 255),
                        .Apellidos = c.String(nullable := False, maxLength := 255),
                        .NumeroIdentidad = c.String(nullable := False, maxLength := 15),
                        .CorreoElectronico = c.String(nullable := False),
                        .Telefono = c.String(nullable := False, maxLength := 255),
                        .EmpresaID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Empresa", Function(t) t.EmpresaID, cascadeDelete := True) _
                .Index(Function(t) t.EmpresaID)
            
            CreateTable(
                "dbo.Empresa",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(nullable := False, maxLength := 255),
                        .Direccion = c.String(nullable := False, maxLength := 255),
                        .Telefono = c.String(nullable := False, maxLength := 255),
                        .Ciudad = c.String(nullable := False, maxLength := 255),
                        .Departamento = c.String(nullable := False, maxLength := 255)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Curso",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombres = c.String(nullable := False, maxLength := 255),
                        .AreaDeConocimientoID = c.Int(nullable := False),
                        .ModalidadDeCursoID = c.Int(nullable := False),
                        .EncargadoDeValidacionID = c.Int(nullable := False),
                        .FechaInicio = c.DateTime(nullable := False),
                        .FechaFinal = c.DateTime(nullable := False),
                        .Periodo = c.Int(nullable := False),
                        .FechaCreacion = c.DateTime(nullable := False),
                        .FechaModificacion = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.AreaDeConocimiento", Function(t) t.AreaDeConocimientoID, cascadeDelete := True) _
                .ForeignKey("dbo.EncargadoDeValidacion", Function(t) t.EncargadoDeValidacionID, cascadeDelete := True) _
                .ForeignKey("dbo.ModalidadDeCurso", Function(t) t.ModalidadDeCursoID, cascadeDelete := True) _
                .Index(Function(t) t.AreaDeConocimientoID) _
                .Index(Function(t) t.ModalidadDeCursoID) _
                .Index(Function(t) t.EncargadoDeValidacionID)
            
            CreateTable(
                "dbo.EncargadoDeValidacion",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(nullable := False, maxLength := 255),
                        .FacultadID = c.Int(nullable := False),
                        .Telefono = c.String(nullable := False, maxLength := 255),
                        .Extensión = c.String(maxLength := 4),
                        .correoElectronico = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Facultad", Function(t) t.FacultadID, cascadeDelete := True) _
                .Index(Function(t) t.FacultadID)
            
            CreateTable(
                "dbo.Facultad",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(nullable := False, maxLength := 255),
                        .FechaCreacion = c.DateTime(nullable := False),
                        .FechaModificacion = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.ModalidadDeCurso",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(nullable := False, maxLength := 255),
                        .Duracion = c.Int(nullable := False),
                        .FechaCreacion = c.DateTime(nullable := False),
                        .FechaModificacion = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Docente",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombres = c.String(nullable := False, maxLength := 255),
                        .Apellidos = c.String(nullable := False, maxLength := 255),
                        .NumeroTalentoHumano = c.String(nullable := False, maxLength := 5),
                        .correoElectronico = c.String(nullable := False),
                        .telefono = c.String(maxLength := 255),
                        .AreaDeConocimientoID = c.Int(nullable := False),
                        .FacultadID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.AreaDeConocimiento", Function(t) t.AreaDeConocimientoID, cascadeDelete := True) _
                .ForeignKey("dbo.Facultad", Function(t) t.FacultadID, cascadeDelete := True) _
                .Index(Function(t) t.AreaDeConocimientoID) _
                .Index(Function(t) t.FacultadID)
            
            CreateStoredProcedure(
                "dbo.AreaDeConocimiento_Insert",
                Function(p) New With
                    {
                        .Nombre = p.String(maxLength := 255),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "INSERT [dbo].[AreaDeConocimiento]([Nombre], [FechaCreacion], [FechaModificacion])" & vbCrLf & _
                    "VALUES (@Nombre, @FechaCreacion, @FechaModificacion)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @ID int" & vbCrLf & _
                    "SELECT @ID = [ID]" & vbCrLf & _
                    "FROM [dbo].[AreaDeConocimiento]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[ID]" & vbCrLf & _
                    "FROM [dbo].[AreaDeConocimiento] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            )
            
            CreateStoredProcedure(
                "dbo.AreaDeConocimiento_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombre = p.String(maxLength := 255),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "UPDATE [dbo].[AreaDeConocimiento]" & vbCrLf & _
                    "SET [Nombre] = @Nombre, [FechaCreacion] = @FechaCreacion, [FechaModificacion] = @FechaModificacion" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.AreaDeConocimiento_Delete",
                Function(p) New With
                    {
                        .ID = p.Int()
                    },
                body :=
                    "DELETE [dbo].[AreaDeConocimiento]" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.ClienteCorporativo_Insert",
                Function(p) New With
                    {
                        .Nombres = p.String(maxLength := 255),
                        .Apellidos = p.String(maxLength := 255),
                        .NumeroIdentidad = p.String(maxLength := 15),
                        .CorreoElectronico = p.String(),
                        .Telefono = p.String(maxLength := 255),
                        .EmpresaID = p.Int()
                    },
                body :=
                    "INSERT [dbo].[ClienteCorporativo]([Nombres], [Apellidos], [NumeroIdentidad], [CorreoElectronico], [Telefono], [EmpresaID])" & vbCrLf & _
                    "VALUES (@Nombres, @Apellidos, @NumeroIdentidad, @CorreoElectronico, @Telefono, @EmpresaID)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @ID int" & vbCrLf & _
                    "SELECT @ID = [ID]" & vbCrLf & _
                    "FROM [dbo].[ClienteCorporativo]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[ID]" & vbCrLf & _
                    "FROM [dbo].[ClienteCorporativo] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            )
            
            CreateStoredProcedure(
                "dbo.ClienteCorporativo_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombres = p.String(maxLength := 255),
                        .Apellidos = p.String(maxLength := 255),
                        .NumeroIdentidad = p.String(maxLength := 15),
                        .CorreoElectronico = p.String(),
                        .Telefono = p.String(maxLength := 255),
                        .EmpresaID = p.Int()
                    },
                body :=
                    "UPDATE [dbo].[ClienteCorporativo]" & vbCrLf & _
                    "SET [Nombres] = @Nombres, [Apellidos] = @Apellidos, [NumeroIdentidad] = @NumeroIdentidad, [CorreoElectronico] = @CorreoElectronico, [Telefono] = @Telefono, [EmpresaID] = @EmpresaID" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.ClienteCorporativo_Delete",
                Function(p) New With
                    {
                        .ID = p.Int()
                    },
                body :=
                    "DELETE [dbo].[ClienteCorporativo]" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.Empresa_Insert",
                Function(p) New With
                    {
                        .Nombre = p.String(maxLength := 255),
                        .Direccion = p.String(maxLength := 255),
                        .Telefono = p.String(maxLength := 255),
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
            
            CreateStoredProcedure(
                "dbo.Empresa_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombre = p.String(maxLength := 255),
                        .Direccion = p.String(maxLength := 255),
                        .Telefono = p.String(maxLength := 255),
                        .Ciudad = p.String(maxLength := 255),
                        .Departamento = p.String(maxLength := 255)
                    },
                body :=
                    "UPDATE [dbo].[Empresa]" & vbCrLf & _
                    "SET [Nombre] = @Nombre, [Direccion] = @Direccion, [Telefono] = @Telefono, [Ciudad] = @Ciudad, [Departamento] = @Departamento" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.Empresa_Delete",
                Function(p) New With
                    {
                        .ID = p.Int()
                    },
                body :=
                    "DELETE [dbo].[Empresa]" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.Curso_Insert",
                Function(p) New With
                    {
                        .Nombres = p.String(maxLength := 255),
                        .AreaDeConocimientoID = p.Int(),
                        .ModalidadDeCursoID = p.Int(),
                        .EncargadoDeValidacionID = p.Int(),
                        .FechaInicio = p.DateTime(),
                        .FechaFinal = p.DateTime(),
                        .Periodo = p.Int(),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "INSERT [dbo].[Curso]([Nombres], [AreaDeConocimientoID], [ModalidadDeCursoID], [EncargadoDeValidacionID], [FechaInicio], [FechaFinal], [Periodo], [FechaCreacion], [FechaModificacion])" & vbCrLf & _
                    "VALUES (@Nombres, @AreaDeConocimientoID, @ModalidadDeCursoID, @EncargadoDeValidacionID, @FechaInicio, @FechaFinal, @Periodo, @FechaCreacion, @FechaModificacion)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @ID int" & vbCrLf & _
                    "SELECT @ID = [ID]" & vbCrLf & _
                    "FROM [dbo].[Curso]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[ID]" & vbCrLf & _
                    "FROM [dbo].[Curso] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            )
            
            CreateStoredProcedure(
                "dbo.Curso_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombres = p.String(maxLength := 255),
                        .AreaDeConocimientoID = p.Int(),
                        .ModalidadDeCursoID = p.Int(),
                        .EncargadoDeValidacionID = p.Int(),
                        .FechaInicio = p.DateTime(),
                        .FechaFinal = p.DateTime(),
                        .Periodo = p.Int(),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "UPDATE [dbo].[Curso]" & vbCrLf & _
                    "SET [Nombres] = @Nombres, [AreaDeConocimientoID] = @AreaDeConocimientoID, [ModalidadDeCursoID] = @ModalidadDeCursoID, [EncargadoDeValidacionID] = @EncargadoDeValidacionID, [FechaInicio] = @FechaInicio, [FechaFinal] = @FechaFinal, [Periodo] = @Periodo, [FechaCreacion] = @FechaCreacion, [FechaModificacion] = @FechaModificacion" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.Curso_Delete",
                Function(p) New With
                    {
                        .ID = p.Int()
                    },
                body :=
                    "DELETE [dbo].[Curso]" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.EncargadoDeValidacion_Insert",
                Function(p) New With
                    {
                        .Nombre = p.String(maxLength := 255),
                        .FacultadID = p.Int(),
                        .Telefono = p.String(maxLength := 255),
                        .Extensión = p.String(maxLength := 4),
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
            
            CreateStoredProcedure(
                "dbo.EncargadoDeValidacion_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombre = p.String(maxLength := 255),
                        .FacultadID = p.Int(),
                        .Telefono = p.String(maxLength := 255),
                        .Extensión = p.String(maxLength := 4),
                        .correoElectronico = p.String()
                    },
                body :=
                    "UPDATE [dbo].[EncargadoDeValidacion]" & vbCrLf & _
                    "SET [Nombre] = @Nombre, [FacultadID] = @FacultadID, [Telefono] = @Telefono, [Extensión] = @Extensión, [correoElectronico] = @correoElectronico" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.EncargadoDeValidacion_Delete",
                Function(p) New With
                    {
                        .ID = p.Int()
                    },
                body :=
                    "DELETE [dbo].[EncargadoDeValidacion]" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.Facultad_Insert",
                Function(p) New With
                    {
                        .Nombre = p.String(maxLength := 255),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "INSERT [dbo].[Facultad]([Nombre], [FechaCreacion], [FechaModificacion])" & vbCrLf & _
                    "VALUES (@Nombre, @FechaCreacion, @FechaModificacion)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @ID int" & vbCrLf & _
                    "SELECT @ID = [ID]" & vbCrLf & _
                    "FROM [dbo].[Facultad]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[ID]" & vbCrLf & _
                    "FROM [dbo].[Facultad] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            )
            
            CreateStoredProcedure(
                "dbo.Facultad_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombre = p.String(maxLength := 255),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "UPDATE [dbo].[Facultad]" & vbCrLf & _
                    "SET [Nombre] = @Nombre, [FechaCreacion] = @FechaCreacion, [FechaModificacion] = @FechaModificacion" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.Facultad_Delete",
                Function(p) New With
                    {
                        .ID = p.Int()
                    },
                body :=
                    "DELETE [dbo].[Facultad]" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.ModalidadDeCurso_Insert",
                Function(p) New With
                    {
                        .Nombre = p.String(maxLength := 255),
                        .Duracion = p.Int(),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "INSERT [dbo].[ModalidadDeCurso]([Nombre], [Duracion], [FechaCreacion], [FechaModificacion])" & vbCrLf & _
                    "VALUES (@Nombre, @Duracion, @FechaCreacion, @FechaModificacion)" & vbCrLf & _
                    "" & vbCrLf & _
                    "DECLARE @ID int" & vbCrLf & _
                    "SELECT @ID = [ID]" & vbCrLf & _
                    "FROM [dbo].[ModalidadDeCurso]" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()" & vbCrLf & _
                    "" & vbCrLf & _
                    "SELECT t0.[ID]" & vbCrLf & _
                    "FROM [dbo].[ModalidadDeCurso] AS t0" & vbCrLf & _
                    "WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            )
            
            CreateStoredProcedure(
                "dbo.ModalidadDeCurso_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombre = p.String(maxLength := 255),
                        .Duracion = p.Int(),
                        .FechaCreacion = p.DateTime(),
                        .FechaModificacion = p.DateTime()
                    },
                body :=
                    "UPDATE [dbo].[ModalidadDeCurso]" & vbCrLf & _
                    "SET [Nombre] = @Nombre, [Duracion] = @Duracion, [FechaCreacion] = @FechaCreacion, [FechaModificacion] = @FechaModificacion" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.ModalidadDeCurso_Delete",
                Function(p) New With
                    {
                        .ID = p.Int()
                    },
                body :=
                    "DELETE [dbo].[ModalidadDeCurso]" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.Docente_Insert",
                Function(p) New With
                    {
                        .Nombres = p.String(maxLength := 255),
                        .Apellidos = p.String(maxLength := 255),
                        .NumeroTalentoHumano = p.String(maxLength := 5),
                        .correoElectronico = p.String(),
                        .telefono = p.String(maxLength := 255),
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
            
            CreateStoredProcedure(
                "dbo.Docente_Update",
                Function(p) New With
                    {
                        .ID = p.Int(),
                        .Nombres = p.String(maxLength := 255),
                        .Apellidos = p.String(maxLength := 255),
                        .NumeroTalentoHumano = p.String(maxLength := 5),
                        .correoElectronico = p.String(),
                        .telefono = p.String(maxLength := 255),
                        .AreaDeConocimientoID = p.Int(),
                        .FacultadID = p.Int()
                    },
                body :=
                    "UPDATE [dbo].[Docente]" & vbCrLf & _
                    "SET [Nombres] = @Nombres, [Apellidos] = @Apellidos, [NumeroTalentoHumano] = @NumeroTalentoHumano, [correoElectronico] = @correoElectronico, [telefono] = @telefono, [AreaDeConocimientoID] = @AreaDeConocimientoID, [FacultadID] = @FacultadID" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
            CreateStoredProcedure(
                "dbo.Docente_Delete",
                Function(p) New With
                    {
                        .ID = p.Int()
                    },
                body :=
                    "DELETE [dbo].[Docente]" & vbCrLf & _
                    "WHERE ([ID] = @ID)"
            )
            
        End Sub
        
        Public Overrides Sub Down()
            DropStoredProcedure("dbo.Docente_Delete")
            DropStoredProcedure("dbo.Docente_Update")
            DropStoredProcedure("dbo.Docente_Insert")
            DropStoredProcedure("dbo.ModalidadDeCurso_Delete")
            DropStoredProcedure("dbo.ModalidadDeCurso_Update")
            DropStoredProcedure("dbo.ModalidadDeCurso_Insert")
            DropStoredProcedure("dbo.Facultad_Delete")
            DropStoredProcedure("dbo.Facultad_Update")
            DropStoredProcedure("dbo.Facultad_Insert")
            DropStoredProcedure("dbo.EncargadoDeValidacion_Delete")
            DropStoredProcedure("dbo.EncargadoDeValidacion_Update")
            DropStoredProcedure("dbo.EncargadoDeValidacion_Insert")
            DropStoredProcedure("dbo.Curso_Delete")
            DropStoredProcedure("dbo.Curso_Update")
            DropStoredProcedure("dbo.Curso_Insert")
            DropStoredProcedure("dbo.Empresa_Delete")
            DropStoredProcedure("dbo.Empresa_Update")
            DropStoredProcedure("dbo.Empresa_Insert")
            DropStoredProcedure("dbo.ClienteCorporativo_Delete")
            DropStoredProcedure("dbo.ClienteCorporativo_Update")
            DropStoredProcedure("dbo.ClienteCorporativo_Insert")
            DropStoredProcedure("dbo.AreaDeConocimiento_Delete")
            DropStoredProcedure("dbo.AreaDeConocimiento_Update")
            DropStoredProcedure("dbo.AreaDeConocimiento_Insert")
            DropForeignKey("dbo.Docente", "FacultadID", "dbo.Facultad")
            DropForeignKey("dbo.Docente", "AreaDeConocimientoID", "dbo.AreaDeConocimiento")
            DropForeignKey("dbo.Curso", "ModalidadDeCursoID", "dbo.ModalidadDeCurso")
            DropForeignKey("dbo.Curso", "EncargadoDeValidacionID", "dbo.EncargadoDeValidacion")
            DropForeignKey("dbo.EncargadoDeValidacion", "FacultadID", "dbo.Facultad")
            DropForeignKey("dbo.Curso", "AreaDeConocimientoID", "dbo.AreaDeConocimiento")
            DropForeignKey("dbo.ClienteCorporativo", "EmpresaID", "dbo.Empresa")
            DropIndex("dbo.Docente", New String() { "FacultadID" })
            DropIndex("dbo.Docente", New String() { "AreaDeConocimientoID" })
            DropIndex("dbo.EncargadoDeValidacion", New String() { "FacultadID" })
            DropIndex("dbo.Curso", New String() { "EncargadoDeValidacionID" })
            DropIndex("dbo.Curso", New String() { "ModalidadDeCursoID" })
            DropIndex("dbo.Curso", New String() { "AreaDeConocimientoID" })
            DropIndex("dbo.ClienteCorporativo", New String() { "EmpresaID" })
            DropTable("dbo.Docente")
            DropTable("dbo.ModalidadDeCurso")
            DropTable("dbo.Facultad")
            DropTable("dbo.EncargadoDeValidacion")
            DropTable("dbo.Curso")
            DropTable("dbo.Empresa")
            DropTable("dbo.ClienteCorporativo")
            DropTable("dbo.AreaDeConocimiento")
        End Sub
    End Class
End Namespace
