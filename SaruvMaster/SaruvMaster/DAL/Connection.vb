Imports SaruvMaster
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Public Class Connection
    Inherits DbContext

    Public Sub New()
        MyBase.New("Context")

    End Sub
    Public Property AreaDeConocimiento As DbSet(Of AreaDeConocimiento)
    Public Property Facultad As DbSet(Of Facultad)

    Public Property Docente As DbSet(Of Docente)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
    End Sub
End Class
