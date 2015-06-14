Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class Connection
    Inherits IdentityDbContext

    Public Sub New()
        MyBase.New("Context")
    End Sub

    Private Shared _mappingCache As New Dictionary(Of Type, Core.Metadata.Edm.EntitySetBase)()

    Public Property AreaDeConocimiento As DbSet(Of AreaDeConocimiento)

    Public Property Curso As DbSet(Of Curso)

    Public Property Facultad As DbSet(Of Facultad)

    Public Property Docente As DbSet(Of Docente)

    Public Property Empresa As DbSet(Of Empresa)

    Public Property ClienteCorporativo As DbSet(Of ClienteCorporativo)

    Public Property ModalidadDeCurso As DbSet(Of ModalidadDeCurso)

    Public Property EncargadoDeValidacion As DbSet(Of EncargadoDeValidacion)

    Public Property TipoDeRecurso As DbSet(Of TipoDeRecurso)

    Public Property RecursoPorUsuario As DbSet(Of RecursoPorUsuario)

    Public Property EventosEstudio As DbSet(Of EventosEstudio)

    Public Property EventosGenerales As DbSet(Of EventosGenerales)

    Public Property Recurso As System.Data.Entity.DbSet(Of Recurso)

    Public Property Departamento As DbSet(Of Departamento)



    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        modelBuilder.Conventions.Remove(Of OneToManyCascadeDeleteConvention)()
        modelBuilder.Conventions.Remove(Of ManyToManyCascadeDeleteConvention)()
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()

        modelBuilder.Entity(Of Departamento).MapToStoredProcedures()
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

        modelBuilder.Entity(Of Departamento).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
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

    Public Overrides Function Savechanges() As Integer

        Dim changed = ChangeTracker.Entries()
        For Each item In changed.Where(Function(m) m.State.Equals(EntityState.Deleted) Or m.State.Equals(EntityState.Modified))
            If item.State.Equals(EntityState.Deleted) Then
                SoftDelete(item, "")
            Else
                If item.State.Equals(EntityState.Modified) Then
                    Dim number = MyBase.SaveChanges()
                    If number.CompareTo(1) Then
                        Return MyBase.SaveChanges()

                    Else
                        SoftDelete(item, "Update")
                    End If
                End If
            End If

        Next


        Return MyBase.SaveChanges()
    End Function

    'Public Function UpdateDate(entry As Infrastructure.DbEntityEntry) As Integer

    '    SoftDelete(entry, "UpdateDate")

    '    Return MyBase.SaveChanges()
    'End Function

    Public Function deshabilitar(value As String) As Integer
        Dim changed = ChangeTracker.Entries()
        For Each item In changed.Where(Function(m) m.State.Equals(EntityState.Deleted) Or m.State.Equals(EntityState.Modified))
            If item.State = EntityState.Modified Then
                SoftDelete(item, value)
            End If

        Next
        Return MyBase.SaveChanges()
    End Function

    Private Sub SoftDelete(entry As Infrastructure.DbEntityEntry, value As String)

        Dim entryEntityType As Type = entry.Entity.[GetType]()
        Dim tableName As String = GetTableName(entryEntityType)
        Dim primaryKeyName As String = GetPrimaryKeyName(entryEntityType)

        Dim sql As String
        If value.Equals(String.Empty) Then
            sql = String.Format("UPDATE {0} SET IsDeleted = 1 WHERE {1} = @id", tableName, primaryKeyName)


        ElseIf value.Equals("Update")
            Debug.WriteLine("Entro a update")
            sql = String.Format("UPDATE {0} SET FechaModificacion = GetDate() WHERE {1} = @id", tableName, primaryKeyName)
            'sql = String.Format("UPDATE {0} SET IsDeleted = 2 WHERE {1} = @id", tableName, primaryKeyName)
        End If


        Database.ExecuteSqlCommand(Sql, New SqlClient.SqlParameter("@id", entry.OriginalValues(primaryKeyName)))

        ' prevent hard delete     

        entry.State = EntityState.Detached
    End Sub


    Private Function GetTableName(type As Type) As String
        Dim es As Core.Metadata.Edm.EntitySetBase = GetEntitySet(type)

        Return String.Format("[{0}].[{1}]", es.MetadataProperties("Schema").Value, es.MetadataProperties("Table").Value)
    End Function

    Private Function GetPrimaryKeyName(type As Type) As String
        Dim es As Core.Metadata.Edm.EntitySetBase = GetEntitySet(type)

        Return es.ElementType.KeyMembers(0).Name
    End Function

    Private Function GetEntitySet(type As Type) As Core.Metadata.Edm.EntitySetBase
        If Not _mappingCache.ContainsKey(type) Then
            Dim octx As Core.Objects.ObjectContext = DirectCast(Me, Infrastructure.IObjectContextAdapter).ObjectContext

            Dim typeName As String = Core.Objects.ObjectContext.GetObjectType(type).Name

            Dim es = octx.MetadataWorkspace.GetItemCollection(Core.Metadata.Edm.DataSpace.SSpace).GetItems(Of Core.Metadata.Edm.EntityContainer)().SelectMany(Function(c) c.BaseEntitySets.Where(Function(e) e.Name = typeName)).FirstOrDefault()

            If es Is Nothing Then
                Throw New ArgumentException("Entity type not found in GetTableName", typeName)
            End If

            _mappingCache.Add(type, es)
        End If

        Return _mappingCache(type)
    End Function
End Class
