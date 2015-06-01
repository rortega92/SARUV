Imports SaruvMaster
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.Object

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

    Public Property Events As DbSet(Of Events)

    Public Property ClienteCorporativo As DbSet(Of ClienteCorporativo)

    Public Property ModalidadDeCurso As DbSet(Of ModalidadDeCurso)

    Public Property EncargadoDeValidacion As DbSet(Of EncargadoDeValidacion)

    Public Property TipoDeRecurso As DbSet(Of TipoDeRecurso)


    Public Property Departamento As DbSet(Of Departamento)

    Public Property RolPorDepartamento As DbSet(Of RolPorDepartamento)
    Public Property Usuario As DbSet(Of Usuario)
    Public Property RecursoPorUsuario As DbSet(Of RecursoPorUsuario)
    Public Property EventosEstudio As DbSet(of EventosEstudio)

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
        modelBuilder.Entity(Of Departamento).MapToStoredProcedures()
        modelBuilder.Entity(Of RolPorDepartamento).MapToStoredProcedures()
        modelBuilder.Entity(Of Usuario).MapToStoredProcedures()

        modelBuilder.Entity(Of Usuario).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
        modelBuilder.Entity(Of RolPorDepartamento).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
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
        modelBuilder.Entity(Of Departamento).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
    End Sub

    Public Property Recursoes As System.Data.Entity.DbSet(Of Recurso)
End Class
