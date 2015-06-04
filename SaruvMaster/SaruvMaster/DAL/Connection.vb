Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class Connection
    Inherits IdentityDbContext

    Public Sub New()
        MyBase.New("Context")
    End Sub

    Private Shared _mappingCache As New Dictionary(Of Type, Core.Metadata.Edm.EntitySetBase)()

    Public Property Departamento As DbSet(Of Departamento)



    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        modelBuilder.Conventions.Remove(Of OneToManyCascadeDeleteConvention)()
        modelBuilder.Conventions.Remove(Of ManyToManyCascadeDeleteConvention)()
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()

        modelBuilder.Entity(Of Departamento).MapToStoredProcedures()

        modelBuilder.Entity(Of Departamento).Map(Function(m) m.Requires("IsDeleted").HasValue(0)).Ignore(Function(m) m.IsDeleted)
    End Sub

    Public Overrides Function Savechanges() As Integer

        Dim changed = ChangeTracker.Entries()
        For Each item In changed.Where(Function(m) m.State.Equals(EntityState.Deleted))
            SoftDelete(item, "")
        Next

        Return MyBase.SaveChanges()
    End Function
    Public Function deshabilitar(value As String) As Integer
        Dim changed = ChangeTracker.Entries()
        For Each item In changed.Where(Function(m) m.State.Equals(EntityState.Deleted))
            SoftDelete(item, value)
        Next
        Return MyBase.SaveChanges()
    End Function
    Private Sub SoftDelete(entry As Infrastructure.DbEntityEntry, value As String)

        Dim entryEntityType As Type = entry.Entity.[GetType]()
        Dim tableName As String = GetTableName(entryEntityType)
        Dim primaryKeyName As String = GetPrimaryKeyName(entryEntityType)

        Dim sql As String
        If IsNothing(value) Then
            sql = String.Format("UPDATE {0} SET IsDeleted = 1 WHERE {1} = @id", tableName, primaryKeyName)
        Else
            sql = String.Format("UPDATE {0} SET IsDeleted = 2 WHERE {1} = @id", tableName, primaryKeyName)
        End If


        Database.ExecuteSqlCommand(sql, New SqlClient.SqlParameter("@id", entry.OriginalValues(primaryKeyName)))

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
