Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SaruvMaster.Controllers

<TestClass()>
Public Class ClienteCorporativoControllerTest

    <TestMethod()>
    Public Sub Index()
        ' Arrange
        Dim controller As New ClienteCorporativoController()
        ' Act
        Dim result As ActionResult = DirectCast(controller.Index(), ActionResult)
        ' Assert
        Assert.IsNotNull(result)
    End Sub

    <TestMethod()>
    Public Sub Details()
        ' Arrange
        Dim controller As New ClienteCorporativoController()
        ' Act
        Dim result As ActionResult = DirectCast(controller.Details(1), ActionResult)
        ' Assert
        Assert.IsNotNull(result)
    End Sub

    <TestMethod()>
    Public Sub Create()
        ' Arrange
        Dim controller As New ClienteCorporativoController()
        ' Act
        Dim result As ActionResult = DirectCast(controller.Create(), ActionResult)
        ' Assert
        Assert.IsNotNull(result)
    End Sub

    <TestMethod()>
    Public Sub Edit()
        ' Arrange
        Dim controller As New ClienteCorporativoController()
        ' Act
        Dim result As ActionResult = DirectCast(controller.Edit(1), ActionResult)
        ' Assert
        Assert.IsNotNull(result)
    End Sub

    <TestMethod()>
    Public Sub Delete()
        ' Arrange
        Dim controller As New ClienteCorporativoController()
        ' Act
        Dim result As ActionResult = DirectCast(controller.Delete(1), ActionResult)
        ' Assert
        Assert.IsNotNull(result)
    End Sub

End Class
