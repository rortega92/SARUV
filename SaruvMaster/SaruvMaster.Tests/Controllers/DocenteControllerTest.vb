Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SaruvMaster.Controllers

<TestClass()>
Public Class DocenteControllerTest


#Region "Additional test attributes"
    '
    ' You can use the following additional attributes as you write your tests:
    '
    ' Use ClassInitialize to run code before running the first test in the class
    ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    ' End Sub
    '
    ' Use ClassCleanup to run code after all tests in a class have run
    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    ' End Sub
    '
    ' Use TestInitialize to run code before running each test
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' Use TestCleanup to run code after each test has run
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region

    <TestMethod()>
    Public Sub Index()
        ' Arrange
        Dim controller As New DocenteController()
        ' Act
        Dim result As ActionResult = DirectCast(controller.Index(), ActionResult)
        ' Assert
        Assert.IsNotNull(result)
    End Sub

    <TestMethod()>
    Public Sub Details()
        ' Arrange
        Dim controller As New DocenteController()
        ' Act
        Dim result As ActionResult = DirectCast(controller.Details(1), ActionResult)
        ' Assert
        Assert.IsNotNull(result)
    End Sub
    <TestMethod()>
    Public Sub Create()
        ' Arrange
        Dim controller As New DocenteController()
        ' Act
        Dim result As ActionResult = DirectCast(controller.Create(), ActionResult)
        ' Assert
        Assert.IsNotNull(result)
    End Sub

    <TestMethod()>
    Public Sub Edit()
        ' Arrange
        Dim controller As New DocenteController()
        ' Act
        Dim result As ActionResult = DirectCast(controller.Edit(1), ActionResult)
        ' Assert
        Assert.IsNotNull(result)
    End Sub

    <TestMethod()>
    Public Sub Delete()
        ' Arrange
        Dim controller As New DocenteController()
        ' Act
        Dim result As ActionResult = DirectCast(controller.Delete(1), ActionResult)
        ' Assert
        Assert.IsNotNull(result)
    End Sub
End Class
