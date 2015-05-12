﻿Imports SaruvMaster
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Public Class Connection
    Inherits DbContext

    Public Sub New()
        MyBase.New("Context")

    End Sub
    Public Property AreaDeConocimiento As DbSet(Of AreaDeConocimiento)

    Public Property Curso As DbSet(Of Curso)

    Public Property Facultad As DbSet(Of Facultad)

    Public Property Docente As DbSet(Of Docente)

    Public Property Empresa As DbSet(Of Empresa)

    Public Property ClienteCorporativo As DbSet(Of ClienteCorporativo)

    Public Property ModalidadDeCurso As DbSet(Of ModalidadDeCurso)

    Public Property EncargadoDeValidacion As DbSet(Of EncargadoDeValidacion)

    Public Property TipoDeRecurso As DbSet(Of TipoDeRecurso)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
        modelBuilder.Entity(Of Facultad).MapToStoredProcedures()
        modelBuilder.Entity(Of AreaDeConocimiento).MapToStoredProcedures()
        modelBuilder.Entity(Of Empresa).MapToStoredProcedures()
        modelBuilder.Entity(Of EncargadoDeValidacion).MapToStoredProcedures()
        modelBuilder.Entity(Of ClienteCorporativo).MapToStoredProcedures()
        modelBuilder.Entity(Of Docente).MapToStoredProcedures()
        modelBuilder.Entity(Of ModalidadDeCurso).MapToStoredProcedures()
        modelBuilder.Entity(Of Curso).MapToStoredProcedures()
        modelBuilder.Entity(Of TipoDeRecurso).MapToStoredProcedures()
        modelBuilder.Entity(Of Recurso).MapToStoredProcedures()
        modelBuilder.Entity(Of Facultad).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
        modelBuilder.Entity(Of AreaDeConocimiento).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
        modelBuilder.Entity(Of Empresa).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
        modelBuilder.Entity(Of EncargadoDeValidacion).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
        modelBuilder.Entity(Of ClienteCorporativo).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
        modelBuilder.Entity(Of Docente).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
        modelBuilder.Entity(Of ModalidadDeCurso).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
        modelBuilder.Entity(Of Curso).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
        modelBuilder.Entity(Of TipoDeRecurso).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
        modelBuilder.Entity(Of Recurso).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
    End Sub
    Public Property Recursoes As System.Data.Entity.DbSet(Of Recurso)
End Class
